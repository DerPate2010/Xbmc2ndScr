using System.Threading.Tasks;
using XBMCRPC.List;
using XBMCRPC.Methods;
using XBMCRPC.Video.Fields;

namespace Xbmc2S.RT.Model
{
    class IdMovieSource:MovieSource
    {
        private readonly int _query;

        public IdMovieSource(ServerInfo server, int query)
            : base(server)
        {
            _query = query;
        }

        public override string Caption
        {
            get { return "Movies"; }
        }

        protected override async Task<VideoLibrary.GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort)
        {
            var mvs = await _server.XBMC.VideoLibrary.GetMovieDetails(_query, Movie.AllFields());
            return new VideoLibrary.GetMoviesResponse()
                {
                    limits = new LimitsReturned(){total = 1},
                    movies = new []{mvs.moviedetails}
                };

        }
    }
}