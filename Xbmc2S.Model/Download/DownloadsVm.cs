using System.Collections.Generic;
using System.Linq;
using Okra.Core;
using Xbmc2S.Model;
using Xbmc2S.Model.Download;

namespace Xbmc2S.RT
{
    public class DownloadsVm:BindableBase
    {
        private readonly IDownloadView _listView;
        private readonly IDownloadManager _dlManager;
        private IList<DownloadItem> _items;
        public DelegateCommand PlaySelected { get; set; }
        public DelegateCommand SelectAll { get; set; }
        public DelegateCommand StopSelected { get; set; }
        public DelegateCommand DeleteSelected { get; set; }
        public DelegateCommand ClearSelection { get; set; }
        public DelegateCommand RemoveFinished { get; set; }
        public IList<DownloadItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public DownloadsVm(IDownloadView listView, IDownloadManager dlManager)
        {
            _listView = listView;
            _dlManager = dlManager;
            Items = dlManager.Downloads;
            PlaySelected = new DelegateCommand(PlaySelectedExecuted,PlaySelectedCanExecute);
            SelectAll = new DelegateCommand(SelectAllExecuted, SelectAllCanExecute);
            ClearSelection = new DelegateCommand(ClearSelectionExecuted, ClearSelectionCanExecute);
            StopSelected = new DelegateCommand(StopSelectedExecuted, StopSelectedCanExecute);
            DeleteSelected = new DelegateCommand(DeleteSelectedExecuted, DeleteSelectedCanExecute);
            RemoveFinished = new DelegateCommand(RemoveFinishedExecuted, RemoveFinishedCanExecute);
        }

        private void NotifyCanExecuteChanged()
        {
            PlaySelected.NotifyCanExecuteChanged();
            SelectAll.NotifyCanExecuteChanged();
            StopSelected.NotifyCanExecuteChanged();
            DeleteSelected.NotifyCanExecuteChanged();
            ClearSelection.NotifyCanExecuteChanged();
            RemoveFinished.NotifyCanExecuteChanged();
        }



        private bool RemoveFinishedCanExecute()
        {
            return _dlManager.Downloads.Any(d => d.Status == DownloadStatus.Finished);
        }

        private void RemoveFinishedExecuted()
        {
            var toRemove=_dlManager.Downloads.Where(d => DownloadManager.IsFinalState(d.Status)).ToList();
            foreach (var downloadItem in toRemove)
            {
                _dlManager.RemoveDownload(downloadItem);
            }
            Items = null;
            Items = _dlManager.Downloads;
            NotifyCanExecuteChanged();
        }


        private bool DeleteSelectedCanExecute()
        {
            return _listView.SelectedItems.Any();
        }

        private async void DeleteSelectedExecuted()
        {
            foreach (DownloadItem download in _listView.SelectedItems)
            {
                await _dlManager.RemoveDownload(download);
            }
            Items = null;
            Items = _dlManager.Downloads;
            NotifyCanExecuteChanged();
        }

        private bool StopSelectedCanExecute()
        {
            return _listView.SelectedItems.Any(d=>NotFinished(d.Status));
        }

        private bool NotFinished(DownloadStatus status)
        {
            return !(status == DownloadStatus.Error || status == DownloadStatus.Canceled ||
                     status == DownloadStatus.Finished);
        }

        private async void StopSelectedExecuted()
        {
            foreach (DownloadItem download in _listView.SelectedItems)
            {
                await download.Stop();
            }
            NotifyCanExecuteChanged();
        }

        private bool ClearSelectionCanExecute()
        {
            return _listView.SelectedItems.Any();
        }

        private void ClearSelectionExecuted()
        {
            _listView.ClearSelection();
            NotifyCanExecuteChanged();
        }

        private bool SelectAllCanExecute()
        {
            return _dlManager.Downloads.Count != _listView.SelectedItems.Count();
        }

        private void SelectAllExecuted()
        {
            _listView.SelectAll();
            NotifyCanExecuteChanged();
        }

        private bool PlaySelectedCanExecute()
        {
            return _listView.SelectedItems.Count() == 1 && _listView.SelectedItems.First().Status==DownloadStatus.Finished;
        }

        private void PlaySelectedExecuted()
        {
            _listView.SelectedItems.First().Play();
        }

        public void NotifySelectionChanged()
        {
            NotifyCanExecuteChanged();
        }
    }
}