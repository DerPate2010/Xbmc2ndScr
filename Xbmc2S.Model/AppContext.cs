using System;
using System.Globalization;
using System.Net;
using TmdbWrapper;
using KODIRPC;
using Xbmc2S.Model.Download;
using KODIRPC.Application;
using KODIRPC.Application.Property;

namespace Xbmc2S.Model
{
    public class AppContext : IAppContext
    {
        public IPlatformServices PlatformServices { get; private set; }
        public IImageManager ImageManager { get; private set; }
        public IUpnpManager Upnp { get; private set; }
        public IDownloadManager Downloads { get; private set; }
        public IView View { get; private set; }
        public Client XBMC { get; private set; }
        //public WatchList WatchList { get; private set; }
        public bool NotificationsEnabled { get; private set; }

        public SettingsVm Settings { get; private set; }

        public const string TmdbApiKey = "0b8dcfc0cf26d3393d2794f2f564319f";

        public AppContext(IPlatformServices platformServices, IView view)
        {
            View = view;
            PlatformServices = platformServices;
            Settings = new SettingsVm(platformServices);
            Downloads=new DownloadManager(this, view);
            //WatchList = new WatchList(this);

            Settings.SettingsChanged += _settings_SettingsChanged;

            Init();

            TheMovieDb.Initialise(TmdbApiKey, View.PreferedCulture.TwoLetterISOLanguageName, PlatformServices);
        }


        internal async void Init()
        {
            var host = Settings.Host;
            if (string.IsNullOrWhiteSpace(host))
            {
                host = "nohost";
            }
            var port = (int)Settings.Port;
            if (port == 0)
            {
                port = 80;
            }

            if (XBMC != null)
            {
                XBMC.Dispose();
            }
            XBMC = new KODIRPC.Client(new ConnectionSettings(host, port, Settings.User, Settings.Password), PlatformServices);
            
            ImageManager = PlatformServices.GetImageManager(XBMC, !string.IsNullOrEmpty(Settings.Password));

            var t = XBMC.StartNotificationListener();
            t.ContinueWith(t2 => { NotificationsEnabled = !t2.IsFaulted; });

            Upnp=new UpnpManager(this);
        }

        void _settings_SettingsChanged(object sender, EventArgs e)
        {
            Init();
        }
    }
}