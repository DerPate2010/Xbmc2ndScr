namespace XBMCRPC.List.Item
{
    //this file is edited manually at the moment

    public class AllFile : XBMCRPC.List.Item.BaseFile, All
    {
        public string channel { get; set; }
        public int channelnumber { get; set; }
        public XBMCRPC.PVR.Channel.Type channeltype { get; set; }
        public string endtime { get; set; }
        public bool hidden { get; set; }
        public bool locked { get; set; }
        public string starttime { get; set; }
    }
    public class AllMedia : XBMCRPC.List.Item.BaseMedia, All
    {
        public string channel { get; set; }
        public int channelnumber { get; set; }
        public XBMCRPC.PVR.Channel.Type channeltype { get; set; }
        public string endtime { get; set; }
        public bool hidden { get; set; }
        public bool locked { get; set; }
        public string starttime { get; set; }
    }
    public interface All : XBMCRPC.List.Item.Base
    {
        string channel { get; set; }
        int channelnumber { get; set; }
        XBMCRPC.PVR.Channel.Type channeltype { get; set; }
        string endtime { get; set; }
        bool hidden { get; set; }
        bool locked { get; set; }
        string starttime { get; set; }
    }
}
