using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okra.Data;
using KODIRPC.List;
using KODIRPC.List.Filter;
using Episodes = KODIRPC.List.Filter.Fields.Episodes;

namespace Xbmc2S.Model
{
    public class CastEpisodesSource:BaseSource<EpisodeVm>
    {

        protected readonly IAppContext _server;
        private readonly string _actor;

        public override string Caption
        {
            get { throw new System.NotImplementedException(); }
        }

        public override ItemsSourceReference GetStateRepresentationInternal()
        {
            var listRef = new ItemsSourceReference() { Type = ItemsSourceType.Episode, Filter = ItemsSourceFilter.Cast, Param = _actor };
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


        async protected override Task<DataListPageResult<EpisodeVm>> FetchCountAsync()
        {
            return await FetchPageAsync(1);
        }

        async protected override Task<DataListPageResult<EpisodeVm>> FetchPageSizeAsync()
        {
            return await FetchPageAsync(1);

        }

        async protected override Task<DataListPageResult<EpisodeVm>> FetchPageAsync(int pageNumber)
        {
            var mvs = await _server.XBMC.VideoLibrary.GetEpisodes(filter:new Rule.Episodes() { field = Episodes.actor, Operator = Operators.Is, value = _actor },tvshowid: 0, season: 0, properties:KODIRPC.Video.Fields.Episode.AllFields(),
                limits:new Limits() { start = (pageNumber - 1) * PageSize, end = (pageNumber - 1) * PageSize + PageSize },
                sort:new Sort()
                {
                    method = Sort_method.label,
                    ignorearticle = true,
                    order = Sort_order.@ascending
                });
            
            List<EpisodeVm> list;
            if (mvs.episodes == null)
            {
                list= new List<EpisodeVm>();
            }
            else
            {
                list = mvs.episodes.Select(ItemFactory).ToList();
            }
            return new DataListPageResult<EpisodeVm>(mvs.limits.total, PageSize, pageNumber, list);
        }

        private EpisodeVm ItemFactory(KODIRPC.Video.Details.Episode arg)
        {
            return new EpisodeVm(arg, _server);
        }

        public CastEpisodesSource(IAppContext server, string actor)
        {
            _server = server;
            _actor = actor;
        }

        #endregion
    }
}