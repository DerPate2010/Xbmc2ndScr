namespace Xbmc2S.Model.Download
{
    public enum TransferStatus
    {
        Idle,
        Running,
        PausedByApplication,
        PausedCostedNetwork,
        PausedNoNetwork,
        Completed,
        Canceled,
        Error,
    }
}