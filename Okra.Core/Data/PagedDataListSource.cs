using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Okra.Helpers;

namespace Okra.Data
{
    public abstract class PagedDataListSource<T> : DataListSourceBase<T>
    {
        // *** Fields ***

        private readonly PageVirtualizingList<T> internalList = new PageVirtualizingList<T>();

        private int? count;
        private int? itemsPerPage;

        private Task fetchingCountTask;
        private Task fetchingPageSizeTask;
        private Task[] fetchingPageTasks = new Task[0];

        // *** Properties ***

        public int PageCacheSize
        {
            get
            {
                return InternalList.PageCacheSize;
            }
            set
            {
                InternalList.PageCacheSize = value;
            }
        }

        // *** Private Properties ***

        private PageVirtualizingList<T> InternalList
        {
            get
            {
                return internalList;
            }
        }

        // *** IDataListSource<T> Methods ***

        public async override Task<int> GetCountAsync()
        {
            // If we are not initialized then await fetching the list

            if (count == null)
                await GetFetchingCountTask();

            // Return the result from the cached list

            return count.Value;
        }

        public async override Task<T> GetItemAsync(int index)
        {
            // Validate arguments

            if (index < 0)
                throw new ArgumentOutOfRangeException("index", ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ArrayIndexOutOfRange"));

            // If we don't know the count then get the number of items

            if (count == null)
                await GetFetchingCountTask();

            // Throw an exception if the specified index is greater than the number of items in the list

            if (index >= count)
                throw new ArgumentOutOfRangeException("index", ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ArrayIndexOutOfRange"));

            // If we don't know the number of items per page then get this

            if (itemsPerPage == null)
                await GetFetchingPageSizeTask();

            // If this item is not initialized then await fetching the page

            if (InternalList[index] == null || InternalList[index].Equals(default(T)))
            {
                int pageNumber = index / itemsPerPage.Value + 1;
                await GetFetchingPageTask(pageNumber);
            }

            // Return the result from the cached list

            return InternalList[index];
        }

        public override int IndexOf(T item)
        {
            // Delegate to the internal list

            return InternalList.IndexOf(item);
        }

        public void Refresh()
        {
            // TODO : Should 'await fetchingTasks' here in case a fetch is currently in progress???

            fetchingCountTask = null;
            fetchingPageSizeTask = null;
            fetchingPageTasks = new Task[0];

            count = null;
            itemsPerPage = null;
            InternalList.Clear();

            PostUpdate(new DataListUpdate(DataListUpdateAction.Reset));
        }

        // *** Protected Methods ***

        protected abstract Task<DataListPageResult<T>> FetchCountAsync();
        protected abstract Task<DataListPageResult<T>> FetchPageSizeAsync();
        protected abstract Task<DataListPageResult<T>> FetchPageAsync(int pageNumber);

        // *** Private Methods ***

        private Task GetFetchingCountTask()
        {
            if (fetchingCountTask == null)
                fetchingCountTask = FetchingCountTask();

            return fetchingCountTask;
        }

        private Task GetFetchingPageSizeTask()
        {
            if (fetchingPageSizeTask == null)
                fetchingPageSizeTask = FetchingPageSizeTask();

            return fetchingPageSizeTask;
        }

        private Task GetFetchingPageTask(int pageNumber)
        {
            int fetchingPageTaskIndex = pageNumber - 1;

            if (fetchingPageTasks[fetchingPageTaskIndex] == null)
                fetchingPageTasks[fetchingPageTaskIndex] = FetchingPageTask(pageNumber);

            return fetchingPageTasks[fetchingPageTaskIndex];
        }

        private async Task FetchingCountTask()
        {
            // Call the deriving class to get the information

            DataListPageResult<T> pageInfo = await FetchCountAsync();
            Update(pageInfo);
        }

        private async Task FetchingPageSizeTask()
        {
            // Call the deriving class to get the information

            DataListPageResult<T> pageInfo = await FetchPageSizeAsync();
            Update(pageInfo);
        }

        private async Task FetchingPageTask(int pageNumber)
        {
            // Call the deriving class to get the information

            DataListPageResult<T> pageInfo = await FetchPageAsync(pageNumber);
            Update(pageInfo);

            // Remove the fetching page task from the internal list so subsequent requests are reperformed

            fetchingPageTasks[pageNumber - 1] = null;
        }

        private void Update(DataListPageResult<T> pageInfo)
        {
            // Update the total item count
            // TODO : Handle situation if the total item count has changed between calls! (raise collection changed & update internals?)

            if (pageInfo.TotalItemCount != null)
                count = pageInfo.TotalItemCount;

            // Update the items per page

            if (pageInfo.ItemsPerPage != null)
                itemsPerPage = pageInfo.ItemsPerPage.Value;

            // If we know both the item count and the items per page then...

            if (count != null && itemsPerPage != null)
            {
                // (a) Update the PageVirtualizingList with this information

                InternalList.UpdateCount(count.Value, itemsPerPage.Value);

                // (b) If the number of pages has changed then update the array for fetching page tasks

                int pageCount = (count.Value - 1) / itemsPerPage.Value + 1;

                if (fetchingPageTasks.Length < pageCount)
                {
                    Task[] newPageFetchingTasks = new Task[pageCount];
                    fetchingPageTasks.CopyTo(newPageFetchingTasks, 0);
                    fetchingPageTasks = newPageFetchingTasks;
                }
            }

            // Update the page information

            if (pageInfo.PageNumber != null)
            {
                int startIndex = itemsPerPage.Value * (pageInfo.PageNumber.Value - 1);

                for (int i = 0; i < pageInfo.Page.Count; i++)
                    InternalList[startIndex + i] = pageInfo.Page[i];
            }
        }
    }
}
