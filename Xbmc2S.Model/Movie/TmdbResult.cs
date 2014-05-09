using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Okra.Data;
using TmdbWrapper;
using TmdbWrapper.Persons;
using TmdbWrapper.Search;

namespace Xbmc2S.Model
{
    public class TmdbResult : PagedDataListSource<TmdbItem>, IItemsSource
    {
        private readonly string _query;
        private VirtualizingDataList<TmdbItem> _virtualizingDataList;
        private Config _config;
        private Task _selectionTask;

        public TmdbResult(string query)
        {
            _query = query;
        }


        public string Caption { get; private set; }
        public object Selected { get; set; }

        public IList Items
        {
            get
            {
                if (_virtualizingDataList == null)
                {
                    _virtualizingDataList = new VirtualizingDataList<TmdbItem>(this);
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
                    _virtualizingDataList = new VirtualizingDataList<TmdbItem>(this);
                }
                return _virtualizingDataList;
            }
        }

        public ItemsSourceReference GetStateRepresentation()
        {
            var listRef = new ItemsSourceReference() { Type = ItemsSourceType.Extern, Filter = ItemsSourceFilter.Title, Param = _query };
            if (Selected != null)
            {
                listRef.Selection = Items.IndexOf(Selected);
            }
            return listRef;
        }

        public async Task<List<string>> FetchAllLabelsAsync()
        {
            return new List<string>();
        }

        public void Goto(object clickedItem)
        {
            throw new System.NotImplementedException();
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

        async protected override Task<DataListPageResult<TmdbItem>> FetchCountAsync()
        {
            try
            {
                return await FetchPageAsync(1);
            }
            catch (Exception)
            {

                return new DataListPageResult<TmdbItem>(0, PageSize, 1, new List<TmdbItem>());
            }
        }

        async protected override Task<DataListPageResult<TmdbItem>> FetchPageSizeAsync()
        {
            return await FetchPageAsync(1);

        }

        private const int PageSize = 20;

        async protected override Task<DataListPageResult<TmdbItem>> FetchPageAsync(int pageNumber)
        {
            if (_config == null)
            {
                _config = await TheMovieDb.GetConfiguration();
            }

            var result = await TheMovieDb.SearchMovieAsync(_query, pageNumber);
            List<TmdbItem> list;
            if (result.Results != null)
            {
                list = result.Results.Select(MovieFactory).ToList();
            }
            else
            {
                list = new List<TmdbItem>();
            }

            return new DataListPageResult<TmdbItem>(result.TotalResults, PageSize, pageNumber, list);
        }

        private TmdbItem MovieFactory(MovieSummary arg)
        {
            return new TmdbItem(_config,arg);
        }
    }
    
    public class CastTmdbResult : BaseSource<TmdbItem>
    {
        private readonly string _query;
        private Config _config;
        private int? personID;
        private Credit _credits;

        public CastTmdbResult(string query)
        {
            _query = query;
        }



        async protected override Task<DataListPageResult<TmdbItem>> FetchPageAsync(int pageNumber)
        {
            if (_config == null)
            {
                _config = await TheMovieDb.GetConfiguration();
            }

            if (personID == null)
            {
                personID = 0;
                var resultPerson = await TheMovieDb.SearchPersonAsync(_query, 1);
                if (resultPerson.Results != null && resultPerson.Results.Count == 1)
                {
                    personID = resultPerson.Results[0].Id;
                }
            }
            
            if (personID == 0)
            {
                return new DataListPageResult<TmdbItem>(0, PageSize, pageNumber, new List<TmdbItem>());
            }
            if (_credits == null)
            {
                _credits = await TheMovieDb.GetCreditsAsync(personID.Value);
            }

            List<TmdbItem> list = new List<TmdbItem>();
            var movies = _credits.Cast.Skip((pageNumber - 1)*PageSize).Take((pageNumber - 1)*PageSize + PageSize).Select(r=>r.Id);
            foreach (var movieId in movies)
            {
                var movie = await TheMovieDb.GetMovieAsync(movieId);
                var tmdbItem=new TmdbItem
                        (_config,
                         movie);
                list.Add(tmdbItem);
            }

            return new DataListPageResult<TmdbItem>(_credits.Cast.Count, PageSize, pageNumber, list);
        }

        public override string Caption
        {
            get { throw new System.NotImplementedException(); }
        }

        public override ItemsSourceReference GetStateRepresentationInternal()
        {
            var listRef = new ItemsSourceReference() { Type = ItemsSourceType.Extern, Filter = ItemsSourceFilter.Cast, Param = _query };
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
    }
}