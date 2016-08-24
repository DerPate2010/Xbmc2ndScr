using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
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
        public async Task<string> AddFavourite(string title, XBMCRPC.Favourite.Type? type, string path=null, string window=null, string windowparameter=null, string thumbnail=null)
        {
            var jArgs = new JObject();

             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
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
                /// <returns>XBMCRPC.Favourites.GetFavouritesResponse</returns>
        public async Task<XBMCRPC.Favourites.GetFavouritesResponse> GetFavourites(XBMCRPC.Favourite.Type? type=null, XBMCRPC.Favourite.Fields.Favourite properties=null)
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
            return await _client.GetData<XBMCRPC.Favourites.GetFavouritesResponse>("Favourites.GetFavourites", jArgs);
        }
   }
}
