using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xbmc2S.RT.UPnP
{
    public class ContentDirectory:UPnPService
    {
        private const string URN_ContentDirectory = "{urn:schemas-upnp-org:service:ContentDirectory:1}";


        private readonly MediaServerDevice _mediaServerDevice;

        public ContentDirectory(MediaServerDevice mediaServerDevice)
        {
            _mediaServerDevice = mediaServerDevice;
        }

        public async Task<string> GetMetadataToId(string id)
        {
            var getMetadataRequest = MakeRawSoapRequest(_mediaServerDevice.ContentDirectoryControlUri, new XElement(URN_ContentDirectory + "Browse"),
                                                    new[]
                                                        {
                                                            "ObjectID", id, 
                                                            "BrowseFlag", "BrowseMetadata",
                                                            "Filter", "",
                                                            "StartingIndex", "0",
                                                            "RequestedCount", "1",
                                                            "SortCriteria", "",
                                                        });
            IProgress<string> progress= new NullProgress();
            var getMetadataResponse = await GetSoapAsync(getMetadataRequest);
            var metadata = getMetadataResponse.Element("Result").Value;
            return metadata;
        }
    }
}