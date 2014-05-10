

using System.Runtime.Serialization;

namespace StreamingClient.StreamManagment
{
    [DataContract]
    public class StreamingSettings
    {
        private string _host;

        [DataMember]
        public bool UseQSV { get; set; }

        [DataMember]
        public PresetTypes PresetType { get; set; }

        [DataMember]
        public string Host
        {
            get { return _host; }
            set { _host = value;
            if (value != null && TempUrl!=null)
                {
                    TempUrl = TempUrl.Replace("http://HOSTNAME/", "http://" + value + "/");
                }
            }
        }

        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// only h264 is supported at the moment
        /// </summary>
        [DataMember]
        public string VCodec { get; set; }
        /// <summary>
        /// in kbits/sec, recommend is 512
        /// </summary>
        [DataMember]
        public int VBitrate { get; set; }
        /// <summary>
        /// recommend is 25 or 30 depending on source
        /// </summary>
        [DataMember]
        public double VFps { get; set; }
        /// <summary>
        /// recommend is 400
        /// </summary>
        [DataMember]
        public int VWidth { get; set; }
        /// <summary>
        /// recommend is 240
        /// </summary>
        [DataMember]
        public int VHeight { get; set; }

        /// <summary>
        /// only aac, mp3 is supported at the moment
        /// </summary>
        [DataMember]
        public string ACodec { get; set; }

        /// <summary>
        /// in kbit/sec, recommend is 96
        /// </summary>
        [DataMember]
        public int ABitrate { get; set; }
        /// <summary>
        /// usually 2
        /// </summary>
        [DataMember]
        public int AChannels { get; set; }
        /// <summary>
        /// recommend is 48000
        /// </summary>
        [DataMember]
        public int ASampleRate { get; set; }

        [DataMember]
        public int StreamPort { get; set; }

        [DataMember]
        public bool ShowSubtitle { get; set; }

        [DataMember]
        public int ATrack { get; set; }

        [DataMember]
        public string TempPath { get; set; }
        [DataMember]
        public string TempUrl { get; set; }

        public void PresetMedium()
        {
            PresetType = PresetTypes.Medium;
            ApplyPreset(400,0,512,96);
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
            ApplyPreset(800, 0, 1024, 128);
        }

        public void PresetHD()
        {
            PresetType = PresetTypes.HD;
            ApplyPreset(1280, 0, 4096, 128);
        }

        public void PresetLow()
        {
            PresetType = PresetTypes.Low;
            ApplyPreset(320, 0, 256, 64, 1);
        }

        public StreamingSettings()
        {
            Host = "";

            TempPath = "C:\\vlctemp";
            TempUrl = "http://HOSTNAME/vlctemp/";
            StreamPort = 8080;
            PresetLow();
        }
    }
}