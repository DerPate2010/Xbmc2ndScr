using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace KODIRPC.Methods
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
        public async Task<string> ActivateWindow(KODIRPC.GUI.Window? window=null, global::System.Collections.Generic.List<string> parameters=null)
        {
             var jArgs = new JObject();

             if (window == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null window");
              }
             else
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
                /// <returns>KODIRPC.GUI.Property.Value</returns>
        public async Task<KODIRPC.GUI.Property.Value> GetProperties(KODIRPC.GUI.GetProperties_properties properties=null)
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
            return await _client.GetData<KODIRPC.GUI.Property.Value>("GUI.GetProperties", jArgs);
        }

                /// <summary>
                /// Returns the supported stereoscopic modes of the GUI
                /// </summary>
                /// <returns>KODIRPC.GUI.GetStereoscopicModesResponse</returns>
        public async Task<KODIRPC.GUI.GetStereoscopicModesResponse> GetStereoscopicModes()
        {
            return await _client.GetData<KODIRPC.GUI.GetStereoscopicModesResponse>("GUI.GetStereoscopicModes",null);
        }

                /// <summary>
                /// Toggle fullscreen/GUI
                /// </summary>
                /// <param name="fullscreen"> REQUIRED </param>
                /// <returns>bool</returns>
        public async Task<bool> SetFullscreen(bool? fullscreen=null)
        {
             var jArgs = new JObject();

             if (fullscreen == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null fullscreen");
              }
             else
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
        public async Task<bool> SetFullscreen(KODIRPC.Global.Toggle2? fullscreen=null)
        {
             var jArgs = new JObject();

             if (fullscreen == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null fullscreen");
              }
             else
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
        public async Task<string> SetStereoscopicMode(KODIRPC.GUI.SetStereoscopicMode_mode? mode=null)
        {
             var jArgs = new JObject();

             if (mode == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null mode");
              }
             else
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
        public async Task<string> ShowNotification(string title=null, string message=null, KODIRPC.GUI.ShowNotification_image1? image=null, int? displaytime=null)
        {
             var jArgs = new JObject();

             if (title == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null title");
              }
             else
              {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
              }
             if (message == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null message");
              }
             else
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
        public async Task<string> ShowNotification(string title=null, string message=null, string image=null, int? displaytime=null)
        {
             var jArgs = new JObject();

             if (title == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null title");
              }
             else
              {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
              }
             if (message == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null message");
              }
             else
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
        public async Task<string> ShowNotification(string title=null, string message=null, int? displaytime=null)
        {
             var jArgs = new JObject();

             if (title == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null title");
              }
             else
              {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
              }
             if (message == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null message");
              }
             else
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

        public delegate void OnDPMSActivatedDelegate(string sender=null, object data=null);
        public event OnDPMSActivatedDelegate OnDPMSActivated;
        internal void RaiseOnDPMSActivated(string sender=null, object data=null)
        {
            if (OnDPMSActivated != null)
            {
                OnDPMSActivated.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnDPMSDeactivatedDelegate(string sender=null, object data=null);
        public event OnDPMSDeactivatedDelegate OnDPMSDeactivated;
        internal void RaiseOnDPMSDeactivated(string sender=null, object data=null)
        {
            if (OnDPMSDeactivated != null)
            {
                OnDPMSDeactivated.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnScreensaverActivatedDelegate(string sender=null, object data=null);
        public event OnScreensaverActivatedDelegate OnScreensaverActivated;
        internal void RaiseOnScreensaverActivated(string sender=null, object data=null)
        {
            if (OnScreensaverActivated != null)
            {
                OnScreensaverActivated.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnScreensaverDeactivatedDelegate(string sender=null, KODIRPC.GUI.OnScreensaverDeactivated_data data=null);
        public event OnScreensaverDeactivatedDelegate OnScreensaverDeactivated;
        internal void RaiseOnScreensaverDeactivated(string sender=null, KODIRPC.GUI.OnScreensaverDeactivated_data data=null)
        {
            if (OnScreensaverDeactivated != null)
            {
                OnScreensaverDeactivated.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
