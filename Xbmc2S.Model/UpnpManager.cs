using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XBMCRPC;
using Xbmc2S.RT.UPnP;

namespace Xbmc2S.Model
{
    public class UpnpManager:BindableBase, IUpnpManager
    {
        private readonly AppContext _server;
        private MediaServerDevice _xbmcMediaServer;
        private bool _isAvailable;
        private string[] _xbmcHostnames;
        private Task _initTask;

        public UpnpManager(AppContext server)
        {
            PathLookup = new Dictionary<string, string>();
            _server = server;
            AvailableRenderDevices= new MediaRendererDevice[0];
            _initTask=Init();
        }

        public async Task WaitForInit()
        {
            await _initTask;
        }

        public async Task<bool> IsXbmcHost(Uri uriToCheck)
        {
            return await IsSameHost(uriToCheck, _server.Settings.Host);
        }

        public async Task<bool> IsSameHost(Uri uriToCheck, string host)
        {
            if (string.IsNullOrWhiteSpace(uriToCheck.DnsSafeHost) || string.IsNullOrWhiteSpace(host))
            {
                return false;
            }
            if (_xbmcHostnames == null)
            {
                _xbmcHostnames = await _server.PlatformServices.SocketFactory.ResolveHostname(host);
            }
            var serverHostnames = await _server.PlatformServices.SocketFactory.ResolveHostname(uriToCheck.DnsSafeHost);
            return _xbmcHostnames.Any(serverHostnames.Contains);
        }

        private async Task Init()
        {
            var disc = new DiscoveryRaw();
            var server = await disc.GetMediaServer();

            var discoveredXBMCs = new List<XbmcServer>();
            foreach (var device in server)
            {
                if (device.FriendlyName.StartsWith("XBMC ("))
                {
                    var discoveredXBMC = new XbmcServer(device.FriendlyName, device.ContentDirectoryControlUri);
                    discoveredXBMCs.Add(discoveredXBMC);
                    discoveredXBMC.CheckWebIf();
                    
                    if (await IsXbmcHost(device.ContentDirectoryControlUri))
                    {
                        discoveredXBMC.IsCurrent = true;
                        _xbmcMediaServer = device;
                    }
                }

            }
            DiscoveredXBMCs = discoveredXBMCs;

            IsAvailable = _xbmcMediaServer != null;

            if (IsAvailable)
            {
                var renderDevices = await disc.GetMediaRenderer();
                var availableRenderDevices= new List<MediaRendererDevice>();
                foreach (var renderer in renderDevices)
                {
//#if !DEBUG
                    if (!(renderer.FriendlyName.StartsWith("XBMC (") &&
                        await IsXbmcHost(renderer.AVTransportControlUrl)))
//#endif
                    {
                        availableRenderDevices.Add(renderer);
                    }
                }
                AvailableRenderDevices = availableRenderDevices.ToArray();

                //MediaRendererDevice rendererUpnp = null;
                //foreach (var device in AvailableRenderDevices)
                //{
                //    if (device.AVTransportControlUrl == null) continue;
                //    if (device.FriendlyName.StartsWith("WDTV"))
                //    {
                //        rendererUpnp = device;
                //        break;
                //    }
                //}
            }
        }

        public List<XbmcServer> DiscoveredXBMCs { get; set; }

        public Dictionary<string, string> PathLookup { get; private set; }

