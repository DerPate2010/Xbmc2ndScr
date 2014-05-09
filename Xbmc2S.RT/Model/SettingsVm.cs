using System;
using System.Runtime.CompilerServices;
using MyToolkit.Storage;
using Xbmc2S.RT.Common;
using Xbmc2S.RT.Properties;

namespace Xbmc2S.RT.Model
{
    class SettingsVm:BindableBase
    {
        private static SettingsVm _current;

        public static SettingsVm Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new SettingsVm();
                }
                return _current;
            }
        }

        public event EventHandler SettingsChanged;

        private string _host;
        private string _user;
        private string _password;
        private uint _port;

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

        [NotifyPropertyChangedInvocator]
        private void SetSetting<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (SetProperty(ref storage, value, propertyName))
            {
                ApplicationSettings.SetSetting(propertyName,value,true);
                EventHandler temp = SettingsChanged;
                if (temp != null)
                {
                    temp(this, new EventArgs());
                }
            }
        }

        private T GetSetting<T>(ref T storage, [CallerMemberName] String propertyName = null)
        {
            if (storage != null)
            {
                return storage;
            }
            return ApplicationSettings.GetSetting<T>(propertyName, true);
        }

        private SettingsVm()
        {
            _host = ApplicationSettings.GetSetting("Host","",true);
            _user = ApplicationSettings.GetSetting("User", "xbmc", true);
            _password = ApplicationSettings.GetSetting("Password", "xbmc", true);
            _port = ApplicationSettings.GetSetting("Port", 80u, true);
        }
    }
}
