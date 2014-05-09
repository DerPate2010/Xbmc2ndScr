using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Xbmc2S.RT.UPnP
{
    public class DiscoveryRaw : DiscoveryBase
    {
        
        
        private const string URN_MediaRenderer = "urn:schemas-upnp-org:device:MediaRenderer:1";



        private const string URN_MediaServer = "urn:schemas-upnp-org:device:MediaServer:1";
        
        
       
        protected static readonly string vbCrLf = Environment.NewLine;
        IProgress<string> progress = new NullProgress();

        public async override Task<MediaRendererDevice[]> GetMediaRenderer()
        {
            return await Platform.Current.GetMediaRenderer();


            var locations = await GetDeviceLocations(URN_MediaRenderer);

            var devices = new List<MediaRendererDevice>();
            foreach (var location in locations)
            {
                MediaRendererDevice device = new MediaRendererDevice();

                try
                {
                    await device.Init(location.Item1, location.Item2, progress);
                    devices.Add(device);
                }
                catch (Exception)
                {
                }
            }
            return devices.ToArray();
        }   
        
        public async Task<MediaServerDevice[]> GetMediaServer()
        {
            return await Platform.Current.GetMediaServer();


            var locations = await GetDeviceLocations(URN_MediaServer);

            var devices = new List<MediaServerDevice>();
            foreach (var location in locations)
            {
                MediaServerDevice device = new MediaServerDevice();

                try
                {
                    await device.Init(location.Item1, location.Item2, progress);
                    devices.Add(device);
                }
                catch (Exception)
                {
                }
            }
            return devices.ToArray();
        }

        private Task<HashSet<Tuple<Uri, Uri>>> GetDeviceLocations(string schema)
        {
            return Platform.Current.GetDeviceLocations(schema, CreateSsdpRequest, ParseSsdpResponse);
        }

        private byte[] CreateSsdpRequest(string authority, string schema)
        {
            var request = "M-SEARCH * HTTP/1.1" + vbCrLf +
                          "HOST: " + authority + vbCrLf +
                          "ST:" + schema + vbCrLf +
                          "MAN: \"ssdp:discover\"" + vbCrLf +
                          "MX: 1" + vbCrLf + "" + vbCrLf;
            return Encoding.UTF8.GetBytes(request);
        }
        
        private Uri ParseSsdpResponse(byte[] responsebuf, int len)
        {
            var response = Encoding.UTF8.GetString(responsebuf, 0, len);

            return (from line in response.Split(new[] { '\r', '\n' })
                    where line.ToLowerInvariant().StartsWith("location:")
                    select new Uri(line.Substring(9).Trim())).FirstOrDefault();
        }





    }
}