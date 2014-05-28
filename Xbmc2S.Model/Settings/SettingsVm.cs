using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Core;
using Xbmc2S.Model.Annotations;
using StreamingClient.StreamManagment;

namespace Xbmc2S.Model
{
    public class SettingsVm:BindableBase
    {
        private static SettingsVm _current;
        private static ISettingsManager _settingsManager;

        public event EventHandler SettingsChanged;

        private string _host;
        private string _user;
        private string _password;
        private uint _port;
        private int _vlcPort;
        private bool _firstStart;
        private string _vlcPassword;
        private bool _vlcUseQsv;
        private List<XbmcServer> _history;
        private bool _showMovies;
        private bool _showShows;
        private bool _showMusic;
        private bool _showWatched;
        private bool _suspendNotifications;
        private bool _useListView;
        public List<XbmcServer> History { get { return _history; } }

        public bool ShowWatched
        {
            get { return _showWatched; }
            set { SetSetting(ref _showWatched, value); }
        }

        public bool UseListView
        {
            get { return _useListView; }
            set { SetSetting(ref _useListView, value); }
        }

        public bool ShowMovies
        {
            get { return _showMovies; }
            set { SetSetting(ref _showMovies, value); }
        }

        public bool ShowShows
        {
            get { return _showShows; }
            set { SetSetting(ref _showShows, value); }
        }

        public bool ShowMusic
        {
            get { return _showMusic; }
            set { SetSetting(ref _showMusic, value); }
        }

        public string Host
        {
            get { return _host; }
            set { SetSetting(ref _host,value); }
        }

        public string User
        {
            get { return _user; }
            set { SetSetting(ref _user, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetSetting(ref _password, value); }
        }

        public uint Port
        {
            get { return _port; }
            set { SetSetting(ref _port, value); }
        }

        public int VlcPort
        {
            get { return _vlcPort; }
            set { SetSetting(ref _vlcPort, value); }
        }

        public string VlcPassword
        {
            get { return _vlcPassword; }
            set { SetSetting(ref _vlcPassword, value); }
        }

        public bool FirstStart
        {
            get { return _firstStart; }
            set { SetSetting(ref _firstStart, value); }
        }

        public bool VlcUseQSV
        {
            get { return _vlcUseQsv; }
            set { SetSetting(ref _vlcUseQsv, value); }
        }

        [NotifyPropertyChangedInvocator]
        private void SetSetting<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (SetProperty(ref storage, value, propertyName))
            {
                _settingsManager.SetSetting(propertyName, value, SaveRemote);
                NotifySettingsChanged();
            }
        }

        private void NotifySettingsChanged()
        {
            if (_suspendNotifications) return;
            
            EventHandler temp = SettingsChanged;
            if (temp != null)
            {
                temp(this, new EventArgs());
            }
        }

        private const bool SaveRemote = false;

        internal SettingsVm(IPlatformServices platformServices)
        {
            _settingsManager = platformServices.SettingsManager;
            _host = _settingsManager.GetSetting("Host", "", SaveRemote);
            _user = _settingsManager.GetSetting("User", "xbmc", SaveRemote);
            _password = _settingsManager.GetSetting("Password", "", SaveRemote);
            _port = _settingsManager.GetSetting("Port", 80u, SaveRemote);
            _vlcPort = _settingsManager.GetSetting("VlcPort", 8080, SaveRemote);
            _vlcPassword = _settingsManager.GetSetting("VlcPassword", "vlc", SaveRemote);
            _vlcUseQsv = _settingsManager.GetSetting("VlcUseQSV", false, SaveRemote);
            _showMovies = _settingsManager.GetSetting("ShowMovies", true, SaveRemote);
            _showShows = _settingsManager.GetSetting("ShowShows", true, SaveRemote);
            _showMusic = _settingsManager.GetSetting("ShowMusic", true, SaveRemote);
            _showWatched = _settingsManager.GetSetting("ShowWatched", true, SaveRemote);
            _useListView = _settingsManager.GetSetting("UseListView", true, SaveRemote);

            InitHistory();
        }

        const string HistoryFile = "conhist.xml";

        async Task InitHistory()
        {

                _history = await _settingsManager.LoadData(HistoryFile, () => new List<XbmcServer>(), false);

        }

        public async Task LoadFromHistory(XbmcServer server)
        {
            await SaveCurrentInHistory();

            VlcPassword = server.VlcPassword;
            VlcPort = server.VlcPort;
            VlcUseQSV = server.VlcUseQsv;
            Set(server.Host, server.WebInterfacePort, server.User, server.Password);
        }

        public async Task SaveCurrentInHistory()
        {
            if (string.IsNullOrWhiteSpace(Host))
            {
                return;
            }

            XbmcServer server = _history.FirstOrDefault(h => h.Host == Host && h.WebInterfacePort == Port);
            if (server == null)
            {
                server = new XbmcServer();
                server.WebInterfacePort = (int)Port;
                server.Host = Host;
                _history.Add(server);
            }
            server.User = User;
            server.Password = Password;
            server.VlcPassword = VlcPassword;
            server.VlcPort = VlcPort;
            server.VlcUseQsv = VlcUseQSV;

            await _settingsManager.SaveData(HistoryFile, _history, false);
        }

        public XbmcServer GetCurrentAsHistoryItem()
        {
                            var server = new XbmcServer();
                server.WebInterfacePort = (int)Port;
                server.Host = Host;

            server.User = User;
            server.Password = Password;
            server.VlcPassword = VlcPassword;
            server.VlcPort = VlcPort;
            server.VlcUseQsv = VlcUseQSV;

            return server;
        }


        public async Task ClearHistory()
        {
            _history = new List<XbmcServer>();
            await _settingsManager.SaveData(HistoryFile, _history, false);
        }

        public void Set(string host, int port, string user, string password)
        {
            _suspendNotifications = true;

            Host = host;
            Port = (uint) port;
            User = user;
            Password = password;

            _suspendNotifications = false;

            NotifySettingsChanged();
        }

        public void SetVlc(string password, int port)
        {
            _suspendNotifications = true;

            VlcPassword = password;
            VlcPort = port;
            
            _suspendNotifications = false;
        }

        public StreamingSettings GetVlcSettings()
        {
            var settings = new StreamingSettings();
            settings.Host = Host;
            settings.StreamPort = VlcPort;
            settings.Password = VlcPassword;
            settings.UseQSV = VlcUseQSV;
            settings.PresetHigh();

            return settings;
        }

        public async Task CheckVlcSettings()
        {
            var vlc = new VlcAccess(GetVlcSettings());
            await vlc.CheckConnection();
        }
    }
}
