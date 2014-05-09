using System.Linq;
using System.Threading.Tasks;
using XBMCRPC.Audio.Fields;
using XBMCRPC.List;

namespace Xbmc2S.Model
{
    public class MusicGroup:GroupBase
    {
        private readonly AppContext _server;


        private async Task GetRecent()
        {
            var albums = await _server.XBMC.AudioLibrary.GetRecentlyAddedAlbums(Album.AllFields(), new Limits() { end = 12, start = 0 }, new Sort() { method = Sort_method.dateadded, ignorearticle = true, order = Sort_order.descending });

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

        public MusicGroup(AppContext server)
        {
            _server = server;

            GetRecent();
        }
    }
}