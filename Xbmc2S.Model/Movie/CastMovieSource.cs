using System.Threading.Tasks;
using TmdbWrapper;
using XBMCRPC.List;
using XBMCRPC.List.Filter;
using XBMCRPC.Methods;
using XBMCRPC.Video.Fields;
using XBMCRPC.VideoLibrary;
using Movies = XBMCRPC.List.Filter.Fields.Movies;

namespace Xbmc2S.Model
{
    public class CastMovieSource:MovieSource
    {
        private readonly string _query;

        public CastMovieSource(AppContext appContext, string query)
            : base(appContext)
        {
            _query = query;
        }

        public override string Caption
        {
            get { return _query; }
        }

        public override ItemsSourceReference GetStateRepresentationInternal()
        {
            var listRef= new ItemsSourceReference(){ Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.Cast, Param = _query};
            if (Selected != null)
            {
                listRef.Selection = Items.IndexOf(Selected);
            }
            return listRef;
        }

        protected override async Task<GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort)
        {
            var mvs = await _appContext.XBMC.VideoLibrary.GetMovies(new Rule.Movies(){field = Movies.actor, Operator = Operators.contains, value = _query }, fields, limits, sort);
            return mvs;
        }

    }
}