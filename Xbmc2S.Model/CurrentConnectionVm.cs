using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using StreamClient.VLM;
using KODIRPC.Application;
using KODIRPC.Application.Property;

namespace Xbmc2S.Model
{
    public class CurrentConnectionVm:BindableBase
    {
        private readonly AppContext _appContext;
        private string _name;
        private bool _connectionFailed;
        private Task<Value> _connectionTask;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public ICommand EditSettings { get; private set; }

        public bool ConnectionFailed
        {
            get { return _connectionFailed; }
            private set { SetProperty(ref _connectionFailed, value); }
        }

        public CurrentConnectionVm(AppContext appContext)
        {
            EditSettings= new DelegateCommand(EditSettingsExecuted);

            _appContext = appContext;
            _appContext.Settings.SettingsChanged += Settings_SettingsChanged;
            CheckConnection();
        }

        private void EditSettingsExecuted()
        {
            _appContext.View.GotoWelcomeWizard();
        }

        private async void CheckConnection()
        {
            if (string.IsNullOrWhiteSpace(_appContext.Settings.Host))
            {
                Name = "Connections";
            }
            else
            {
                Name = _appContext.Settings.Host;
            }

            Task<Value> connectionTask=null;
            try
            {
                connectionTask = _appContext.XBMC.Application.GetProperties(new GetProperties_properties(){ KODIRPC.Application.Property.Name.version });
                _connectionTask = connectionTask;
                await connectionTask;

                ConnectionFailed = false;
                
            }
            catch (Exception)
            {
                if (connectionTask == _connectionTask)
                {
                    ConnectionFailed = true;
                }
            }
        }

        void Settings_SettingsChanged(object sender, System.EventArgs e)
        {
            CheckConnection();
        }

        public List<XbmcServer> GetAvailableServers()
        {
            return _appContext.Upnp.DiscoveredXBMCs;
        }

        public List<XbmcServer> GetRecentServers()
        {
            var history = _appContext.Settings.History;

            foreach (var server in history)
            {
                server.IsCurrent = false;
            }
            var current = history.FirstOrDefault(h => h.Host == _appContext.Settings.Host && h.WebInterfacePort == _appContext.Settings.Port);
            if (current == null && !string.IsNullOrWhiteSpace(_appContext.Settings.Host))
            {
                current = _appContext.Settings.GetCurrentAsHistoryItem();
                history.Insert(0,current);
            }

            if (current != null) current.IsCurrent = true;

            return history;
        }

        public async Task OnLaunch()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_appContext.Settings.Host))
                {
                    await _appContext.Upnp.WaitForInit();

                    var server = _appContext.Upnp.DiscoveredXBMCs.FirstOrDefault();

                    if (server != null)
                    {
                        
                        await _appContext.Settings.LoadFromHistory(server);
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public async Task<bool> UPnPAvailable()
        {
            await _appContext.Upnp.WaitForInit();
            return _appContext.Upnp.IsAvailable;
        }
    }
}