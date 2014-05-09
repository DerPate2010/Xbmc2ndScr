using System.Linq;
using System.Threading.Tasks;
using XBMCRPC.List;
using XBMCRPC.Video.Fields;

namespace Xbmc2S.RT.Model
{
    class MovieGroup:GroupBase
    {
        private readonly ServerInfo _server;
        private int counter;


        private async Task GetRecent()
        {
            var movies = await _server.XBMC.VideoLibrary.GetRecentlyAddedMovies(Movie.AllFields(), new Limits() { end = 9, start = 0 }, new Sort() { method = Sort.methodEnum.dateadded, ignorearticle = true, order = Sort.orderEnum.descending });
            counter = 0;
            RefreshTops(movies.movies.Select(MovieFactory).ToList());
        }

        private MovieVm MovieFactory(XBMCRPC.Video.Details.Movie arg)
        {
            int first = counter%10;
            counter++;
            if (first==0)
            {
                return new FirstMovieVm(arg, _server);
            }
            return new MovieVm(arg, _server);
        }

        

        public MovieGroup(ServerInfo server)
        {
            _server = server;

            GetRecent();
        }
    }
}