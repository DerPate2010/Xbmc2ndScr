using System;

namespace Xbmc2S.Model.Download
{
    public class DownloadDefinition
    {
        public Uri Source { get; set; }
        public StorageType Storage { get; set; }
        public string Filename { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Transcode { get; set; }
        public string Label { get; set; }
        public string Path { get; set; }

        public int AudioTrack { get; set; }

        public int SubtitleTrack { get; set; }
    }
}