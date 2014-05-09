using System.Linq;
using System.Threading.Tasks;
using XBMCRPC.Audio.Fields;
using XBMCRPC.List;

namespace Xbmc2S.RT.Model
{
    class MusicGroup:GroupBase
    {
        private readonly ServerInfo _server;


        private async Task GetRecent()
        {
            var albums = await _server.XBMC.AudioLibrary.GetRecentlyAddedAlbums(Album.AllFields(), new Limits() { end = 12, start = 0 }, new Sort() { method = Sort.methodEnum.dateadded, ignorearticle = true, order = Sort.orderEnum.descending });

            RefreshTops(albums.albums.Select(ItemFactory).ToList());
            
        }

        private AlbumVm ItemFactory(XBMCRPC.Audio.Details.Album arg)
        {
            if (first)
            {
                first = false;
                return new FirstAlbumVm(arg, _server);
            }
            return new AlbumVm(arg, _server);
        }

        private bool first = true;

        public MusicGroup(ServerInfo server)
        {
            _server = server;

            GetRecent();
        }
    }
}