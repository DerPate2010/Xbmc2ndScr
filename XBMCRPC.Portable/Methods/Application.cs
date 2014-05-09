using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using XBMCRPC.Global;

namespace XBMCRPC.Methods
{
   public partial class Application
   {
        private readonly Client _client;
          public Application(Client client)
          {
              _client = client;
          }

        async public Task<XBMCRPC.Application.Property.Value> GetProperties(XBMCRPC.Application.Property.Name[] properties=null)
        {
            var jArgs = new JObject();
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<XBMCRPC.Application.Property.Value>("Application.GetProperties", jArgs);
            return jRet;
        }

        async public Task<string> Quit()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("Application.Quit", jArgs);
            return jRet;
        }

        async public Task<bool> SetMute(XBMCRPC.Global.Toggle mute=0)
        {
            var jArgs = new JObject();
            JToken jpropmute;
            switch (mute)
             {
                 case Toggle.True:
                 case Toggle.False:
                     jpropmute = JToken.FromObject(bool.Parse(mute.ToString()), _client.Serializer);
                     break;
                default:
                     jpropmute = JToken.FromObject(mute, _client.Serializer);

                     break;
             }
             jArgs.Add(new JProperty("mute", jpropmute));
            var jRet = await _client.GetData<bool>("Application.SetMute", jArgs);
            return jRet;
        }

        async public Task<int> SetVolume()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<int>("Application.SetVolume", jArgs);
            return jRet;
        }

        async public Task<int> SetVolume2(int volume=0)
        {
            var jArgs = new JObject();
             if (volume != null)
             {
                 var jpropvolume = JToken.FromObject(volume, _client.Serializer);
                 jArgs.Add(new JProperty("volume", jpropvolume));
             }
            var jRet = await _client.GetData<int>("Application.SetVolume", jArgs);
            return jRet;
        }

        async public Task<int> SetVolume2(XBMCRPC.Global.IncrementDecrement volume=0)
        {
            var jArgs = new JObject();
             if (volume != null)
             {
                 var jpropvolume = JToken.FromObject(volume, _client.Serializer);
                 jArgs.Add(new JProperty("volume", jpropvolume));
             }
            var jRet = await _client.GetData<int>("Application.SetVolume", jArgs);
            return jRet;
        }
   public class OnVolumeChangeddataType
   {
       public bool muted {get;set;}
       public int volume {get;set;}
   }

        public delegate void OnVolumeChangedDelegate(string sender=null, OnVolumeChangeddataType data=null);
        public event OnVolumeChangedDelegate OnVolumeChanged;
        internal void RaiseOnVolumeChanged(string sender=null, OnVolumeChangeddataType data=null)
        {
            if (OnVolumeChanged != null)
            {
                OnVolumeChanged.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
