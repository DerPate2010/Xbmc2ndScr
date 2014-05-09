using XBMCRPC.Playlist;
using XBMCRPC.Video.Details;

namespace Xbmc2S.RT.Model
{
    internal class EpisodeVm:PlayableItemVm
    {
        private readonly Episode _episode;
        private readonly IServerInfo _server;

        public EpisodeVm(XBMCRPC.Video.Details.Episode episode, IServerInfo server):base(episode,server)
        {
            _episode = episode;
            _server = server;
            Label= episode.title;
            SecondLabel = episode.season + "x" + episode.episode;
            Content= episode.plot;
        }

        public string Content { get; set; }

        protected override async void PlayExecute()
        {
            await _server.XBMC.Player.Open2(new Item4() { episodeid = _episode.episodeid }, null);
        }

        protected override async void SetWatched(bool value)
        {
            await _server.XBMC.VideoLibrary.SetEpisodeDetails(_episode.episodeid, playcount: value ? 1 : 0);
        }
    }
}