using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StreamingClient.StreamManagment;
using TmdbWrapper;

namespace TestVLC
{
    public class Requester: IRequester
    {
        public async Task<string> Get(string uri)
        {
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.Accept = "application/json";
            var response = await request.GetResponseAsync();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            return json;
        }
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TheMovieDb.Initialise("0b8dcfc0cf26d3393d2794f2f564319f", "de", new Requester());
            var result=await TheMovieDb.SearchMovieAsync("Harry Potter");
            
            return;
            var settings = new StreamingSettings();
            settings.Host = "homeserver";
            settings.ControlPort = settings.StreamPort = 8080;
            settings.PresetMedium();
            var vlc = new VlcAccess(settings);
            var job = new VlmJob(vlc);
            await job.Transcode("file:///C:/testvideo.avi", @"C:\Users\Steve\Desktop\test.mp4");
        }
    }

    public class VlmJob
    {
        private readonly VlcAccess _vlc;
        public string Name { get; set; }
        public VlmStatus Status { get; set; }
        public byte Progress { get; set; }

        public VlmJob(VlcAccess vlc)
        {
            _vlc = vlc;
            Name = Guid.NewGuid().ToString("N");
        }

        public async Task UpdateState()
        {
            Status = await _vlc.GetStatus(Name);
            var pos = await _vlc.GetPosition(Name);
            Progress = (byte) (pos*100);
        }

        public Task Transcode(string source, string destination)
        {
            return _vlc.Transcode(Name, source, destination);
        }

        public Task Play()
        {
            return _vlc.PlayStream(Name);
        }

        public Task Pause()
        {
            return _vlc.PauseStream(Name);
        }

        public Task Abort()
        {
            return _vlc.StopStreaming(Name);
        }
    }
}
