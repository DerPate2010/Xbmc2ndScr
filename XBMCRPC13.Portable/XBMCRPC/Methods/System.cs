using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
{
   public partial class System
   {
        private readonly Client _client;
          public System(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Ejects or closes the optical disc drive (if available)
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> EjectOpticalDrive()
        {
            return await _client.GetData<string>("System.EjectOpticalDrive",null);
        }

                /// <summary>
                /// Retrieves the values of the given properties
                /// </summary>
                /// <param name="properties"> REQUIRED </param>
                /// <returns>XBMCRPC.System.Property.Value</returns>
        public async Task<XBMCRPC.System.Property.Value> GetProperties(XBMCRPC.System.GetProperties_properties properties)
        {
            var jArgs = new JObject();

             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<XBMCRPC.System.Property.Value>("System.GetProperties", jArgs);
        }

                /// <summary>
                /// Puts the system running Kodi into hibernate mode
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Hibernate()
        {
            return await _client.GetData<string>("System.Hibernate",null);
        }

                /// <summary>
                /// Reboots the system running Kodi
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Reboot()
        {
            return await _client.GetData<string>("System.Reboot",null);
        }

                /// <summary>
                /// Shuts the system running Kodi down
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Shutdown()
        {
            return await _client.GetData<string>("System.Shutdown",null);
        }

                /// <summary>
                /// Suspends the system running Kodi
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Suspend()
        {
            return await _client.GetData<string>("System.Suspend",null);
        }

        public delegate void OnLowBatteryDelegate(string sender, object data);
        public event OnLowBatteryDelegate OnLowBattery;
        internal void RaiseOnLowBattery(string sender, object data)
        {
            if (OnLowBattery != null)
            {
                OnLowBattery.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnQuitDelegate(string sender, XBMCRPC.System.OnQuit_data data);
        public event OnQuitDelegate OnQuit;
        internal void RaiseOnQuit(string sender, XBMCRPC.System.OnQuit_data data)
        {
            if (OnQuit != null)
            {
                OnQuit.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnRestartDelegate(string sender, object data);
        public event OnRestartDelegate OnRestart;
        internal void RaiseOnRestart(string sender, object data)
        {
            if (OnRestart != null)
            {
                OnRestart.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnSleepDelegate(string sender, object data);
        public event OnSleepDelegate OnSleep;
        internal void RaiseOnSleep(string sender, object data)
        {
            if (OnSleep != null)
            {
                OnSleep.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnWakeDelegate(string sender, object data);
        public event OnWakeDelegate OnWake;
        internal void RaiseOnWake(string sender, object data)
        {
            if (OnWake != null)
            {
                OnWake.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
