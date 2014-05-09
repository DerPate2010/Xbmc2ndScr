using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Okra.Helpers;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace Okra.Data
{
    public class IncrementalLoadingDataList<T> : VirtualizingVectorBase<T>, ISupportIncrementalLoading, IUpdatableCollection
    {
        // *** Fields ***

        private readonly IDataListSource<T> dataListSource;

        private int minimumPagingSize;
        private int currentCount;
        private int? sourceCount;

        // *** Constructors ***

        public IncrementalLoadingDataList(IDataListSource<T> dataListSource)
        {
            // Validate the parameters

            if (dataListSource == null)
                throw new ArgumentNullException("dataListSource");

            // Set the fields

            this.dataListSource = dataListSource;
        }

        // *** Properties ***

        public int MinimumPagingSize
        {
            get
            {
                return minimumPagingSize;
            }
            set
            {
                if (minimumPagingSize != value)
                {
                    minimumPagingSize = value;
                    OnPropertyChanged("MinimumPagingSize");
                }
            }
        }

        // *** IUpdatableCollection Members ***

        void IUpdatableCollection.Update(DataListUpdate update)
        {
            switch (update.Action)
            {
                case DataListUpdateAction.Add:
                    Update_Add(update);
                    break;
                case DataListUpdateAction.Remove:
                    Update_Remove(update);
                    break;
                case DataListUpdateAction.Reset:
                    Update_Reset();
                    break;
            }
        }

        // *** ISupportIncrementalLoading Members ***

        public bool HasMoreItems
        {
            get
            {
                // If we have not yet retrived the number of items from the data list source then return true

                if (sourceCount == null)
                    return true;

                // Otherwise return true only if there are items yet to be retrived

                else
                    return currentCount < sourceCount;
            }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return LoadMoreItemsAsyncInternal((int)count).AsAsyncOperation();
        }

        // *** Overridden Base Methods ***

        protected override Task<int> GetCountAsync()
        {
            return Task.FromResult<int>(currentCount);
        }

        protected override Task<T> GetItemAsync(int index)
        {
            // Validate arguments

            if (index < 0 || index > currentCount)
                throw new ArgumentOutOfRangeException("index", ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ArrayIndexOutOfRange"));

            // Return the value from the source

            return dataListSource.GetItemAsync(index);
        }

        protected override int GetIndexOf(T item)
        {
            // Get the index from the source

            int index = dataListSource.IndexOf(item);

            // If the index is in the currently visible region then return the index, otherwise return -1

            return index < currentCount ? index : -1;
        }

        // *** Private Methods ***

        private async Task<LoadMoreItemsResult> LoadMoreItemsAsyncInternal(int count)
        {
            IsLoading = true;

            // If we currently do not know the number of items then fetch this

            if (sourceCount == null)
                sourceCount = await dataListSource.GetCountAsync();

            // Set a minimum paging size if requested

            count = Math.Max(count, MinimumPagingSize);

            // Limit the number of items to fetch to the number of remaining items

            count = Math.Min(count, sourceCount.Value - currentCount);

            // Get all the items and wait until they are all fetched

            Task<T>[] fetchItemTasks = new Task<T>[count];
            int startIndex = currentCount;

            for (int i = 0; i < count; i++)
                fetchItemTasks[i] = dataListSource.GetItemAsync(startIndex + i);

            await Task.WhenAll(fetchItemTasks);

            // Increment the current count

            currentCount += count;

            // Set properties and raise property changed for HasMoreItems if this is not false

            IsLoading = false;

            if (currentCount == sourceCount)
                OnPropertyChanged("HasMoreItems");

            // Raise collection changed events

            OnItemsAdded(startIndex, count);

            // Return the number of items added
            
            return new LoadMoreItemsResult() { Count = (uint)count };
        }

        private void Update_Add(DataListUpdate update)
        {
            // If the entire update is outside of the visible collection then ignore it

            if (update.Index > currentCount)
                return;

            currentCount += update.Count;
            base.OnItemsAdded(update.Index, update.Count);
        }

        private void Update_Remove(DataListUpdate update)
        {
            // If the entire update is outside of the visible collection then ignore it

            if (update.Index >= currentCount)
                return;

            // If the update overlaps the boundary of the visible collection then only remove visible items

            int removedItemCount = Math.Min(update.Count, currentCount - update.Index);

            currentCount -= removedItemCount;
            base.OnItemsRemoved(update.Index, removedItemCount);
        }

        private void Update_Reset()
        {
            // Set the count to zero

            currentCount = 0;

            // Raise the Reset events

            base.Reset();

            // Raise a 'HasMoreItems' property changed event

            OnPropertyChanged("HasMoreItems");
        }
    }
}
