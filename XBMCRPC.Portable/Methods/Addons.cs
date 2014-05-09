using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace XBMCRPC.Methods
{
   public partial class Addons
   {
        private readonly Client _client;
          public Addons(Client client)
          {
              _client = client;
          }

        async public Task<string> ExecuteAddon(string addonid=null, bool wait=false)
        {
            var jArgs = new JObject();
             if (addonid != null)
             {
                 var jpropaddonid = JToken.FromObject(addonid, _client.Serializer);
                 jArgs.Add(new JProperty("addonid", jpropaddonid));
             }
             if (wait != null)
             {
                 var jpropwait = JToken.FromObject(wait, _client.Serializer);
                 jArgs.Add(new JProperty("wait", jpropwait));
             }
            var jRet = await _client.GetData<string>("Addons.ExecuteAddon", jArgs);
            return jRet;
        }

        async public Task<string> ExecuteAddon2(string addonid=null, string[] params_arg=null, bool wait=false)
        {
            var jArgs = new JObject();
             if (addonid != null)
             {
                 var jpropaddonid = JToken.FromObject(addonid, _client.Serializer);
                 jArgs.Add(new JProperty("addonid", jpropaddonid));
             }
             if (params_arg != null)
             {
                 var jpropparams_arg = JToken.FromObject(params_arg, _client.Serializer);
                 jArgs.Add(new JProperty("params", jpropparams_arg));
             }
             if (wait != null)
             {
                 var jpropwait = JToken.FromObject(wait, _client.Serializer);
                 jArgs.Add(new JProperty("wait", jpropwait));
             }
            var jRet = await _client.GetData<string>("Addons.ExecuteAddon", jArgs);
            return jRet;
        }
   public class GetAddonDetailsResponse
   {
       public XBMCRPC.Addon.Details addon {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetAddonDetailsResponse> GetAddonDetails(string addonid=null, XBMCRPC.Addon.Fields properties=null)
        {
            var jArgs = new JObject();
             if (addonid != null)
             {
                 var jpropaddonid = JToken.FromObject(addonid, _client.Serializer);
                 jArgs.Add(new JProperty("addonid", jpropaddonid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<GetAddonDetailsResponse>("Addons.GetAddonDetails", jArgs);
            return jRet;
        }
   public class GetAddonsResponse
   {
       public XBMCRPC.Addon.Details[] addons {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetAddonsResponse> GetAddons(XBMCRPC.Addon.Types type=0, XBMCRPC.Addon.Content content=0, XBMCRPC.Addon.Fields properties=null, XBMCRPC.List.Limits limits=null)
        {
            var jArgs = new JObject();
             if (type != null)
             {
                 var jproptype = JToken.FromObject(type, _client.Serializer);
                 jArgs.Add(new JProperty("type", jproptype));
             }
             if (content != null)
             {
                 var jpropcontent = JToken.FromObject(content, _client.Serializer);
                 jArgs.Add(new JProperty("content", jpropcontent));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
             if (limits != null)
             {
                 var jproplimits = JToken.FromObject(limits, _client.Serializer);
                 jArgs.Add(new JProperty("limits", jproplimits));
             }
            var jRet = await _client.GetData<GetAddonsResponse>("Addons.GetAddons", jArgs);
            return jRet;
        }

        async public Task<GetAddonsResponse> GetAddons2(XBMCRPC.Addon.Types type=0, XBMCRPC.Addon.Content content=0, bool enabled=false, XBMCRPC.Addon.Fields properties=null, XBMCRPC.List.Limits limits=null)
        {
            var jArgs = new JObject();
             if (type != null)
             {
                 var jproptype = JToken.FromObject(type, _client.Serializer);
                 jArgs.Add(new JProperty("type", jproptype));
             }
             if (content != null)
             {
                 var jpropcontent = JToken.FromObject(content, _client.Serializer);
                 jArgs.Add(new JProperty("content", jpropcontent));
             }
             if (enabled != null)
             {
                 var jpropenabled = JToken.FromObject(enabled, _client.Serializer);
                 jArgs.Add(new JProperty("enabled", jpropenabled));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
             if (limits != null)
             {
                 var jproplimits = JToken.FromObject(limits, _client.Serializer);
                 jArgs.Add(new JProperty("limits", jproplimits));
             }
            var jRet = await _client.GetData<GetAddonsResponse>("Addons.GetAddons", jArgs);
            return jRet;
        }
   public enum GetAddonsenabled
   {
       all,
   }

        async public Task<GetAddonsResponse> GetAddons2(XBMCRPC.Addon.Types type=0, XBMCRPC.Addon.Content content=0, GetAddonsenabled enabled=0, XBMCRPC.Addon.Fields properties=null, XBMCRPC.List.Limits limits=null)
        {
            var jArgs = new JObject();
             if (type != null)
             {
                 var jproptype = JToken.FromObject(type, _client.Serializer);
                 jArgs.Add(new JProperty("type", jproptype));
             }
             if (content != null)
             {
                 var jpropcontent = JToken.FromObject(content, _client.Serializer);
                 jArgs.Add(new JProperty("content", jpropcontent));
             }
             if (enabled != null)
             {
                 var jpropenabled = JToken.FromObject(enabled, _client.Serializer);
                 jArgs.Add(new JProperty("enabled", jpropenabled));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
             if (limits != null)
             {
                 var jproplimits = JToken.FromObject(limits, _client.Serializer);
                 jArgs.Add(new JProperty("limits", jproplimits));
             }
            var jRet = await _client.GetData<GetAddonsResponse>("Addons.GetAddons", jArgs);
            return jRet;
        }

        async public Task<string> SetAddonEnabled(string addonid=null, XBMCRPC.Global.Toggle enabled=0)
        {
            var jArgs = new JObject();
             if (addonid != null)
             {
                 var jpropaddonid = JToken.FromObject(addonid, _client.Serializer);
                 jArgs.Add(new JProperty("addonid", jpropaddonid));
             }
             if (enabled != null)
             {
                 var jpropenabled = JToken.FromObject(enabled, _client.Serializer);
                 jArgs.Add(new JProperty("enabled", jpropenabled));
             }
            var jRet = await _client.GetData<string>("Addons.SetAddonEnabled", jArgs);
            return jRet;
        }
   }
}
