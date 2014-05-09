using System;
using System.Collections.Generic;
//using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XBMCRPC;
using XBMCRPC.Application.Property;
using XBMCRPC.Files;
using XBMCRPC.List;
using XBMCRPC.List.Fields;
using XBMCRPC.List.Filter;
using XBMCRPC.List.Filter.Fields;
using XBMCRPC.List.Item;
using XBMCRPC.Methods;
using XBMCRPC.Playlist;
using XBMCRPC.Video.Fields;
using All = XBMCRPC.List.Fields.All;
using Files = XBMCRPC.List.Fields.Files;
using GetProperties_properties = XBMCRPC.Application.GetProperties_properties;


namespace XBMCRPC13.Tryout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            System.Collections.Generic.List<string> s;
            IPlatformServices platformServices = new PlatformServices();
            var xbmc = new Client(platformServices,"localhost", 85);
            var m = await xbmc.VideoLibrary.GetMovies(new XBMCRPC.List.Filter.Rule.Movies() { field = Movies.playcount, Operator = Operators.Is, value = "0" }, Movie.AllFields(), new Limits() { start = 1, end = 10 });
            xbmc.Playlist.OnClear += Playlist_OnClear;

            //await xbmc.StartNotificationListener();

            var p = await xbmc.Application.GetProperties(GetProperties_properties.AllFields());

            var wellKnownPlayerIdVideo = 1; //or use xbmc.Player.GetActivePlayers()
            var playerPropertiesPercentageOnly = await xbmc.Player.GetProperties(1, new XBMCRPC.Player.GetProperties_properties() {XBMCRPC.Player.Property.Name.percentage });
            var playerPropertiesAll = await xbmc.Player.GetProperties(1, XBMCRPC.Player.GetProperties_properties.AllFields());
            var ret0 = await xbmc.JSONRPC.Introspect();
            var ret1 = await xbmc.Application.GetProperties(GetProperties_properties.AllFields());
            var ret2 = await xbmc.VideoLibrary.GetTVShows(TVShow.AllFields());

            var ret3 = await xbmc.VideoLibrary.SetMovieDetails(3, playcount: 10);
            var ret4 = await xbmc.VideoLibrary.GetMovies(Movie.AllFields(), new Limits() { start = 1, end = 10 });
            var ret4a = await xbmc.Files.PrepareDownload(ret4.movies[0].thumbnail);
            var unlistedFiles = await GetUnlistedFiles(xbmc);


            var ret5 = await xbmc.Files.GetSources();
            var ret5a = await xbmc.Files.GetDirectory(ret5.sources[5].file);
            var ret5b = await xbmc.Files.GetDirectory(ret5a.files[0].file);
            var ret5c = await xbmc.Files.GetDirectory(ret5b.files[0].file, Media.files, Files.AllFields());
            var ret5d = await xbmc.Files.GetDirectory("C:\\Archiv\\Serien1\\How I met your Mother\\Staffel 3", Media.video);
            var ret5e = await xbmc.Files.GetDirectory("C:\\Archiv\\HD2", Media.video, Files.AllFields());
            var ret6 = await xbmc.Files.GetDirectory(@"C:\Users\steve_000\Music\Amazon MP3\die ärzte\auch", Media.music, Files.AllFields());
            var ret7 = await xbmc.Playlist.GetItems(0, properties: All.AllFields());
            var ret7a = await xbmc.Playlist.GetItems(1, properties: All.AllFields());
            var ret8 = await xbmc.Playlist.GetPlaylists();
            var ret9 = await xbmc.Player.GetActivePlayers();

            Sample_GetImageToCurrentPlayingItem(xbmc);
        }

        private void Playlist_OnClear(string sender, OnClear_data data)
        {
            
        }

        private async Task<List<string>> GetUnlistedFiles(Client xbmc, Media mediaType = Media.video)
        {
            var result = new List<string>();
            var sources = await xbmc.Files.GetSources(mediaType);
            foreach (var source in sources.sources)
            {
                result.AddRange(await GetUnlistedFiles(xbmc, mediaType, source.file));
            }
            return result;
        }

        private async Task<IEnumerable<string>> GetUnlistedFiles(Client xbmc, Media mediaType, string directory)
        {
            var result = new List<string>();
            GetDirectoryResponse files;
            try
            {
                files = await xbmc.Files.GetDirectory(directory, mediaType, new Files() { FilesItem.mimetype });
            }
            catch (Exception ex)
            {
                return result;
            }


            if (files.files != null)
            {
                foreach (var file in files.files)
                {
                    if (file.filetype == File_filetype.directory)
                    {
                        result.AddRange(await GetUnlistedFiles(xbmc, mediaType, file.file));
                    }
                    else
                    {
                        if (file.id == 0)
                        {
                            result.Add(file.file);
                        }
                    }
                }
            }
            return result;
        }


        private async void Sample_GetImageToCurrentPlayingItem(Client xbmc)
        {
            var wellKnownPlayerIdVideo = 1; //or use xbmc.Player.GetActivePlayers()
            var getCurrentItemResponse = await xbmc.Player.GetItem(wellKnownPlayerIdVideo, All.AllFields());
            var currentPlayingVideo = getCurrentItemResponse.item.AsMediaDetailsBase;
            //use AllMedia for audio player or the shared base class for both: XBMCRPC.Media.Details.Base
            var imageStream = await xbmc.GetImageStream(currentPlayingVideo.thumbnail);
            //display in image control:
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = imageStream;
            bitmapImage.EndInit();
            ThumbImage.Source = bitmapImage;
        }
    }

    internal class PlatformServices : IPlatformServices
    {
        public PlatformServices()
        {
            SocketFactory = new SocketFactory();
        }

        public ISocketFactory SocketFactory { get; private set; }
        public async Task<Stream> GetRequestStream(WebRequest request)
        {
            try
            {
                return await request.GetRequestStreamAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<WebResponse> GetResponse(WebRequest request)
        {
            {
                try
                {
                    return await request.GetResponseAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }

    internal class SocketFactory : ISocketFactory
    {
        public ISocket GetSocket()
        {
            return new DummySocket();
        }

        public async Task<string[]> ResolveHostname(string hostname)
        {
            return new[] { hostname };
        }
    }

    internal class DummySocket : ISocket
    {
        private Socket _s;

        public void Dispose()
        {

        }

        public async Task ConnectAsync(string hostName, int port)
        {
            _s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _s.Connect(hostName, port);
        }

        public Stream GetInputStream()
        {
            return new NetworkStream(_s);
        }
    }
}
