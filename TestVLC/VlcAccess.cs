using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Serialization;



namespace StreamingClient.StreamManagment
{

    public class VlcAccess
    {
        const string SubtitleSwitches = ",scodec,soverlay";
        private readonly StreamingSettings _settings;

        public VlcAccess(StreamingSettings settings)
        {
            _settings = settings;
        }

        private bool ServerAvailable()
        {
            return true;
        }
        
        public async Task Transcode(string jobName, string source, string destination)
        {
            await ValidateVLCVersionAsync();

            Uri uri;
            if (!Uri.TryCreate(source, UriKind.RelativeOrAbsolute, out uri))
            {
                throw new Exception("No valid Uri: " + source);
            }
            var cmd = uri.ToString();
            var subtitleSwitches = _settings.ShowSubtitle ? SubtitleSwitches : string.Empty;
            var vlmcmd = string.Format(
                        "new {10} broadcast enabled input \"{11}\" output #transcode{{vcodec={0},vb={1},fps={2},width={3},height={4},venc=x264{{profile=baseline,level=1}},acodec={5},ab={6},channels={7},samplerate={8}{12}}}:file{{dst={13}}}",
                        _settings.VCodec, _settings.VBitrate, _settings.VFps, _settings.VWidth, _settings.VHeight, _settings.ACodec,
                        _settings.ABitrate, _settings.AChannels, _settings.ASampleRate, _settings.ControlPort, jobName, cmd, subtitleSwitches, destination);


            await SendCommandVLM(vlmcmd);
            await PlayStream(jobName);
        }

        private bool _versionChecked;

        private async Task ValidateVLCVersionAsync()
        {
            if (!_versionChecked)
            {
                string text = string.Format("http://{0}:{1}/requests/status.xml", _settings.Host, _settings.ControlPort);
                HttpWebRequest webRequest = WebRequest.CreateHttp(text);
                HttpWebResponse httpWebResponse = (HttpWebResponse)
                    await
                    Task.Factory.FromAsync<WebResponse>(webRequest.BeginGetResponse, webRequest.EndGetResponse, null);

                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream responseStream = httpWebResponse.GetResponseStream())
                    {
                        var status = XDocument.Load(responseStream);
                        var versionTag = status.Descendants("version").FirstOrDefault();
                        if (versionTag != null)
                        {
                            var version = versionTag.Value;
                            if (version.Contains("2.0.4") || version.Contains("2.0.3"))
                            {
                                throw new NotSupportedException(
                                    string.Format(
                                        "You are using VLC version {0}. This version has known issues with file transcoding and will crash during playback. Please use Version 2.0.2 instead.",
                                        version));

                            }
                        }
                    }
                }
                _versionChecked = true;
            }
        }

        public async Task PlayStream(string jobName)
        {
            await SendCommandVLM(string.Format("control {0} play", jobName));
        }
        public async Task PauseStream(string jobName)
        {
            await SendCommandVLM(string.Format("control {0} pause", jobName));
        }

        public async Task StopStreaming(string jobName)
        {
            await SendCommandVLM(string.Format("control {0} stop", jobName));
            await DelStream(jobName);
        }

        private async Task Seek(string jobName, double pos)
        {
            await SendCommandVLM(string.Format("control {0} seek {1}", jobName, pos));
        }

        public async Task<double> GetPosition(string jobName)
        {
            var vlm = await GetVlmQueue();
            var job = vlm.Items.FirstOrDefault(j => j.name == jobName);
            if (job == null)
            {
                return 0;
            }
            var instance = job.instances.FirstOrDefault();
            if (instance == null)
            {
                return 0;
            }
            double pos;
            double.TryParse(instance.position, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out pos);
            return pos;
        }

        public async Task<VlmStatus> GetStatus(string jobName)
        {
            var vlm = await GetVlmQueue();
            var job = vlm.Items.FirstOrDefault(j => j.name == jobName);
            if (job == null)
            {
                return VlmStatus.None;
            }
            var instance = job.instances.FirstOrDefault();
            if (instance == null)
            {
                return VlmStatus.Stopped;
            }
            VlmStatus vlmStatus;
            if (Enum.TryParse(instance.state, true, out vlmStatus))
            {
                return vlmStatus;
            }
            return VlmStatus.Unknown;
        }

        private DateTime _lastUpdate;
        private vlm _vlm;

        private async Task<vlm> GetVlmQueue()
        {
            if ((DateTime.Now - _lastUpdate)< TimeSpan.FromSeconds(2))
            {
                return _vlm;
            }
            _lastUpdate = DateTime.Now;
            var url = string.Format("http://{0}:{1}/requests/vlm.xml", _settings.Host, _settings.ControlPort);
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse response =
                await Task.Factory.FromAsync<WebResponse>(webRequest.BeginGetResponse, webRequest.EndGetResponse, null);

            var stream = response.GetResponseStream();
            var serializer = new XmlSerializer(typeof (vlm));
            _vlm = (vlm) serializer.Deserialize(stream);
            return _vlm;
        }


        private async Task DelStream(string jobName)
        {
            await SendCommandVLM(string.Format("del {0}", jobName));
        }

        private async Task SendCommandVLM(string command)
        {
            if (ServerAvailable())
            {
                command = Uri.EscapeDataString(command);

                string text = string.Format("http://{0}:{1}/requests/vlm_cmd.xml?command={2}", _settings.Host, _settings.ControlPort, command);
                WebRequest webRequest = WebRequest.Create(text);
                WebResponse response =
                    await
                    Task.Factory.FromAsync<WebResponse>(webRequest.BeginGetResponse, webRequest.EndGetResponse, null);
                var stream = response.GetResponseStream();
                var xResponse=XDocument.Load(stream);
                var xError=xResponse.Descendants("error").FirstOrDefault();

                if (xError!=null && !string.IsNullOrEmpty( xError.Value))
                {
                    throw new Exception(xError.Value);
                }
            }
        }

    }

        public enum VlmStatus
        {
            None, Playing, Paused, Stopped, Unknown
        }
}
