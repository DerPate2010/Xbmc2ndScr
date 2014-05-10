using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using StreamClient.VLM;
using StreamingClient.StreamManagment;

namespace StreamingClient.StreamManagment
{
    public class VlcAccess
    {
        const string SubtitleSwitches = ",scodec,soverlay";
        private const int VlcTimeFactor = 1000000;
        private readonly StreamingSettings _settings;

        public VlcAccess(StreamingSettings settings)
        {
            _settings = settings;
        }

        private bool ServerAvailable()
        {
            return true;
        }

        public async Task Transcode(string jobName, string source, string destination, int aTrack, int sTrack)
        {
            var destinationPipe = string.Format(":file{{dst=\"{0}\"}}", destination);
            await StartStreamingInternal(jobName, source, destinationPipe, aTrack, sTrack);
        }
        private async Task StartStreamingInternal(string jobName, string source, string destination, int aTrack, int sTrack)
        {
            await Task.Factory.StartNew(async () => { await ValidateVLCVersionAsync(); });

            var cmd = await FormatUri(source);
            //var cmd1 = await FormatUri("C:/firecore.log");
            //var cmd2 = await FormatUri("/home/steve/sample_mpeg4.mp4");
            //var cmd3 = await FormatUri("http://techslides.com/demos/sample-videos/small.mp4");


            var venc = _settings.UseQSV ? "qsv" : "x264{{profile=baseline,level=1}}";
            var subtitleSwitches = sTrack >= 0 ? SubtitleSwitches : string.Empty;
            var vlmcmd = string.Format(
                "new {10} broadcast enabled input \"{11}\" output #transcode{{vcodec={0},vb={1},fps={2},width={3},height={4},venc={14},acodec={5},ab={6},channels={7},samplerate={8}{12}}}{13}",
                _settings.VCodec, _settings.VBitrate, _settings.VFps, _settings.VWidth, _settings.VHeight, _settings.ACodec,
                _settings.ABitrate, _settings.AChannels, _settings.ASampleRate, _settings.StreamPort, jobName, cmd,
                subtitleSwitches, destination, venc);


            if (aTrack >= 0)
            {
                vlmcmd += " option audio-track=" + aTrack;
            }
            if (sTrack >= 0)
            {
                vlmcmd += " option sub-track=" + sTrack;
            }


            await SendCommandVLM(vlmcmd);
            await PlayStream(jobName);
        }

        internal async Task<string> FormatUri(string source)
        {
            Uri uri;
            if (!Uri.TryCreate(source, UriKind.RelativeOrAbsolute, out uri))
            {
                throw new Exception("No valid Uri: " + source);
            }

            string cmd;
            if (uri.IsAbsoluteUri && uri.Scheme == "file")
            {
                cmd = uri.LocalPath;
            }
            else
            {
                cmd = uri.ToString();
            }
            return cmd;
        }
        private void SetCredentials(WebRequest webRequest)
        {
            if (!string.IsNullOrEmpty(_settings.Password))
            {
                byte[] credentialBuffer = new UTF8Encoding().GetBytes(":" + _settings.Password);
                webRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
                //webRequest.Credentials = new NetworkCredential(null, _settings.Password);
            }
        }

        private bool _versionChecked;

        public async Task CheckConnection()
        {

            string text = string.Format("http://{0}:{1}/requests/status.xml", _settings.Host, _settings.StreamPort);
            HttpWebRequest webRequest = WebRequest.CreateHttp(text);
            SetCredentials(webRequest);
            HttpWebResponse httpWebResponse = (HttpWebResponse)
                                              await
                                              Task.Factory.FromAsync<WebResponse>(webRequest.BeginGetResponse, webRequest.EndGetResponse, null);
            if (httpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(httpWebResponse.StatusDescription);
            }
        }

