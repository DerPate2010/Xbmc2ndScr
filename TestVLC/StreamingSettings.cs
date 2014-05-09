

namespace StreamingClient.StreamManagment
{
    public class StreamingSettings
    {
        public PresetTypes PresetType { get;  set; }
        public string Host { get; set; }
        /// <summary>
        /// default is 8080
        /// </summary>
        public int ControlPort { get; set; }

        /// <summary>
        /// only h264 is supported at the moment
        /// </summary>
        public string VCodec { get; set; }
        /// <summary>
        /// in kbits/sec, recommend is 512
        /// </summary>
        public int VBitrate { get; set; }
        /// <summary>
        /// recommend is 25 or 30 depending on source
        /// </summary>
        public double VFps { get; set; }
        /// <summary>
        /// recommend is 400
        /// </summary>
        public int VWidth { get; set; }
        /// <summary>
        /// recommend is 240
        /// </summary>
        public int VHeight { get; set; }
        /// <summary>
        /// only mp3 is supported at the moment
        /// </summary>
        public string ACodec { get; set; }
        /// <summary>
        /// in kbit/sec, recommend is 96
        /// </summary>
        public int ABitrate { get; set; }
        /// <summary>
        /// usually 2
        /// </summary>
        public int AChannels { get; set; }
        /// <summary>
        /// recommend is 48000
        /// </summary>
        public int ASampleRate { get; set; }

        public int StreamPort { get; set; }

        public bool ShowSubtitle { get; set; }

        public void PresetMedium()
        {
            PresetType = PresetTypes.Medium;
            ApplyPreset(400,240,512,96);
        }

        private void ApplyPreset(int width, int height, int vBitrate, int aBitrate, int aChannels=2)
        {
            VCodec = "h264";
            ACodec = "mp3";
            VFps = 25;

            VBitrate = vBitrate;
            VWidth = width;
            VHeight = height;
            ABitrate = aBitrate;
            AChannels = aChannels;
            ASampleRate = 48000;
        }

        public void PresetHigh()
        {
            PresetType = PresetTypes.High;
            ApplyPreset(800, 480, 1024, 128);
        }

        public void PresetLow()
        {
            PresetType = PresetTypes.Low;
            ApplyPreset(320, 160, 256, 64, 1);
        }

        public StreamingSettings()
        {
            Host = "";
            ControlPort = 8080;
            StreamPort = 8080;
            PresetLow();
        }
    }
}