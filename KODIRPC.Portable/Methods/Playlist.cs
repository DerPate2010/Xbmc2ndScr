using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace KODIRPC.Methods
{
   public partial class Playlist
   {
        private readonly Client _client;
          public Playlist(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Add item(s) to playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Add(int? playlistid=null, KODIRPC.Playlist.ItemFile item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Add", jArgs);
        }

                /// <summary>
                /// Add item(s) to playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Add(int? playlistid=null, KODIRPC.Playlist.Item1 item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Add", jArgs);
        }

                /// <summary>
                /// Add item(s) to playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Add(int? playlistid=null, KODIRPC.Playlist.ItemMovieid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Add", jArgs);
        }

                /// <summary>
                /// Add item(s) to playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Add(int? playlistid=null, KODIRPC.Playlist.ItemEpisodeid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Add", jArgs);
        }

                /// <summary>
                /// Add item(s) to playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Add(int? playlistid=null, KODIRPC.Playlist.ItemMusicvideoid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Add", jArgs);
        }

                /// <summary>
                /// Add item(s) to playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Add(int? playlistid=null, KODIRPC.Playlist.ItemArtistid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Add", jArgs);
        }

                /// <summary>
                /// Add item(s) to playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Add(int? playlistid=null, KODIRPC.Playlist.ItemAlbumid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Add", jArgs);
        }

                /// <summary>
                /// Add item(s) to playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Add(int? playlistid=null, KODIRPC.Playlist.ItemSongid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Add", jArgs);
        }

                /// <summary>
                /// Add item(s) to playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Add(int? playlistid=null, KODIRPC.Playlist.ItemGenreid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Add", jArgs);
        }

                /// <summary>
                /// Add item(s) to playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Add(int? playlistid=null, global::System.Collections.Generic.List<object> item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Add", jArgs);
        }

                /// <summary>
                /// Add item(s) to playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Add(int? playlistid=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
            return await _client.GetData<string>("Playlist.Add", jArgs);
        }

                /// <summary>
                /// Clear playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Clear(int? playlistid=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
            return await _client.GetData<string>("Playlist.Clear", jArgs);
        }

                /// <summary>
                /// Get all items from playlist
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.Playlist.GetItemsResponse</returns>
        public async Task<KODIRPC.Playlist.GetItemsResponse> GetItems(int? playlistid=null, KODIRPC.List.Fields.All properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
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
             if (sort != null)
             {
                 var jpropsort = JToken.FromObject(sort, _client.Serializer);
                 jArgs.Add(new JProperty("sort", jpropsort));
             }
            return await _client.GetData<KODIRPC.Playlist.GetItemsResponse>("Playlist.GetItems", jArgs);
        }

                /// <summary>
                /// Returns all existing playlists
                /// </summary>
                /// <returns>global::System.Collections.Generic.List<KODIRPC.Playlist.GetPlaylistsResponseItem></returns>
        public async Task<global::System.Collections.Generic.List<KODIRPC.Playlist.GetPlaylistsResponseItem>> GetPlaylists()
        {
            return await _client.GetData<global::System.Collections.Generic.List<KODIRPC.Playlist.GetPlaylistsResponseItem>>("Playlist.GetPlaylists",null);
        }

                /// <summary>
                /// Retrieves the values of the given properties
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="properties"> REQUIRED </param>
                /// <returns>KODIRPC.Playlist.Property.Value</returns>
        public async Task<KODIRPC.Playlist.Property.Value> GetProperties(int? playlistid=null, KODIRPC.Playlist.GetProperties_properties properties=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (properties == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null properties");
              }
             else
              {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
              }
            return await _client.GetData<KODIRPC.Playlist.Property.Value>("Playlist.GetProperties", jArgs);
        }

                /// <summary>
                /// Insert item(s) into playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Insert(int? playlistid=null, int? position=null, KODIRPC.Playlist.ItemFile item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position");
              }
             else
              {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Insert", jArgs);
        }

                /// <summary>
                /// Insert item(s) into playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Insert(int? playlistid=null, int? position=null, KODIRPC.Playlist.Item1 item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position");
              }
             else
              {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Insert", jArgs);
        }

                /// <summary>
                /// Insert item(s) into playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Insert(int? playlistid=null, int? position=null, KODIRPC.Playlist.ItemMovieid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position");
              }
             else
              {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Insert", jArgs);
        }

                /// <summary>
                /// Insert item(s) into playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Insert(int? playlistid=null, int? position=null, KODIRPC.Playlist.ItemEpisodeid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position");
              }
             else
              {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Insert", jArgs);
        }

                /// <summary>
                /// Insert item(s) into playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Insert(int? playlistid=null, int? position=null, KODIRPC.Playlist.ItemMusicvideoid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position");
              }
             else
              {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Insert", jArgs);
        }

                /// <summary>
                /// Insert item(s) into playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Insert(int? playlistid=null, int? position=null, KODIRPC.Playlist.ItemArtistid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position");
              }
             else
              {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Insert", jArgs);
        }

                /// <summary>
                /// Insert item(s) into playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Insert(int? playlistid=null, int? position=null, KODIRPC.Playlist.ItemAlbumid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position");
              }
             else
              {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Insert", jArgs);
        }

                /// <summary>
                /// Insert item(s) into playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Insert(int? playlistid=null, int? position=null, KODIRPC.Playlist.ItemSongid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position");
              }
             else
              {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Insert", jArgs);
        }

                /// <summary>
                /// Insert item(s) into playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Insert(int? playlistid=null, int? position=null, KODIRPC.Playlist.ItemGenreid item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position");
              }
             else
              {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Insert", jArgs);
        }

                /// <summary>
                /// Insert item(s) into playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Insert(int? playlistid=null, int? position=null, global::System.Collections.Generic.List<object> item=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position");
              }
             else
              {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
              }
             if (item == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null item");
              }
             else
              {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
              }
            return await _client.GetData<string>("Playlist.Insert", jArgs);
        }

                /// <summary>
                /// Insert item(s) into playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Insert(int? playlistid=null, int? position=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position");
              }
             else
              {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
              }
            return await _client.GetData<string>("Playlist.Insert", jArgs);
        }

                /// <summary>
                /// Remove item from playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Remove(int? playlistid=null, int? position=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position");
              }
             else
              {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
              }
            return await _client.GetData<string>("Playlist.Remove", jArgs);
        }

                /// <summary>
                /// Swap items in the playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position1"> REQUIRED </param>
                /// <param name="position2"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Swap(int? playlistid=null, int? position1=null, int? position2=null)
        {
             var jArgs = new JObject();

             if (playlistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playlistid");
              }
             else
              {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
              }
             if (position1 == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position1");
              }
             else
              {
                 var jpropposition1 = JToken.FromObject(position1, _client.Serializer);
                 jArgs.Add(new JProperty("position1", jpropposition1));
              }
             if (position2 == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null position2");
              }
             else
              {
                 var jpropposition2 = JToken.FromObject(position2, _client.Serializer);
                 jArgs.Add(new JProperty("position2", jpropposition2));
              }
            return await _client.GetData<string>("Playlist.Swap", jArgs);
        }

        public delegate void OnAddDelegate(string sender=null, KODIRPC.Playlist.OnAdd_data data=null);
        public event OnAddDelegate OnAdd;
        internal void RaiseOnAdd(string sender=null, KODIRPC.Playlist.OnAdd_data data=null)
        {
            if (OnAdd != null)
            {
                OnAdd.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnClearDelegate(string sender=null, KODIRPC.Playlist.OnClear_data data=null);
        public event OnClearDelegate OnClear;
        internal void RaiseOnClear(string sender=null, KODIRPC.Playlist.OnClear_data data=null)
        {
            if (OnClear != null)
            {
                OnClear.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnRemoveDelegate(string sender=null, KODIRPC.Playlist.OnRemove_data data=null);
        public event OnRemoveDelegate OnRemove;
        internal void RaiseOnRemove(string sender=null, KODIRPC.Playlist.OnRemove_data data=null)
        {
            if (OnRemove != null)
            {
                OnRemove.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
