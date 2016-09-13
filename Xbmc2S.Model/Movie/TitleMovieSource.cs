using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KODIRPC.List;
using KODIRPC.List.Filter;
using KODIRPC.Methods;
using KODIRPC.Video.Fields;
using KODIRPC.VideoLibrary;
using Movies = KODIRPC.List.Filter.Fields.Movies;

namespace Xbmc2S.Model
{
    class TitleMovieSource:MovieSource
    {
        private readonly string _query;

        public TitleMovieSource(AppContext appContext, string query)
            : base(appContext)
        {
            _query = query;
        }

        public override string Caption
        {
            get { return "Search for " + '\u201c' + _query + '\u201d'; }
        }

        public override ItemsSourceReference GetStateRepresentationInternal()
        {
            return new ItemsSourceReference(){ Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.Title, Param = _query};
        }

        protected override async Task<GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort)
        {
            var mvs = await _appContext.XBMC.VideoLibrary.GetMovies(filter:new Rule.Movies() { field = Movies.title, Operator = Operators.contains, value = _query }, properties:fields, limits:limits, sort:sort);
            return mvs;
        }
    }   
    class FullTextMovieSource:MovieSource
    {
        private readonly string _query;

        public FullTextMovieSource(AppContext appContext, string query)
            : base(appContext)
        {
            _query = query;
        }

        public override string Caption
        {
            get { return "Search for " + '\u201c' + _query + '\u201d'; }
        }

        public override ItemsSourceReference GetStateRepresentationInternal()
        {
            return new ItemsSourceReference(){ Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.FullText, Param = _query};
        }

        protected override async Task<GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort)
        {
            var mvs = await GetResult(_appContext, fields, limits, sort, _query);
            return mvs;
        }

        public static async Task<int> GetResultCount(AppContext appContext, string query)
        {
            var mvs = await GetResult(appContext, null, new Limits(){end = 1}, null, query);
            return mvs.limits.total;
        }

        private static async Task<GetMoviesResponse> GetResult(AppContext appContext, Movie fields, Limits limits, Sort sort, string query)
        {
            return await appContext.XBMC.VideoLibrary.GetMovies(filter:new MoviesOr(){ or = new List<object>() 
                {
                    new Rule.Movies () { field = Movies.title, Operator = Operators.contains, value = query }, 
                    new Rule.Movies() { field = Movies.plot, Operator = Operators.contains, value = query }, 
                    new Rule.Movies() { field = Movies.plotoutline, Operator = Operators.contains, value = query }, 
                    new Rule.Movies() { field = Movies.tagline, Operator = Operators.contains, value = query }, 
                }},properties:fields, limits:limits, sort:sort);
        }
    }

    public class WatchlistMovieSource : TagMovieSource
    {
        public WatchlistMovieSource(AppContext appContext) : base(appContext, PlayableItemVm.WatchlistKey)
        {
        }

        public override string Caption
        {
            get
            {
                return "Watchlist";
            }
        }

        public override ItemsSourceReference GetStateRepresentationInternal()
        {
            return new ItemsSourceReference() { Type = ItemsSourceType.WatchList };
        }
    }

    class GenreMovieSource:MovieSource
    {
        private readonly string _query;
        //private int _genreId;

        public GenreMovieSource(AppContext appContext, string query)
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
            return new ItemsSourceReference(){ Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.Genre, Param = _query};
        }

        protected override async Task<GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort)
        {
            //if (_genreId == 0)
            //{
            //    var g = await _appContext.XBMC.VideoLibrary.GetGenres(properties: KODIRPC.Library.Fields.Genre.AllFields());
            //    var gw = g.genres.FirstOrDefault(g2 => g2.title == _query);
            //    _genreId = gw.genreid;
            //}

            var mvs = await _appContext.XBMC.VideoLibrary.GetMovies(filter:new GetMovies_filterGenre(){genre = _query},properties:fields, limits:limits, sort:sort);
            return mvs;
        }
    }

    public class TagMovieSource:MovieSource
    {
        private readonly string _query;

        public TagMovieSource(AppContext appContext, string query)
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
            return new ItemsSourceReference(){ Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.Tag, Param = _query};
        }

        protected override async Task<GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort)
        {

            var mvs = await _appContext.XBMC.VideoLibrary.GetMovies(filter:new GetMovies_filterTag(){tag = _query},properties:fields, limits:limits, sort:sort);
            return mvs;
        }
    }
}