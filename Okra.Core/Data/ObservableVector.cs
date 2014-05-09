using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Okra.Data
{
    // NB   : In the Developer Preview & Consumer Preview implementing IObservableVector<T> only works where T is object
    //        However the WinRT wrapper to INotifyCollectionChanged does work!

    public class ObservableVector<T> : Collection<T>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        // *** Constants ***

        private const string PropertyNameCount = "Count";
        private const string PropertyNameIndexer = "Item[]";

        // *** Events ***

        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        // *** Constructors ***

        public ObservableVector()
            : base()
        {
        }

        public ObservableVector(IList<T> list)
            : base(list)
        {
        }

        // *** Protected Methods ***

        protected override void ClearItems()
        {
            base.ClearItems();
            OnPropertyChanged(PropertyNameCount);
            OnPropertyChanged(PropertyNameIndexer);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            OnPropertyChanged(PropertyNameCount);
            OnPropertyChanged(PropertyNameIndexer);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
        }

        protected override void RemoveItem(int index)
        {
            T oldItem = base[index];
            base.RemoveItem(index);
            OnPropertyChanged(PropertyNameCount);
            OnPropertyChanged(PropertyNameIndexer);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItem, index));
        }

        protected override void SetItem(int index, T item)
        {
            T oldItem = base[index];
            base.SetItem(index, item);
            OnPropertyChanged(PropertyNameIndexer);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, oldItem, index));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        // *** Event Handlers ***

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler eventHandler = PropertyChanged;

            if (eventHandler != null)
                eventHandler(this, e);
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler eventHandler = CollectionChanged;

            if (eventHandler != null)
                eventHandler(this, e);
        }
    }
}