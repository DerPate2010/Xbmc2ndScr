using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Okra.Data;
using Xbmc2S.Model.Annotations;

namespace Xbmc2S.Model
{
    public abstract class BaseSource<T>:PagedDataListSource<T>, IItemsSource, INotifyPropertyChanged
    {
        public abstract string Caption { get; }
        private T _selected;

        private Task _selectionTask;
        private VirtualizingDataList<T> _virtualizingDataList;

        public object Selected
        {
            get
            {
                //if (_selected == null)
                //{
                //    if (Items.Count != 0)
                //    {
                //        _selected = (T) Items[0];
                //    }
                //}
                return _selected;
            }
            set
            {
                if (Equals(value, _selected)) return;
                _selected = (T)value;
                OnPropertyChanged();
            }
        }

        protected const int PageSize = 20;

        async protected override Task<DataListPageResult<T>> FetchCountAsync()
        {
            try
            {
                return await FetchPageAsync(1);
            }
            catch (Exception)
            {

                return new DataListPageResult<T>(0, PageSize, 1, new List<T>());
            }
            
        }

        async protected override Task<DataListPageResult<T>> FetchPageSizeAsync()
        {
            return await FetchPageAsync(1);

        }

        private VirtualizingDataList<T> VirtualizingDataList
        {
            get
            {
                if (_virtualizingDataList == null)
                {
                    _virtualizingDataList = new VirtualizingDataList<T>(this);
                }
                return _virtualizingDataList;
            }
        }


        public IList Items
        {
            get
            {

                return VirtualizingDataList;
            }
        }

        public INotifyCollectionChanged ChangeNotification { get { return VirtualizingDataList; } }

        public virtual ItemsSourceReference GetStateRepresentation()
        {
            var state= GetStateRepresentationInternal();
            if (Selected != null)
            {
                state.Selection = Items.IndexOf(Selected);
            }
            return state;
        }

        public abstract ItemsSourceReference GetStateRepresentationInternal();

        public abstract Task<List<string>> FetchAllLabelsAsync();

        public abstract void Goto(object clickedItem);


        public void RestoreSelection(int index)
        {
            _selectionTask = RestoreSelectionAsync(index);
        }

        public async Task RestoreSelectionAsync(int index)
        {
            Selected = await GetItemAsync(index);
        }

        public async Task WaitForSelection()
        {
            if (_selectionTask != null && !_selectionTask.IsCompleted)
            {
                await _selectionTask;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}