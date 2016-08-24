using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
{
   public partial class XBMC
   {
        private readonly Client _client;
          public XBMC(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Retrieve info booleans about Kodi and the system
                /// </summary>
                /// <param name="booleans"> REQUIRED </param>
                /// <returns>XBMCRPC.XBMC.GetInfoBooleansResponse</returns>
        public async Task<XBMCRPC.XBMC.GetInfoBooleansResponse> GetInfoBooleans(global::System.Collections.Generic.List<string> booleans)
        {
            var jArgs = new JObject();

             {
                 var jpropbooleans = JToken.FromObject(booleans, _client.Serializer);
                 jArgs.Add(new JProperty("booleans", jpropbooleans));
             }
            return await _client.GetData<XBMCRPC.XBMC.GetInfoBooleansResponse>("XBMC.GetInfoBooleans", jArgs);
        }

                /// <summary>
                /// Retrieve info labels about Kodi and the system
                /// </summary>
                /// <param name="labels"> REQUIRED See http://kodi.wiki/view/InfoLabels for a list of possible info labels</param>
                /// <returns>XBMCRPC.XBMC.GetInfoLabelsResponse</returns>
        public async Task<XBMCRPC.XBMC.GetInfoLabelsResponse> GetInfoLabels(global::System.Collections.Generic.List<string> labels)
        {
            var jArgs = new JObject();

             {
                 var jproplabels = JToken.FromObject(labels, _client.Serializer);
                 jArgs.Add(new JProperty("labels", jproplabels));
             }
            return await _client.GetData<XBMCRPC.XBMC.GetInfoLabelsResponse>("XBMC.GetInfoLabels", jArgs);
        }
   }
}
