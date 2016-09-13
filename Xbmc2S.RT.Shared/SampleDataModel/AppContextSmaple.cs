using KODIRPC;
using Xbmc2S.Model;
using Xbmc2S.Model.Download;
using IPlatformServices = Xbmc2S.Model.IPlatformServices;

namespace Xbmc2S.RT.SampleDataModel
{
    class AppContextSmaple:IAppContext
    {
        public Client XBMC { get; private set; }
        public IPlatformServices PlatformServices { get; private set; }
        public IImageManager ImageManager { get; private set; }
        public IUpnpManager Upnp { get; private set; }
        public IDownloadManager Downloads { get; private set; }
        public IView View { get; private set; }
        public SettingsVm Settings { get; private set; }
        public WatchList WatchList { get; private set; }

        public AppContextSmaple()
        {
            ImageManager = new ImageManSample();
            PlatformServices= new PlatformServices.PlatformServices();
        }
    }
}