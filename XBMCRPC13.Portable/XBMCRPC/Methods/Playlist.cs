using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
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
        public async Task<string> Add(int playlistid, XBMCRPC.Playlist.ItemFile item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
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
        public async Task<string> Add(int playlistid, XBMCRPC.Playlist.Item1 item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
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
        public async Task<string> Add(int playlistid, XBMCRPC.Playlist.ItemMovieid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
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
        public async Task<string> Add(int playlistid, XBMCRPC.Playlist.ItemEpisodeid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
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
        public async Task<string> Add(int playlistid, XBMCRPC.Playlist.ItemMusicvideoid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
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
        public async Task<string> Add(int playlistid, XBMCRPC.Playlist.ItemArtistid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
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
        public async Task<string> Add(int playlistid, XBMCRPC.Playlist.ItemAlbumid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
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
        public async Task<string> Add(int playlistid, XBMCRPC.Playlist.ItemSongid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
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
        public async Task<string> Add(int playlistid, XBMCRPC.Playlist.ItemGenreid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
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
        public async Task<string> Add(int playlistid, global::System.Collections.Generic.List<object> item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
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
        public async Task<string> Add(int playlistid)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

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
        public async Task<string> Clear(int playlistid)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

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
                /// <returns>XBMCRPC.Playlist.GetItemsResponse</returns>
        public async Task<XBMCRPC.Playlist.GetItemsResponse> GetItems(int playlistid, XBMCRPC.List.Fields.All properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

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
            return await _client.GetData<XBMCRPC.Playlist.GetItemsResponse>("Playlist.GetItems", jArgs);
        }

                /// <summary>
                /// Returns all existing playlists
                /// </summary>
                /// <returns>global::System.Collections.Generic.List<XBMCRPC.Playlist.GetPlaylistsResponseItem></returns>
        public async Task<global::System.Collections.Generic.List<XBMCRPC.Playlist.GetPlaylistsResponseItem>> GetPlaylists()
        {
            return await _client.GetData<global::System.Collections.Generic.List<XBMCRPC.Playlist.GetPlaylistsResponseItem>>("Playlist.GetPlaylists",null);
        }

                /// <summary>
                /// Retrieves the values of the given properties
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="properties"> REQUIRED </param>
                /// <returns>XBMCRPC.Playlist.Property.Value</returns>
        public async Task<XBMCRPC.Playlist.Property.Value> GetProperties(int playlistid, XBMCRPC.Playlist.GetProperties_properties properties)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<XBMCRPC.Playlist.Property.Value>("Playlist.GetProperties", jArgs);
        }

                /// <summary>
                /// Insert item(s) into playlist. Does not work for picture playlists (aka slideshows).
                /// </summary>
                /// <param name="playlistid"> REQUIRED </param>
                /// <param name="position"> REQUIRED </param>
                /// <param name="item"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Insert(int playlistid, int position, XBMCRPC.Playlist.ItemFile item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
             }
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
        public async Task<string> Insert(int playlistid, int position, XBMCRPC.Playlist.Item1 item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
             }
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
        public async Task<string> Insert(int playlistid, int position, XBMCRPC.Playlist.ItemMovieid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
             }
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
        public async Task<string> Insert(int playlistid, int position, XBMCRPC.Playlist.ItemEpisodeid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
             }
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
        public async Task<string> Insert(int playlistid, int position, XBMCRPC.Playlist.ItemMusicvideoid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
             }
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
        public async Task<string> Insert(int playlistid, int position, XBMCRPC.Playlist.ItemArtistid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
             }
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
        public async Task<string> Insert(int playlistid, int position, XBMCRPC.Playlist.ItemAlbumid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
             }
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
        public async Task<string> Insert(int playlistid, int position, XBMCRPC.Playlist.ItemSongid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
             }
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
        public async Task<string> Insert(int playlistid, int position, XBMCRPC.Playlist.ItemGenreid item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
             }
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
        public async Task<string> Insert(int playlistid, int position, global::System.Collections.Generic.List<object> item)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
             }
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
        public async Task<string> Insert(int playlistid, int position)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
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
        public async Task<string> Remove(int playlistid, int position)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
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
        public async Task<string> Swap(int playlistid, int position1, int position2)
        {
             if (playlistid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             {
                 var jpropposition1 = JToken.FromObject(position1, _client.Serializer);
                 jArgs.Add(new JProperty("position1", jpropposition1));
             }
             {
                 var jpropposition2 = JToken.FromObject(position2, _client.Serializer);
                 jArgs.Add(new JProperty("position2", jpropposition2));
             }
            return await _client.GetData<string>("Playlist.Swap", jArgs);
        }

        public delegate void OnAddDelegate(string sender, XBMCRPC.Playlist.OnAdd_data data);
        public event OnAddDelegate OnAdd;
        internal void RaiseOnAdd(string sender, XBMCRPC.Playlist.OnAdd_data data)
        {
            if (OnAdd != null)
            {
                OnAdd.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnClearDelegate(string sender, XBMCRPC.Playlist.OnClear_data data);
        public event OnClearDelegate OnClear;
        internal void RaiseOnClear(string sender, XBMCRPC.Playlist.OnClear_data data)
        {
            if (OnClear != null)
            {
                OnClear.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnRemoveDelegate(string sender, XBMCRPC.Playlist.OnRemove_data data);
        public event OnRemoveDelegate OnRemove;
        internal void RaiseOnRemove(string sender, XBMCRPC.Playlist.OnRemove_data data)
        {
            if (OnRemove != null)
            {
                OnRemove.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
