using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using KODIRPC;
using Xbmc2S.Model;

namespace Xbmc2S.RT.PlatformServices
{

    class ImageRequest
    {
        public string FileName { get; set; }
        public string ImgUri { get; set; }
        private Action<object> Callback { get; set; }

        public ImageRequest(string imgUri, Action<object> callback)
        {
            ImgUri = imgUri;
            Callback = callback;
        }

        public ImageRequest(string imgUri, Action<object> callback, string fileName):this(imgUri,callback)
        {
            FileName = fileName;
        }

        public void InvokeCallback(object img)
        {
            Callback(img);
        }
    }
    class ImageManager : IImageManager
    {



        private readonly Client _xbmc;

        public ImageManager(Client xbmc)
        {
            _xbmc = xbmc;
            _cancellationSource= new CancellationTokenSource();
            Task.Factory.StartNew(()=> Loader(_cancellationSource.Token), _cancellationSource.Token);

        }

        private void Loader(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _requestsAvailable.WaitOne();
                _requestsAvailable.Reset(); 
                while(_requests.Count!=0)
                {
                    var request = _requests.Dequeue();
                    try
                    {
                        var task = GetImageNow2(request);
                        task.Wait();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        Queue<ImageRequest> _requests=new Queue<ImageRequest>();

        ManualResetEvent _requestsAvailable=new ManualResetEvent(false);
        private CancellationTokenSource _cancellationSource;

        public void GetImage(string imgUri, Action<object> callback)
        {
            _requests.Enqueue(new ImageRequest(imgUri,callback));
            _requestsAvailable.Set();

        }
        private static Uri _baseUri = new Uri("ms-appx:///");
        private List<string> _files;

        public object GetBlankImage()
        {
            return new Uri(_baseUri, "Assets/DarkGray.png");
        }

        async private Task GetImageNow2(ImageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ImgUri))
            {
                return;
            }
            var tmpDir = ApplicationData.Current.TemporaryFolder;
            StorageFile file=null;
            var fileName = Uri.EscapeDataString(request.ImgUri.TrimEnd('/'));
            if (fileName.Length > 30)
            {
                fileName = fileName.Substring(fileName.Length - 30, 30);
            }


            if (_files == null)
            {
                _files = (await tmpDir.GetFilesAsync()).Select(f=>f.Name).ToList();
            }
            var exists=_files.Contains(fileName);
            if (exists)
            {
                try
                {
                    file = await tmpDir.GetFileAsync(fileName);
                }
                catch (Exception)
                {
                }
            }

            if(file==null)
            {
                var stream = await _xbmc.GetImageStream(request.ImgUri);
                file = await tmpDir.CreateFileAsync(fileName);
                var fileStream = await file.OpenStreamForWriteAsync();
                await stream.CopyToAsync(fileStream);
                fileStream.Dispose();
                _files.Add(fileName);
            }
            if (file != null)
            {
                request.InvokeCallback(new Uri(file.Path));
            }

        }
    }
}