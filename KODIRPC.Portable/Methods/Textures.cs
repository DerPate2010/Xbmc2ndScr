using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace KODIRPC.Methods
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
                /// <returns>KODIRPC.Textures.GetTexturesResponse</returns>
        public async Task<KODIRPC.Textures.GetTexturesResponse> GetTextures(KODIRPC.Textures.Fields.Texture properties=null, KODIRPC.List.Filter.TexturesAnd filter=null)
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
            return await _client.GetData<KODIRPC.Textures.GetTexturesResponse>("Textures.GetTextures", jArgs);
        }

                /// <summary>
                /// Retrieve all textures
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.Textures.GetTexturesResponse</returns>
        public async Task<KODIRPC.Textures.GetTexturesResponse> GetTextures(KODIRPC.Textures.Fields.Texture properties=null, KODIRPC.List.Filter.TexturesOr filter=null)
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
            return await _client.GetData<KODIRPC.Textures.GetTexturesResponse>("Textures.GetTextures", jArgs);
        }

                /// <summary>
                /// Retrieve all textures
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.Textures.GetTexturesResponse</returns>
        public async Task<KODIRPC.Textures.GetTexturesResponse> GetTextures(KODIRPC.Textures.Fields.Texture properties=null, KODIRPC.List.Filter.Rule.Textures filter=null)
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
            return await _client.GetData<KODIRPC.Textures.GetTexturesResponse>("Textures.GetTextures", jArgs);
        }

                /// <summary>
                /// Retrieve all textures
                /// </summary>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.Textures.GetTexturesResponse</returns>
        public async Task<KODIRPC.Textures.GetTexturesResponse> GetTextures(KODIRPC.Textures.Fields.Texture properties=null)
        {
             var jArgs = new JObject();

             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.Textures.GetTexturesResponse>("Textures.GetTextures", jArgs);
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
