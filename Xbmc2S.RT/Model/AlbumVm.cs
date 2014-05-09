using System.Linq;
using Windows.UI.Xaml.Controls;
using XBMCRPC.Audio.Details;
using XBMCRPC.Playlist;

namespace Xbmc2S.RT.Model
{
    class AlbumVm:PlayableItemVm
    {
        private readonly Album _albumItem;
        private readonly IServerInfo _server;

        public AlbumVm(Album albumItem, IServerInfo server)
            : base(albumItem, server)
        {
            _albumItem = albumItem;
            _server = server;
            Label=_albumItem.title;
            SecondLabel = _albumItem.artist.FirstOrDefault();
            Id = _albumItem.albumid;
            Content = albumItem.description;
            Year = albumItem.year>0?albumItem.year.ToString():null;
        }

        protected string Year { get; set; }

        public string Content { get; set; }

        public int Id { get; set; }
        protected override async void PlayExecute()
        {
            await _server.XBMC.Player.Open2(new Item7() { albumid = _albumItem.albumid }, null);
        }

        protected override void SetWatched(bool value)
        {
            throw new System.NotImplementedException();
        }

        public override void NavigateToDetails(Frame frame)
        {
            frame.Navigate(typeof(AlbumPage), _albumItem.albumid);
        }
    }
}