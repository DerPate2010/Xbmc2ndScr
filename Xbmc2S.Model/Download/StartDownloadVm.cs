using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Okra.Core;
using KODIRPC.Files;
using KODIRPC.List.Fields;

namespace Xbmc2S.Model.Download
{
    public class StartDownloadVm:BindableBase
    {
        private readonly PlayableItemVm _playableItemVm;
        private readonly StorageType _defaultStorage;
        private readonly IAppContext _appContext;
        private string _fileName;
        private bool _transcode;
        private string _modeHint;
        private string _details;
        private string _target;
        private List<TrackVm> _audioTracks;
        private TrackVm _audioTrack;
        private List<TrackVm> _subtitles;
        private TrackVm _subtitle;

        public StartDownloadVm(PlayableItemVm playableItemVm, StorageType defaultStorage, IAppContext appContext)
        {
            _playableItemVm = playableItemVm;
            _defaultStorage = defaultStorage;
            _appContext = appContext;
            StartDownload = new DelegateCommand(StartDownloadExecute);
            Target = defaultStorage == StorageType.VideoLibrary ? "Video Library" : "Audio Library";
            FileName = _playableItemVm.GetDownloadName();
            Transcode = true;
            AudioTrack= new UndefinedTrackVm(_appContext);
            Subtitle= new UndefinedTrackVm(_appContext);
            AudioTracks = new List<TrackVm>() { AudioTrack};
            Subtitles = new List<TrackVm>() {Subtitle};
            LoadDetails();
            
        }

        private async void LoadDetails()
        {
            if (!string.IsNullOrEmpty(_playableItemVm.Path))
            {
                var fileInfo =
                    await _appContext.XBMC.Files.GetFileDetails(_playableItemVm.Path, Media.video, Files.AllFields());
                var videodetails = fileInfo.filedetails.AsVideoDetailsFile;
                Details = fileInfo.filedetails.mimetype;
                if (videodetails.streamdetails.video.Count != 0)
                {
                    Details += " (" + videodetails.streamdetails.video[0].codec + ")";    
                }
                AudioTracks.AddRange(
                    videodetails.streamdetails.audio.Select((a, i) => new AudioTrackVm(a, i, _appContext)));
                Subtitles.AddRange(
                    videodetails.streamdetails.subtitle.Select((a, i) => new SubtitleTrackVm(a, i, _appContext)));
            }
        }

        private async void StartDownloadExecute()
        {
            await _playableItemVm.StartDownload(Transcode, _defaultStorage, FileName, AudioTrack.Track, Subtitle.Track);
        }

        public ICommand StartDownload { get; private set; }

        public string FileName
        {
            get { return _fileName; }
            set { SetProperty(ref _fileName, value); }
        }

        public bool Transcode
        {
            get { return _transcode; }
            set 
            { 
                SetProperty(ref _transcode, value);
                ModeHint = value?"Transcode Hint":"Download Hint";
            }
        }

        public string ModeHint
        {
            get { return _modeHint; }
            set { SetProperty(ref _modeHint, value); }
        }

        public string Details
        {
            get { return _details; }
            set { SetProperty(ref _details, value); }
        }

        public string Target
        {
            get { return _target; }
            set { SetProperty(ref _target, value); }
        }

        public List<TrackVm> AudioTracks
        {
            get { return _audioTracks; }
            set { SetProperty(ref _audioTracks, value); }
        }

        public TrackVm AudioTrack
        {
            get { return _audioTrack; }
            set { SetProperty(ref _audioTrack, value); }
        }

        public List<TrackVm> Subtitles
        {
            get { return _subtitles; }
            set { SetProperty(ref _subtitles, value); }
        }

        public TrackVm Subtitle
        {
            get { return _subtitle; }
            set { SetProperty(ref _subtitle, value); }
        }

        public static StartDownloadVm Current { get; set; }
    }
}