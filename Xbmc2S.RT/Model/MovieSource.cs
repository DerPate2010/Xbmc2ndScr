using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Okra.Data;
using XBMCRPC.List;
using XBMCRPC.Methods;
using XBMCRPC.Video.Fields;
using Movie = XBMCRPC.Video.Fields.Movie;

namespace Xbmc2S.RT.Model
{
    abstract class MovieSource:PagedDataListSource<MovieVm>
    {
        public abstract string Caption { get; }

        protected readonly ServerInfo _server;

        public MovieVm Selected
        {
            get
            {
                if (_selected == null)
                {
                    _selected = VirtualizingDataList[0];
                }
                return _selected;
            }
            set { _selected = value; }
        }

        private const int PageSize = 20;

        private VirtualMovies _virtualizingDataList;
        private MovieVm _selected;

        public VirtualMovies VirtualizingDataList
        {
            get
            {
                if (_virtualizingDataList == null)
                {
                    _virtualizingDataList = new VirtualMovies(this);
                }
                return _virtualizingDataList;
            }
        }

        #region Overrides of PagedDataListSource<MovieVM>


        async protected override Task<DataListPageResult<MovieVm>> FetchCountAsync()
        {
            return await FetchPageAsync(1);
        }

        async protected override Task<DataListPageResult<MovieVm>> FetchPageSizeAsync()
        {
            return await FetchPageAsync(1);

        }

        async protected override Task<DataListPageResult<MovieVm>> FetchPageAsync(int pageNumber)
        {
            //var mvs = await _server.XBMC.VideoLibrary.GetMovies(Movie.AllFields(), new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize }, new Sort() { method = Sort.methodEnum.title, ignorearticle = true, order = Sort.orderEnum.@ascending });
            var mvs = await GetMovies(Movie.AllFields(),
                                  new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize },
                                  new Sort()
                                  {
                                      method = Sort.methodEnum.title,
                                      ignorearticle = true,
                                      order = Sort.orderEnum.@ascending
                                  });
            var list = mvs.movies.Select(MovieFactory).ToList();
            return new DataListPageResult<MovieVm>(mvs.limits.total, PageSize, pageNumber, list);
        }

        async public Task<List<string>> FetchInitAsync()
        {
            //var mvs = await _server.XBMC.VideoLibrary.GetMovies(Movie.AllFields(), new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize }, new Sort() { method = Sort.methodEnum.title, ignorearticle = true, order = Sort.orderEnum.@ascending });
            Stopwatch
                sw= new Stopwatch();
            sw.Start();
            var mvs = await GetMovies(new Movie{MovieItem.title},
                                  null,
                                  new Sort()
                                  {
                                      method = Sort.methodEnum.title,
                                      ignorearticle = true,
                                      order = Sort.orderEnum.@ascending
                                  });
            sw.Stop();
            var m2 = mvs.movies.Select(m => m.title).ToList();
            return m2;
        }

        protected abstract Task<VideoLibrary.GetMoviesResponse> GetMovies(Movie fields, Limits limits, Sort sort);
 
        private MovieVm MovieFactory(XBMCRPC.Video.Details.Movie arg)
        {
            return new MovieVm(arg,_server);
        }

        protected MovieSource(ServerInfo server)
        {
            _server = server;
        }

        #endregion
    }
}
