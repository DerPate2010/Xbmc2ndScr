using System;
using System.Runtime.Serialization;

namespace Xbmc2S.Model
{
    public class XbmcServer
    {
        public string FriendlyName { get; set; }
        public Uri ContentDirectoryControlUri { get; set; }
        public int WebInterfacePort { get; set; }
        public int VlcPort { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string VlcPassword { get; set; }
        public bool VlcUseQsv { get; set; }

        public XbmcServer(string friendlyName, Uri contentDirectoryControlUri)
        {
            FriendlyName = friendlyName;
            ContentDirectoryControlUri = contentDirectoryControlUri;
        }

        public XbmcServer()
        {
        }

        [IgnoreDataMember]
        public bool IsCurrent { get; set; }

        public void CheckWebIf()
        {
            Host = ContentDirectoryControlUri.DnsSafeHost;
            Host = FriendlyName.Replace("XBMC (", "").Replace(")","");
            VlcPort = 8080;
            WebInterfacePort = 80;
            User = "xbmc";
            VlcPassword = "vlc";
        }
    }
}