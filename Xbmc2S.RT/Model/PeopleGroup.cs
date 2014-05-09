using System.Linq;
using System.Threading.Tasks;
using XBMCRPC.List;
using XBMCRPC.Video;
using XBMCRPC.Video.Fields;

namespace Xbmc2S.RT.Model
{
    class PeopleGroup:GroupBase
    {
        private readonly ServerInfo _server;


        private async Task GetRecent()
        {
            var movies = await _server.XBMC.VideoLibrary.GetRecentlyAddedMovies(Movie.AllFields(), new Limits() { end = 1, start = 0 }, new Sort() { method = Sort.methodEnum.dateadded, ignorearticle = true, order = Sort.orderEnum.descending });
            var movie = movies.movies.FirstOrDefault();
            if (movie != null)
            {
                RefreshTops(movie.cast.Take(9).Select(ItemFactory).ToList());
            }
            
        }

        private CastVm ItemFactory(CastItem arg)
        {
            if (first)
            {
                first = false;
                return new FirstCastVm(arg, _server);
            }
            return new CastVm(arg, _server);
        }

        private bool first = true;

        public PeopleGroup(ServerInfo server)
        {
            _server = server;

            GetRecent();
        }
    }
}