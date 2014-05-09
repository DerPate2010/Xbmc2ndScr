using System.Collections.ObjectModel;
using System.Linq;
using Okra.Core;
using Xbmc2S.Model.Download;

namespace Xbmc2S.Model
{
    public class WatchListVm : BindableBase
    {
        private readonly IWatchListView _view;
        private readonly WatchList _watchList;

        public WatchListVm(IWatchListView view, WatchList watchList)
        {
            _view = view;
            _watchList = watchList;
            _watchList.PropertyChanged += _watchList_PropertyChanged;
            SelectAll = new DelegateCommand(SelectAllExecuted, SelectAllCanExecute);
            ClearSelection = new DelegateCommand(ClearSelectionExecuted, ClearSelectionCanExecute);
            RemoveSelected = new DelegateCommand(RemoveSelectedExecuted, RemoveSelectedCanExecute);

        }

        void _watchList_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        public DelegateCommand SelectAll { get; private set; }
        public DelegateCommand ClearSelection { get; private set; }
        public DelegateCommand RemoveSelected { get; private set; }

        public ObservableCollection<WatchListItem> Items { get { return _watchList.Items; } } 


        private void NotifyCanExecuteChanged()
        {
            SelectAll.NotifyCanExecuteChanged();
            RemoveSelected.NotifyCanExecuteChanged();
            ClearSelection.NotifyCanExecuteChanged();
        }

        private bool RemoveSelectedCanExecute()
        {
            return _view.SelectedItems.Any();
        }

        private async void RemoveSelectedExecuted()
        {
            foreach (var item in _view.SelectedItems.ToList())
            {
                await _watchList.RemoveItem(item);
            }
            NotifyCanExecuteChanged();
        }

        private bool ClearSelectionCanExecute()
        {
            return _view.SelectedItems.Any();
        }

        private async void ClearSelectionExecuted()
        {
            _view.ClearSelection();
            NotifyCanExecuteChanged();
        }

        private bool SelectAllCanExecute()
        {
            return _watchList.Items != null && _view.SelectedItems.Count()!=_watchList.Items.Count;
        }

        private async void SelectAllExecuted()
        {
            _view.SelectAll();
            NotifyCanExecuteChanged();
        }

        public void NotifySelectionChanged()
        {
            NotifyCanExecuteChanged();
        }

    }
}