namespace Xbmc2S.Model.Download
{
    public enum DownloadStatus
    {
        NotStarted,
        Transcoding,
        Downloading,
        Finished,
        Canceled,
        Error,
        PausedTranscoding,
        PausedNoNetwork,
        PausedCostedNetwork,
        PausedDownload,
    }
}