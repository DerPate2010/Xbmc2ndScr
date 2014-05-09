using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using XBMCRPC.Global;

namespace XBMCRPC.Methods
{
   public partial class Player
   {
        private readonly Client _client;
          public Player(Client client)
          {
              _client = client;
          }
   public class GetActivePlayersResponse
   {
       public int playerid {get;set;}
       public XBMCRPC.Player.Type type {get;set;}
   }

        async public Task<GetActivePlayersResponse[]> GetActivePlayers()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<GetActivePlayersResponse[]>("Player.GetActivePlayers", jArgs);
            return jRet;
        }
   public class GetItemResponse
   {
       public XBMCRPC.List.Item.All item {get;set;}
   }

        async public Task<GetItemResponse> GetItem(int playerid=0, XBMCRPC.List.Fields.All properties=null)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<GetItemResponse>("Player.GetItem", jArgs);
            return jRet;
        }

        async public Task<XBMCRPC.Player.Property.Value> GetProperties(int playerid=0, XBMCRPC.Player.Property.Name[] properties=null)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<XBMCRPC.Player.Property.Value>("Player.GetProperties", jArgs);
            return jRet;
        }

        async public Task<string> GoTo(int playerid=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            var jRet = await _client.GetData<string>("Player.GoTo", jArgs);
            return jRet;
        }
   public enum GoToto
   {
       previous,
       next,
   }

        async public Task<string> GoTo2(int playerid=0, GoToto to=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (to != null)
             {
                 var jpropto = JToken.FromObject(to, _client.Serializer);
                 jArgs.Add(new JProperty("to", jpropto));
             }
            var jRet = await _client.GetData<string>("Player.GoTo", jArgs);
            return jRet;
        }

        async public Task<string> GoTo2(int playerid=0, int to=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (to != null)
             {
                 var jpropto = JToken.FromObject(to, _client.Serializer);
                 jArgs.Add(new JProperty("to", jpropto));
             }
            var jRet = await _client.GetData<string>("Player.GoTo", jArgs);
            return jRet;
        }
   public enum directionEnum
   {
       left,
       right,
       up,
       down,
   }

        async public Task<string> Move(int playerid=0, directionEnum direction=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (direction != null)
             {
                 var jpropdirection = JToken.FromObject(direction, _client.Serializer);
                 jArgs.Add(new JProperty("direction", jpropdirection));
             }
            var jRet = await _client.GetData<string>("Player.Move", jArgs);
            return jRet;
        }
   public class optionsType
   {
       public XBMCRPC.Player.Repeat? repeat {get;set;}
       public string resume {get;set;}
       public bool? shuffled {get;set;}
   }

        async public Task<string> Open(optionsType options=null)
        {
            var jArgs = new JObject();
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            var jRet = await _client.GetData<string>("Player.Open", jArgs);
            return jRet;
        }
   public class Openitem1
   {
       public int playlistid {get;set;}
       public int position {get;set;}
   }

        async public Task<string> Open2(Openitem1 item=null, optionsType options=null)
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
            var jRet = await _client.GetData<string>("Player.Open", jArgs);
            return jRet;
        }

        async public Task<string> Open2(XBMCRPC.Playlist.Item item=null, optionsType options=null)
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
            var jRet = await _client.GetData<string>("Player.Open", jArgs);
            return jRet;
        }
   public class Openitem3
   {
       public string path {get;set;}
       public bool random {get;set;}
       public bool recursive {get;set;}
   }

        async public Task<string> Open2(Openitem3 item=null, optionsType options=null)
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
            var jRet = await _client.GetData<string>("Player.Open", jArgs);
            return jRet;
        }
   public class Openitem4
   {
       public string partymode {get;set;}
   }

        async public Task<string> Open2(Openitem4 item=null, optionsType options=null)
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
            var jRet = await _client.GetData<string>("Player.Open", jArgs);
            return jRet;
        }
   public class Openitem5
   {
       public int channelid {get;set;}
   }

        async public Task<string> Open2(Openitem5 item=null, optionsType options=null)
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
            var jRet = await _client.GetData<string>("Player.Open", jArgs);
            return jRet;
        }

        async public Task<XBMCRPC.Player.Speed> PlayPause(int playerid=0, XBMCRPC.Global.Toggle play=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             JToken jpropplay;
             switch (play)
             {
                 case Toggle.True:
                 case Toggle.False:
                     jpropplay = JToken.FromObject(bool.Parse(play.ToString()), _client.Serializer);
                     break;
                 default:
                     jpropplay = JToken.FromObject(play, _client.Serializer);

                     break;
             }
             jArgs.Add(new JProperty("play", jpropplay));
            var jRet = await _client.GetData<XBMCRPC.Player.Speed>("Player.PlayPause", jArgs);
            return jRet;
        }
   public enum valueEnum
   {
       clockwise,
       counterclockwise,
   }

        async public Task<string> Rotate(int playerid=0, valueEnum value=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (value != null)
             {
                 var jpropvalue = JToken.FromObject(value, _client.Serializer);
                 jArgs.Add(new JProperty("value", jpropvalue));
             }
            var jRet = await _client.GetData<string>("Player.Rotate", jArgs);
            return jRet;
        }
   public class SeekResponse
   {
       public double percentage {get;set;}
       public XBMCRPC.Global.Time time {get;set;}
       public XBMCRPC.Global.Time totaltime {get;set;}
   }

        async public Task<SeekResponse> Seek(int playerid=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            var jRet = await _client.GetData<SeekResponse>("Player.Seek", jArgs);
            return jRet;
        }

        async public Task<SeekResponse> Seek2(int playerid=0, double value=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (value != null)
             {
                 var jpropvalue = JToken.FromObject(value, _client.Serializer);
                 jArgs.Add(new JProperty("value", jpropvalue));
             }
            var jRet = await _client.GetData<SeekResponse>("Player.Seek", jArgs);
            return jRet;
        }

        async public Task<SeekResponse> Seek2(int playerid=0, XBMCRPC.Player.Position.Time value=null)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (value != null)
             {
                 var jpropvalue = JToken.FromObject(value, _client.Serializer);
                 jArgs.Add(new JProperty("value", jpropvalue));
             }
            var jRet = await _client.GetData<SeekResponse>("Player.Seek", jArgs);
            return jRet;
        }
   public enum Seekvalue
   {
       smallforward,
       smallbackward,
       bigforward,
       bigbackward,
   }

        async public Task<SeekResponse> Seek2(int playerid=0, Seekvalue value=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (value != null)
             {
                 var jpropvalue = JToken.FromObject(value, _client.Serializer);
                 jArgs.Add(new JProperty("value", jpropvalue));
             }
            var jRet = await _client.GetData<SeekResponse>("Player.Seek", jArgs);
            return jRet;
        }

        async public Task<string> SetAudioStream(int playerid=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            var jRet = await _client.GetData<string>("Player.SetAudioStream", jArgs);
            return jRet;
        }
   public enum SetAudioStreamstream
   {
       previous,
       next,
   }

        async public Task<string> SetAudioStream2(int playerid=0, SetAudioStreamstream stream=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (stream != null)
             {
                 var jpropstream = JToken.FromObject(stream, _client.Serializer);
                 jArgs.Add(new JProperty("stream", jpropstream));
             }
            var jRet = await _client.GetData<string>("Player.SetAudioStream", jArgs);
            return jRet;
        }

        async public Task<string> SetAudioStream2(int playerid=0, int stream=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (stream != null)
             {
                 var jpropstream = JToken.FromObject(stream, _client.Serializer);
                 jArgs.Add(new JProperty("stream", jpropstream));
             }
            var jRet = await _client.GetData<string>("Player.SetAudioStream", jArgs);
            return jRet;
        }

        async public Task<string> SetPartymode(int playerid=0, XBMCRPC.Global.Toggle partymode=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (partymode != null)
             {
                 var jproppartymode = JToken.FromObject(partymode, _client.Serializer);
                 jArgs.Add(new JProperty("partymode", jproppartymode));
             }
            var jRet = await _client.GetData<string>("Player.SetPartymode", jArgs);
            return jRet;
        }

        async public Task<string> SetRepeat(int playerid=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            var jRet = await _client.GetData<string>("Player.SetRepeat", jArgs);
            return jRet;
        }

        async public Task<string> SetRepeat2(int playerid=0, XBMCRPC.Player.Repeat repeat=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (repeat != null)
             {
                 var jproprepeat = JToken.FromObject(repeat, _client.Serializer);
                 jArgs.Add(new JProperty("repeat", jproprepeat));
             }
            var jRet = await _client.GetData<string>("Player.SetRepeat", jArgs);
            return jRet;
        }
   public enum SetRepeatrepeat
   {
       cycle,
   }

        async public Task<string> SetRepeat2(int playerid=0, SetRepeatrepeat repeat=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (repeat != null)
             {
                 var jproprepeat = JToken.FromObject(repeat, _client.Serializer);
                 jArgs.Add(new JProperty("repeat", jproprepeat));
             }
            var jRet = await _client.GetData<string>("Player.SetRepeat", jArgs);
            return jRet;
        }

        async public Task<string> SetShuffle(int playerid=0, XBMCRPC.Global.Toggle shuffle=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (shuffle != null)
             {
                 var jpropshuffle = JToken.FromObject(shuffle, _client.Serializer);
                 jArgs.Add(new JProperty("shuffle", jpropshuffle));
             }
            var jRet = await _client.GetData<string>("Player.SetShuffle", jArgs);
            return jRet;
        }

        async public Task<XBMCRPC.Player.Speed> SetSpeed(int playerid=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            var jRet = await _client.GetData<XBMCRPC.Player.Speed>("Player.SetSpeed", jArgs);
            return jRet;
        }

        async public Task<XBMCRPC.Player.Speed> SetSpeed2(int playerid=0, int speed=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (speed != null)
             {
                 var jpropspeed = JToken.FromObject(speed, _client.Serializer);
                 jArgs.Add(new JProperty("speed", jpropspeed));
             }
            var jRet = await _client.GetData<XBMCRPC.Player.Speed>("Player.SetSpeed", jArgs);
            return jRet;
        }

        async public Task<XBMCRPC.Player.Speed> SetSpeed2(int playerid=0, XBMCRPC.Global.IncrementDecrement speed=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (speed != null)
             {
                 var jpropspeed = JToken.FromObject(speed, _client.Serializer);
                 jArgs.Add(new JProperty("speed", jpropspeed));
             }
            var jRet = await _client.GetData<XBMCRPC.Player.Speed>("Player.SetSpeed", jArgs);
            return jRet;
        }

        async public Task<string> SetSubtitle(int playerid=0, bool enable=false)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (enable != null)
             {
                 var jpropenable = JToken.FromObject(enable, _client.Serializer);
                 jArgs.Add(new JProperty("enable", jpropenable));
             }
            var jRet = await _client.GetData<string>("Player.SetSubtitle", jArgs);
            return jRet;
        }
   public enum SetSubtitlesubtitle
   {
       previous,
       next,
       off,
       on,
   }

        async public Task<string> SetSubtitle2(int playerid=0, SetSubtitlesubtitle subtitle=0, bool enable=false)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (subtitle != null)
             {
                 var jpropsubtitle = JToken.FromObject(subtitle, _client.Serializer);
                 jArgs.Add(new JProperty("subtitle", jpropsubtitle));
             }
             if (enable != null)
             {
                 var jpropenable = JToken.FromObject(enable, _client.Serializer);
                 jArgs.Add(new JProperty("enable", jpropenable));
             }
            var jRet = await _client.GetData<string>("Player.SetSubtitle", jArgs);
            return jRet;
        }

        async public Task<string> SetSubtitle2(int playerid=0, int subtitle=0, bool enable=false)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (subtitle != null)
             {
                 var jpropsubtitle = JToken.FromObject(subtitle, _client.Serializer);
                 jArgs.Add(new JProperty("subtitle", jpropsubtitle));
             }
             if (enable != null)
             {
                 var jpropenable = JToken.FromObject(enable, _client.Serializer);
                 jArgs.Add(new JProperty("enable", jpropenable));
             }
            var jRet = await _client.GetData<string>("Player.SetSubtitle", jArgs);
            return jRet;
        }

        async public Task<string> Stop(int playerid=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            var jRet = await _client.GetData<string>("Player.Stop", jArgs);
            return jRet;
        }

        async public Task<string> Zoom(int playerid=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
            var jRet = await _client.GetData<string>("Player.Zoom", jArgs);
            return jRet;
        }
   public enum Zoomzoom
   {
       [global::System.Runtime.Serialization.EnumMember(Value="in")]
       In,
       [global::System.Runtime.Serialization.EnumMember(Value="out")]
       Out,
   }

        async public Task<string> Zoom2(int playerid=0, Zoomzoom zoom=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (zoom != null)
             {
                 var jpropzoom = JToken.FromObject(zoom, _client.Serializer);
                 jArgs.Add(new JProperty("zoom", jpropzoom));
             }
            var jRet = await _client.GetData<string>("Player.Zoom", jArgs);
            return jRet;
        }

        async public Task<string> Zoom2(int playerid=0, int zoom=0)
        {
            var jArgs = new JObject();
             if (playerid != null)
             {
                 var jpropplayerid = JToken.FromObject(playerid, _client.Serializer);
                 jArgs.Add(new JProperty("playerid", jpropplayerid));
             }
             if (zoom != null)
             {
                 var jpropzoom = JToken.FromObject(zoom, _client.Serializer);
                 jArgs.Add(new JProperty("zoom", jpropzoom));
             }
            var jRet = await _client.GetData<string>("Player.Zoom", jArgs);
            return jRet;
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
   public class OnPropertyChangeddataType
   {
       public XBMCRPC.Player.Notifications.Player player {get;set;}
       public XBMCRPC.Player.Property.Value property {get;set;}
   }

        public delegate void OnPropertyChangedDelegate(string sender=null, OnPropertyChangeddataType data=null);
        public event OnPropertyChangedDelegate OnPropertyChanged;
        internal void RaiseOnPropertyChanged(string sender=null, OnPropertyChangeddataType data=null)
        {
            if (OnPropertyChanged != null)
            {
                OnPropertyChanged.BeginInvoke(sender, data, null, null);
            }
        }
   public class OnSeekdataType
   {
       public XBMCRPC.Notifications.Item item {get;set;}
       public XBMCRPC.Player.Notifications.Player.Seek player {get;set;}
   }

        public delegate void OnSeekDelegate(string sender=null, OnSeekdataType data=null);
        public event OnSeekDelegate OnSeek;
        internal void RaiseOnSeek(string sender=null, OnSeekdataType data=null)
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
   public class OnStopdataType
   {
       public bool end {get;set;}
       public XBMCRPC.Notifications.Item item {get;set;}
   }

        public delegate void OnStopDelegate(string sender=null, OnStopdataType data=null);
        public event OnStopDelegate OnStop;
        internal void RaiseOnStop(string sender=null, OnStopdataType data=null)
        {
            if (OnStop != null)
            {
                OnStop.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
