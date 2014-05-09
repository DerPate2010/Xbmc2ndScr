using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Okra.Data;
using XBMCRPC.List;
using XBMCRPC.Methods;
using XBMCRPC.Video.Fields;
using Movie = XBMCRPC.Video.Fields.Movie;

namespace Xbmc2S.Model
{
    public abstract class MovieSource : BaseSource<MovieVm>, IGroupedItemsSource
    {
        

        protected readonly AppContext _appContext;






        #region Overrides of PagedDataListSource<MovieVM>

        async protected override Task<DataListPageResult<MovieVm>> FetchPageAsync(int pageNumber)
        {
            //var mvs = await _appContext.XBMC.VideoLibrary.GetMovies(Movie.AllFields(), new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize }, new Sort() { method = Sort_method.title, ignorearticle = true, order = Sort_order.@ascending });
            var mvs = await GetMovies(Movie.AllFields(),
                                  new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize },
                                  new Sort()
                                  {
                                      method = Sort_method.title,
                                      ignorearticle = false,
                                      order = Sort_order.@ascending
                                  });
            List<MovieVm> list=null;
            if (mvs.movies != null)
            {
                list = mvs.movies.Select(MovieFactory).ToList();
            }
            else
            {
                list = new List<MovieVm>();
            }

            return new DataListPageResult<MovieVm>(mvs.limits.total, PageSize, pageNumber, list);
        }

        async override public Task<List<string>> FetchAllLabelsAsync()
        {
            //var mvs = await _appContext.XBMC.VideoLibrary.GetMovies(Movie.AllFields(), new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize }, new Sort() { method = Sort_method.title, ignorearticle = true, order = Sort_order.@ascending });
            Stopwatch
                sw= new Stopwatch();
            sw.Start();
            var mvs = await GetMovies(new Movie{MovieItem.title},
                                  null,
                                  new Sort()
                                  {
                                      method = Sort_method.title,
                                      ignorearticle = false,
                                      order = Sort_order.@ascending
                                  });
            sw.Stop();

            var m2 = mvs.movies.Select(m => m.title).ToList();
            return m2;
        }

        protected abstract Task<XBMCRPC.VideoLibrary.GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort);
 
        private MovieVm MovieFactory(XBMCRPC.Video.Details.Movie arg)
        {
            return new MovieVm(arg,_appContext);
        }

        protected MovieSource(AppContext appContext)
        {
            _appContext = appContext;
        }


        public override void Goto(object clickedItem)
        {
            Selected = clickedItem;
            _appContext.View.GotoMovie(GetStateRepresentationInternal());
        }

        #endregion


    }
}
