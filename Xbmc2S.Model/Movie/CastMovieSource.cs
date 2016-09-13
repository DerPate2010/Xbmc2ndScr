using System.Threading.Tasks;
using TmdbWrapper;
using KODIRPC.List;
using KODIRPC.List.Filter;
using KODIRPC.Methods;
using KODIRPC.Video.Fields;
using KODIRPC.VideoLibrary;
using Movies = KODIRPC.List.Filter.Fields.Movies;

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
            var mvs = await _appContext.XBMC.VideoLibrary.GetMovies(filter:new Rule.Movies(){field = Movies.actor, Operator = Operators.contains, value = _query }, properties:fields, limits:limits, sort:sort);
            return mvs;
        }

    }
}