using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
{
   public partial class GUI
   {
        private readonly Client _client;
          public GUI(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Activates the given window
                /// </summary>
                /// <param name="window"> REQUIRED </param>
                /// <param name="parameters"> </param>
                /// <returns>string</returns>
        public async Task<string> ActivateWindow(XBMCRPC.GUI.Window? window, global::System.Collections.Generic.List<string> parameters=null)
        {
            var jArgs = new JObject();

             {
                 var jpropwindow = JToken.FromObject(window, _client.Serializer);
                 jArgs.Add(new JProperty("window", jpropwindow));
             }
             if (parameters != null)
             {
                 var jpropparameters = JToken.FromObject(parameters, _client.Serializer);
                 jArgs.Add(new JProperty("parameters", jpropparameters));
             }
            return await _client.GetData<string>("GUI.ActivateWindow", jArgs);
        }

                /// <summary>
                /// Retrieves the values of the given properties
                /// </summary>
                /// <param name="properties"> REQUIRED </param>
                /// <returns>XBMCRPC.GUI.Property.Value</returns>
        public async Task<XBMCRPC.GUI.Property.Value> GetProperties(XBMCRPC.GUI.GetProperties_properties properties)
        {
            var jArgs = new JObject();

             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<XBMCRPC.GUI.Property.Value>("GUI.GetProperties", jArgs);
        }

                /// <summary>
                /// Returns the supported stereoscopic modes of the GUI
                /// </summary>
                /// <returns>XBMCRPC.GUI.GetStereoscopicModesResponse</returns>
        public async Task<XBMCRPC.GUI.GetStereoscopicModesResponse> GetStereoscopicModes()
        {
            return await _client.GetData<XBMCRPC.GUI.GetStereoscopicModesResponse>("GUI.GetStereoscopicModes",null);
        }

                /// <summary>
                /// Toggle fullscreen/GUI
                /// </summary>
                /// <param name="fullscreen"> REQUIRED </param>
                /// <returns>bool</returns>
        public async Task<bool> SetFullscreen(bool? fullscreen=null)
        {
            var jArgs = new JObject();

             {
                 var jpropfullscreen = JToken.FromObject(fullscreen, _client.Serializer);
                 jArgs.Add(new JProperty("fullscreen", jpropfullscreen));
             }
            return await _client.GetData<bool>("GUI.SetFullscreen", jArgs);
        }

                /// <summary>
                /// Toggle fullscreen/GUI
                /// </summary>
                /// <param name="fullscreen"> REQUIRED </param>
                /// <returns>bool</returns>
        public async Task<bool> SetFullscreen(XBMCRPC.Global.Toggle2? fullscreen)
        {
            var jArgs = new JObject();

             {
                 var jpropfullscreen = JToken.FromObject(fullscreen, _client.Serializer);
                 jArgs.Add(new JProperty("fullscreen", jpropfullscreen));
             }
            return await _client.GetData<bool>("GUI.SetFullscreen", jArgs);
        }

                /// <summary>
                /// Toggle fullscreen/GUI
                /// </summary>
                /// <returns>bool</returns>
        public async Task<bool> SetFullscreen()
        {
            return await _client.GetData<bool>("GUI.SetFullscreen",null);
        }

                /// <summary>
                /// Sets the stereoscopic mode of the GUI to the given mode
                /// </summary>
                /// <param name="mode"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetStereoscopicMode(XBMCRPC.GUI.SetStereoscopicMode_mode? mode)
        {
            var jArgs = new JObject();

             {
                 var jpropmode = JToken.FromObject(mode, _client.Serializer);
                 jArgs.Add(new JProperty("mode", jpropmode));
             }
            return await _client.GetData<string>("GUI.SetStereoscopicMode", jArgs);
        }

                /// <summary>
                /// Shows a GUI notification
                /// </summary>
                /// <param name="title"> REQUIRED </param>
                /// <param name="message"> REQUIRED </param>
                /// <param name="image"> </param>
                /// <param name="displaytime"> The time in milliseconds the notification will be visible</param>
                /// <returns>string</returns>
        public async Task<string> ShowNotification(string title, string message, XBMCRPC.GUI.ShowNotification_image1? image=null, int displaytime=0)
        {
            var jArgs = new JObject();

             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             {
                 var jpropmessage = JToken.FromObject(message, _client.Serializer);
                 jArgs.Add(new JProperty("message", jpropmessage));
             }
             if (image != null)
             {
                 var jpropimage = JToken.FromObject(image, _client.Serializer);
                 jArgs.Add(new JProperty("image", jpropimage));
             }
             if (displaytime != null)
             {
                 var jpropdisplaytime = JToken.FromObject(displaytime, _client.Serializer);
                 jArgs.Add(new JProperty("displaytime", jpropdisplaytime));
             }
            return await _client.GetData<string>("GUI.ShowNotification", jArgs);
        }

                /// <summary>
                /// Shows a GUI notification
                /// </summary>
                /// <param name="title"> REQUIRED </param>
                /// <param name="message"> REQUIRED </param>
                /// <param name="image"> </param>
                /// <param name="displaytime"> The time in milliseconds the notification will be visible</param>
                /// <returns>string</returns>
        public async Task<string> ShowNotification(string title, string message, string image=null, int displaytime=0)
        {
            var jArgs = new JObject();

             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             {
                 var jpropmessage = JToken.FromObject(message, _client.Serializer);
                 jArgs.Add(new JProperty("message", jpropmessage));
             }
             if (image != null)
             {
                 var jpropimage = JToken.FromObject(image, _client.Serializer);
                 jArgs.Add(new JProperty("image", jpropimage));
             }
             if (displaytime != null)
             {
                 var jpropdisplaytime = JToken.FromObject(displaytime, _client.Serializer);
                 jArgs.Add(new JProperty("displaytime", jpropdisplaytime));
             }
            return await _client.GetData<string>("GUI.ShowNotification", jArgs);
        }

                /// <summary>
                /// Shows a GUI notification
                /// </summary>
                /// <param name="title"> REQUIRED </param>
                /// <param name="message"> REQUIRED </param>
                /// <param name="displaytime"> The time in milliseconds the notification will be visible</param>
                /// <returns>string</returns>
        public async Task<string> ShowNotification(string title, string message, int displaytime=0)
        {
            var jArgs = new JObject();

             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             {
                 var jpropmessage = JToken.FromObject(message, _client.Serializer);
                 jArgs.Add(new JProperty("message", jpropmessage));
             }
             if (displaytime != null)
             {
                 var jpropdisplaytime = JToken.FromObject(displaytime, _client.Serializer);
                 jArgs.Add(new JProperty("displaytime", jpropdisplaytime));
             }
            return await _client.GetData<string>("GUI.ShowNotification", jArgs);
        }

        public delegate void OnDPMSActivatedDelegate(string sender, object data);
        public event OnDPMSActivatedDelegate OnDPMSActivated;
        internal void RaiseOnDPMSActivated(string sender, object data)
        {
            if (OnDPMSActivated != null)
            {
                OnDPMSActivated.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnDPMSDeactivatedDelegate(string sender, object data);
        public event OnDPMSDeactivatedDelegate OnDPMSDeactivated;
        internal void RaiseOnDPMSDeactivated(string sender, object data)
        {
            if (OnDPMSDeactivated != null)
            {
                OnDPMSDeactivated.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnScreensaverActivatedDelegate(string sender, object data);
        public event OnScreensaverActivatedDelegate OnScreensaverActivated;
        internal void RaiseOnScreensaverActivated(string sender, object data)
        {
            if (OnScreensaverActivated != null)
            {
                OnScreensaverActivated.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnScreensaverDeactivatedDelegate(string sender, XBMCRPC.GUI.OnScreensaverDeactivated_data data);
        public event OnScreensaverDeactivatedDelegate OnScreensaverDeactivated;
        internal void RaiseOnScreensaverDeactivated(string sender, XBMCRPC.GUI.OnScreensaverDeactivated_data data)
        {
            if (OnScreensaverDeactivated != null)
            {
                OnScreensaverDeactivated.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
