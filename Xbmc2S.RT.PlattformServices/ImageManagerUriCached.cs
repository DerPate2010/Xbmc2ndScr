using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using Xbmc2S.Model;
using XBMCRPC;

namespace Xbmc2S.RT.PlatformServices
{
    class ImageManagerUriCached : IImageManager
    {


        private readonly Client _xbmc;

        public ImageManagerUriCached(Client xbmc)
        {
            _xbmc = xbmc;
            _tmpDir = ApplicationData.Current.TemporaryFolder;
            InitFiles();

            _cancellationSource = new CancellationTokenSource();
            Task.Factory.StartNew(() => Loader(_cancellationSource.Token), _cancellationSource.Token);
        }

        private void Loader(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _requestsAvailable.WaitOne();
                _requestsAvailable.Reset();
                while (_requests.Count != 0)
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

        private async Task GetImageNow2(ImageRequest request)
        {
            var stream = await _xbmc.GetImageStream(request.ImgUri);
            var file = await _tmpDir.CreateFileAsync(request.FileName);
            var fileStream = await file.OpenStreamForWriteAsync();
            await stream.CopyToAsync(fileStream);
            fileStream.Dispose();
            _files.Add(request.FileName);
            var filePath = Path.Combine(_tmpDir.Path, request.FileName);
            request.InvokeCallback(filePath);
        }

        private async Task InitFiles()
        {
            var files = new ConcurrentBag<string>((await _tmpDir.GetFilesAsync()).Select(f => f.Name));

            _files = files;
        }

        Queue<ImageRequest> _requests = new Queue<ImageRequest>();

        ManualResetEvent _requestsAvailable = new ManualResetEvent(false);
        private CancellationTokenSource _cancellationSource;

        public async void GetImage(string imgUri, Action<object> callback)
        {
            if (!string.IsNullOrWhiteSpace(imgUri))
            {
                try
                {
                    var fileName = Uri.EscapeDataString(imgUri.TrimEnd('/'));
                    if (fileName.Length > 30)
                    {
                        fileName = fileName.Substring(fileName.Length - 30, 30);
                    }

                    var filePath = Path.Combine(_tmpDir.Path, fileName);

                    while (_files == null)
                    {
                        await Task.Delay(500);
                    }

                    var exists = _files.Contains(fileName);
                    if (!exists)
                    {
                        _requests.Enqueue(new ImageRequest(imgUri, callback, fileName));
                        _requestsAvailable.Set();
                    }
                    else
                    {
                        callback(new Uri(filePath));
                    }
                    
                    return;
                }
                catch (Exception)
                {
                }
            }

            callback(GetBlankImage());
        }

        private static Uri _baseUri = new Uri("ms-appx:///");
        private ConcurrentBag<string> _files;
        private StorageFolder _tmpDir;

        public static int _count;

        public object GetBlankImage()
        {
            return new Uri(_baseUri, "Assets/DarkGray.png");
        }
    }
}