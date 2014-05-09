using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xbmc2S.RT.UPnP
{
    public class DiscoveryWin8 : DiscoveryBase
    {
        public override async Task<MediaRendererDevice[]> GetMediaRenderer()
        {


            var results = new List<MediaRendererDevice>();
            //
            // Notionally we should search for all devices that are urn:schemas-upnp-org:device:MediaRenderer:1
            // But the device-enumeration API doesn//t support a search by device-type.
            // Instead, rely on the fact that all MediaRenderers have ConnectionManager, RenderingControl and (optionally) AVTransport

            // Obtained by looking in Windows SDK headers for PKEYs, and figuring out by experiment that this refers to the control Url:
            var PKEY_PNPX_ServiceControlUrl = "{656A3BB3-ECC0-43FD-8477-4AE0404A96CD},16388";

            // Obtained by experimenting with three different MediaRenderers, and verifying that they all used these interfaces (service-types):
            // DeviceInterface::System.Devices.InterfaceClassGuid is a reliable way of finding servicetypes.
            // DeviceInterface::System.Devices.ServiceId is unreliable.
            var RenderingControlInterfaceClass = new Guid("8660e926-ff3d-580c-959e-8b8af44d7cde");
            var ConnectionManagerInterfaceClass = new Guid("ae9eb9c4-8819-51d8-879d-9a42ffb89d4e");
            var AVTransportInterfaceClass = new Guid("4c38e836-6a2f-5949-9406-1788ea20d1d5");


            var RenderingControls = await Windows.Devices.Enumeration.Pnp.PnpObject.FindAllAsync(
                Windows.Devices.Enumeration.Pnp.PnpObjectType.DeviceInterface, new List<string>()
                    {
                        "System.Devices.DeviceInstanceId",
                        "System.Devices.InterfaceClassGuid",
                        "System.Devices.ContainerId"
                    },
                "System.Devices.InterfaceClassGuid:=\"{" + RenderingControlInterfaceClass.ToString() + "}\"");
            foreach (var device in RenderingControls)
            {


                if (!device.Properties.ContainsKey("System.Devices.DeviceInstanceId")) continue;
                if (!device.Properties.ContainsKey("System.Devices.ContainerId")) continue;
                var id = (string)device.Properties["System.Devices.DeviceInstanceId"];
                var containerId = (Guid)device.Properties["System.Devices.ContainerId"];

                var ConnectionManagerInterface = (await Windows.Devices.Enumeration.Pnp.PnpObject.FindAllAsync(
                    Windows.Devices.Enumeration.Pnp.PnpObjectType.DeviceInterface, new List<string>()
                        {
                            "System.Devices.DeviceInstanceId",
                            "System.Devices.InterfaceClassGuid",
                            PKEY_PNPX_ServiceControlUrl
                        },
                    "System.Devices.DeviceInstanceId:=\"" + id + "\" AND System.Devices.InterfaceClassGuid:=\"{" +
                    ConnectionManagerInterfaceClass.ToString() + "}\"")).FirstOrDefault();
                if (ConnectionManagerInterface == null) continue;
                if (!ConnectionManagerInterface.Properties.ContainsKey(PKEY_PNPX_ServiceControlUrl)) continue;
                var connectionManagerUrl =
                    new Uri((string)ConnectionManagerInterface.Properties[PKEY_PNPX_ServiceControlUrl]);
                //
                var AVTransportInterface = (await Windows.Devices.Enumeration.Pnp.PnpObject.FindAllAsync(
                    Windows.Devices.Enumeration.Pnp.PnpObjectType.DeviceInterface, new List<string>()
                        {
                            "System.Devices.DeviceInstanceId",
                            "System.Devices.InterfaceClassGuid",
                            PKEY_PNPX_ServiceControlUrl
                        },
                    "System.Devices.DeviceInstanceId:=\"" + id + "\" AND System.Devices.InterfaceClassGuid:=\"{" +
                    AVTransportInterfaceClass.ToString() + "}\"")).FirstOrDefault();
                if (AVTransportInterface != null &&
                    !AVTransportInterface.Properties.ContainsKey(PKEY_PNPX_ServiceControlUrl))
                    AVTransportInterface = null;
                var avTransportUrl = AVTransportInterface == null
                                         ? null
                                         : new Uri((string)AVTransportInterface.Properties[PKEY_PNPX_ServiceControlUrl]);
                //
                var Container = await Windows.Devices.Enumeration.Pnp.PnpObject.CreateFromIdAsync(
                    Windows.Devices.Enumeration.Pnp.PnpObjectType.DeviceContainer,
                    containerId.ToString(), new List<string>() { "System.Devices.Connected", "System.Devices.FriendlyName" });
                if (Container == null) continue;
                if (!Container.Properties.ContainsKey("System.Devices.Connected")) continue;
                if (!Container.Properties.ContainsKey("System.Devices.FriendlyName")) continue;
                var connected = (bool)Container.Properties["System.Devices.Connected"];
                var friendlyName = (string)Container.Properties["System.Devices.FriendlyName"];


                //if (!connected) continue;

                results.Add(new MediaRendererDevice()
                    {
                        FriendlyName = friendlyName,
                        ConnectionManagerControlUrl = connectionManagerUrl,
                        AVTransportControlUrl = avTransportUrl,
                        //LocalUri = localUri
                    });

            }

            return results.ToArray();
        }
    }
}