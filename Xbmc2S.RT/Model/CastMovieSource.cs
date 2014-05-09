using System.Threading.Tasks;
using XBMCRPC.List;
using XBMCRPC.List.Filter;
using XBMCRPC.Methods;
using XBMCRPC.Video.Fields;
using Movies = XBMCRPC.List.Filter.Fields.Movies;

namespace Xbmc2S.RT.Model
{
    class CastMovieSource:MovieSource
    {
        private readonly string _query;

        public CastMovieSource(ServerInfo server, string query)
            : base(server)
        {
            _query = query;
        }

        public override string Caption
        {
            get { return "Movies with " + _query; }
        }

        protected override async Task<VideoLibrary.GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort)
        {
            var mvs = await _server.XBMC.VideoLibrary.GetMovies2(fields, limits, sort, new Movies3() { field = Movies.actor, Operator = Operators.contains, value = _query });
            return mvs;
        }
    }
}