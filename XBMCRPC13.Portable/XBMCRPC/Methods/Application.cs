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
        public async Task<XBMCRPC.Application.Property.Value> GetProperties(XBMCRPC.Application.GetProperties_properties properties=null)
        {
             var jArgs = new JObject();

             if (properties == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null properties");
              }
             else
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

             if (mute == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null mute");
              }
             else
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
        public async Task<bool> SetMute(XBMCRPC.Global.Toggle2? mute=null)
        {
             var jArgs = new JObject();

             if (mute == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null mute");
              }
             else
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
        public async Task<int> SetVolume(int? volume=null)
        {
             var jArgs = new JObject();

             if (volume == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null volume");
              }
             else
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
        public async Task<int> SetVolume(XBMCRPC.Global.IncrementDecrement? volume=null)
        {
             var jArgs = new JObject();

             if (volume == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null volume");
              }
             else
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

        public delegate void OnVolumeChangedDelegate(string sender=null, XBMCRPC.Application.OnVolumeChanged_data data=null);
        public event OnVolumeChangedDelegate OnVolumeChanged;
        internal void RaiseOnVolumeChanged(string sender=null, XBMCRPC.Application.OnVolumeChanged_data data=null)
        {
            if (OnVolumeChanged != null)
            {
                OnVolumeChanged.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
