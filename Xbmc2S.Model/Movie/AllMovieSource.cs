using System.Threading.Tasks;
using KODIRPC.List;
using KODIRPC.List.Filter;
using KODIRPC.Methods;
using KODIRPC.Video.Fields;
using KODIRPC.VideoLibrary;
using Movies = KODIRPC.List.Filter.Fields.Movies;

namespace Xbmc2S.Model
{
    class AllMovieSource : MovieSource
    {
        private string _caption="Movies";

        public AllMovieSource(AppContext appContext) : base(appContext)
        {
        }

        public override string Caption
        {
            get { return _caption; }
        }

        public override ItemsSourceReference GetStateRepresentationInternal()
        {
            return new ItemsSourceReference(){ Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.All};
        }

        protected override async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort)
        {
            KODIRPC.VideoLibrary.GetMoviesResponse mvs;
            if (_appContext.Settings.ShowWatched)
            {
                mvs = await _appContext.XBMC.VideoLibrary.GetMovies(fields, limits, sort);    
            }
            else
            {
                mvs =
                    await
                        _appContext.XBMC.VideoLibrary.GetMovies(filter:new Rule.Movies() { field = Movies.playcount, Operator = Operators.Is, value = "0" },properties:fields, limits:limits, sort:sort);    
            }
            
            return mvs;
        }
    }
}