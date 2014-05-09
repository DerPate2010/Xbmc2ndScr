using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Xbmc2S.Model.Download
{
    public class DownloadManager:IDownloadManager
    {
        private readonly IAppContext _appContext;
        private const string StorageKey = "ActiveDownloads";

        public DownloadManager(IAppContext appContext, IView view)
        {
            _appContext = appContext;
            Downloads = new List<DownloadItem>();
            ResumeDownloads();
            
        }

        private async Task ResumeDownloads()
        {
            Downloads = await _appContext.PlatformServices.SettingsManager.LoadData(StorageKey, () => new List<DownloadItem>());
            foreach (var downloadItem in Downloads)
            {
                await downloadItem.Attach(_appContext);
                downloadItem.StatusChanged += downloadItem_StatusChanged;
            }
        }

        void downloadItem_StatusChanged(object sender, EventArgs e)
        {
            PersistDownloads();
        }

        public async Task AddDownload(DownloadDefinition downloadDefinition)
        {
            DownloadItem download = new DownloadItem(downloadDefinition, _appContext);
            Downloads.Add(download);
            await download.Start();
            await PersistDownloads();
            download.StatusChanged += downloadItem_StatusChanged;
        }

        public async Task RemoveDownload(DownloadItem download)
        {
            download.StatusChanged -= downloadItem_StatusChanged;
            await download.Stop();
            Downloads.Remove(download);
        }

        public async Task PersistDownloads()
        {
            try
            {
                await _appContext.PlatformServices.SettingsManager.SaveData(StorageKey, Downloads);
            }
            catch (Exception)
            {
            }
        }

        public void PrepareDownload(PlayableItemVm playableItemVm, StorageType defaultStorage)
        {
            var vm = new StartDownloadVm(playableItemVm, defaultStorage, _appContext);
            _appContext.View.PrepareDownload(vm);
        }

        public IList<DownloadItem> Downloads { get; private set; }

        public bool TransfersPending()
        {
            return Downloads.Any(d => !IsFinalState(d.Status));
        }

        public static bool IsFinalState(DownloadStatus status)
        {
            switch (status)
            {
                case DownloadStatus.Finished:
                case DownloadStatus.Canceled:
                case DownloadStatus.Error:
                    return true;
                default:
                    return false;
            }
        }

    }
}
