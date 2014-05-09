using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Networking;
using Windows.Networking.Sockets;

namespace Xbmc2S.RT.UPnP
{
    public class Util:Platform
    {
        static readonly string vbCrLf = Environment.NewLine;
        private const string Soap = "{http://schemas.xmlsoap.org/soap/envelope/}";
        private readonly NullProgress _progress = new NullProgress();

        public override async Task<XElement> GetSoapAsync(Tuple<Uri, string> request)
        {
            MyTuple t = (MyTuple) request;
            XName soapResponse = "{" + t.soapSchema + "}" + t.soapVerb + "Response"; // e.g. {schema}actionResponse

            XDocument xml = await GetXmlAsync(request);
            var body =
                xml.Element(Soap+"Envelope")
                   .Element(Soap+"Body")
                   .Elements(soapResponse)
                   .FirstOrDefault();
            if (body == null) throw new HttpRequestException("no soap body");
            return body;
        }

        public override async Task<XDocument> GetXmlAsync(Uri requestUri)
        {
            HttpClient httpClient= new HttpClient();
            var response=await httpClient.GetAsync(requestUri);
            var buf = await response.Content.ReadAsByteArrayAsync();
            var body = Encoding.UTF8.GetString(buf, 0, buf.Length);
            if (_progress!=null) _progress.Report(String.Join(vbCrLf + "        ", (vbCrLf + "<--------" + vbCrLf  + vbCrLf + body).Split(new []{vbCrLf}, StringSplitOptions.None)));


            return XDocument.Parse(body);
        }

        public override async Task<XDocument> GetXmlAsync(Tuple<Uri, string> request)
        {
            var requestUri = request.Item1;
            var requestBody = request.Item2;
            if (_progress != null)
                _progress.Report("---------> " + requestUri.DnsSafeHost + ":" + requestUri.Port + vbCrLf +
                                request);

            HttpClient httpClient= new HttpClient();
            var soapVerb = ((MyTuple)request).soapVerb;
            var soapSchema = ((MyTuple)request).soapSchema;

            httpClient.DefaultRequestHeaders.Add("SOAPAction", "\"" + soapSchema + "#" + soapVerb + "\"");
            var content = new StringContent(requestBody);
            
            content.Headers.ContentType = new MediaTypeHeaderValue("text/xml") { CharSet = "utf-8" }; 
            var response=await httpClient.PostAsync(requestUri, content);
            var buf = await response.Content.ReadAsByteArrayAsync();
            var body = Encoding.UTF8.GetString(buf, 0, buf.Length);

            if (_progress!=null) _progress.Report(String.Join(vbCrLf + "        ", (vbCrLf + "<--------" + vbCrLf  + vbCrLf + body).Split(new []{vbCrLf}, StringSplitOptions.None)));

            return XDocument.Parse(body);
        }

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
            var ContentDirectoryInterfaceClass = new Guid("575d078a-63b9-5bc0-958b-87cc35b279cc");


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
                    "System.Devices.DeviceInstanceId:=\"" + id + "\" AND System.Devices.InterfaceClassGuid:=\"{" + ConnectionManagerInterfaceClass.ToString() + "}\"")).FirstOrDefault();

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

                if (connected)
                {

                    var rend = new MediaRendererDevice()
                    {
                        FriendlyName = friendlyName,
                        ConnectionManagerControlUrl = connectionManagerUrl,
                        AVTransportControlUrl = avTransportUrl,
                        //LocalUri = localUri
                    };

                    results.Add(rend);
                }
            }

            return results.ToArray();
        }


        public override async Task<MediaServerDevice[]> GetMediaServer()
        {


            var results = new List<MediaServerDevice>();
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
            var ContentDirectoryInterfaceClass = new Guid("575d078a-63b9-5bc0-958b-87cc35b279cc");


            var RenderingControls = await Windows.Devices.Enumeration.Pnp.PnpObject.FindAllAsync(
                Windows.Devices.Enumeration.Pnp.PnpObjectType.DeviceInterface, new List<string>()
                    {
                        "System.Devices.DeviceInstanceId",
                        "System.Devices.InterfaceClassGuid",
                        "System.Devices.ContainerId"
                    },
                "System.Devices.InterfaceClassGuid:=\"{" + ContentDirectoryInterfaceClass.ToString() + "}\"");
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
                    "System.Devices.DeviceInstanceId:=\"" + id + "\" AND System.Devices.InterfaceClassGuid:=\"{" + ConnectionManagerInterfaceClass.ToString() + "}\"")).FirstOrDefault();

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
                    ContentDirectoryInterfaceClass.ToString() + "}\"")).FirstOrDefault();
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

                if (connected)
                {
                    results.Add(new MediaServerDevice()
                    {

                        FriendlyName = friendlyName,
                        ConnectionManagerControlUrl = connectionManagerUrl,
                        ContentDirectoryControlUri = avTransportUrl,
                    });
                }
            }

            return results.ToArray();
        }


        //This code will work on win phone too
        public override async Task<HashSet<Tuple<Uri, Uri>>> GetDeviceLocations(string schema, Func<string, string, byte[]> createSsdpRequest, Func<byte[], int, Uri> parseSsdpResponse)
        {
            

            var remoteIp = new HostName("239.255.255.250");
            var remotePort = "1900"; // standard multicast address+port for SSDP
            var reqbuf =
                WindowsRuntimeBufferExtensions.AsBuffer(
                    createSsdpRequest(remoteIp.RawName + ":" + remotePort, schema));
            var locations = new HashSet<Tuple<Uri, Uri>>();
            using (var socket = new DatagramSocket())
            {
                socket.MessageReceived += (sender, e) =>
                    {
                        if (e.LocalAddress.IPInformation.NetworkAdapter.IanaInterfaceType == 24) return; // loopback
                        // any loopback renderer will also report itself on the actual network, and I don't want to show duplicates
                        using (var reader = e.GetDataReader())
                        {
                            var responsebuf = new Byte[reader.UnconsumedBufferLength - 1];
                            reader.ReadBytes(responsebuf);
                            if (_progress != null)
                                _progress.Report("Received from " + e.RemoteAddress.DisplayName + ":" + e.RemotePort +
                                                vbCrLf + Encoding.UTF8.GetString(responsebuf, 0, responsebuf.Length));
                            var location = parseSsdpResponse(responsebuf, responsebuf.Length);
                            if (location != null)
                                locations.Add(Tuple.Create(location, new Uri("http://" + e.LocalAddress.CanonicalName)));
                        }
                    };

                // CAPABILITY: PrivateNetworks
                await socket.BindEndpointAsync(null, "");
                socket.Control.OutboundUnicastHopLimit = 1;
                socket.JoinMulticastGroup(remoteIp); // Alas there's no WinRT equivalent of ReuseAddress

                using (var stream = await socket.GetOutputStreamAsync(new HostName("239.255.255.250"), remotePort))
                {
                    await stream.WriteAsync(reqbuf);
                    await Task.Delay(20);
                    await stream.WriteAsync(reqbuf);
                    await Task.Delay(20);
                    await stream.WriteAsync(reqbuf);
                }


                await Task.Delay(1200);
            }
            return locations;
        }
    }
}