using System.Threading.Tasks;
using XBMCRPC.List;
using XBMCRPC.List.Filter;
using XBMCRPC.Methods;
using XBMCRPC.Video.Fields;
using XBMCRPC.VideoLibrary;
using Movies = XBMCRPC.List.Filter.Fields.Movies;

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

        protected override async Task<XBMCRPC.VideoLibrary.GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort)
        {
            XBMCRPC.VideoLibrary.GetMoviesResponse mvs;
            if (_appContext.Settings.ShowWatched)
            {
                mvs = await _appContext.XBMC.VideoLibrary.GetMovies(fields, limits, sort);    
            }
            else
            {
                mvs =
                    await
                        _appContext.XBMC.VideoLibrary.GetMovies(new Rule.Movies() { field = Movies.playcount, Operator = Operators.Is, value = "0" },fields, limits, sort);    
            }
            
            return mvs;
        }
    }
}