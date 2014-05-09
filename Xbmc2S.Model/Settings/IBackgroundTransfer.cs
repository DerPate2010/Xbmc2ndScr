using System;
using System.Threading.Tasks;
using Xbmc2S.Model.Download;

namespace Xbmc2S.Model
{
    public interface IBackgroundTransfer
    {
        Task<TransferInfo> AddTransfer(DownloadDefinition request);
        Task<TransferInfo> GetTransfer(string transferId);
        void StopTransfer(string transferId);
    }
}