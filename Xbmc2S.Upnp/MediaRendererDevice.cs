using System;
using System.Threading.Tasks;

namespace Xbmc2S.RT.UPnP
{
    public class MediaRendererDevice : UPnPDevice
    {
        private const string URN_RenderingControl = "urn:schemas-upnp-org:service:RenderingControl:1";
        private const string URN_AVTransport = "urn:schemas-upnp-org:service:AVTransport:1";

        public Uri AVTransportControlUrl;
        public AVTransport AVTransport { get; private set; }

        public MediaRendererDevice()
        {
            AVTransport = new AVTransport(this);
        }

        public async Task Init(Uri deviceLocation, Uri localUri, IProgress<string> progress)
        {
            var desc_services = await DoSsdpDiscoveryDialogAsync(deviceLocation, localUri, progress);
            //RenderingControlUrl = GetServiceUri(deviceLocation, desc_services, URN_RenderingControl);
            AVTransportControlUrl = GetServiceUri(deviceLocation, desc_services, URN_AVTransport);
            
        }

        public override string ToString()
        {
            return String.Format("{1} - {2}{0}    ConnectionManager:{3}{0}    AVTransport:{4}", Environment.NewLine, FriendlyName,
                                 LocalUri, ConnectionManagerControlUrl, AVTransportControlUrl);
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public override bool Equals(object obj)
        {
            var Him = obj as MediaRendererDevice;
            if (Him == null) return false;
            return this.FriendlyName.Equals(Him.FriendlyName) &&
                   this.AVTransportControlUrl.PathAndQuery.Equals(Him.AVTransportControlUrl.PathAndQuery) &&
                   this.ConnectionManagerControlUrl.PathAndQuery.Equals(Him.ConnectionManagerControlUrl.PathAndQuery);
            // We don't compare on hostnames. That's because a device that we know through IPv6 and IPv4 will have
            // different hostnames but will still the the same device.
            // Instead of FriendlyName, we might have compared against SSDP <UDN>uuid:5f9ec1b3-ed59-1900-4530-0007f521ebd6</UDN>
            // which is probably the same as WinRT's PnpObjectType.Device::System.Devices.ContainerId=5f9ec1b3-ed59-1900-4530-0007f521ebd6
            // and hope that this is how WinRT populated that field. But I reckon that FriendlyName is a better bet.
        }
    }
}