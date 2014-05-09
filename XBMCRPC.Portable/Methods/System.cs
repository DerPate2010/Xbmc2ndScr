using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace XBMCRPC.Methods
{
   public partial class System
   {
        private readonly Client _client;
          public System(Client client)
          {
              _client = client;
          }

        async public Task<string> EjectOpticalDrive()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("System.EjectOpticalDrive", jArgs);
            return jRet;
        }

        async public Task<XBMCRPC.System.Property.Value> GetProperties(XBMCRPC.System.Property.Name[] properties=null)
        {
            var jArgs = new JObject();
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<XBMCRPC.System.Property.Value>("System.GetProperties", jArgs);
            return jRet;
        }

        async public Task<string> Hibernate()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("System.Hibernate", jArgs);
            return jRet;
        }

        async public Task<string> Reboot()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("System.Reboot", jArgs);
            return jRet;
        }

        async public Task<string> Shutdown()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("System.Shutdown", jArgs);
            return jRet;
        }

        async public Task<string> Suspend()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("System.Suspend", jArgs);
            return jRet;
        }

        public delegate void OnLowBatteryDelegate(string sender=null);
        public event OnLowBatteryDelegate OnLowBattery;
        internal void RaiseOnLowBattery(string sender=null)
        {
            if (OnLowBattery != null)
            {
                OnLowBattery.BeginInvoke(sender, null, null);
            }
        }

        public delegate void OnQuitDelegate(string sender=null);
        public event OnQuitDelegate OnQuit;
        internal void RaiseOnQuit(string sender=null)
        {
            if (OnQuit != null)
            {
                OnQuit.BeginInvoke(sender, null, null);
            }
        }

        public delegate void OnRestartDelegate(string sender=null);
        public event OnRestartDelegate OnRestart;
        internal void RaiseOnRestart(string sender=null)
        {
            if (OnRestart != null)
            {
                OnRestart.BeginInvoke(sender, null, null);
            }
        }

        public delegate void OnSleepDelegate(string sender=null);
        public event OnSleepDelegate OnSleep;
        internal void RaiseOnSleep(string sender=null)
        {
            if (OnSleep != null)
            {
                OnSleep.BeginInvoke(sender, null, null);
            }
        }

        public delegate void OnWakeDelegate(string sender=null);
        public event OnWakeDelegate OnWake;
        internal void RaiseOnWake(string sender=null)
        {
            if (OnWake != null)
            {
                OnWake.BeginInvoke(sender, null, null);
            }
        }
   }
}
