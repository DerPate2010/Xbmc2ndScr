using System.Linq;
using System.Threading.Tasks;
using Okra.Data;
using XBMCRPC.List;

namespace Xbmc2S.RT.Model
{
    class TvShowSource:PagedDataListSource<TVShowVm>
    {

        protected readonly IServerInfo _server;

        public TVShowVm Selected
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

        private VirtualizingDataList<TVShowVm> _virtualizingDataList;
        private TVShowVm _selected;

        public VirtualizingDataList<TVShowVm> VirtualizingDataList
        {
            get
            {
                if (_virtualizingDataList == null)
                {
                    _virtualizingDataList = new VirtualizingDataList<TVShowVm>(this);
                }
                return _virtualizingDataList;
            }
        }


        #region Overrides of PagedDataListSource<MovieVM>


        async protected override Task<DataListPageResult<TVShowVm>> FetchCountAsync()
        {
            return await FetchPageAsync(1);
        }

        async protected override Task<DataListPageResult<TVShowVm>> FetchPageSizeAsync()
        {
            return await FetchPageAsync(1);

        }

        async protected override Task<DataListPageResult<TVShowVm>> FetchPageAsync(int pageNumber)
        {
            var mvs = await _server.XBMC.VideoLibrary.GetTVShows(XBMCRPC.Video.Fields.TVShow.AllFields(),
                                                                 new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize },
                                                                 new Sort()
                                                                     {
                                                                         method = Sort.methodEnum.title,
                                                                         ignorearticle = true,
                                                                         order = Sort.orderEnum.@ascending
                                                                     });
            var list = mvs.tvshows.Select(ItemFactory).ToList();
            return new DataListPageResult<TVShowVm>(mvs.limits.total, PageSize, pageNumber, list);
        }

        private TVShowVm ItemFactory(XBMCRPC.Video.Details.TVShow arg)
        {
            return new TVShowVm(arg, _server);
        }

        public TvShowSource(IServerInfo server)
        {
            _server = server;
        }

        #endregion
    }
}