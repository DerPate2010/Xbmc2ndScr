using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace XBMCRPC.Methods
{
   public partial class GUI
   {
        private readonly Client _client;
          public GUI(Client client)
          {
              _client = client;
          }

        async public Task<string> ActivateWindow(XBMCRPC.GUI.Window window=0, string[] parameters=null)
        {
            var jArgs = new JObject();
             if (window != null)
             {
                 var jpropwindow = JToken.FromObject(window, _client.Serializer);
                 jArgs.Add(new JProperty("window", jpropwindow));
             }
             if (parameters != null)
             {
                 var jpropparameters = JToken.FromObject(parameters, _client.Serializer);
                 jArgs.Add(new JProperty("parameters", jpropparameters));
             }
            var jRet = await _client.GetData<string>("GUI.ActivateWindow", jArgs);
            return jRet;
        }

        async public Task<XBMCRPC.GUI.Property.Value> GetProperties(XBMCRPC.GUI.Property.Name[] properties=null)
        {
            var jArgs = new JObject();
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<XBMCRPC.GUI.Property.Value>("GUI.GetProperties", jArgs);
            return jRet;
        }

        async public Task<bool> SetFullscreen(XBMCRPC.Global.Toggle fullscreen=0)
        {
            var jArgs = new JObject();
             if (fullscreen != null)
             {
                 var jpropfullscreen = JToken.FromObject(fullscreen, _client.Serializer);
                 jArgs.Add(new JProperty("fullscreen", jpropfullscreen));
             }
            var jRet = await _client.GetData<bool>("GUI.SetFullscreen", jArgs);
            return jRet;
        }

        async public Task<string> ShowNotification(string title=null, string message=null, int displaytime=0)
        {
            var jArgs = new JObject();
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             if (message != null)
             {
                 var jpropmessage = JToken.FromObject(message, _client.Serializer);
                 jArgs.Add(new JProperty("message", jpropmessage));
             }
             if (displaytime != null)
             {
                 var jpropdisplaytime = JToken.FromObject(displaytime, _client.Serializer);
                 jArgs.Add(new JProperty("displaytime", jpropdisplaytime));
             }
            var jRet = await _client.GetData<string>("GUI.ShowNotification", jArgs);
            return jRet;
        }
   public enum ShowNotificationimage
   {
       info,
       warning,
       error,
   }

        async public Task<string> ShowNotification2(string title=null, string message=null, ShowNotificationimage image=0, int displaytime=0)
        {
            var jArgs = new JObject();
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             if (message != null)
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
            var jRet = await _client.GetData<string>("GUI.ShowNotification", jArgs);
            return jRet;
        }

        async public Task<string> ShowNotification2(string title=null, string message=null, string image=null, int displaytime=0)
        {
            var jArgs = new JObject();
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             if (message != null)
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
            var jRet = await _client.GetData<string>("GUI.ShowNotification", jArgs);
            return jRet;
        }
   }
}
