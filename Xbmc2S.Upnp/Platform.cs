using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xbmc2S.RT.UPnP
{

    public abstract class Platform
    {
        public static Platform Current { get; set; }
        public abstract Task<XElement> GetSoapAsync(Tuple<Uri, string> request);
        public abstract Task<XDocument> GetXmlAsync(Uri requestUri);
        public abstract Task<XDocument> GetXmlAsync(Tuple<Uri, string> request);
        public abstract Task<HashSet<Tuple<Uri, Uri>>> GetDeviceLocations(string schema,  Func<string, string, byte[]> createSsdpRequest, Func<byte[], int, Uri> parseSsdpResponse);

        public abstract Task<MediaRendererDevice[]> GetMediaRenderer();
        public abstract Task<MediaServerDevice[]> GetMediaServer();
    }
}