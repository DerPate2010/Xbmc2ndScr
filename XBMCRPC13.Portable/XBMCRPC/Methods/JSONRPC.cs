using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
{
   public partial class JSONRPC
   {
        private readonly Client _client;
          public JSONRPC(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Enumerates all actions and descriptions
                /// </summary>
                /// <param name="getdescriptions"> </param>
                /// <param name="getmetadata"> </param>
                /// <param name="filterbytransport"> </param>
                /// <param name="filter"> </param>
                /// <returns>XBMCRPC.JSONRPC.IntrospectResponse</returns>
        public async Task<XBMCRPC.JSONRPC.IntrospectResponse> Introspect(bool? getdescriptions=null, bool? getmetadata=null, bool? filterbytransport=null, XBMCRPC.JSONRPC.Introspect_filter filter=null)
        {
             var jArgs = new JObject();

             if (getdescriptions != null)
             {
                 var jpropgetdescriptions = JToken.FromObject(getdescriptions, _client.Serializer);
                 jArgs.Add(new JProperty("getdescriptions", jpropgetdescriptions));
             }
             if (getmetadata != null)
             {
                 var jpropgetmetadata = JToken.FromObject(getmetadata, _client.Serializer);
                 jArgs.Add(new JProperty("getmetadata", jpropgetmetadata));
             }
             if (filterbytransport != null)
             {
                 var jpropfilterbytransport = JToken.FromObject(filterbytransport, _client.Serializer);
                 jArgs.Add(new JProperty("filterbytransport", jpropfilterbytransport));
             }
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            return await _client.GetData<XBMCRPC.JSONRPC.IntrospectResponse>("JSONRPC.Introspect", jArgs);
        }

                /// <summary>
                /// Notify all other connected clients
                /// </summary>
                /// <param name="sender"> REQUIRED </param>
                /// <param name="message"> REQUIRED </param>
                /// <param name="data"> </param>
                /// <returns>object</returns>
        public async Task<object> NotifyAll(string sender=null, string message=null, object data=null)
        {
             var jArgs = new JObject();

             if (sender == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null sender");
              }
             else
              {
                 var jpropsender = JToken.FromObject(sender, _client.Serializer);
                 jArgs.Add(new JProperty("sender", jpropsender));
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
             if (data != null)
             {
                 var jpropdata = JToken.FromObject(data, _client.Serializer);
                 jArgs.Add(new JProperty("data", jpropdata));
             }
            return await _client.GetData<object>("JSONRPC.NotifyAll", jArgs);
        }

                /// <summary>
                /// Retrieve the clients permissions
                /// </summary>
                /// <returns>XBMCRPC.JSONRPC.PermissionResponse</returns>
        public async Task<XBMCRPC.JSONRPC.PermissionResponse> Permission()
        {
            return await _client.GetData<XBMCRPC.JSONRPC.PermissionResponse>("JSONRPC.Permission",null);
        }

                /// <summary>
                /// Ping responder
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Ping()
        {
            return await _client.GetData<string>("JSONRPC.Ping",null);
        }

                /// <summary>
                /// Retrieve the JSON-RPC protocol version.
                /// </summary>
                /// <returns>XBMCRPC.JSONRPC.VersionResponse</returns>
        public async Task<XBMCRPC.JSONRPC.VersionResponse> Version()
        {
            return await _client.GetData<XBMCRPC.JSONRPC.VersionResponse>("JSONRPC.Version",null);
        }
   }
}
