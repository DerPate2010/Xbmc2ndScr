using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
{
   public partial class Application
   {
        private readonly Client _client;
          public Application(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Retrieves the values of the given properties
                /// </summary>
                /// <param name="properties"> REQUIRED </param>
                /// <returns>XBMCRPC.Application.Property.Value</returns>
        public async Task<XBMCRPC.Application.Property.Value> GetProperties(XBMCRPC.Application.GetProperties_properties properties)
        {
            var jArgs = new JObject();

             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<XBMCRPC.Application.Property.Value>("Application.GetProperties", jArgs);
        }

                /// <summary>
                /// Quit application
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Quit()
        {
            return await _client.GetData<string>("Application.Quit",null);
        }

                /// <summary>
                /// Toggle mute/unmute
                /// </summary>
                /// <param name="mute"> REQUIRED </param>
                /// <returns>bool</returns>
        public async Task<bool> SetMute(bool? mute=null)
        {
            var jArgs = new JObject();

             {
                 var jpropmute = JToken.FromObject(mute, _client.Serializer);
                 jArgs.Add(new JProperty("mute", jpropmute));
             }
            return await _client.GetData<bool>("Application.SetMute", jArgs);
        }

                /// <summary>
                /// Toggle mute/unmute
                /// </summary>
                /// <param name="mute"> REQUIRED </param>
                /// <returns>bool</returns>
        public async Task<bool> SetMute(XBMCRPC.Global.Toggle2? mute)
        {
            var jArgs = new JObject();

             {
                 var jpropmute = JToken.FromObject(mute, _client.Serializer);
                 jArgs.Add(new JProperty("mute", jpropmute));
             }
            return await _client.GetData<bool>("Application.SetMute", jArgs);
        }

                /// <summary>
                /// Toggle mute/unmute
                /// </summary>
                /// <returns>bool</returns>
        public async Task<bool> SetMute()
        {
            return await _client.GetData<bool>("Application.SetMute",null);
        }

                /// <summary>
                /// Set the current volume
                /// </summary>
                /// <param name="volume"> REQUIRED </param>
                /// <returns>int</returns>
        public async Task<int> SetVolume(int volume)
        {
             if (volume == 0 )
             {
                 return 0;
              }

            var jArgs = new JObject();

             {
                 var jpropvolume = JToken.FromObject(volume, _client.Serializer);
                 jArgs.Add(new JProperty("volume", jpropvolume));
             }
            return await _client.GetData<int>("Application.SetVolume", jArgs);
        }

                /// <summary>
                /// Set the current volume
                /// </summary>
                /// <param name="volume"> REQUIRED </param>
                /// <returns>int</returns>
        public async Task<int> SetVolume(XBMCRPC.Global.IncrementDecrement? volume)
        {
            var jArgs = new JObject();

             {
                 var jpropvolume = JToken.FromObject(volume, _client.Serializer);
                 jArgs.Add(new JProperty("volume", jpropvolume));
             }
            return await _client.GetData<int>("Application.SetVolume", jArgs);
        }

                /// <summary>
                /// Set the current volume
                /// </summary>
                /// <returns>int</returns>
        public async Task<int> SetVolume()
        {
            return await _client.GetData<int>("Application.SetVolume",null);
        }

        public delegate void OnVolumeChangedDelegate(string sender, XBMCRPC.Application.OnVolumeChanged_data data);
        public event OnVolumeChangedDelegate OnVolumeChanged;
        internal void RaiseOnVolumeChanged(string sender, XBMCRPC.Application.OnVolumeChanged_data data)
        {
            if (OnVolumeChanged != null)
            {
                OnVolumeChanged.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
