using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Xbmc2S.RT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        //private async Task<HashSet<Tuple<Uri, Uri>>> GetDeviceLocations(string schema)
        //{
        //    var remoteIp = new HostName("239.255.255.250");
        //    var remotePort = "1900"; // standard multicast address+port for SSDP
        //    var reqbuf =
        //        WindowsRuntimeBufferExtensions.AsBuffer(
        //            CreateSsdpRequest(remoteIp.RawName + ":" + remotePort, schema));
        //    var locations = new HashSet<Tuple<Uri, Uri>>();
        //    using (var socket = new DatagramSocket())
        //    {
        //        socket.MessageReceived += (sender, e) =>
        //        {
        //            if (e.LocalAddress.IPInformation.NetworkAdapter.IanaInterfaceType == 24) return; // loopback
        //            // any loopback renderer will also report itself on the actual network, and I don't want to show duplicates
        //            using (var reader = e.GetDataReader())
        //            {
        //                var responsebuf = new Byte[reader.UnconsumedBufferLength - 1];
        //                reader.ReadBytes(responsebuf);
        //                if (progress != null)
        //                    progress.Report("Received from " + e.RemoteAddress.DisplayName + ":" + e.RemotePort +
        //                                    vbCrLf + Encoding.UTF8.GetString(responsebuf, 0, responsebuf.Length));
        //                var location = ParseSsdpResponse(responsebuf, responsebuf.Length);
        //                if (location != null)
        //                    locations.Add(Tuple.Create(location, new Uri("http://" + e.LocalAddress.CanonicalName)));
        //            }
        //        };

        //        // CAPABILITY: PrivateNetworks
        //        await socket.BindEndpointAsync(null, "");
        //        socket.Control.OutboundUnicastHopLimit = 1;
        //        socket.JoinMulticastGroup(remoteIp); // Alas there's no WinRT equivalent of ReuseAddress
        //        using (var stream = await socket.GetOutputStreamAsync(remoteIp, remotePort))
        //        {
        //            await stream.WriteAsync(reqbuf);
        //            await Task.Delay(20);
        //            await stream.WriteAsync(reqbuf);
        //            await Task.Delay(20);
        //            await stream.WriteAsync(reqbuf);
        //        }

        //        await Task.Delay(1200);
        //    }
        //    return locations;
        //}

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
    }
}
