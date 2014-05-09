using System;
using Windows.Networking.BackgroundTransfer;
using Xbmc2S.Model.Download;

namespace Xbmc2S.RT.PlatformServices
{
    public class DownloadProgress:IProgress<DownloadOperation>
    {
        private readonly DownloadOperation _download;

        public DownloadProgress(DownloadOperation download)
        {
            _download = download;
            TransferInfo = GetTransferInfo(download);
        }

        private TransferInfo GetTransferInfo(DownloadOperation download)
        {
            var transferInfo = new TransferInfo();
            transferInfo.TransferId = download.Guid.ToString();
            FillTransferInfo(download, transferInfo);
            return transferInfo;
        }

        private void FillTransferInfo(DownloadOperation download, TransferInfo transferInfo)
        {
            transferInfo.Status = ToTransferStatus(download.Progress.Status);
            transferInfo.TargetFile = download.ResultFile.Path;
            if (download.Progress.TotalBytesToReceive > 0)
            {
                transferInfo.Progress =
                    (byte)((download.Progress.BytesReceived * 100 / download.Progress.TotalBytesToReceive));
            }
            transferInfo.Size = download.Progress.TotalBytesToReceive;
        }

        public TransferInfo TransferInfo { get; private set; }

        public void Report(DownloadOperation downloadOperation)
        {
            FillTransferInfo(downloadOperation, TransferInfo);
        }

        private TransferStatus ToTransferStatus(BackgroundTransferStatus status)
        {
            return (TransferStatus)Enum.Parse(typeof(TransferStatus), status.ToString());
        }

        public void Abort()
        {
            _download.AttachAsync().Cancel();
        }
    }
}