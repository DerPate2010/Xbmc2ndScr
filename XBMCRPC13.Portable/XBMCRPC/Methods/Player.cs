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
        public async Task<XBMCRPC.Player.GetItemResponse> GetItem(int? playerid=null, XBMCRPC.List.Fields.All properties=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
        public async Task<XBMCRPC.Player.Property.Value> GetProperties(int? playerid=null, XBMCRPC.Player.GetProperties_properties properties=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
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
            return await _client.GetData<XBMCRPC.Player.Property.Value>("Player.GetProperties", jArgs);
        }

                /// <summary>
                /// Go to previous/next/specific item in the playlist
                /// </summary>
                /// <param name="playerid"> REQUIRED </param>
                /// <param name="to"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> GoTo(int? playerid=null, XBMCRPC.Player.GoTo_to1? to=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (to == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null to");
              }
             else
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
        public async Task<string> GoTo(int? playerid=null, int? to=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (to == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null to");
              }
             else
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
        public async Task<string> GoTo(int? playerid=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
        public async Task<string> Move(int? playerid=null, XBMCRPC.Player.Move_direction? direction=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (direction == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null direction");
              }
             else
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
        public async Task<XBMCRPC.Player.Speed> PlayPause(int? playerid=null, bool? play=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
                /// <param name="play"> </param>
                /// <returns>XBMCRPC.Player.Speed</returns>
        public async Task<XBMCRPC.Player.Speed> PlayPause(int? playerid=null, XBMCRPC.Global.Toggle2? play=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
        public async Task<XBMCRPC.Player.Speed> PlayPause(int? playerid=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
        public async Task<string> Rotate(int? playerid=null, XBMCRPC.Player.Rotate_value? value=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int? playerid=null, double? value=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (value == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null value");
              }
             else
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
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int? playerid=null, XBMCRPC.Player.Position.Time value=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (value == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null value");
              }
             else
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
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int? playerid=null, XBMCRPC.Player.Seek_value1? value=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (value == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null value");
              }
             else
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
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int? playerid=null, XBMCRPC.Player.Seek_valuePercentage value=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (value == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null value");
              }
             else
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
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int? playerid=null, XBMCRPC.Player.Seek_valueTime value=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (value == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null value");
              }
             else
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
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int? playerid=null, XBMCRPC.Player.Seek_valueStep value=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (value == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null value");
              }
             else
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
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int? playerid=null, XBMCRPC.Player.Seek_valueSeconds value=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (value == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null value");
              }
             else
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
        public async Task<XBMCRPC.Player.SeekResponse> Seek(int? playerid=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
        public async Task<string> SetAudioStream(int? playerid=null, XBMCRPC.Player.SetAudioStream_stream1? stream=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (stream == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null stream");
              }
             else
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
        public async Task<string> SetAudioStream(int? playerid=null, int? stream=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (stream == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null stream");
              }
             else
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
        public async Task<string> SetAudioStream(int? playerid=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
        public async Task<string> SetPartymode(int? playerid=null, bool? partymode=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (partymode == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null partymode");
              }
             else
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
        public async Task<string> SetPartymode(int? playerid=null, XBMCRPC.Global.Toggle2? partymode=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (partymode == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null partymode");
              }
             else
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
        public async Task<string> SetPartymode(int? playerid=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
        public async Task<string> SetRepeat(int? playerid=null, XBMCRPC.Player.Repeat? repeat=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (repeat == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null repeat");
              }
             else
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
        public async Task<string> SetRepeat(int? playerid=null, XBMCRPC.Player.SetRepeat_repeat1? repeat=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (repeat == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null repeat");
              }
             else
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
        public async Task<string> SetRepeat(int? playerid=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
        public async Task<string> SetShuffle(int? playerid=null, bool? shuffle=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (shuffle == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null shuffle");
              }
             else
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
        public async Task<string> SetShuffle(int? playerid=null, XBMCRPC.Global.Toggle2? shuffle=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (shuffle == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null shuffle");
              }
             else
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
        public async Task<string> SetShuffle(int? playerid=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
        public async Task<XBMCRPC.Player.Speed> SetSpeed(int? playerid=null, int? speed=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (speed == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null speed");
              }
             else
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
        public async Task<XBMCRPC.Player.Speed> SetSpeed(int? playerid=null, XBMCRPC.Global.IncrementDecrement? speed=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (speed == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null speed");
              }
             else
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
        public async Task<XBMCRPC.Player.Speed> SetSpeed(int? playerid=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
        public async Task<string> SetSubtitle(int? playerid=null, XBMCRPC.Player.SetSubtitle_subtitle1? subtitle=null, bool? enable=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (subtitle == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null subtitle");
              }
             else
              {
                 var jpropsubtitle = JToken.FromObject(subtitle, _client.Serializer);
                 jArgs.Add(new JProperty("subtitle", jpropsubtitle));
              }
             if (enable != null)
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
        public async Task<string> SetSubtitle(int? playerid=null, int? subtitle=null, bool? enable=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (subtitle == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null subtitle");
              }
             else
              {
                 var jpropsubtitle = JToken.FromObject(subtitle, _client.Serializer);
                 jArgs.Add(new JProperty("subtitle", jpropsubtitle));
              }
             if (enable != null)
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
        public async Task<string> SetSubtitle(int? playerid=null, bool? enable=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (enable != null)
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
        public async Task<string> Stop(int? playerid=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
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
        public async Task<string> Zoom(int? playerid=null, XBMCRPC.Player.Zoom_zoom1? zoom=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (zoom == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null zoom");
              }
             else
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
        public async Task<string> Zoom(int? playerid=null, int? zoom=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
             if (zoom == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null zoom");
              }
             else
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
        public async Task<string> Zoom(int? playerid=null)
        {
             var jArgs = new JObject();

             if (playerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null playerid");
              }
             else
              {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
              }
            return await _client.GetData<string>("Player.Zoom", jArgs);
        }

        public delegate void OnPauseDelegate(string sender=null, XBMCRPC.Player.Notifications.Data data=null);
        public event OnPauseDelegate OnPause;
        internal void RaiseOnPause(string sender=null, XBMCRPC.Player.Notifications.Data data=null)
        {
            if (OnPause != null)
            {
                OnPause.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnPlayDelegate(string sender=null, XBMCRPC.Player.Notifications.Data data=null);
        public event OnPlayDelegate OnPlay;
        internal void RaiseOnPlay(string sender=null, XBMCRPC.Player.Notifications.Data data=null)
        {
            if (OnPlay != null)
            {
                OnPlay.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnPropertyChangedDelegate(string sender=null, XBMCRPC.Player.OnPropertyChanged_data data=null);
        public event OnPropertyChangedDelegate OnPropertyChanged;
        internal void RaiseOnPropertyChanged(string sender=null, XBMCRPC.Player.OnPropertyChanged_data data=null)
        {
            if (OnPropertyChanged != null)
            {
                OnPropertyChanged.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnSeekDelegate(string sender=null, XBMCRPC.Player.OnSeek_data data=null);
        public event OnSeekDelegate OnSeek;
        internal void RaiseOnSeek(string sender=null, XBMCRPC.Player.OnSeek_data data=null)
        {
            if (OnSeek != null)
            {
                OnSeek.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnSpeedChangedDelegate(string sender=null, XBMCRPC.Player.Notifications.Data data=null);
        public event OnSpeedChangedDelegate OnSpeedChanged;
        internal void RaiseOnSpeedChanged(string sender=null, XBMCRPC.Player.Notifications.Data data=null)
        {
            if (OnSpeedChanged != null)
            {
                OnSpeedChanged.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnStopDelegate(string sender=null, XBMCRPC.Player.OnStop_data data=null);
        public event OnStopDelegate OnStop;
        internal void RaiseOnStop(string sender=null, XBMCRPC.Player.OnStop_data data=null)
        {
            if (OnStop != null)
            {
                OnStop.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
