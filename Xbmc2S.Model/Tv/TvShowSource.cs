using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okra.Data;
using XBMCRPC.List;
using XBMCRPC.Methods;

namespace Xbmc2S.Model
{
    public class TvShowSource:BaseSource<TVShowVm>
    {

        protected readonly IAppContext _server;



        #region Overrides of PagedDataListSource<MovieVM>

        public override string Caption
        {
            get { return "TV Shows"; }
        }

        public override ItemsSourceReference GetStateRepresentationInternal()
        {
            return new ItemsSourceReference(ItemsSourceType.TVShow,ItemsSourceFilter.All){Selection=Items.IndexOf(Selected)};
        }

        public override Task<List<string>> FetchAllLabelsAsync()
        {
            throw new NotImplementedException();
        }

        public override void Goto(object clickedItem)
        {
            throw new NotImplementedException();
        }

        async protected override Task<DataListPageResult<TVShowVm>> FetchPageAsync(int pageNumber)
        {
            var mvs = await _server.XBMC.VideoLibrary.GetTVShows(XBMCRPC.Video.Fields.TVShow.AllFields(),
                                                                 new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize },
                                                                 new Sort()
                                                                     {
                                                                         method = Sort_method.title,
                                                                         ignorearticle = true,
                                                                         order = Sort_order.@ascending
                                                                     });
            var list = mvs.tvshows.Select(ItemFactory).ToList();
            return new DataListPageResult<TVShowVm>(mvs.limits.total, PageSize, pageNumber, list);
        }

        private TVShowVm ItemFactory(XBMCRPC.Video.Details.TVShow arg)
        {
            return new TVShowVm(arg, _server);
        }

        public TvShowSource(IAppContext server)
        {
            _server = server;
        }

        #endregion
    }
}