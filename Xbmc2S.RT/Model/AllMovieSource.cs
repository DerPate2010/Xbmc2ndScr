using System.Threading.Tasks;
using XBMCRPC.List;
using XBMCRPC.List.Filter;
using XBMCRPC.Methods;
using XBMCRPC.Video.Fields;
using Movies = XBMCRPC.List.Filter.Fields.Movies;

namespace Xbmc2S.RT.Model
{
    class AllMovieSource:MovieSource
    {
        private string _caption="Movies";

        public AllMovieSource(ServerInfo server) : base(server)
        {
        }

        public override string Caption
        {
            get { return _caption; }
        }

        protected override async Task<VideoLibrary.GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort)
        {
            VideoLibrary.GetMoviesResponse mvs;
            if (Settings.Current.ShowWatched)
            {
                mvs = await _server.XBMC.VideoLibrary.GetMovies(fields, limits, sort);    
            }
            else
            {
                mvs = await _server.XBMC.VideoLibrary.GetMovies2(fields, limits, sort, new Movies3() { field = Movies.playcount, Operator = Operators.Is, value = 0.ToString() });    
            }
            
            return mvs;
        }
    }
}