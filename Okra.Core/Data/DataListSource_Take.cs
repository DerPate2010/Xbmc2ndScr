using System;
using System.Threading.Tasks;
using Okra.Helpers;

namespace Okra.Data
{
    internal class DataListSource_Take<T> : DataListSourceOperatorBase<T>
    {
        // *** Fields ***

        private readonly int count;

        // NB: 'sourceCount' holds the last known value - if this gets out of sync with the source then this is because there
        //     is nobody observing the changes to the collection and any new observers will need to resync first by calling GetCountAsync()
        private int sourceCount;

        // *** Constructors ***

        public DataListSource_Take(IDataListSource<T> source, int count)
            : base(source)
        {
            this.count = count;
        }

        // *** Methods ***

        public override async Task<int> GetCountAsync()
        {
            // Get the source count

            sourceCount = await Source.GetCountAsync();

            // Return the minimum value of source and 'count'

            return Math.Min(sourceCount, count);
        }

        public override Task<T> GetItemAsync(int index)
        {
            // If the index is outside of the bounds of the Take then throw an exception
            // NB: If the source is shorter than the count then it will handle throwing the exception

            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ArrayIndexOutOfRange"));

            // Otherwise defer to the source

            return Source.GetItemAsync(index);
        }

        public override int IndexOf(T item)
        {
            // Get the index from the source

            int index = Source.IndexOf(item);

            // Return the supplied value if within the bounds of the Take, otherwise return -1

            if (index >= count)
                return -1;
            else
                return index;
        }

        protected override void ProcessUpdate(DataListUpdate update)
        {
            switch (update.Action)
            {
                case DataListUpdateAction.Add:
                    ProcessUpdate_Add(update);
                    break;
                case DataListUpdateAction.Remove:
                    ProcessUpdate_Remove(update);
                    break;
                default:
                    PostUpdate(update);
                    break;
            }
        }

        // *** Private Methods ***

        private void ProcessUpdate_Add(DataListUpdate update)
        {
            // If the update is outside of the bounds of the 'count' then simply consume the event

            if (update.Index >= count)
                return;

            // Forward the 'Add' update to any subscribers
            // NB: The number of items added may need to be trimmed if they will exceed the bounds of the Take

            int itemsAdded = Math.Min(update.Count, count - update.Index);
            PostUpdate(new DataListUpdate(DataListUpdateAction.Add, update.Index, itemsAdded));

            // If the 'Add' operation has pushed some items outside of the bounds of the Take then these will need to be removed

            int oldCount = Math.Min(sourceCount, count);
            int itemsRemoved = oldCount + itemsAdded - count;

            if (itemsRemoved > 0)
                PostUpdate(new DataListUpdate(DataListUpdateAction.Remove, count, itemsRemoved));

            // Set the last known source count

            sourceCount += update.Count;
        }

        private void ProcessUpdate_Remove(DataListUpdate update)
        {
            // If the update is outside of the bounds of the 'count' then simply consume the event

            if (update.Index >= count)
                return;

            // Forward the 'Remove' update to any subscribers
            // NB: The number of items removed may need to be trimmed if they exceed the bounds of the Take

            int itemsRemoved = Math.Min(update.Count, count - update.Index);
            PostUpdate(new DataListUpdate(DataListUpdateAction.Remove, update.Index, itemsRemoved));

            // If the 'Remove' operation has pulled in some items outside of the bounds of the Take then these will need to be added

            int itemsAvailable = sourceCount - Math.Max(update.Index + update.Count, count);
            int itemsAdded = Math.Min(itemsRemoved, itemsAvailable);

            if (itemsAdded > 0)
                PostUpdate(new DataListUpdate(DataListUpdateAction.Add, count - itemsRemoved, itemsAdded));

            // Set the last known source count

            sourceCount -= update.Count;
        }
    }
}
