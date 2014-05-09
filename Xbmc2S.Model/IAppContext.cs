using System;
using XBMCRPC;
using Xbmc2S.Model.Download;

namespace Xbmc2S.Model
{
    public interface IAppContext
    {
        Client XBMC { get; }
        IPlatformServices PlatformServices { get; }
        IImageManager ImageManager { get; }
        IUpnpManager Upnp { get; }
        IDownloadManager Downloads { get; }
        IView View { get; }
        SettingsVm Settings { get; }
        //WatchList WatchList { get; }
    }
}