using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Okra.Internal;

namespace Okra.Data
{
    internal abstract class DataListSourceOperatorBase<T> : IDataListSource<T>, IUpdatableCollection
    {
        // *** Fields ***

        private readonly IDataListSource<T> source;

        private WeakReferenceList<IUpdatableCollection> updateSubscriptions = new WeakReferenceList<IUpdatableCollection>();
        private IDisposable sourceUpdateDisposable;

        // *** Constructors ***

        public DataListSourceOperatorBase(IDataListSource<T> source)
        {
            this.source = source;
        }

        // *** Properties ***

        protected IDataListSource<T> Source
        {
            get
            {
                return source;
            }
        }

        // *** Methods ***

        public abstract Task<int> GetCountAsync();
        public abstract Task<T> GetItemAsync(int index);
        public abstract int IndexOf(T item);

        public IDisposable Subscribe(IUpdatableCollection collection)
        {
            // Store the IUpdatableCollection in a WeakReferenceList

            WeakReference<IUpdatableCollection> collectionReference = updateSubscriptions.AddAndReturnReference(collection);

            // Subscribe to the source if there is not currently a subscription in place

            if (sourceUpdateDisposable == null)
                sourceUpdateDisposable = source.Subscribe(this);
            
            // Return an IDisposable to remove the subscription

            return new DelegateDisposable(delegate()
            {
                updateSubscriptions.Remove(collectionReference);
                UnsubscribeFromSourceIfNoSubscribers();
            });
        }

        // *** Protected Methods ***

        protected void PostUpdate(DataListUpdate update)
        {
            foreach (IUpdatableCollection collection in updateSubscriptions)
                collection.Update(update);
        }

        protected virtual void ProcessUpdate(DataListUpdate update)
        {
            // Unsubscribe from future updates if all subscribers have been garbage collected or removed

            UnsubscribeFromSourceIfNoSubscribers();

            // If the derived class does not implement ProcessUpdate then simply forward the update

            PostUpdate(update);
        }

        // *** IUpdatableCollection Methods ***

        void IUpdatableCollection.Update(DataListUpdate update)
        {
            // Process the update to perform any side-effects or conversions required and forward to any subscribers

            ProcessUpdate(update);
        }

        // *** Private Methods ***

        private void UnsubscribeFromSourceIfNoSubscribers()
        {
            if (updateSubscriptions.Count == 0 && sourceUpdateDisposable != null)
            {
                sourceUpdateDisposable.Dispose();
                sourceUpdateDisposable = null;
            }
        }
    }
}
