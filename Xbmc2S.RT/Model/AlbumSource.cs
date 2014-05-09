using System.Linq;
using System.Threading.Tasks;
using Okra.Data;
using XBMCRPC.List;
using XBMCRPC.Methods;

namespace Xbmc2S.RT.Model
{
    internal class AlbumSource:PagedDataListSource<AlbumVm>
    {

        protected readonly IServerInfo _server;

        public AlbumVm Selected
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

        private VirtualizingDataList<AlbumVm> _virtualizingDataList;
        private AlbumVm _selected;
        private int _artistId;

        public VirtualizingDataList<AlbumVm> VirtualizingDataList
        {
            get
            {
                if (_virtualizingDataList == null)
                {
                    _virtualizingDataList = new VirtualizingDataList<AlbumVm>(this);
                }
                return _virtualizingDataList;
            }
        }


        #region Overrides of PagedDataListSource<MovieVM>


        async protected override Task<DataListPageResult<AlbumVm>> FetchCountAsync()
        {
            return await FetchPageAsync(1);
        }

        async protected override Task<DataListPageResult<AlbumVm>> FetchPageSizeAsync()
        {
            return await FetchPageAsync(1);

        }

        async protected override Task<DataListPageResult<AlbumVm>> FetchPageAsync(int pageNumber)
        {
            var mvs = await _server.XBMC.AudioLibrary.GetAlbums2(XBMCRPC.Audio.Fields.Album.AllFields(),
                                                                 new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize },
                                                                 new Sort()
                                                                     {
                                                                         method = Sort.methodEnum.title,
                                                                         ignorearticle = true,
                                                                         order = Sort.orderEnum.@ascending
                                                                     }, new AudioLibrary.GetAlbumsfilter3(){artistid = _artistId});
            var list = mvs.albums.Select(ItemFactory).ToList();
            return new DataListPageResult<AlbumVm>(mvs.limits.total, PageSize, pageNumber, list);
        }

        private AlbumVm ItemFactory(XBMCRPC.Audio.Details.Album arg)
        {
            return new AlbumVm(arg, _server);
        }

        public AlbumSource(IServerInfo server, int artistId)
        {
            _server = server;
            _artistId = artistId;
        }

        #endregion
    }
}