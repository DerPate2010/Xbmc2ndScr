using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xbmc2S.RT.UPnP
{
    public class AVTransport:UPnPService
    {
        private readonly MediaRendererDevice _mediaRendererDevice;
        private readonly NullProgress _progress;

        public AVTransport(MediaRendererDevice mediaRendererDevice)
        {
            _mediaRendererDevice = mediaRendererDevice;
            _progress = new NullProgress();
        }

        private const string URN_AVTransport = "{urn:schemas-upnp-org:service:AVTransport:1}";

        public async Task SetAVTransportURI(string uri, string metadata)
        {
            
            var dataLocation = new Uri(uri);

            var seturi_request = MakeRawSoapRequest(_mediaRendererDevice.AVTransportControlUrl, new XElement(URN_AVTransport + "SetAVTransportURI"),
                                                    new[]
                                                        {
                                                            "InstanceID", "0", "CurrentURI", dataLocation.ToString(),
                                                            "CurrentURIMetaData", metadata
                                                        });
            var seturi_response = await GetSoapAsync(seturi_request);
        }



        public async Task<string[]> GetMimeTypes()
        {

            var getprotocol_request = MakeRawSoapRequest(_mediaRendererDevice.ConnectionManagerControlUrl,
                                                         new XElement(XName.Get("GetProtocolInfo",
                                                                                "urn:schemas-upnp-org:service:ConnectionManager:1")),
                                                         new string[0]);
            var getprotocol_response = await GetSoapAsync(getprotocol_request);
            var getprotocol_sinks = getprotocol_response.Element("Sink")
                                                        .Value.Split(new char[] {','},
                                                                     StringSplitOptions.RemoveEmptyEntries);
            return getprotocol_sinks.Select(p => p.Split(':')[2]).ToArray();
        }

        public async Task Stop()
        {

            try
            {
                var stop_request = MakeRawSoapRequest(_mediaRendererDevice.AVTransportControlUrl, new XElement(URN_AVTransport + "Stop"),
                                                      new[] {"InstanceID", "0"});
                var stop_response = await GetSoapAsync(stop_request);

            }
            catch (Exception)
            //catch (HttpRequestException)
            {
                //Some devices give an http error code if you ask them to stop when they're already stopped
            }

        }

        public async Task Play()
        {
            var play_request = MakeRawSoapRequest(_mediaRendererDevice.AVTransportControlUrl,
                                                  new XElement(URN_AVTransport + "Play"),
                                                  new[] {"InstanceID", "0", "Speed", "1"});
            var play_response = await GetSoapAsync(play_request);
        }

        public async Task<CurrentUpnpPlayback> GetCurrentPlaybackItem()
        {
            var current = new CurrentUpnpPlayback(_mediaRendererDevice);

                var transp_request = MakeRawSoapRequest(_mediaRendererDevice.AVTransportControlUrl, new XElement(URN_AVTransport + "GetTransportInfo"),
                                                        new[] { "InstanceID", "0" });
                var transp_response = await GetSoapAsync(transp_request);
                current.TranspState = transp_response.Element("CurrentTransportState").Value;
                current.TranspStatus = transp_response.Element("CurrentTransportStatus").Value;

            //if (current.transp_state == "STOPPED" && warmupDelay.IsCompleted)
  
            var pos_request = MakeRawSoapRequest(_mediaRendererDevice.AVTransportControlUrl, new XElement(URN_AVTransport + "GetPositionInfo"),
                                     new[] { "InstanceID", "0" });
            var pos_response = await GetSoapAsync(pos_request);
            current.PosTrack = pos_response.Element("Track").Value;
            current.PosTrackuri = pos_response.Element("TrackURI").Value;
            current.PosDuration = pos_response.Element("TrackDuration").Value;
            current.PosReltime = pos_response.Element("RelTime").Value;
            current.PosRelcount = pos_response.Element("RelCount").Value;
            return current;
        }


        public async Task Pause()
        {
            var pauseRequest = MakeRawSoapRequest(_mediaRendererDevice.AVTransportControlUrl,
                                                  new XElement(URN_AVTransport + "Pause"),
                                                  new[] { "InstanceID", "0" });
            var pause_response = await GetSoapAsync(pauseRequest);
        }
        public async Task Next()
        {
            var request = MakeRawSoapRequest(_mediaRendererDevice.AVTransportControlUrl,
                                                  new XElement(URN_AVTransport + "Next"),
                                                  new[] { "InstanceID", "0" });
            var response = await GetSoapAsync(request);
        }
        public async Task Seek(TimeSpan time)
        {
            var request = MakeRawSoapRequest(_mediaRendererDevice.AVTransportControlUrl,
                                                  new XElement(URN_AVTransport + "Seek"),
                                                  new[] { "InstanceID", "0", "Unit", "REL_TIME", "Target", time.ToString("c"), }
                                                  );
            var response = await GetSoapAsync(request);
        }
        public async Task Previous()
        {
            var request = MakeRawSoapRequest(_mediaRendererDevice.AVTransportControlUrl,
                                                  new XElement(URN_AVTransport + "Previous"),
                                                  new[] { "InstanceID", "0" });
            var response = await GetSoapAsync(request);
        }
    }

    public class CurrentUpnpPlayback
    {
        public MediaRendererDevice MediaRendererDevice { get; set; }

        public CurrentUpnpPlayback(MediaRendererDevice mediaRendererDevice)
        {
            MediaRendererDevice = mediaRendererDevice;
        }

        public string TranspState { get; set; }

        public string TranspStatus { get; set; }

        public string PosTrack { get; set; }

        public string PosTrackuri { get; set; }

        public string PosDuration { get; set; }

        public string PosReltime { get; set; }

        public string PosRelcount { get; set; }
    }
}