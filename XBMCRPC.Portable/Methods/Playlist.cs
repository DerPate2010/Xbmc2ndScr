using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace XBMCRPC.Methods
{
   public partial class Playlist
   {
        private readonly Client _client;
          public Playlist(Client client)
          {
              _client = client;
          }

        async public Task<string> Add(int playlistid=0, XBMCRPC.Playlist.Item item=null)
        {
            var jArgs = new JObject();
             if (playlistid != null)
             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
            var jRet = await _client.GetData<string>("Playlist.Add", jArgs);
            return jRet;
        }

        async public Task<string> Clear(int playlistid=0)
        {
            var jArgs = new JObject();
             if (playlistid != null)
             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
            var jRet = await _client.GetData<string>("Playlist.Clear", jArgs);
            return jRet;
        }
   public class GetItemsResponse
   {
       public XBMCRPC.List.Item.All[] items {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetItemsResponse> GetItems(int playlistid=0, XBMCRPC.List.Fields.All properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();
             if (playlistid != null)
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
            var jRet = await _client.GetData<GetItemsResponse>("Playlist.GetItems", jArgs);
            return jRet;
        }
   public class GetPlaylistsResponse
   {
       public int playlistid {get;set;}
       public XBMCRPC.Playlist.Type type {get;set;}
   }

        async public Task<GetPlaylistsResponse[]> GetPlaylists()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<GetPlaylistsResponse[]>("Playlist.GetPlaylists", jArgs);
            return jRet;
        }

        async public Task<XBMCRPC.Playlist.Property.Value> GetProperties(int playlistid=0, XBMCRPC.Playlist.Property.Name[] properties=null)
        {
            var jArgs = new JObject();
             if (playlistid != null)
             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<XBMCRPC.Playlist.Property.Value>("Playlist.GetProperties", jArgs);
            return jRet;
        }

        async public Task<string> Insert(int playlistid=0, int position=0, XBMCRPC.Playlist.Item item=null)
        {
            var jArgs = new JObject();
             if (playlistid != null)
             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             if (position != null)
             {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
             }
             if (item != null)
             {
                 var jpropitem = JToken.FromObject(item, _client.Serializer);
                 jArgs.Add(new JProperty("item", jpropitem));
             }
            var jRet = await _client.GetData<string>("Playlist.Insert", jArgs);
            return jRet;
        }

        async public Task<string> Remove(int playlistid=0, int position=0)
        {
            var jArgs = new JObject();
             if (playlistid != null)
             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             if (position != null)
             {
                 var jpropposition = JToken.FromObject(position, _client.Serializer);
                 jArgs.Add(new JProperty("position", jpropposition));
             }
            var jRet = await _client.GetData<string>("Playlist.Remove", jArgs);
            return jRet;
        }

        async public Task<string> Swap(int playlistid=0, int position1=0, int position2=0)
        {
            var jArgs = new JObject();
             if (playlistid != null)
             {
                 var jpropplaylistid = JToken.FromObject(playlistid, _client.Serializer);
                 jArgs.Add(new JProperty("playlistid", jpropplaylistid));
             }
             if (position1 != null)
             {
                 var jpropposition1 = JToken.FromObject(position1, _client.Serializer);
                 jArgs.Add(new JProperty("position1", jpropposition1));
             }
             if (position2 != null)
             {
                 var jpropposition2 = JToken.FromObject(position2, _client.Serializer);
                 jArgs.Add(new JProperty("position2", jpropposition2));
             }
            var jRet = await _client.GetData<string>("Playlist.Swap", jArgs);
            return jRet;
        }
   public class OnAdddataType
   {
       public XBMCRPC.Notifications.Item item {get;set;}
       public int playlistid {get;set;}
       public int position {get;set;}
   }

        public delegate void OnAddDelegate(string sender=null, OnAdddataType data=null);
        public event OnAddDelegate OnAdd;
        internal void RaiseOnAdd(string sender=null, OnAdddataType data=null)
        {
            if (OnAdd != null)
            {
                OnAdd.BeginInvoke(sender, data, null, null);
            }
        }
   public class OnCleardataType
   {
       public int playlistid {get;set;}
   }

        public delegate void OnClearDelegate(string sender=null, OnCleardataType data=null);
        public event OnClearDelegate OnClear;
        internal void RaiseOnClear(string sender=null, OnCleardataType data=null)
        {
            if (OnClear != null)
            {
                OnClear.BeginInvoke(sender, data, null, null);
            }
        }
   public class OnRemovedataType
   {
       public int playlistid {get;set;}
       public int position {get;set;}
   }

        public delegate void OnRemoveDelegate(string sender=null, OnRemovedataType data=null);
        public event OnRemoveDelegate OnRemove;
        internal void RaiseOnRemove(string sender=null, OnRemovedataType data=null)
        {
            if (OnRemove != null)
            {
                OnRemove.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
