using System;
using System.Threading.Tasks;

namespace Xbmc2S.RT.UPnP
{
    public class MediaServerDevice:UPnPDevice
    {
        private const string URN_ContentDirectory = "urn:schemas-upnp-org:service:ContentDirectory:1";

        public async Task Init(Uri deviceLocation, Uri localUri, IProgress<string> progress)
        {
            var desc_services = await DoSsdpDiscoveryDialogAsync(deviceLocation, localUri, progress);
            ContentDirectoryControlUri = GetServiceUri(deviceLocation, desc_services, URN_ContentDirectory);
            
        }

        public MediaServerDevice()
        {
            ContentDirectory = new ContentDirectory(this);
        }

        public Uri ContentDirectoryControlUri { get; set; }
        
        public ContentDirectory ContentDirectory { get; private set; }

        public override string ToString()
        {
            return String.Format("{1} - {2}{0}    ConnectionManager:{3}{0}    ContentDirectory:{4}", Environment.NewLine, FriendlyName,
                                 LocalUri, ConnectionManagerControlUrl, ContentDirectoryControlUri);
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public override bool Equals(object obj)
        {
            var Him = obj as MediaServerDevice;
            if (Him == null) return false;
            return this.FriendlyName.Equals(Him.FriendlyName) &&
                   this.ContentDirectoryControlUri.PathAndQuery.Equals(Him.ContentDirectoryControlUri.PathAndQuery) &&
                   this.ConnectionManagerControlUrl.PathAndQuery.Equals(Him.ConnectionManagerControlUrl.PathAndQuery);
            // We don't compare on hostnames. That's because a device that we know through IPv6 and IPv4 will have
            // different hostnames but will still the the same device.
            // Instead of FriendlyName, we might have compared against SSDP <UDN>uuid:5f9ec1b3-ed59-1900-4530-0007f521ebd6</UDN>
            // which is probably the same as WinRT's PnpObjectType.Device::System.Devices.ContainerId=5f9ec1b3-ed59-1900-4530-0007f521ebd6
            // and hope that this is how WinRT populated that field. But I reckon that FriendlyName is a better bet.
        }
    }
}