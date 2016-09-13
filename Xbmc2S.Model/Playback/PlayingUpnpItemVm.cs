using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KODIRPC.Files;
using KODIRPC.List;
using KODIRPC.List.Fields;
using KODIRPC.List.Filter;
using KODIRPC.List.Item;
using KODIRPC.Video.Fields;
using Xbmc2S.RT.UPnP;
using Episodes = KODIRPC.List.Filter.Fields.Episodes;
using Movies = KODIRPC.List.Filter.Fields.Movies;

namespace Xbmc2S.Model
{
    public class PlayingUpnpItemVm:BaseVM,ICurrentPlayingItem
    {

        private CurrentUpnpPlayback _curPlayback;
        private readonly IAppContext _appContext;

        public PlayingUpnpItemVm(CurrentUpnpPlayback curPlayback, IAppContext appContext):base(appContext)
        {
            _curPlayback = curPlayback;
            _appContext = appContext;
            Id = curPlayback.PosTrackuri;
            UpdateTime(curPlayback);
            PlayToInfo = "Playing to " + curPlayback.MediaRendererDevice.FriendlyName;
            var parts = _curPlayback.PosTrackuri.Split('/');
            string filename = parts.Last();
            Label = filename;
            string path;
            _appContext.Upnp.PathLookup.TryGetValue(curPlayback.PosTrackuri, out path);
            GetItemInfo(path);
        }

        private void UpdateTime(CurrentUpnpPlayback curPlayback)
        {
            TotalTime = TimeSpan.Parse(curPlayback.PosDuration);
            Time = TimeSpan.Parse(curPlayback.PosReltime);
            var perc = ((double) Time.Ticks*100/TotalTime.Ticks);
            if (!double.IsNaN(perc))
            {
                Percentage = perc;
            }
        }

        public string PlayToInfo { get; private set; }

        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }
        }

        private async Task GetItemInfo(string path)
        {
                var parts = _curPlayback.PosTrackuri.Split('/');
                string filename = parts.Last();
                var candidates = await _appContext.XBMC.VideoLibrary.GetMovies(filter:new Rule.Movies() { field = Movies.filename, Operator = Operators.Is, value = filename }, properties:Movie.AllFields(), limits: new Limits(){end = 1});
                var candidates2 = await _appContext.XBMC.VideoLibrary.GetEpisodes(filter:new Rule.Episodes() { field = Episodes.filename, Operator = Operators.Is, value = filename }, properties: Episode.AllFields(), limits: new Limits(){end = 1});

                if (candidates.limits.total == 1 && candidates2.limits.total == 0)
                {
                    _libItem = new MovieVm(candidates.movies.First(),_appContext);
                }
                else if (candidates.limits.total == 0 && candidates2.limits.total == 1)
                {
                    _libItem = new EpisodeVm(candidates2.episodes.First(), _appContext, null);
                }

                if (_libItem == null && path != null)
                {
                    var fileInfo = await _appContext.XBMC.Files.GetFileDetails(path, Media.video, Files.AllFields());
                    _libItem = new FileInfo(fileInfo.filedetails, _appContext);

                }
            if (_libItem != null)
            {
                Label = _libItem.Label;
                SecondLabel = _libItem.SecondLabel;
                SetImage(_libItem.Images);
            }

        }

        public string SecondLabel
        {
            get { return _secondLabel; }
            set { SetProperty(ref _secondLabel, value); }
        }

        public string Id { get; private set; }

        private double _percentage=0;
        private TimeSpan _totalTime;
        private TimeSpan _time;
        private string _label;
        private string _secondLabel;
        private IItemDetails _libItem;

        public double Percentage
        {
            get { return _percentage; }
            private set { SetProperty(ref _percentage, value); }
        }

        public TimeSpan TotalTime
        {
            get { return _totalTime; }
            private set { SetProperty(ref _totalTime, value); }
        }

        public TimeSpan Time
        {
            get { return _time; }
            private set { SetProperty(ref _time, value); }
        }

        public async Task Pause()
        {
            if (_curPlayback.TranspState!="PLAYING")
            {
                await _curPlayback.MediaRendererDevice.AVTransport.Play();
            }
            else
            {
                await _curPlayback.MediaRendererDevice.AVTransport.Pause();
            }
            
        }

        public async Task Stop()
        {
            await _curPlayback.MediaRendererDevice.AVTransport.Stop();
        }

        public async Task Skip()
        {
            await _curPlayback.MediaRendererDevice.AVTransport.Next();
        }

        public async Task SkipBack()
        {
            await _curPlayback.MediaRendererDevice.AVTransport.Previous();
        }

        public async Task Refresh()
        {
            _curPlayback = await  _curPlayback.MediaRendererDevice.AVTransport.GetCurrentPlaybackItem();
            UpdateTime(_curPlayback);
        }

        public async Task Seek(double percent)
        {
            var newTime = new TimeSpan((long) (TotalTime.Ticks*percent/100));
            await _curPlayback.MediaRendererDevice.AVTransport.Seek(newTime);
        }

        public void RefreshTime()
        {
            Time = Time.Add(TimeSpan.FromSeconds(1));
        }

        public void GotoDetails()
        {
            if (_libItem != null)
            {
                _libItem.GoTo();
            }
        }
    }
}