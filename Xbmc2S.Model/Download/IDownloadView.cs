using System.Collections.Generic;

namespace Xbmc2S.Model.Download
{
    public interface IWatchListView : ISelectableListView<WatchListItem>
    {
    }    
    public interface IDownloadView:ISelectableListView<DownloadItem>
    {
    }    
    
    public interface ISelectableListView<out T>
    {
        IEnumerable<T> SelectedItems { get; }
        void SelectAll();
        void ClearSelection();
    }
}