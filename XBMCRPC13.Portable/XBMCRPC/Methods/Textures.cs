using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
{
   public partial class Textures
   {
        private readonly Client _client;
          public Textures(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Retrieve all textures
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="filter"> </param>
                /// <returns>XBMCRPC.Textures.GetTexturesResponse</returns>
        public async Task<XBMCRPC.Textures.GetTexturesResponse> GetTextures(XBMCRPC.Textures.Fields.Texture properties=null, XBMCRPC.List.Filter.TexturesAnd filter=null)
        {
             var jArgs = new JObject();

             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            return await _client.GetData<XBMCRPC.Textures.GetTexturesResponse>("Textures.GetTextures", jArgs);
        }

                /// <summary>
                /// Retrieve all textures
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="filter"> </param>
                /// <returns>XBMCRPC.Textures.GetTexturesResponse</returns>
        public async Task<XBMCRPC.Textures.GetTexturesResponse> GetTextures(XBMCRPC.Textures.Fields.Texture properties=null, XBMCRPC.List.Filter.TexturesOr filter=null)
        {
             var jArgs = new JObject();

             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            return await _client.GetData<XBMCRPC.Textures.GetTexturesResponse>("Textures.GetTextures", jArgs);
        }

                /// <summary>
                /// Retrieve all textures
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="filter"> </param>
                /// <returns>XBMCRPC.Textures.GetTexturesResponse</returns>
        public async Task<XBMCRPC.Textures.GetTexturesResponse> GetTextures(XBMCRPC.Textures.Fields.Texture properties=null, XBMCRPC.List.Filter.Rule.Textures filter=null)
        {
             var jArgs = new JObject();

             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            return await _client.GetData<XBMCRPC.Textures.GetTexturesResponse>("Textures.GetTextures", jArgs);
        }

                /// <summary>
                /// Retrieve all textures
                /// </summary>
                /// <param name="properties"> </param>
                /// <returns>XBMCRPC.Textures.GetTexturesResponse</returns>
        public async Task<XBMCRPC.Textures.GetTexturesResponse> GetTextures(XBMCRPC.Textures.Fields.Texture properties=null)
        {
             var jArgs = new JObject();

             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<XBMCRPC.Textures.GetTexturesResponse>("Textures.GetTextures", jArgs);
        }

                /// <summary>
                /// Remove the specified texture
                /// </summary>
                /// <param name="textureid"> REQUIRED Texture database identifier</param>
                /// <returns>string</returns>
        public async Task<string> RemoveTexture(int? textureid=null)
        {
             var jArgs = new JObject();

             if (textureid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null textureid");
              }
             else
              {
                 var jproptextureid = JToken.FromObject(textureid, _client.Serializer);
                 jArgs.Add(new JProperty("textureid", jproptextureid));
              }
            return await _client.GetData<string>("Textures.RemoveTexture", jArgs);
        }
   }
}
