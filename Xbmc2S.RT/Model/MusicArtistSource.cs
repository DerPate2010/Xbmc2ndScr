using System.Linq;
using System.Threading.Tasks;
using Okra.Data;
using XBMCRPC.List;

namespace Xbmc2S.RT.Model
{
    internal class MusicArtistSource:PagedDataListSource<ArtistVm>
    {

        protected readonly IServerInfo _server;

        public ArtistVm Selected
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

        private VirtualizingDataList<ArtistVm> _virtualizingDataList;
        private ArtistVm _selected;

        public VirtualizingDataList<ArtistVm> VirtualizingDataList
        {
            get
            {
                if (_virtualizingDataList == null)
                {
                    _virtualizingDataList = new VirtualizingDataList<ArtistVm>(this);
                }
                return _virtualizingDataList;
            }
        }


        #region Overrides of PagedDataListSource<MovieVM>


        async protected override Task<DataListPageResult<ArtistVm>> FetchCountAsync()
        {
            return await FetchPageAsync(1);
        }

        async protected override Task<DataListPageResult<ArtistVm>> FetchPageSizeAsync()
        {
            return await FetchPageAsync(1);

        }

        async protected override Task<DataListPageResult<ArtistVm>> FetchPageAsync(int pageNumber)
        {
            var mvs = await _server.XBMC.AudioLibrary.GetArtists(true, XBMCRPC.Audio.Fields.Artist.AllFields(),
                                                                 new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize },
                                                                 new Sort()
                                                                     {
                                                                         method = Sort.methodEnum.title,
                                                                         ignorearticle = true,
                                                                         order = Sort.orderEnum.@ascending
                                                                     });
            var list = mvs.artists.Select(ItemFactory).ToList();
            return new DataListPageResult<ArtistVm>(mvs.limits.total, PageSize, pageNumber, list);
        }

        private ArtistVm ItemFactory(XBMCRPC.Audio.Details.Artist arg)
        {
            return new ArtistVm(arg, _server);
        }

        public MusicArtistSource(IServerInfo server)
        {
            _server = server;
        }

        #endregion
    }
}