        public async Task PlayItem(PlayableItemVm playableItem, MediaRendererDevice renderDevice)
        {
            ////var metadata = await xbmcUpnp.ContentDirectory.GetMetadataToId(@"musicdb://2/1/2/2.mp3?albumartistsonly=false&amp;albumid=2&amp;artistid=1");
            //var metadata = await _xbmcMediaServer.ContentDirectory.GetMetadataToId(@"C:\Archiv\Serien1\Californication\Staffel 1\itg-cf-s01e12.avi");
            ////var metadata = await xbmcUpnp.ContentDirectory.GetMetadataToId(@"C:\Archiv\HD1\Air Force One.m2ts");
            //var xMetadata = XElement.Parse(metadata);
            //var uri = xMetadata.Element("{urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/}item").Element("{urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/}res").Value;
            //xMetadata.Element("{urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/}item").Element("{http://purl.org/dc/elements/1.1/}title").SetValue("bla");
            ////uri = "http://www.w3schools.com/html/movie.mp4";
            ////            metadata = "&lt;DIDL-Lite xmlns=\"urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\" xmlns:upnp=\"urn:schemas-upnp-org:metadata-1-0/upnp/\" xmlns:dlna=\"urn:schemas-dlna-org:metadata-1-0/\"&gt;&lt;item id=\"musicdb://2/1/2/2.mp3?albumartistsonly=false&amp;amp;albumid=2&amp;amp;artistid=1\" parentID=\"musicdb://2/1/2/?albumartistsonly=false&amp;amp;artistid=1\" restricted=\"1\"&gt;&lt;dc:title&gt;Sie marschieren wieder&lt;/dc:title&gt;&lt;dc:creator&gt;1. Mai &amp;apos;87&lt;/dc:creator&gt;&lt;upnp:artist&gt;1. Mai &amp;apos;87&lt;/upnp:artist&gt;&lt;upnp:artist role=\"Performer\"&gt;1. Mai &amp;apos;87&lt;/upnp:artist&gt;&lt;upnp:artist role=\"AlbumArtist\"&gt;1. Mai &amp;apos;87&lt;/upnp:artist&gt;&lt;upnp:album&gt;Rip Off&lt;/upnp:album&gt;&lt;upnp:genre&gt;Rock&lt;/upnp:genre&gt;&lt;upnp:albumArtURI dlna:profileID=\"JPEG_TN\"&gt;http://192.168.178.20:1287/%25/221918E6358C9A5FC9C35376AB12213F/15%2520-%25201.%2520Mai%2520%252787%2520-%2520Sie%2520marschieren%2520wieder.mp3&lt;/upnp:albumArtURI&gt;&lt;upnp:originalTrackNumber&gt;10&lt;/upnp:originalTrackNumber&gt;&lt;res protocolInfo=\"http-get:*:audio/mpeg:DLNA.ORG_PN=MP3;DLNA.ORG_OP=01;DLNA.ORG_CI=0;DLNA.ORG_FLAGS=01500000000000000000000000000000\"&gt;http://192.168.178.20:1287/%25/E4A2E930D9559EDFAEDF91745105A70E/15%2520-%25201.%2520Mai%2520%252787%2520-%2520Sie%2520marschieren%2520wieder.mp3&lt;/res&gt;&lt;upnp:class&gt;object.item.audioItem.musicTrack&lt;/upnp:class&gt;&lt;/item&gt;&lt;/DIDL-Lite&gt;";
            ////            metadata = @"<DIDL-Lite xmlns=""urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/"" xmlns:dc=""http://purl.org/dc/elements/1.1/"" xmlns:upnp=""urn:schemas-upnp-org:metadata-1-0/upnp/"" xmlns:dlna=""urn:schemas-dlna-org:metadata-1-0/"">
            ////  <item id=""C:\\Archiv\\HD1\\Air Force One.m2ts"" parentID=""C:\\Archiv\\HD1\\"" restricted=""1"">
            ////    <dc:title>Sie marschieren wieder</dc:title>
            ////    <dc:creator>1. Mai &apos;87</dc:creator>
            ////    <upnp:artist>1. Mai &apos;87</upnp:artist>
            ////    <upnp:artist role=""Performer"">1. Mai &apos;87</upnp:artist>
            ////    <upnp:artist role=""AlbumArtist"">1. Mai &apos;87</upnp:artist>
            ////    <upnp:album>Rip Off</upnp:album>
            ////    <upnp:genre>Rock</upnp:genre>
            ////    <upnp:albumArtURI dlna:profileID=""JPEG_TN"">http://192.168.178.20:1287/%25/221918E6358C9A5FC9C35376AB12213F/15%2520-%25201.%2520Mai%2520%252787%2520-%2520Sie%2520marschieren%2520wieder.mp3</upnp:albumArtURI>
            ////    <upnp:originalTrackNumber>10</upnp:originalTrackNumber>
            ////    <res protocolInfo=""http-get:*:video/m2ts:*"">http://192.168.178.20:1287/%25/B4552443801113DC3FDA9E0BF33529FC/Air%2520Force%2520One.m2ts</res>
            ////    <upnp:class>object.item.videoItem</upnp:class>
            ////  </item>
            ////</DIDL-Lite>";

            var metadata = await _xbmcMediaServer.ContentDirectory.GetMetadataToId(playableItem.Path);
            var xMetadata = XElement.Parse(metadata);
            var uri = xMetadata.Element("{urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/}item").Element("{urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/}res").Value;
            xMetadata.Element("{urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/}item").Element("{http://purl.org/dc/elements/1.1/}title").SetValue(playableItem.Label);
            metadata = xMetadata.ToString(SaveOptions.DisableFormatting);

            PathLookup[uri] = playableItem.Path;

            //await SelectedRenderDevices.AVTransport.GetMimeTypes();
            await renderDevice.AVTransport.Stop();
            await renderDevice.AVTransport.SetAVTransportURI(uri, metadata);
            await renderDevice.AVTransport.Play();
            //var current = await SelectedRenderDevices.AVTransport.GetCurrentPlaybackItem();
        } 
        
        public async Task<string> GetPlaybackUri(PlayableItemVm playableItem)
        {

            var metadata = await _xbmcMediaServer.ContentDirectory.GetMetadataToId(playableItem.Path);
            var xMetadata = XElement.Parse(metadata);
            var uri = xMetadata.Element("{urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/}item").Element("{urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/}res").Value;
            return uri;
        }



        public MediaRendererDevice[] AvailableRenderDevices { get; private set; }

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; OnPropertyChanged();}
        }
    }
}
