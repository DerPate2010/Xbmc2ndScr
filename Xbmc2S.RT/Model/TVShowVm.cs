using Windows.UI.Xaml.Controls;
using XBMCRPC.Global;
using XBMCRPC.Playlist;
using XBMCRPC.Video.Details;

namespace Xbmc2S.RT.Model
{
    internal class TVShowVm:PlayableItemVm
    {
        private readonly TVShow _tvShow;
        private readonly IServerInfo _server;

        public TVShowVm(XBMCRPC.Video.Details.TVShow tvShow, IServerInfo server, bool useBanner=true)
            : base(tvShow, server)
        {
            _tvShow = tvShow;
            _server = server;
            //Subtitle = movie.tagline;
            Year = tvShow.year;
            ID = tvShow.tvshowid;
            Label = tvShow.title;
            //Runtime = movie.runtime;
            Content = tvShow.plot;
            WatchedCheck = tvShow.playcount==tvShow.episode;
            //_imgMan.GetImage(movie.thumbnail,SetImage);
            //_imgMan.GetImage(movie.art.banner, SetImage);
            if (useBanner)
            {
                _imagePath = tvShow.art.banner;
            }

        }

        public int Runtime { get; set; }
        public int Year { get; set; }

        public string Subtitle { get; set; }
        public string Content { get; set; }



        public int ID { get; set; }

        protected override async void PlayExecute()
        {
            int wellKnownPlayerIdVideo = 1;

            var seasons = await _server.XBMC.VideoLibrary.GetSeasons(_tvShow.tvshowid);
            foreach (var season in seasons.seasons)
            {
                var eps = await _server.XBMC.VideoLibrary.GetEpisodes(season.tvshowid, season.season);
                await _server.XBMC.Playlist.Clear(wellKnownPlayerIdVideo);
                foreach (var episode in eps.episodes)
                {
                    await _server.XBMC.Playlist.Add(wellKnownPlayerIdVideo, new Item4() { episodeid = episode.episodeid });
                }
                await _server.XBMC.Player.PlayPause(wellKnownPlayerIdVideo, Toggle.True);
                
            }
        }

        protected override async void SetWatched(bool value)
        {
            var seasons = await _server.XBMC.VideoLibrary.GetSeasons(_tvShow.tvshowid);
            foreach (var season in seasons.seasons)
            {
                var eps = await _server.XBMC.VideoLibrary.GetEpisodes(season.tvshowid, season.season);
                foreach (var episode in eps.episodes)
                {
                    await _server.XBMC.VideoLibrary.SetEpisodeDetails(episode.episodeid, playcount: value ? 1 : 0);
                }
            }
        }

        public override void NavigateToDetails(Frame frame)
        {
            frame.Navigate(typeof(TvShowPage), ID);
        }
    }
}