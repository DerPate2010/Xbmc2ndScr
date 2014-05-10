using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Security.Credentials;
using Windows.Storage;
using Xbmc2S.Model;
using Xbmc2S.Model.Download;

namespace Xbmc2S.RT.PlatformServices
{
    public class BackgroundTransferManager : IBackgroundTransfer
    {
        private Dictionary<Guid, DownloadProgress> _activeDownloads;

        public BackgroundTransferManager()
        {
            _initTask = Init();
        }

        private bool _initialized;
        private object _initLock;
        private Task _initTask;

        private async Task Init()
        {
            var activeDownloads = await BackgroundDownloader.GetCurrentDownloadsAsync();
            var progresses = new Dictionary<Guid, DownloadProgress>();
            foreach (var downloadOperation in activeDownloads)
            {
                var progress = new DownloadProgress(downloadOperation);
                downloadOperation.AttachAsync().AsTask(progress);
                progresses.Add(downloadOperation.Guid, progress);
            }
            _activeDownloads = progresses;
        }

        private async Task AssureInit()
        {
            if (!_initTask.IsCompleted)
            {
                await _initTask;
            }
        }

        public async Task<TransferInfo> AddTransfer(DownloadDefinition request)
        {
            await AssureInit();
            StorageFolder destinationFolder;
            switch (request.Storage)
            {
                case StorageType.AudioLibrary:
                    destinationFolder = KnownFolders.MusicLibrary;
                    break;
                default:
                    destinationFolder = KnownFolders.VideosLibrary;
                    break;
            }
            
            var destinationFile = await destinationFolder.CreateFileAsync(request.Filename, CreationCollisionOption.GenerateUniqueName);
         
            var downloader = new BackgroundDownloader();
            if (!string.IsNullOrEmpty(request.Username) && !string.IsNullOrEmpty(request.Password))
            {
                downloader.ServerCredential = new PasswordCredential(request.Source.ToString(), request.Username,
                                                                     request.Password);
            }
            var download = downloader.CreateDownload(request.Source, destinationFile);
            var progress = new DownloadProgress(download);
            download.StartAsync().AsTask(progress);
            _activeDownloads.Add(download.Guid, progress);
            return progress.TransferInfo;
        }

        public async Task<TransferInfo> GetTransfer(string transferId)
        {
            await AssureInit();
            var transferGuid = new Guid(transferId);
            DownloadProgress download;
            if (_activeDownloads.TryGetValue(transferGuid, out download))
            {
                return download.TransferInfo;
            }
            return new TransferInfo() { TransferId=transferId , Status = TransferStatus.Error};
        }

        public void StopTransfer(string transferId)
        {
            var transferGuid = new Guid(transferId);
            DownloadProgress download;
            if (_activeDownloads.TryGetValue(transferGuid, out download))
            {
                download.Abort();
            }
        }
    }
}