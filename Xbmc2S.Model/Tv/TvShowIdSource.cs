using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Okra.Data;
using XBMCRPC.Video.Fields;

namespace Xbmc2S.Model
{
    public class TvShowIdSource:BaseSource<TVShowVm>
    {

        protected readonly IAppContext _appContext;
        private readonly int _id;

        #region Overrides of PagedDataListSource<MovieVM>

        public override string Caption
        {
            get { return "TV Shows"; }
        }

        public override ItemsSourceReference GetStateRepresentationInternal()
        {
            return new ItemsSourceReference(ItemsSourceType.TVShow,ItemsSourceFilter.Id){Param = _id.ToString()};
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
            var tvshow = await _appContext.XBMC.VideoLibrary.GetTVShowDetails(_id, TVShow.AllFields());
            var vm = new TVShowVm(tvshow.tvshowdetails, _appContext, false);

            var list = new List<TVShowVm>(){vm};
            return new DataListPageResult<TVShowVm>(1, PageSize, pageNumber, list);
        }

        public TvShowIdSource(IAppContext appContext, int id)
        {
            _appContext = appContext;
            _id = id;
        }

        #endregion
    }
}