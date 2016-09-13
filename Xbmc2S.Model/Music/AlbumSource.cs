using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okra.Data;
using KODIRPC.AudioLibrary;
using KODIRPC.List;
using KODIRPC.Methods;

namespace Xbmc2S.Model
{
    public class AlbumSource:PagedDataListSource<AlbumVm>
    {

        protected readonly IAppContext _server;

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
            try
            {
                return await FetchPageAsync(1);
            }
            catch (Exception)
            {

                return new DataListPageResult<AlbumVm>(0, PageSize, 1, new List<AlbumVm>());
            }
            
        }

        async protected override Task<DataListPageResult<AlbumVm>> FetchPageSizeAsync()
        {
            return await FetchPageAsync(1);

        }

        async protected override Task<DataListPageResult<AlbumVm>> FetchPageAsync(int pageNumber)
        {
            var mvs = await _server.XBMC.AudioLibrary.GetAlbums(filter:new GetAlbums_filterArtistid() { artistid = _artistId }, properties: KODIRPC.Audio.Fields.Album.AllFields(),
                                                                limits: new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize },
                                                                sort: new Sort()
                                                                     {
                                                                         method = Sort_method.title,
                                                                         ignorearticle = true,
                                                                         order = Sort_order.@ascending
                                                                     });
            var list = mvs.albums.Select(ItemFactory).ToList();
            return new DataListPageResult<AlbumVm>(mvs.limits.total, PageSize, pageNumber, list);
        }

        private AlbumVm ItemFactory(KODIRPC.Audio.Details.Album arg)
        {
            return new AlbumVm(arg, _server);
        }

        public AlbumSource(IAppContext server, int artistId)
        {
            _server = server;
            _artistId = artistId;
        }

        #endregion
    }
}