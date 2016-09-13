using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okra.Data;
using KODIRPC.List;
using KODIRPC.List.Filter;
using KODIRPC.Settings;
using TVShows = KODIRPC.List.Filter.Fields.TVShows;

namespace Xbmc2S.Model
{
    public class CastTTVShowSource:BaseSource<TVShowVm>
    {

        protected readonly IAppContext _server;
        private readonly string _actor;

        public override string Caption
        {
            get { throw new System.NotImplementedException(); }
        }

        public override ItemsSourceReference GetStateRepresentationInternal()
        {
            var listRef = new ItemsSourceReference() { Type = ItemsSourceType.TVShow, Filter = ItemsSourceFilter.Cast, Param = _actor };
            if (Selected != null)
            {
                listRef.Selection = Items.IndexOf(Selected);
            }
            return listRef;
        }

        public override Task<List<string>> FetchAllLabelsAsync()
        {
            throw new System.NotImplementedException();
        }

        public override void Goto(object clickedItem)
        {
            throw new System.NotImplementedException();
        }

        #region Overrides of PagedDataListSource<MovieVM>

        async protected override Task<DataListPageResult<TVShowVm>> FetchPageAsync(int pageNumber)
        {
            var mvs = await _server.XBMC.VideoLibrary.GetTVShows(filter: new Rule.TVShows() { field = TVShows.actor, Operator = Operators.Is, value = _actor }, properties: KODIRPC.Video.Fields.TVShow.AllFields(),limits:
                                                                  new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize }, sort:
                                                                  new Sort()
                                                                  {
                                                                      method = Sort_method.label,
                                                                      ignorearticle = true,
                                                                      order = Sort_order.@ascending
                                                                  });

            var list = mvs.tvshows.Select(ItemFactory).ToList();
            return new DataListPageResult<TVShowVm>(mvs.limits.total, PageSize, pageNumber, list);
        }

        private TVShowVm ItemFactory(KODIRPC.Video.Details.TVShow arg)
        {
            return new TVShowVm(arg, _server);
        }

        public CastTTVShowSource(IAppContext server, string actor)
        {
            _server = server;
            _actor = actor;
        }

        #endregion
    }  
    
    public class TitleTVShowSource:BaseSource<TVShowVm>
    {

        protected readonly IAppContext _server;
        private readonly string _query;

        public override string Caption
        {
            get { throw new System.NotImplementedException(); }
        }

        public override ItemsSourceReference GetStateRepresentationInternal()
        {
            var listRef = new ItemsSourceReference() { Type = ItemsSourceType.TVShow, Filter = ItemsSourceFilter.Title, Param = _query };
            if (Selected != null)
            {
                listRef.Selection = Items.IndexOf(Selected);
            }
            return listRef;
        }

        public override Task<List<string>> FetchAllLabelsAsync()
        {
            throw new System.NotImplementedException();
        }

        public override void Goto(object clickedItem)
        {
            throw new System.NotImplementedException();
        }

        #region Overrides of PagedDataListSource<MovieVM>

        async protected override Task<DataListPageResult<TVShowVm>> FetchPageAsync(int pageNumber)
        {
            var mvs = await _server.XBMC.VideoLibrary.GetTVShows(filter:new Rule.TVShows(){field = TVShows.title, Operator = Operators.contains, value = _query},properties:KODIRPC.Video.Fields.TVShow.AllFields(),
                                                                  limits: new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize },
                                                                  sort: new Sort()
                                                                      {
                                                                          method = Sort_method.label,
                                                                          ignorearticle = true,
                                                                          order = Sort_order.@ascending
                                                                      });
            var list = mvs.tvshows.Select(ItemFactory).ToList();
            return new DataListPageResult<TVShowVm>(mvs.limits.total, PageSize, pageNumber, list);
        }

        private TVShowVm ItemFactory(KODIRPC.Video.Details.TVShow arg)
        {
            return new TVShowVm(arg, _server);
        }

        public TitleTVShowSource(IAppContext server, string query)
        {
            _server = server;
            _query = query;
        }

        #endregion
    }
}