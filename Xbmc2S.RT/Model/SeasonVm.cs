using XBMCRPC.Global;
using XBMCRPC.Playlist;
using Season = XBMCRPC.Video.Details.Season;

namespace Xbmc2S.RT.Model
{
    internal class SeasonVm:PlayableItemVm
    {
        private readonly Season _season;
        private readonly IServerInfo _server;

        public SeasonVm(XBMCRPC.Video.Details.Season season, IServerInfo server):base(season,server)
        {
            _season = season;
            _server = server;
            Label= "Season " + season.season;
            SecondLabel= season.watchedepisodes  + "/" + season.episode;
            Id = season.season;
            ShowId = season.tvshowid;
        }

        public string Label { get; private set; }
        public string SecondLabel { get; private set; }

        public int ShowId { get; set; }

        public int Id { get; set; }

        protected override async void PlayExecute()
        {
            int wellKnownPlayerIdVideo = 1;
            var eps = await _server.XBMC.VideoLibrary.GetEpisodes(_season.tvshowid, _season.season);
            await _server.XBMC.Playlist.Clear(wellKnownPlayerIdVideo);
            foreach (var episode in eps.episodes)
            {
                await _server.XBMC.Playlist.Add(wellKnownPlayerIdVideo,new Item4(){episodeid = episode.episodeid});
            }
            await _server.XBMC.Player.PlayPause(wellKnownPlayerIdVideo, Toggle.True);
        }

        protected override async void SetWatched(bool value)
        {
            var eps = await _server.XBMC.VideoLibrary.GetEpisodes(_season.tvshowid, _season.season);
            foreach (var episode in eps.episodes)
            {
                await _server.XBMC.VideoLibrary.SetEpisodeDetails(episode.episodeid, playcount: value ? 1 : 0);
            }
        }

    }
}