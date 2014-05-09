using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okra.Core;
using XBMCRPC.Global;
using XBMCRPC.Playlist;
using XBMCRPC.Video.Details;

namespace Xbmc2S.Model
{
    public class SeasonVm:PlayableItemVm,IItemDetails, ICollectionDetails
    {
        private readonly Season _season;
        private readonly IAppContext _appContext;
        private readonly TVShowVm _tvShowVm;

        public SeasonVm(Season season, IAppContext appContext, TVShowVm tvShowVm):base(season,appContext)
        {
            _season = season;
            _appContext = appContext;
            _tvShowVm = tvShowVm;
            Label= "Season " + season.season;
            SecondLabel= season.watchedepisodes  + "/" + season.episode;
            Id = season.season;
            ShowId = season.tvshowid;
        }

        private List<EpisodeVm> _episodes;
        public async Task<List<EpisodeVm>> GetEpisodes()
        {
            if (_episodes == null)
            {
                var episodes = await _appContext.XBMC.VideoLibrary.GetEpisodes(_season.tvshowid, _season.season, XBMCRPC.Video.Fields.Episode.AllFields());
                _episodes = episodes.episodes.OrderBy(e => e.episode).Select(EpisodeFactory).ToList();
            }

            OnPropertyChanged("Items");
            return _episodes;
        }

        private EpisodeVm EpisodeFactory(XBMCRPC.Video.Details.Episode arg)
        {
            return new EpisodeVm(arg, _appContext,this);
        }

        public int ShowId { get; set; }

        protected override async void PlayExecute()
        {
            int wellKnownPlayerIdVideo = 1;
            var eps = await GetEpisodes();
            await _appContext.XBMC.Playlist.Clear(wellKnownPlayerIdVideo);
            foreach (var episode in eps)
            {
                await _appContext.XBMC.Playlist.Add( new ItemEpisodeid(){episodeid=episode.Id},wellKnownPlayerIdVideo);
            }
            await _appContext.XBMC.Player.PlayPause(true, wellKnownPlayerIdVideo);
            base.PlayExecute();
        }

        protected override async void SetWatched(bool value)
        {
            var eps = await GetEpisodes();
            

            //var eps = await _appContext.XBMC.VideoLibrary.GetEpisodes(_season.tvshowid, _season.season);
            foreach (var episode in eps)
            {
                episode.IsWatched=value;
            }
        }

        public override async Task StartDownload(bool transcode, StorageType storage, string name, int audioTrack, int subtitleTrack)
        {
            var episodes = await GetEpisodes();
            foreach (var episodeVm in episodes)
            {
                await episodeVm.StartDownload(transcode, storage, name, audioTrack, subtitleTrack);
            }
        }

        public void ItemWatchedChanged(bool value)
        {
            _season.watchedepisodes+= (value? 1 : -1);
            SecondLabel = _season.watchedepisodes + "/" + _season.episode;
            WatchedCheck = _season.watchedepisodes == _season.episode;

            _tvShowVm.ItemWatchedChanged(value);
        }

        public int Runtime { get { return _tvShowVm.Runtime; } }
        public int Year { get { return _tvShowVm.Year; } }
        public string Content { get { return _tvShowVm.Content; } }
        public IEnumerable<ICastVm> Cast { get { return _tvShowVm.Cast; } }
        public string Genre { get { return _tvShowVm.Genre; } }
        public string Country { get { return _tvShowVm.Country; } }
        public string OriginalTitle { get { return _tvShowVm.OriginalTitle; } }
        public double Rating { get { return _tvShowVm.Rating; } }
        public double RatingBase5 { get { return _tvShowVm.RatingBase5; } set { _tvShowVm.RatingBase5=value; } }
        public string Studio { get { return _tvShowVm.Studio; } }
        public string Writer { get { return _tvShowVm.Writer; } }
        public string Director { get { return _tvShowVm.Director; } }
        public string Trailer { get { return _tvShowVm.Trailer; } }
        public DelegateCommand PlayTrailer { get { return _tvShowVm.PlayTrailer; } }

        public void GoTo()
        {
            _appContext.View.GotoSeason(this.ShowId + "_" + Id);
        }





        public IEnumerable<IItemDetails> Items
        {
            get
            {
                GetEpisodes();
                return _episodes;
            }
        }

        public string ItemsLabel { get { return "Episodes"; } }
    }
}