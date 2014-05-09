using System;
using XBMCRPC;

namespace Xbmc2S.RT.Model
{
    class ServerInfo : IServerInfo
    {
        private readonly SettingsVm _settings;
        public Client XBMC { get; private set; }
        public IImageManager ImageManager { get; private set; }
        public bool NotificationsEnabled { get; private set; }

        public ServerInfo()
        {
            _settings = SettingsVm.Current;

            _settings.SettingsChanged += _settings_SettingsChanged;

            Init();
        }

        private void Init()
        {
            var host = _settings.Host;
            if (string.IsNullOrWhiteSpace(host))
            {
                host = "nohost";
            }
            var port = (int) _settings.Port;
            if (port == 0)
            {
                port = 80;
            }
            XBMC = new XBMCRPC.Client(host, port, _settings.User, _settings.Password);
            ImageManager = new ImageManager(XBMC);

            var t = XBMC.StartNotificationListener();
            t.ContinueWith(t2 => { NotificationsEnabled = !t2.IsFaulted; });
        }

        void _settings_SettingsChanged(object sender, EventArgs e)
        {
            Init();
        }
    }
}