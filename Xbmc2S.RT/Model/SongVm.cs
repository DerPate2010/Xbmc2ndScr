using System;
using XBMCRPC.Audio.Details;
using XBMCRPC.Playlist;

namespace Xbmc2S.RT.Model
{
    internal class SongVm:PlayableItemVm
    {
        private readonly Song _song;
        private readonly IServerInfo _server;

        public SongVm(Song song, IServerInfo server)
            : base(song, server)
        {
            _song = song;
            _server = server;
            Label= song.title;
            SecondLabel = TimeSpan.FromSeconds(_song.duration).ToString();
            Track = _song.track;
        }

        public int Track { get; set; }


        protected override async void PlayExecute()
        {
            await _server.XBMC.Player.Open2(new Item8() { songid = _song.songid }, null);
        }

        protected override async void SetWatched(bool value)
        {
            throw new NotImplementedException();
        }
    }
}