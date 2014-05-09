using System.Collections.Generic;
using System.Threading.Tasks;
using XBMCRPC.List;
using XBMCRPC.Methods;
using XBMCRPC.Video.Fields;

namespace Xbmc2S.Model
{
    class IdMovieSource:MovieSource
    {
        private readonly int _query;

        public IdMovieSource(AppContext appContext, int query)
            : base(appContext)
        {
            _query = query;
        }

        public override string Caption
        {
            get { return "Movies"; }
        }

        public override ItemsSourceReference GetStateRepresentationInternal()
        {
            return new ItemsSourceReference(){ Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.Id, Param = _query.ToString()};
        }

        protected override async Task<XBMCRPC.VideoLibrary.GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort)
        {
            var mvs = await _appContext.XBMC.VideoLibrary.GetMovieDetails(_query, Movie.AllFields());
            return new XBMCRPC.VideoLibrary.GetMoviesResponse()
                {
                    limits = new LimitsReturned(){total = 1},
                    movies = new List<XBMCRPC.Video.Details.Movie>(){ mvs.moviedetails}
                };

        }
    }
}