using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace XBMCRPC.Methods
{
   public partial class XBMC
   {
        private readonly Client _client;
          public XBMC(Client client)
          {
              _client = client;
          }

        async public Task<JObject> GetInfoBooleans(string[] booleans=null)
        {
            var jArgs = new JObject();
             if (booleans != null)
             {
                 var jpropbooleans = JToken.FromObject(booleans, _client.Serializer);
                 jArgs.Add(new JProperty("booleans", jpropbooleans));
             }
            var jRet = await _client.GetData<JObject>("XBMC.GetInfoBooleans", jArgs);
            return jRet;
        }

        async public Task<JObject> GetInfoLabels(string[] labels=null)
        {
            var jArgs = new JObject();
             if (labels != null)
             {
                 var jproplabels = JToken.FromObject(labels, _client.Serializer);
                 jArgs.Add(new JProperty("labels", jproplabels));
             }
            var jRet = await _client.GetData<JObject>("XBMC.GetInfoLabels", jArgs);
            return jRet;
        }
   }
}
