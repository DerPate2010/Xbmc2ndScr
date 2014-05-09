using System;
using System.Threading.Tasks;

namespace Okra.Data
{
    public class VirtualizingDataList<T> : VirtualizingVectorBase<T>, IUpdatableCollection
    {
        // *** Fields ***

        private readonly IDataListSource<T> dataListSource;

        // *** Constructors ***

        public VirtualizingDataList(IDataListSource<T> dataListSource)
        {
            // Validate the parameters

            if (dataListSource == null)
                throw new ArgumentNullException("dataListSource");

            // Set the fields and subscribe for collection updates

            this.dataListSource = dataListSource;
            dataListSource.Subscribe(this);
        }

        // *** IUpdatableCollection Members ***

        void IUpdatableCollection.Update(DataListUpdate update)
        {
            switch (update.Action)
            {
                case DataListUpdateAction.Add:
                    base.OnItemsAdded(update.Index, update.Count);
                    break;
                case DataListUpdateAction.Remove:
                    base.OnItemsRemoved(update.Index, update.Count);
                    break;
                case DataListUpdateAction.Reset:
                    base.Reset();
                    break;
            }
        }

        // *** Overridden Base Methods ***

        protected override Task<int> GetCountAsync()
        {
            return dataListSource.GetCountAsync();
        }

        protected override Task<T> GetItemAsync(int index)
        {
            return dataListSource.GetItemAsync(index);
        }

        protected override int GetIndexOf(T item)
        {
            return dataListSource.IndexOf(item);
        }
    }
}
