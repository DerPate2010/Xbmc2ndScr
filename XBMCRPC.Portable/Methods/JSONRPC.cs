using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace XBMCRPC.Methods
{
   public partial class JSONRPC
   {
        private readonly Client _client;
          public JSONRPC(Client client)
          {
              _client = client;
          }
   public class filterType
   {
       public bool getreferences {get;set;}
       public string id {get;set;}
   public enum typeEnum
   {
       method,
       [global::System.Runtime.Serialization.EnumMember(Value="namespace")]
       Namespace,
       type,
       notification,
   }
       public typeEnum type {get;set;}
   }

        async public Task<JObject> Introspect(bool getdescriptions=false, bool getmetadata=false, bool filterbytransport=false, filterType filter=null)
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
            var jRet = await _client.GetData<JObject>("JSONRPC.Introspect", jArgs);
            return jRet;
        }

        async public Task<JObject> NotifyAll(string sender=null, string message=null)
        {
            var jArgs = new JObject();
             if (sender != null)
             {
                 var jpropsender = JToken.FromObject(sender, _client.Serializer);
                 jArgs.Add(new JProperty("sender", jpropsender));
             }
             if (message != null)
             {
                 var jpropmessage = JToken.FromObject(message, _client.Serializer);
                 jArgs.Add(new JProperty("message", jpropmessage));
             }
            var jRet = await _client.GetData<JObject>("JSONRPC.NotifyAll", jArgs);
            return jRet;
        }
   public class PermissionResponse
   {
       public bool controlgui {get;set;}
       public bool controlnotify {get;set;}
       public bool controlplayback {get;set;}
       public bool controlpower {get;set;}
       public bool controlpvr {get;set;}
       public bool controlsystem {get;set;}
       public bool executeaddon {get;set;}
       public bool manageaddon {get;set;}
       public bool navigate {get;set;}
       public bool readdata {get;set;}
       public bool removedata {get;set;}
       public bool updatedata {get;set;}
       public bool writefile {get;set;}
   }

        async public Task<PermissionResponse> Permission()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<PermissionResponse>("JSONRPC.Permission", jArgs);
            return jRet;
        }

        async public Task<string> Ping()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("JSONRPC.Ping", jArgs);
            return jRet;
        }
   public class VersionResponse
   {
       public int major {get;set;}
       public int minor {get;set;}
       public int patch {get;set;}
   }

        async public Task<VersionResponse> Version()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<VersionResponse>("JSONRPC.Version", jArgs);
            return jRet;
        }
   }
}
