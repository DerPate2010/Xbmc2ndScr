using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBMCRPC.List;
using XBMCRPC.Video;
using XBMCRPC.Video.Fields;

namespace Xbmc2S.Model
{
    public class PeopleGroup:GroupBase
    {
        private readonly AppContext _server;


        private async Task GetRecent()
        {
            var movies = await _server.XBMC.VideoLibrary.GetRecentlyAddedMovies( new Movie(){MovieItem.cast}, 
                new Limits() { end = 10, start = 0 }, new Sort() { method = Sort_method.dateadded, ignorearticle = true, order = Sort_order.descending });
            var cast = new List<CastItem>();
            if (movies.movies != null)
            {
                foreach (var movie in movies.movies)
                {
                    cast.AddRange(movie.cast.Take(2));
                }

                RefreshTops(cast.Take(9).Select(ItemFactory).ToList());
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

        public PeopleGroup(AppContext server)
        {
            _server = server;

            GetRecent();
        }
    }
}