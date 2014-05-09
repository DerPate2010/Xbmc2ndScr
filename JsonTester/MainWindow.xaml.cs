using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using XBMCRPC;
using XBMCRPC.Application.Property;
using XBMCRPC.Files;
using XBMCRPC.List;
using XBMCRPC.List.Fields;
using XBMCRPC.List.Item;
using XBMCRPC.Methods;
using XBMCRPC.Video.Fields;
using All = XBMCRPC.List.Fields.All;
using Application = XBMCRPC.Methods.Application;
using Files = XBMCRPC.List.Fields.Files;

namespace JsonTester
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

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            var xbmc = new Client(new PlattformServices(),"homeserver.fritz.box", 85, "xbmc", "xbmc");
            xbmc.Playlist.OnClear += Playlist_OnClear;
            //xbmc.StartNotificationListener();

            var p = await xbmc.Application.GetProperties(properties:new Name[]{ new Name(), });
            
            var wellKnownPlayerIdVideo = 1; //or use xbmc.Player.GetActivePlayers()
            var playerPropertiesPercentageOnly = await xbmc.Player.GetProperties(1, new [] {XBMCRPC.Player.Property.Name.percentage});
            var playerPropertiesAll = await xbmc.Player.GetProperties(1,Client.AllValues<XBMCRPC.Player.Property.Name>());
            var ret0 = await xbmc.JSONRPC.Introspect();
            var ret1 = await xbmc.Application.GetProperties(Client.AllValues<Name>());
            var ret2 = await xbmc.VideoLibrary.GetTVShows(TVShow.AllFields());

            var ret3 = await xbmc.VideoLibrary.SetMovieDetails(5801, playcount: 10);
            var ret4 = await xbmc.VideoLibrary.GetMovies(Movie.AllFields(), new Limits() { start = 1, end = 10 });
            var ret4a = await xbmc.Files.PrepareDownload(ret4.movies[0].thumbnail);

            var unlistedFiles = await GetUnlistedFiles(xbmc);

            var ret5 = await xbmc.Files.GetSources();
            var ret5a=await xbmc.Files.GetDirectory(ret5.sources[5].file);
            var ret5b=await xbmc.Files.GetDirectory(ret5a.files[0].file);
            var ret5c=await xbmc.Files.GetDirectory(ret5b.files[0].file, Media.files, Files.AllFields());
            var ret5d = await xbmc.Files.GetDirectory("C:\\Archiv\\Serien1\\How I met your Mother\\Staffel 3", Media.video);
            var ret5e = await xbmc.Files.GetDirectory("C:\\Archiv\\HD2", Media.video, Files.AllFields());
            var ret6 = await xbmc.Files.GetDirectory(@"C:\Users\steve_000\Music\Amazon MP3\die ärzte\auch", Media.music, Files.AllFields());
            var ret7 = await xbmc.Playlist.GetItems(0, properties: All.AllFields());
            var ret7a = await xbmc.Playlist.GetItems(1, properties: All.AllFields());
            var ret8 = await xbmc.Playlist.GetPlaylists();
            var ret9 = await xbmc.Player.GetActivePlayers();

            Sample_GetImageToCurrentPlayingItem(xbmc);
        }

        private async Task<List<string>> GetUnlistedFiles(Client xbmc, Media mediaType= Media.video)
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
            XBMCRPC.Methods.Files.GetDirectoryResponse files;            
            try
            {
                files = await xbmc.Files.GetDirectory(directory, mediaType, new Files(){ FilesItem.mimetype });
            }
            catch (Exception ex)
            {
                return result;
            }

            
            if (files.files != null)
            {
                foreach (var file in files.files)
                {
                    if (file.filetype == filetypeEnum.directory)
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

        void Playlist_OnClear(string sender = null, Playlist.OnCleardataType data = null)
        {

        }

        private async void Sample_GetImageToCurrentPlayingItem(Client xbmc)
        {
            var wellKnownPlayerIdVideo = 1; //or use xbmc.Player.GetActivePlayers()
            var getCurrentItemResponse = await xbmc.Player.GetItem(wellKnownPlayerIdVideo, All.AllFields());
            var currentPlayingVideo = getCurrentItemResponse.item as AllFile;
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

    internal class PlattformServices : IPlattformServices
    {
        public PlattformServices()
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
            return new[] {hostname};
        }
    }

    internal class DummySocket : ISocket
    {
        public void Dispose()
        {
            
        }

        public async Task ConnectAsync(string hostName, int port)
        {
            
        }

        public Stream GetInputStream()
        {
            return new MemoryStream();
        }
    }
}
