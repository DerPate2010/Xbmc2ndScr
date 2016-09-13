using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okra.Core;
using KODIRPC.Audio.Details;
using KODIRPC.AudioLibrary;
using KODIRPC.Methods;
using KODIRPC.Playlist;
using Song = KODIRPC.Audio.Fields.Song;

namespace Xbmc2S.Model
{
    public class AlbumVm:PlayableItemVm
    {
        private readonly Album _albumItem;
        private readonly IAppContext _appContext;
        private List<SongVm> _songs;

        public AlbumVm(Album albumItem, IAppContext appContext)
            : base(albumItem, appContext)
        {
            _albumItem = albumItem;
            _appContext = appContext;
            Label=_albumItem.title;
            SecondLabel = _albumItem.artist.FirstOrDefault();
            Id = _albumItem.albumid;
            Content = albumItem.description;
            Year = albumItem.year>0?albumItem.year.ToString():null;
            DefaultStorage = StorageType.AudioLibrary;

            var noCommand = new DelegateCommand(() => { }, () => false);
            WatchedCommand = noCommand;
            PlayTrailer = noCommand;
        }

        public DelegateCommand WatchedCommand { get; set; }
        public DelegateCommand PlayTrailer { get; set; }

        protected string Year { get; set; }

        public string Content { get; set; }

        public int Id { get; set; }

        public async Task<List<SongVm>> GetSongs()
        {
            if (_songs != null)
            {
                return _songs;
            }
            var songs = await _appContext.XBMC.AudioLibrary.GetSongs(filter:new GetSongs_filterAlbumid(){albumid = Id},properties:Song.AllFields());
            _songs = songs.songs.OrderBy(e => e.track).Select(SongFactory).ToList();
            return _songs;
        }

        public override async Task StartDownload(bool transcode, StorageType storage, string name, int audioTrack, int subtitleTrack)
        {
            var songs = await GetSongs();
            foreach (var songVm in songs)
            {
                await songVm.StartDownload(transcode, storage, name, audioTrack, subtitleTrack);
            }
        }

        private SongVm SongFactory(KODIRPC.Audio.Details.Song arg)
        {
            return new SongVm(arg, _appContext);
        }

        protected override async void PlayExecute()
        {
            await _appContext.XBMC.Player.Open( new ItemAlbumid() { albumid = _albumItem.albumid }, null);
            base.PlayExecute();
        }

        protected override void SetWatched(bool value)
        {
            throw new System.NotImplementedException();
        }
    }
}