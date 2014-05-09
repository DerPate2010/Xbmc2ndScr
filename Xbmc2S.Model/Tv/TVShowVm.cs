using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okra.Core;
using Q42.WinRT.Portable.Data;
using XBMCRPC.Global;
using XBMCRPC.Playlist;
using XBMCRPC.Video.Details;
using Season = XBMCRPC.Video.Fields.Season;

namespace Xbmc2S.Model
{
    public class TVShowVm:PlayableItemVm, IItemDetails, ICollectionDetails
    {
        private readonly TVShow _tvShow;
        private readonly IAppContext _appContext;
        private List<SeasonVm> _seasons;
        private List<IItemDetails> _items;
        private IEnumerable<ICastVm> _cast;

        public TVShowVm(XBMCRPC.Video.Details.TVShow tvShow, IAppContext appContext, bool useBanner=true)
            : base(tvShow, appContext)
        {
            _tvShow = tvShow;
            _appContext = appContext;
            //Subtitle = movie.tagline;
            Year = tvShow.year;
            ID = tvShow.tvshowid;
            Label = tvShow.title;
            //Runtime = movie.runtime;
            Content = tvShow.plot;
            WatchedCheck = tvShow.playcount==tvShow.episode;
            //_imgMan.GetImage(movie.thumbnail,SetImage);
            //_imgMan.GetImage(movie.art.banner, SetImage);


        }

        public async Task<List<SeasonVm>> GetSeasons()
        {
            if (_seasons != null)
            {
                return _seasons;
            }
            var seasons = await _appContext.XBMC.VideoLibrary.GetSeasons(_tvShow.tvshowid, Season.AllFields());
            if (seasons.seasons == null)
            {
                _seasons= new List<SeasonVm>();
            }
            else
            {
                _seasons = seasons.seasons.OrderBy(s => s.season).Select(SeasonFactory).ToList();
            }
            OnPropertyChanged("Items");
            return _seasons;
        }

        private SeasonVm SeasonFactory(XBMCRPC.Video.Details.Season arg)
        {
            return new SeasonVm(arg, _appContext, this);
        }

        public int Runtime { get; set; }
        public int Year { get; set; }

        public string Subtitle { get; set; }
        public string Content { get; set; }
        public IEnumerable<ICastVm> Cast
        {
            get
            {
                if (_cast == null)
                {
                    LoadCast();
                }
                return _cast;
            }
        }

        private void LoadCast()
        {
            _cast = _tvShow.cast.Select(c => new CastVm(c, _appContext));
        }
        public string Genre { get; set; }
        public string Country { get; set; }
        public string OriginalTitle { get; set; }
        public double Rating { get; set; }
        public double RatingBase5 { get; set; }
        public string Studio { get; set; }
        public string Writer { get; set; }
        public string Director { get; set; }
        public string Trailer { get; set; }
        public DelegateCommand PlayTrailer { get; private set; }


        public int ID { get; set; }

        public override async Task StartDownload(bool transcode, StorageType storage, string name, int audioTrack, int subtitleTrack)
        {
            var seasons = await GetSeasons();
            foreach (var season in seasons)
            {
                await season.StartDownload(transcode, storage, name, audioTrack, subtitleTrack);
            }
        }

        protected override async void PlayExecute()
        {
            int wellKnownPlayerIdVideo = 1;

            try
            {
                var seasons = await GetSeasons();
                foreach (var season in seasons)
                {
                    var eps = await season.GetEpisodes();
                    await _appContext.XBMC.Playlist.Clear(wellKnownPlayerIdVideo);
                    foreach (var episode in eps)
                    {
                        await _appContext.XBMC.Playlist.Add(new ItemEpisodeid() { episodeid = episode.Id }, wellKnownPlayerIdVideo);
                    }
                    await _appContext.XBMC.Player.PlayPause(true, wellKnownPlayerIdVideo);

                }
                base.PlayExecute();

            }
            catch (Exception)
            {

            }


        }

        protected override async void SetWatched(bool value)
        {
            var seasons = await GetSeasons();
            foreach (var season in seasons)
            {
                season.IsWatched = value;
            }
        }

        public void ItemWatchedChanged(bool value)
        {
            _tvShow.watchedepisodes += (value ? 1 : -1);
            WatchedCheck = _tvShow.watchedepisodes == _tvShow.episode;

        }

        public void GoTo()
        {
            var iRef = new ItemsSourceReference(ItemsSourceType.TVShow, Id);
            _appContext.View.GotoMovie(iRef);
        }


        public IEnumerable<IItemDetails> Items
        {
            get
            {
                GetSeasons();
                return _seasons;
            }
        }

        public string ItemsLabel { get { return "Seasons"; } }
    }
}