        private async Task ValidateVLCVersionAsync()
        {
            if (!_versionChecked)
            {
                string text = string.Format("http://{0}:{1}/requests/status.xml", _settings.Host, _settings.StreamPort);
                HttpWebRequest webRequest = WebRequest.CreateHttp(text);
                SetCredentials(webRequest);
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
                                        "You are using VLC version {0}. This version has known issues with file transcoding and will crash during playback. Please use Version 2.0.5 instead.",
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
            try
            {
                await SendCommandVLM(string.Format("control {0} stop", jobName));
            }
            catch (Exception)
            {
            }

            await DelStream(jobName);
        }

        public async Task Seek(string jobName, double pos)
        {
            await SendCommandVLM(string.Format("control {0} seek {1}", jobName, pos));
        }

        public class JobInfo
        {
            public double Position { get; set; }

            public TimeSpan CurrentTime { get; set; }

            public TimeSpan Duration { get; set; }
        }

        public async Task<JobInfo> GetInfo(string jobName)
        {
            var vlm = await GetVlmQueue();
            if (vlm.Items == null)
            {
                return new JobInfo();
            }
            var job = vlm.Items.FirstOrDefault(j => j.name == jobName);
            if (job == null)
            {
                return new JobInfo();
            }
            var instance = job.instances.FirstOrDefault();
            if (instance == null)
            {
                return new JobInfo();
            }
            var jobInfo = new JobInfo();
            double pos;
            double.TryParse(instance.position, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out pos);
            jobInfo.Position = pos;

            long intVal;
            long.TryParse(instance.time, out intVal);
            jobInfo.CurrentTime = TimeSpan.FromSeconds(intVal/VlcTimeFactor);

            long.TryParse(instance.length, out intVal);
            jobInfo.Duration = TimeSpan.FromSeconds(intVal/VlcTimeFactor);

            return jobInfo;
        }

        public async Task<double> GetPosition(string jobName)
        {
            var vlm = await GetVlmQueue();
            if (vlm.Items == null)
            {
                return 0;
            }
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
            if (vlm.Items==null)
            {
                return VlmStatus.None;
            }
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

            try
            {
                return (VlmStatus) Enum.Parse(typeof (VlmStatus), instance.state, true);
            }
            catch (Exception)
            {
                return VlmStatus.Unknown;
            }
            
        }

        private DateTime _lastUpdate;
        private vlm _vlm;

        private async Task<vlm> GetVlmQueue()
        {
            if ((DateTime.Now - _lastUpdate) < TimeSpan.FromSeconds(2) &&_vlm !=null)
            {
                return _vlm;
            }
            _lastUpdate = DateTime.Now;
            var url = string.Format("http://{0}:{1}/requests/vlm.xml", _settings.Host, _settings.StreamPort);
            WebRequest webRequest = WebRequest.Create(url);
            SetCredentials(webRequest);
            WebResponse response = await Task.Factory.StartNew((() => Task<WebResponse>.Factory.FromAsync(webRequest.BeginGetResponse, webRequest.EndGetResponse, null)), CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var s=sr.ReadToEnd();
            var strr = new StringReader(s);
            var serializer = new XmlSerializer(typeof(vlm));
            _vlm = (vlm)serializer.Deserialize(strr);
            return _vlm;
        }


        private async Task DelStream(string jobName)
        {
            try
            {
                await SendCommandVLM(string.Format("del {0}", jobName));
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("media unknown"))
                {
                    throw;
                }
            }
        }

        private async Task SendCommandVLM(string command)
        {
            if (ServerAvailable())
            {
                command = Uri.EscapeDataString(command);

                string text = string.Format("http://{0}:{1}/requests/vlm_cmd.xml?command={2}", _settings.Host, _settings.StreamPort, command);
                WebRequest webRequest = WebRequest.Create(text);
                SetCredentials(webRequest);
                WebResponse response =
                    await
                    Task.Factory.FromAsync<WebResponse>(webRequest.BeginGetResponse, webRequest.EndGetResponse, null);
                var stream = response.GetResponseStream();
                var xResponse = XDocument.Load(stream);
                var xError = xResponse.Descendants("error").FirstOrDefault();

                if (xError != null&& !string.IsNullOrEmpty(xError.Value))
                {
                    throw new Exception(xError.Value);
                }
            }
        }

    }
}