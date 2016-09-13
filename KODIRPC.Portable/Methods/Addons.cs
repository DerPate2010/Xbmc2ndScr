using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace KODIRPC.Methods
{
   public partial class Addons
   {
        private readonly Client _client;
          public Addons(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Executes the given addon with the given parameters (if possible)
                /// </summary>
                /// <param name="addonid"> REQUIRED </param>
                /// <param name="params_arg"> </param>
                /// <param name="wait"> </param>
                /// <returns>string</returns>
        public async Task<string> ExecuteAddon(string addonid=null, KODIRPC.Addons.ExecuteAddon_params1 params_arg=null, bool? wait=null)
        {
             var jArgs = new JObject();

             if (addonid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null addonid");
              }
             else
              {
                 var jpropaddonid = JToken.FromObject(addonid, _client.Serializer);
                 jArgs.Add(new JProperty("addonid", jpropaddonid));
              }
             if (params_arg != null)
             {
                 var jpropparams_arg = JToken.FromObject(params_arg, _client.Serializer);
                 jArgs.Add(new JProperty("params_arg", jpropparams_arg));
             }
             if (wait != null)
             {
                 var jpropwait = JToken.FromObject(wait, _client.Serializer);
                 jArgs.Add(new JProperty("wait", jpropwait));
             }
            return await _client.GetData<string>("Addons.ExecuteAddon", jArgs);
        }

                /// <summary>
                /// Executes the given addon with the given parameters (if possible)
                /// </summary>
                /// <param name="addonid"> REQUIRED </param>
                /// <param name="params_arg"> </param>
                /// <param name="wait"> </param>
                /// <returns>string</returns>
        public async Task<string> ExecuteAddon(string addonid=null, global::System.Collections.Generic.List<string> params_arg=null, bool? wait=null)
        {
             var jArgs = new JObject();

             if (addonid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null addonid");
              }
             else
              {
                 var jpropaddonid = JToken.FromObject(addonid, _client.Serializer);
                 jArgs.Add(new JProperty("addonid", jpropaddonid));
              }
             if (params_arg != null)
             {
                 var jpropparams_arg = JToken.FromObject(params_arg, _client.Serializer);
                 jArgs.Add(new JProperty("params_arg", jpropparams_arg));
             }
             if (wait != null)
             {
                 var jpropwait = JToken.FromObject(wait, _client.Serializer);
                 jArgs.Add(new JProperty("wait", jpropwait));
             }
            return await _client.GetData<string>("Addons.ExecuteAddon", jArgs);
        }

                /// <summary>
                /// Executes the given addon with the given parameters (if possible)
                /// </summary>
                /// <param name="addonid"> REQUIRED </param>
                /// <param name="params_arg"> </param>
                /// <param name="wait"> </param>
                /// <returns>string</returns>
        public async Task<string> ExecuteAddon(string addonid=null, string params_arg=null, bool? wait=null)
        {
             var jArgs = new JObject();

             if (addonid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null addonid");
              }
             else
              {
                 var jpropaddonid = JToken.FromObject(addonid, _client.Serializer);
                 jArgs.Add(new JProperty("addonid", jpropaddonid));
              }
             if (params_arg != null)
             {
                 var jpropparams_arg = JToken.FromObject(params_arg, _client.Serializer);
                 jArgs.Add(new JProperty("params_arg", jpropparams_arg));
             }
             if (wait != null)
             {
                 var jpropwait = JToken.FromObject(wait, _client.Serializer);
                 jArgs.Add(new JProperty("wait", jpropwait));
             }
            return await _client.GetData<string>("Addons.ExecuteAddon", jArgs);
        }

                /// <summary>
                /// Executes the given addon with the given parameters (if possible)
                /// </summary>
                /// <param name="addonid"> REQUIRED </param>
                /// <param name="wait"> </param>
                /// <returns>string</returns>
        public async Task<string> ExecuteAddon(string addonid=null, bool? wait=null)
        {
             var jArgs = new JObject();

             if (addonid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null addonid");
              }
             else
              {
                 var jpropaddonid = JToken.FromObject(addonid, _client.Serializer);
                 jArgs.Add(new JProperty("addonid", jpropaddonid));
              }
             if (wait != null)
             {
                 var jpropwait = JToken.FromObject(wait, _client.Serializer);
                 jArgs.Add(new JProperty("wait", jpropwait));
             }
            return await _client.GetData<string>("Addons.ExecuteAddon", jArgs);
        }

                /// <summary>
                /// Gets the details of a specific addon
                /// </summary>
                /// <param name="addonid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.Addons.GetAddonDetailsResponse</returns>
        public async Task<KODIRPC.Addons.GetAddonDetailsResponse> GetAddonDetails(string addonid=null, KODIRPC.Addon.Fields properties=null)
        {
             var jArgs = new JObject();

             if (addonid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null addonid");
              }
             else
              {
                 var jpropaddonid = JToken.FromObject(addonid, _client.Serializer);
                 jArgs.Add(new JProperty("addonid", jpropaddonid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.Addons.GetAddonDetailsResponse>("Addons.GetAddonDetails", jArgs);
        }

                /// <summary>
                /// Gets all available addons
                /// </summary>
                /// <param name="type"> </param>
                /// <param name="content"> Content provided by the addon. Only considered for plugins and scripts.</param>
                /// <param name="enabled"> </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>KODIRPC.Addons.GetAddonsResponse</returns>
        public async Task<KODIRPC.Addons.GetAddonsResponse> GetAddons(KODIRPC.Addon.Types? type=null, KODIRPC.Addon.Content? content=null, bool? enabled=null, KODIRPC.Addon.Fields properties=null, KODIRPC.List.Limits limits=null)
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
            return await _client.GetData<KODIRPC.Addons.GetAddonsResponse>("Addons.GetAddons", jArgs);
        }

                /// <summary>
                /// Gets all available addons
                /// </summary>
                /// <param name="type"> </param>
                /// <param name="content"> Content provided by the addon. Only considered for plugins and scripts.</param>
                /// <param name="enabled"> </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>KODIRPC.Addons.GetAddonsResponse</returns>
        public async Task<KODIRPC.Addons.GetAddonsResponse> GetAddons(KODIRPC.Addon.Types? type=null, KODIRPC.Addon.Content? content=null, KODIRPC.Addons.GetAddons_enabled2? enabled=null, KODIRPC.Addon.Fields properties=null, KODIRPC.List.Limits limits=null)
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
            return await _client.GetData<KODIRPC.Addons.GetAddonsResponse>("Addons.GetAddons", jArgs);
        }

                /// <summary>
                /// Gets all available addons
                /// </summary>
                /// <param name="type"> </param>
                /// <param name="content"> Content provided by the addon. Only considered for plugins and scripts.</param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>KODIRPC.Addons.GetAddonsResponse</returns>
        public async Task<KODIRPC.Addons.GetAddonsResponse> GetAddons(KODIRPC.Addon.Types? type=null, KODIRPC.Addon.Content? content=null, KODIRPC.Addon.Fields properties=null, KODIRPC.List.Limits limits=null)
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
            return await _client.GetData<KODIRPC.Addons.GetAddonsResponse>("Addons.GetAddons", jArgs);
        }

                /// <summary>
                /// Enables/Disables a specific addon
                /// </summary>
                /// <param name="addonid"> REQUIRED </param>
                /// <param name="enabled"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetAddonEnabled(string addonid=null, bool? enabled=null)
        {
             var jArgs = new JObject();

             if (addonid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null addonid");
              }
             else
              {
                 var jpropaddonid = JToken.FromObject(addonid, _client.Serializer);
                 jArgs.Add(new JProperty("addonid", jpropaddonid));
              }
             if (enabled == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null enabled");
              }
             else
              {
                 var jpropenabled = JToken.FromObject(enabled, _client.Serializer);
                 jArgs.Add(new JProperty("enabled", jpropenabled));
              }
            return await _client.GetData<string>("Addons.SetAddonEnabled", jArgs);
        }

                /// <summary>
                /// Enables/Disables a specific addon
                /// </summary>
                /// <param name="addonid"> REQUIRED </param>
                /// <param name="enabled"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetAddonEnabled(string addonid=null, KODIRPC.Global.Toggle2? enabled=null)
        {
             var jArgs = new JObject();

             if (addonid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null addonid");
              }
             else
              {
                 var jpropaddonid = JToken.FromObject(addonid, _client.Serializer);
                 jArgs.Add(new JProperty("addonid", jpropaddonid));
              }
             if (enabled == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null enabled");
              }
             else
              {
                 var jpropenabled = JToken.FromObject(enabled, _client.Serializer);
                 jArgs.Add(new JProperty("enabled", jpropenabled));
              }
            return await _client.GetData<string>("Addons.SetAddonEnabled", jArgs);
        }

                /// <summary>
                /// Enables/Disables a specific addon
                /// </summary>
                /// <param name="addonid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetAddonEnabled(string addonid=null)
        {
             var jArgs = new JObject();

             if (addonid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null addonid");
              }
             else
              {
                 var jpropaddonid = JToken.FromObject(addonid, _client.Serializer);
                 jArgs.Add(new JProperty("addonid", jpropaddonid));
              }
            return await _client.GetData<string>("Addons.SetAddonEnabled", jArgs);
        }
   }
}
