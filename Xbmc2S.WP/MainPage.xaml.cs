using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Networking;
using Windows.Networking.Sockets;
using Xbmc2S.WP.Resources;

namespace Xbmc2S.WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            Image img= new Image();
            img.Source = new;
            WebRequest w;
        }

        private async Task<HashSet<Tuple<Uri, Uri>>> GetDeviceLocations(string schema)
        {
            var remoteIp = new HostName("239.255.255.250");
            var remotePort = "1900"; // standard multicast address+port for SSDP
            var reqbuf =
                WindowsRuntimeBufferExtensions.AsBuffer(
                    CreateSsdpRequest(remoteIp.RawName + ":" + remotePort, schema));
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
                        if (progress != null)
                            progress.Report("Received from " + e.RemoteAddress.DisplayName + ":" + e.RemotePort +
                                            vbCrLf + Encoding.UTF8.GetString(responsebuf, 0, responsebuf.Length));
                        var location = ParseSsdpResponse(responsebuf, responsebuf.Length);
                        if (location != null)
                            locations.Add(Tuple.Create(location, new Uri("http://" + e.LocalAddress.CanonicalName)));
                    }
                };

                // CAPABILITY: PrivateNetworks
                await socket.BindEndpointAsync(null, "");
                socket.Control.OutboundUnicastHopLimit = 1;
                socket.JoinMulticastGroup(remoteIp); // Alas there's no WinRT equivalent of ReuseAddress
                using (var stream = await socket.GetOutputStreamAsync(remoteIp, remotePort))
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

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}