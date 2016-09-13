using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace KODIRPC.Methods
{
   public partial class Favourites
   {
        private readonly Client _client;
          public Favourites(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Add a favourite with the given details
                /// </summary>
                /// <param name="title"> REQUIRED </param>
                /// <param name="type"> REQUIRED </param>
                /// <param name="path"> Required for media and script favourites types</param>
                /// <param name="window"> Required for window favourite type</param>
                /// <param name="windowparameter"> </param>
                /// <param name="thumbnail"> </param>
                /// <returns>string</returns>
        public async Task<string> AddFavourite(string title=null, KODIRPC.Favourite.Type? type=null, string path=null, string window=null, string windowparameter=null, string thumbnail=null)
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
             if (type == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null type");
              }
             else
              {
                 var jproptype = JToken.FromObject(type, _client.Serializer);
                 jArgs.Add(new JProperty("type", jproptype));
              }
             if (path != null)
             {
                 var jproppath = JToken.FromObject(path, _client.Serializer);
                 jArgs.Add(new JProperty("path", jproppath));
             }
             if (window != null)
             {
                 var jpropwindow = JToken.FromObject(window, _client.Serializer);
                 jArgs.Add(new JProperty("window", jpropwindow));
             }
             if (windowparameter != null)
             {
                 var jpropwindowparameter = JToken.FromObject(windowparameter, _client.Serializer);
                 jArgs.Add(new JProperty("windowparameter", jpropwindowparameter));
             }
             if (thumbnail != null)
             {
                 var jpropthumbnail = JToken.FromObject(thumbnail, _client.Serializer);
                 jArgs.Add(new JProperty("thumbnail", jpropthumbnail));
             }
            return await _client.GetData<string>("Favourites.AddFavourite", jArgs);
        }

                /// <summary>
                /// Retrieve all favourites
                /// </summary>
                /// <param name="type"> </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.Favourites.GetFavouritesResponse</returns>
        public async Task<KODIRPC.Favourites.GetFavouritesResponse> GetFavourites(KODIRPC.Favourite.Type? type=null, KODIRPC.Favourite.Fields.Favourite properties=null)
        {
             var jArgs = new JObject();

             if (type != null)
             {
                 var jproptype = JToken.FromObject(type, _client.Serializer);
                 jArgs.Add(new JProperty("type", jproptype));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.Favourites.GetFavouritesResponse>("Favourites.GetFavourites", jArgs);
        }
   }
}
