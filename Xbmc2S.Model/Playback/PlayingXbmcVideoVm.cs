using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Okra.Core;
using KODIRPC.List.Item;
using KODIRPC.Methods;
using KODIRPC.Player;
using KODIRPC.Video;
using File = KODIRPC.Video.Details.File;

namespace Xbmc2S.Model
{
    public class PlayingXbmcVideoVm : PlayingXbmcItemVm
    {
        private readonly All _baseDetails;

        public PlayingXbmcVideoVm(All baseDetails, int playerid, IAppContext appContext)
            : base(baseDetails.AsMediaDetailsBase, playerid, appContext)
        {
            _baseDetails = baseDetails;
            Label = baseDetails.AsVideoDetailsFile.title;
            SecondLabel = baseDetails.showtitle;
            AudioTracks = _baseDetails.AsVideoDetailsFile.streamdetails.audio.Select((a, i) => new AudioTrackVm(a, i, appContext)).ToList<TrackVm>();
            SubtitleTracks = _baseDetails.AsVideoDetailsFile.streamdetails.subtitle.Select((a, i) => new SubtitleTrackVm(a, i, appContext)).ToList<TrackVm>();
            SubtitleTracks.Insert(0, new NoSubtitleTrackVm(appContext, SubtitleTracks.Count));
        }

        public List<TrackVm> SubtitleTracks { get; set; }

        public List<TrackVm> AudioTracks { get; set; }

        public override string Id
        {
            get { return _baseDetails.id.ToString(); }
        }

        public override void GotoDetails()
        {
            switch (_baseDetails.type)
            {
                case Base_type.movie:
                    var movieRef = new ItemsSourceReference() { Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.Id, Param = _baseDetails.id.ToString()};
                    _appContext.View.GotoMovie(movieRef);
                    break;
                case Base_type.episode:
                    _appContext.View.GotoEpisode(EpisodeVm.GetRef(_baseDetails.tvshowid, _baseDetails.season, _baseDetails.episode) + "n");
                    break;
            }
        }
    }

    public class SubtitleTrackVm:TrackVm
    {
        public SubtitleTrackVm(Streams_subtitleItem subtitleItem, int track, IAppContext server):base(subtitleItem.language,track, server)
        {
        }

        protected override async void SelectExecute()
        {
            await Server.XBMC.Player.SetSubtitle(Track, wellKnownPlayerIdVideo, true);
        }
    }
    public class NoSubtitleTrackVm:SubtitleTrackVm
    {
        private readonly int _subtitleCount;

        public NoSubtitleTrackVm(IAppContext server, int subtitleCount)
            : base(new Streams_subtitleItem(){language = "Disabled"}, -1, server)
        {
            _subtitleCount = subtitleCount;
        }

        protected override async void SelectExecute()
        {
            if (_subtitleCount > 0)
            {
                await Server.XBMC.Player.SetSubtitle(wellKnownPlayerIdVideo, SetSubtitle_subtitle1.off, false);
            }
        }
    }

    public class AudioTrackVm:TrackVm
    {
        public AudioTrackVm(Streams_audioItem audioItem, int track, IAppContext server):base(audioItem.language, track, server)
        {
        }

        protected override async void SelectExecute()
        {
            await Server.XBMC.Player.SetAudioStream(Track, wellKnownPlayerIdVideo);
        }
    }    

    public class UndefinedTrackVm:TrackVm
    {
        public UndefinedTrackVm(IAppContext server) : base("Default", -1, server)
        {
        }

        protected override void SelectExecute()
        {
        }
    }
    
    public abstract class TrackVm
    {
        protected const int wellKnownPlayerIdVideo = 1;


        public TrackVm(string label, int track, IAppContext server)
        {
            Track = track;
            Server = server;
            Label = label;
            Select = new DelegateCommand(SelectExecute);
        }

        protected abstract void SelectExecute();

        public int Track { get; private set; }
        public IAppContext Server { get; private set; }

        public string Label { get; private set; }

        public ICommand Select { get; private set; }
    }
}