using System;
using KODIRPC.Audio.Details;
using KODIRPC.Playlist;

namespace Xbmc2S.Model
{
    public class SongVm:PlayableItemVm
    {
        private readonly Song _song;
        private readonly IAppContext _appContext;

        public SongVm(Song song, IAppContext appContext)
            : base(song, appContext)
        {
            _song = song;
            _appContext = appContext;
            Label= song.title;
            SecondLabel = TimeSpan.FromSeconds(_song.duration).ToString();
            Track = _song.track;
            DefaultStorage = StorageType.AudioLibrary;
        }

        public int Track { get; set; }

        public override System.Threading.Tasks.Task StartDownload(bool transcode, StorageType storage, string name, int audioTrack, int subtitleTrack)
        {
            if (transcode)
            {
                throw new NotSupportedException();
            }
            return base.StartDownload(transcode,storage, name, audioTrack, subtitleTrack);
        }

        protected override async void PlayExecute()
        {
            await _appContext.XBMC.Player.Open(new ItemSongid() { songid = _song.songid });
            //base.PlayExecute();
        }

        protected override async void SetWatched(bool value)
        {
            throw new NotImplementedException();
        }
    }
}