using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Q42.WinRT.Data;
using KODIRPC;
using Xbmc2S.Model;

namespace Xbmc2S.RT.PlatformServices
{
    public class PlatformServices:Model.IPlatformServices
    {
        private readonly IConnectionStatus _connectionStatus;
        public ISettingsManager SettingsManager { get; private set; }
        public IImageManager GetImageManager(Client xbmc, bool needsLogin)
        {
            if (needsLogin)
            {
                return new ImageManagerUriCached(xbmc);
            }
            else
            {
                return new ImageManagerUri(xbmc);
            }
        }

        public IBackgroundTransfer BackgroundTransfer { get; private set; }
        public ILauncher Launcher { get; private set; }

        private PlatformServices(ILauncher launcher)
        {
            Launcher = launcher;
            SettingsManager = new SettingsManager();
            SocketFactory = new SocketFactory();
            BackgroundTransfer = new BackgroundTransferManager();
            _connectionStatus = new NoConnectionStatus();
        }

        public PlatformServices():this(new LauncherWp())
        {
        }

        public PlatformServices(IConnectionStatus connectionStatus, ILauncher launcher):this(launcher)
        {
            _connectionStatus = connectionStatus;
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
                _connectionStatus.SetError(ex.Message);
                throw;
            }
        }

        public async Task<WebResponse> GetResponse(WebRequest request)
        {
            using (_connectionStatus.GetProgressToken())
            {
                try
                {
                    return await request.GetResponseAsync();
                }
                catch (Exception ex)
                {
                    _connectionStatus.SetError(ex.Message);
                    throw;
                }
            }
        }

        public async Task<string> Get(string uri)
        {
            try
            {
                return await DataCache.GetAsync(uri.GetHashCode().ToString(), () => GetInternal(uri));

            }
            catch (Exception)
            {
            }
            return await GetInternal(uri);
        }

        private async Task<string> GetInternal(string uri)
        {
            using (_connectionStatus.GetProgressToken())
            {
                try
                {
                    HttpWebRequest request = WebRequest.CreateHttp(uri);
                    request.Accept = "application/json";
                    var response = await request.GetResponseAsync();
                    var stream = response.GetResponseStream();
                    var reader = new StreamReader(stream);
                    var json = reader.ReadToEnd();
                    return json;
                }
                catch (Exception ex)
                {
                    _connectionStatus.SetError(ex.Message);
                    throw;
                }
            }
        }

        private class NoProgressToken:IDisposable
        {
            public void Dispose()
            {
            }
        }

        private class NoConnectionStatus:IConnectionStatus
        {
            private static readonly NoProgressToken _token= new NoProgressToken();

            public IDisposable GetProgressToken()
            {
                return _token;
            }

            public void SetError(string message)
            {
            }
        }
    }

    public interface IConnectionStatus
    {
        IDisposable GetProgressToken();
        void SetError(string message);
    }

}