using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xbmc2S.Model.Download
{
    public interface IDownloadManager
    {
        Task AddDownload(DownloadDefinition download);
        Task RemoveDownload(DownloadItem download);
        IList<DownloadItem> Downloads { get; }
        Task PersistDownloads();
        void PrepareDownload(PlayableItemVm playableItemVm, StorageType defaultStorage);
        bool TransfersPending();
    }
}