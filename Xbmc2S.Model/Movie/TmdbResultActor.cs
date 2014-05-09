using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Okra.Data;
using TmdbWrapper;
using TmdbWrapper.Search;

namespace Xbmc2S.Model
{
    public class TmdbResultActor : PagedDataListSource<TmdbPerson>,IItemsSource
    {
        private readonly string _query;
        private VirtualizingDataList<TmdbPerson> _virtualizingDataList;
        private Config _config;
        private Task _selectionTask;

        public string Caption { get; private set; }
        public object Selected { get; set; }

        public TmdbResultActor(string query)
        {
            _query = query;
        }


        public IList Items
        {
            get
            {
                if (_virtualizingDataList == null)
                {
                    _virtualizingDataList = new VirtualizingDataList<TmdbPerson>(this);
                }
                return _virtualizingDataList;
            }
        }

        public INotifyCollectionChanged ChangeNotification
        {
            get
            {
                if (_virtualizingDataList == null)
                {
                    _virtualizingDataList = new VirtualizingDataList<TmdbPerson>(this);
                }
                return _virtualizingDataList;
            }
        }

        async protected override Task<DataListPageResult<TmdbPerson>> FetchCountAsync()
        {
            try
            {
                return await FetchPageAsync(1);
            }
            catch (Exception)
            {

                return new DataListPageResult<TmdbPerson>(0, PageSize, 1, new List<TmdbPerson>());
            }
        }

        async protected override Task<DataListPageResult<TmdbPerson>> FetchPageSizeAsync()
        {
            return await FetchPageAsync(1);

        }
        public void RestoreSelection(int index)
        {
            _selectionTask = RestoreSelectionAsync(index);
        }

        public async Task RestoreSelectionAsync(int index)
        {
            Selected = await GetItemAsync(index);
        }

        public Task WaitForSelection()
        {
            if (_selectionTask != null)
            {
                return _selectionTask;
            }
            return Task.Factory.StartNew(() => { });
        }

        private const int PageSize = 20;

        async protected override Task<DataListPageResult<TmdbPerson>> FetchPageAsync(int pageNumber)
        {
            if (_config == null)
            {
                _config = await TheMovieDb.GetConfiguration();
            }
            var result = await TheMovieDb.SearchPersonAsync(_query, pageNumber);
            List<TmdbPerson> list;
            if (result.Results != null)
            {
                list = result.Results.Select(PersonFactory).ToList();
            }
            else
            {
                list = new List<TmdbPerson>();
            }

            return new DataListPageResult<TmdbPerson>(result.TotalResults, PageSize, pageNumber, list);
        }

        private TmdbPerson PersonFactory(PersonSummary arg)
        {
            return new TmdbPerson(_config,  arg); ;
        }

        public ItemsSourceReference GetStateRepresentation()
        {
            return new ItemsSourceReference();
        }

        public async Task<List<string>> FetchAllLabelsAsync()
        {
            return new List<string>();
        }

        public void Goto(object clickedItem)
        {
            throw new System.NotImplementedException();
        }
    }
}