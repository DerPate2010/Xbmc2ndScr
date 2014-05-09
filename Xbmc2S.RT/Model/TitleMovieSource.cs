using System.Threading.Tasks;
using XBMCRPC.List;
using XBMCRPC.List.Filter;
using XBMCRPC.Methods;
using XBMCRPC.Video.Fields;
using Movies = XBMCRPC.List.Filter.Fields.Movies;

namespace Xbmc2S.RT.Model
{
    class TitleMovieSource:MovieSource
    {
        private readonly string _query;

        public TitleMovieSource(ServerInfo server, string query)
            : base(server)
        {
            _query = query;
        }

        public override string Caption
        {
            get { return "Search for " + '\u201c' + _query + '\u201d'; }
        }

        protected override async Task<VideoLibrary.GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort)
        {
            var mvs = await _server.XBMC.VideoLibrary.GetMovies2(fields, limits, sort, new Movies3() { field = Movies.title, Operator = Operators.contains, value = _query });
            return mvs;
        }
    }
}