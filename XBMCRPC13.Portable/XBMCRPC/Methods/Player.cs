using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
{
   public partial class Player
   {
        private readonly Client _client;
          public Player(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Returns all active players
                /// </summary>
                /// <returns>global::System.Collections.Generic.List<XBMCRPC.Player.GetActivePlayersResponseItem></returns>
        public async Task<global::System.Collections.Generic.List<XBMCRPC.Player.GetActivePlayersResponseItem>> GetActivePlayers()
        {
            return await _client.GetData<global::System.Collections.Generic.List<XBMCRPC.Player.GetActivePlayersResponseItem>>("Player.GetActivePlayers",null);
        }

                /// <summary>
                /// Retrieves the currently played item
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>XBMCRPC.Player.GetItemResponse</returns>
        public async Task<XBMCRPC.Player.GetItemResponse> GetItem(int playerid, XBMCRPC.List.Fields.All properties=null)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<XBMCRPC.Player.GetItemResponse>("Player.GetItem", jArgs);
        }

                /// <summary>
                /// Get a list of available players
                /// </summary>
                /// <param name="media"> </param>
                /// <returns>global::System.Collections.Generic.List<XBMCRPC.Player.GetPlayersResponseItem></returns>
        public async Task<global::System.Collections.Generic.List<XBMCRPC.Player.GetPlayersResponseItem>> GetPlayers(XBMCRPC.Player.GetPlayers_media? media=null)
        {
            var jArgs = new JObject();

             if (media != null)
             {
                 var jpropmedia = JToken.FromObject(media, _client.Serializer);
                 jArgs.Add(new JProperty("media", jpropmedia));
             }
            return await _client.GetData<global::System.Collections.Generic.List<XBMCRPC.Player.GetPlayersResponseItem>>("Player.GetPlayers", jArgs);
        }

                /// <summary>
                /// Retrieves the values of the given properties
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="properties"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.Property.Value</returns>
        public async Task<XBMCRPC.Player.Property.Value> GetProperties(int playerid, XBMCRPC.Player.GetProperties_properties properties)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<XBMCRPC.Player.Property.Value>("Player.GetProperties", jArgs);
        }

                /// <summary>
                /// Go to previous/next/specific item in the playlist
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="to"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> GoTo(int playerid, XBMCRPC.Player.GoTo_to1? to)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropto = JToken.FromObject(to, _client.Serializer);
                 jArgs.Add(new JProperty("to", jpropto));
             }
            return await _client.GetData<string>("Player.GoTo", jArgs);
        }

                /// <summary>
                /// Go to previous/next/specific item in the playlist
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="to"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> GoTo(int playerid, int to)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropto = JToken.FromObject(to, _client.Serializer);
                 jArgs.Add(new JProperty("to", jpropto));
             }
            return await _client.GetData<string>("Player.GoTo", jArgs);
        }

                /// <summary>
                /// Go to previous/next/specific item in the playlist
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> GoTo(int playerid)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            return await _client.GetData<string>("Player.GoTo", jArgs);
        }

                /// <summary>
                /// If picture is zoomed move viewport left/right/up/down otherwise skip previous/next
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="direction"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Move(int playerid, XBMCRPC.Player.Move_direction? direction)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropdirection = JToken.FromObject(direction, _client.Serializer);
                 jArgs.Add(new JProperty("direction", jpropdirection));
             }
            return await _client.GetData<string>("Player.Move", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Player.Open_item1 item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Playlist.ItemFile item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Playlist.Item1 item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Playlist.ItemMovieid item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Playlist.ItemEpisodeid item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Playlist.ItemMusicvideoid item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Playlist.ItemArtistid item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Playlist.ItemAlbumid item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Playlist.ItemSongid item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Playlist.ItemGenreid item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Player.Open_item2 item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Player.Open_itemPartymode item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Player.Open_itemChannelid item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="item"> </param>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Player.Open_itemRecordingid item=null, XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Start playback of either the playlist with the given ID, a slideshow with the pictures from the given directory or a single file or an item from the database.
                /// </summary>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Open(XBMCRPC.Player.Open_options options=null)
        {
            var jArgs = new JObject();

             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("Player.Open", jArgs);
        }

                /// <summary>
                /// Pauses or unpause playback and returns the new state
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="play"> </param>
                /// <returns>XBMCRPC.Player.Speed</returns>
        public async Task<XBMCRPC.Player.Speed> PlayPause(int playerid, bool? play=null)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropplay = JToken.FromObject(play, _client.Serializer);
                 jArgs.Add(new JProperty("play", jpropplay));
             }
            return await _client.GetData<XBMCRPC.Player.Speed>("Player.PlayPause", jArgs);
        }

                /// <summary>
                /// Pauses or unpause playback and returns the new state
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="play"> </param>
                /// <returns>XBMCRPC.Player.Speed</returns>
        public async Task<XBMCRPC.Player.Speed> PlayPause(int playerid, XBMCRPC.Global.Toggle2? play=null)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (play != null)
             {
                 var jpropplay = JToken.FromObject(play, _client.Serializer);
                 jArgs.Add(new JProperty("play", jpropplay));
             }
            return await _client.GetData<XBMCRPC.Player.Speed>("Player.PlayPause", jArgs);
        }

                /// <summary>
                /// Pauses or unpause playback and returns the new state
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.Speed</returns>
        public async Task<XBMCRPC.Player.Speed> PlayPause(int playerid)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            return await _client.GetData<XBMCRPC.Player.Speed>("Player.PlayPause", jArgs);
        }

                /// <summary>
                /// Rotates current picture
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="value"> </param>
                /// <returns>string</returns>
        public async Task<string> Rotate(int playerid, XBMCRPC.Player.Rotate_value? value=null)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (value != null)
             {
                 var jpropvalue = JToken.FromObject(value, _client.Serializer);
                 jArgs.Add(new JProperty("value", jpropvalue));
             }
            return await _client.GetData<string>("Player.Rotate", jArgs);
        }

                /// <summary>
                /// Seek through the playing item
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="value"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.SeekResponse</returns>
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int playerid, double? value=null)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropvalue = JToken.FromObject(value, _client.Serializer);
                 jArgs.Add(new JProperty("value", jpropvalue));
             }
            return await _client.GetData<XBMCRPC.Player.SeekResponse>("Player.Seek", jArgs);
        }

                /// <summary>
                /// Seek through the playing item
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="value"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.SeekResponse</returns>
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int playerid, XBMCRPC.Player.Position.Time value)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropvalue = JToken.FromObject(value, _client.Serializer);
                 jArgs.Add(new JProperty("value", jpropvalue));
             }
            return await _client.GetData<XBMCRPC.Player.SeekResponse>("Player.Seek", jArgs);
        }

                /// <summary>
                /// Seek through the playing item
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="value"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.SeekResponse</returns>
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int playerid, XBMCRPC.Player.Seek_value1? value)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropvalue = JToken.FromObject(value, _client.Serializer);
                 jArgs.Add(new JProperty("value", jpropvalue));
             }
            return await _client.GetData<XBMCRPC.Player.SeekResponse>("Player.Seek", jArgs);
        }

                /// <summary>
                /// Seek through the playing item
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="value"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.SeekResponse</returns>
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int playerid, XBMCRPC.Player.Seek_valuePercentage value)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropvalue = JToken.FromObject(value, _client.Serializer);
                 jArgs.Add(new JProperty("value", jpropvalue));
             }
            return await _client.GetData<XBMCRPC.Player.SeekResponse>("Player.Seek", jArgs);
        }

                /// <summary>
                /// Seek through the playing item
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="value"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.SeekResponse</returns>
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int playerid, XBMCRPC.Player.Seek_valueTime value)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropvalue = JToken.FromObject(value, _client.Serializer);
                 jArgs.Add(new JProperty("value", jpropvalue));
             }
            return await _client.GetData<XBMCRPC.Player.SeekResponse>("Player.Seek", jArgs);
        }

                /// <summary>
                /// Seek through the playing item
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="value"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.SeekResponse</returns>
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int playerid, XBMCRPC.Player.Seek_valueStep value)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropvalue = JToken.FromObject(value, _client.Serializer);
                 jArgs.Add(new JProperty("value", jpropvalue));
             }
            return await _client.GetData<XBMCRPC.Player.SeekResponse>("Player.Seek", jArgs);
        }

                /// <summary>
                /// Seek through the playing item
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="value"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.SeekResponse</returns>
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int playerid, XBMCRPC.Player.Seek_valueSeconds value)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropvalue = JToken.FromObject(value, _client.Serializer);
                 jArgs.Add(new JProperty("value", jpropvalue));
             }
            return await _client.GetData<XBMCRPC.Player.SeekResponse>("Player.Seek", jArgs);
        }

                /// <summary>
                /// Seek through the playing item
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.SeekResponse</returns>
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int playerid)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            return await _client.GetData<XBMCRPC.Player.SeekResponse>("Player.Seek", jArgs);
        }

                /// <summary>
                /// Set the audio stream played by the player
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="stream"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetAudioStream(int playerid, XBMCRPC.Player.SetAudioStream_stream1? stream)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropstream = JToken.FromObject(stream, _client.Serializer);
                 jArgs.Add(new JProperty("stream", jpropstream));
             }
            return await _client.GetData<string>("Player.SetAudioStream", jArgs);
        }

                /// <summary>
                /// Set the audio stream played by the player
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="stream"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetAudioStream(int playerid, int stream)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropstream = JToken.FromObject(stream, _client.Serializer);
                 jArgs.Add(new JProperty("stream", jpropstream));
             }
            return await _client.GetData<string>("Player.SetAudioStream", jArgs);
        }

                /// <summary>
                /// Set the audio stream played by the player
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetAudioStream(int playerid)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            return await _client.GetData<string>("Player.SetAudioStream", jArgs);
        }

                /// <summary>
                /// Turn partymode on or off
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="partymode"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetPartymode(int playerid, bool? partymode=null)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jproppartymode = JToken.FromObject(partymode, _client.Serializer);
                 jArgs.Add(new JProperty("partymode", jproppartymode));
             }
            return await _client.GetData<string>("Player.SetPartymode", jArgs);
        }

                /// <summary>
                /// Turn partymode on or off
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="partymode"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetPartymode(int playerid, XBMCRPC.Global.Toggle2? partymode)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jproppartymode = JToken.FromObject(partymode, _client.Serializer);
                 jArgs.Add(new JProperty("partymode", jproppartymode));
             }
            return await _client.GetData<string>("Player.SetPartymode", jArgs);
        }

                /// <summary>
                /// Turn partymode on or off
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetPartymode(int playerid)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            return await _client.GetData<string>("Player.SetPartymode", jArgs);
        }

                /// <summary>
                /// Set the repeat mode of the player
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="repeat"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetRepeat(int playerid, XBMCRPC.Player.Repeat? repeat)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jproprepeat = JToken.FromObject(repeat, _client.Serializer);
                 jArgs.Add(new JProperty("repeat", jproprepeat));
             }
            return await _client.GetData<string>("Player.SetRepeat", jArgs);
        }

                /// <summary>
                /// Set the repeat mode of the player
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="repeat"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetRepeat(int playerid, XBMCRPC.Player.SetRepeat_repeat1? repeat)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jproprepeat = JToken.FromObject(repeat, _client.Serializer);
                 jArgs.Add(new JProperty("repeat", jproprepeat));
             }
            return await _client.GetData<string>("Player.SetRepeat", jArgs);
        }

                /// <summary>
                /// Set the repeat mode of the player
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetRepeat(int playerid)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            return await _client.GetData<string>("Player.SetRepeat", jArgs);
        }

                /// <summary>
                /// Shuffle/Unshuffle items in the player
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="shuffle"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetShuffle(int playerid, bool? shuffle=null)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropshuffle = JToken.FromObject(shuffle, _client.Serializer);
                 jArgs.Add(new JProperty("shuffle", jpropshuffle));
             }
            return await _client.GetData<string>("Player.SetShuffle", jArgs);
        }

                /// <summary>
                /// Shuffle/Unshuffle items in the player
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="shuffle"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetShuffle(int playerid, XBMCRPC.Global.Toggle2? shuffle)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropshuffle = JToken.FromObject(shuffle, _client.Serializer);
                 jArgs.Add(new JProperty("shuffle", jpropshuffle));
             }
            return await _client.GetData<string>("Player.SetShuffle", jArgs);
        }

                /// <summary>
                /// Shuffle/Unshuffle items in the player
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> SetShuffle(int playerid)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            return await _client.GetData<string>("Player.SetShuffle", jArgs);
        }

                /// <summary>
                /// Set the speed of the current playback
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="speed"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.Speed</returns>
        public async Task<XBMCRPC.Player.Speed> SetSpeed(int playerid, int speed)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropspeed = JToken.FromObject(speed, _client.Serializer);
                 jArgs.Add(new JProperty("speed", jpropspeed));
             }
            return await _client.GetData<XBMCRPC.Player.Speed>("Player.SetSpeed", jArgs);
        }

                /// <summary>
                /// Set the speed of the current playback
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="speed"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.Speed</returns>
        public async Task<XBMCRPC.Player.Speed> SetSpeed(int playerid, XBMCRPC.Global.IncrementDecrement? speed)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropspeed = JToken.FromObject(speed, _client.Serializer);
                 jArgs.Add(new JProperty("speed", jpropspeed));
             }
            return await _client.GetData<XBMCRPC.Player.Speed>("Player.SetSpeed", jArgs);
        }

                /// <summary>
                /// Set the speed of the current playback
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <returns>XBMCRPC.Player.Speed</returns>
        public async Task<XBMCRPC.Player.Speed> SetSpeed(int playerid)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            return await _client.GetData<XBMCRPC.Player.Speed>("Player.SetSpeed", jArgs);
        }

                /// <summary>
                /// Set the subtitle displayed by the player
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="subtitle"> REQUIRED </param>
                /// <param name="enable"> Whether to enable subtitles to be displayed after setting the new subtitle</param>
                /// <returns>string</returns>
        public async Task<string> SetSubtitle(int playerid, XBMCRPC.Player.SetSubtitle_subtitle1? subtitle, bool? enable=null)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropsubtitle = JToken.FromObject(subtitle, _client.Serializer);
                 jArgs.Add(new JProperty("subtitle", jpropsubtitle));
             }
             {
                 var jpropenable = JToken.FromObject(enable, _client.Serializer);
                 jArgs.Add(new JProperty("enable", jpropenable));
             }
            return await _client.GetData<string>("Player.SetSubtitle", jArgs);
        }

                /// <summary>
                /// Set the subtitle displayed by the player
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="subtitle"> REQUIRED </param>
                /// <param name="enable"> Whether to enable subtitles to be displayed after setting the new subtitle</param>
                /// <returns>string</returns>
        public async Task<string> SetSubtitle(int playerid, int subtitle, bool? enable=null)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropsubtitle = JToken.FromObject(subtitle, _client.Serializer);
                 jArgs.Add(new JProperty("subtitle", jpropsubtitle));
             }
             {
                 var jpropenable = JToken.FromObject(enable, _client.Serializer);
                 jArgs.Add(new JProperty("enable", jpropenable));
             }
            return await _client.GetData<string>("Player.SetSubtitle", jArgs);
        }

                /// <summary>
                /// Set the subtitle displayed by the player
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="enable"> Whether to enable subtitles to be displayed after setting the new subtitle</param>
                /// <returns>string</returns>
        public async Task<string> SetSubtitle(int playerid, bool? enable=null)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropenable = JToken.FromObject(enable, _client.Serializer);
                 jArgs.Add(new JProperty("enable", jpropenable));
             }
            return await _client.GetData<string>("Player.SetSubtitle", jArgs);
        }

                /// <summary>
                /// Stops playback
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Stop(int playerid)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            return await _client.GetData<string>("Player.Stop", jArgs);
        }

                /// <summary>
                /// Zoom current picture
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="zoom"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Zoom(int playerid, XBMCRPC.Player.Zoom_zoom1? zoom)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropzoom = JToken.FromObject(zoom, _client.Serializer);
                 jArgs.Add(new JProperty("zoom", jpropzoom));
             }
            return await _client.GetData<string>("Player.Zoom", jArgs);
        }

                /// <summary>
                /// Zoom current picture
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="zoom"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Zoom(int playerid, int zoom)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             {
                 var jpropzoom = JToken.FromObject(zoom, _client.Serializer);
                 jArgs.Add(new JProperty("zoom", jpropzoom));
             }
            return await _client.GetData<string>("Player.Zoom", jArgs);
        }

                /// <summary>
                /// Zoom current picture
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> Zoom(int playerid)
        {
             if (playerid == 0 )
             {
                 return null;
              }

            var jArgs = new JObject();

             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            return await _client.GetData<string>("Player.Zoom", jArgs);
        }

        public delegate void OnPauseDelegate(string sender, XBMCRPC.Player.Notifications.Data data);
        public event OnPauseDelegate OnPause;
        internal void RaiseOnPause(string sender, XBMCRPC.Player.Notifications.Data data)
        {
            if (OnPause != null)
            {
                OnPause.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnPlayDelegate(string sender, XBMCRPC.Player.Notifications.Data data);
        public event OnPlayDelegate OnPlay;
        internal void RaiseOnPlay(string sender, XBMCRPC.Player.Notifications.Data data)
        {
            if (OnPlay != null)
            {
                OnPlay.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnPropertyChangedDelegate(string sender, XBMCRPC.Player.OnPropertyChanged_data data);
        public event OnPropertyChangedDelegate OnPropertyChanged;
        internal void RaiseOnPropertyChanged(string sender, XBMCRPC.Player.OnPropertyChanged_data data)
        {
            if (OnPropertyChanged != null)
            {
                OnPropertyChanged.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnSeekDelegate(string sender, XBMCRPC.Player.OnSeek_data data);
        public event OnSeekDelegate OnSeek;
        internal void RaiseOnSeek(string sender, XBMCRPC.Player.OnSeek_data data)
        {
            if (OnSeek != null)
            {
                OnSeek.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnSpeedChangedDelegate(string sender, XBMCRPC.Player.Notifications.Data data);
        public event OnSpeedChangedDelegate OnSpeedChanged;
        internal void RaiseOnSpeedChanged(string sender, XBMCRPC.Player.Notifications.Data data)
        {
            if (OnSpeedChanged != null)
            {
                OnSpeedChanged.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnStopDelegate(string sender, XBMCRPC.Player.OnStop_data data);
        public event OnStopDelegate OnStop;
        internal void RaiseOnStop(string sender, XBMCRPC.Player.OnStop_data data)
        {
            if (OnStop != null)
            {
                OnStop.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
