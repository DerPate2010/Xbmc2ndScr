using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace XBMCRPC.Methods
{
   public partial class AudioLibrary
   {
        private readonly Client _client;
          public AudioLibrary(Client client)
          {
              _client = client;
          }

        async public Task<string> Clean()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("AudioLibrary.Clean", jArgs);
            return jRet;
        }

        async public Task<string> Export()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("AudioLibrary.Export", jArgs);
            return jRet;
        }
   public class Exportoptions1
   {
       public string path {get;set;}
   }

        async public Task<string> Export2(Exportoptions1 options=null)
        {
            var jArgs = new JObject();
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            var jRet = await _client.GetData<string>("AudioLibrary.Export", jArgs);
            return jRet;
        }
   public class Exportoptions2
   {
       public bool images {get;set;}
       public bool overwrite {get;set;}
   }

        async public Task<string> Export2(Exportoptions2 options=null)
        {
            var jArgs = new JObject();
             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            var jRet = await _client.GetData<string>("AudioLibrary.Export", jArgs);
            return jRet;
        }
   public class GetAlbumDetailsResponse
   {
       public XBMCRPC.Audio.Details.Album albumdetails {get;set;}
   }

        async public Task<GetAlbumDetailsResponse> GetAlbumDetails(int albumid=0, XBMCRPC.Audio.Fields.Album properties=null)
        {
            var jArgs = new JObject();
             if (albumid != null)
             {
                 var jpropalbumid = JToken.FromObject(albumid, _client.Serializer);
                 jArgs.Add(new JProperty("albumid", jpropalbumid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<GetAlbumDetailsResponse>("AudioLibrary.GetAlbumDetails", jArgs);
            return jRet;
        }
   public class GetAlbumsResponse
   {
       public XBMCRPC.Audio.Details.Album[] albums {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetAlbumsResponse> GetAlbums(XBMCRPC.Audio.Fields.Album properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();
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
            var jRet = await _client.GetData<GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
            return jRet;
        }
   public class GetAlbumsfilter1
   {
       public int genreid {get;set;}
   }

        async public Task<GetAlbumsResponse> GetAlbums2(XBMCRPC.Audio.Fields.Album properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetAlbumsfilter1 filter=null)
        {
            var jArgs = new JObject();
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
            return jRet;
        }
   public class GetAlbumsfilter2
   {
       public string genre {get;set;}
   }

        async public Task<GetAlbumsResponse> GetAlbums2(XBMCRPC.Audio.Fields.Album properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetAlbumsfilter2 filter=null)
        {
            var jArgs = new JObject();
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
            return jRet;
        }
   public class GetAlbumsfilter3
   {
       public int artistid {get;set;}
   }

        async public Task<GetAlbumsResponse> GetAlbums2(XBMCRPC.Audio.Fields.Album properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetAlbumsfilter3 filter=null)
        {
            var jArgs = new JObject();
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
            return jRet;
        }
   public class GetAlbumsfilter4
   {
       public string artist {get;set;}
   }

        async public Task<GetAlbumsResponse> GetAlbums2(XBMCRPC.Audio.Fields.Album properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetAlbumsfilter4 filter=null)
        {
            var jArgs = new JObject();
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
            return jRet;
        }

        async public Task<GetAlbumsResponse> GetAlbums2(XBMCRPC.Audio.Fields.Album properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, XBMCRPC.List.Filter.Albums filter=null)
        {
            var jArgs = new JObject();
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
            return jRet;
        }
   public class GetArtistDetailsResponse
   {
       public XBMCRPC.Audio.Details.Artist artistdetails {get;set;}
   }

        async public Task<GetArtistDetailsResponse> GetArtistDetails(int artistid=0, XBMCRPC.Audio.Fields.Artist properties=null)
        {
            var jArgs = new JObject();
             if (artistid != null)
             {
                 var jpropartistid = JToken.FromObject(artistid, _client.Serializer);
                 jArgs.Add(new JProperty("artistid", jpropartistid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<GetArtistDetailsResponse>("AudioLibrary.GetArtistDetails", jArgs);
            return jRet;
        }
   public class GetArtistsResponse
   {
       public XBMCRPC.Audio.Details.Artist[] artists {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetArtistsResponse> GetArtists(bool? albumartistsonly=null, XBMCRPC.Audio.Fields.Artist properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();
             if (albumartistsonly != null)
             {
                 var jpropalbumartistsonly = JToken.FromObject(albumartistsonly, _client.Serializer);
                 jArgs.Add(new JProperty("albumartistsonly", jpropalbumartistsonly));
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
            var jRet = await _client.GetData<GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
            return jRet;
        }
   public class GetArtistsfilter1
   {
       public int genreid {get;set;}
   }

        async public Task<GetArtistsResponse> GetArtists2(bool? albumartistsonly=null, XBMCRPC.Audio.Fields.Artist properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetArtistsfilter1 filter=null)
        {
            var jArgs = new JObject();
             if (albumartistsonly != null)
             {
                 var jpropalbumartistsonly = JToken.FromObject(albumartistsonly, _client.Serializer);
                 jArgs.Add(new JProperty("albumartistsonly", jpropalbumartistsonly));
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
            return jRet;
        }
   public class GetArtistsfilter2
   {
       public string genre {get;set;}
   }

        async public Task<GetArtistsResponse> GetArtists2(bool? albumartistsonly=null, XBMCRPC.Audio.Fields.Artist properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetArtistsfilter2 filter=null)
        {
            var jArgs = new JObject();
             if (albumartistsonly != null)
             {
                 var jpropalbumartistsonly = JToken.FromObject(albumartistsonly, _client.Serializer);
                 jArgs.Add(new JProperty("albumartistsonly", jpropalbumartistsonly));
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
            return jRet;
        }
   public class GetArtistsfilter3
   {
       public int albumid {get;set;}
   }

        async public Task<GetArtistsResponse> GetArtists2(bool? albumartistsonly=null, XBMCRPC.Audio.Fields.Artist properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetArtistsfilter3 filter=null)
        {
            var jArgs = new JObject();
             if (albumartistsonly != null)
             {
                 var jpropalbumartistsonly = JToken.FromObject(albumartistsonly, _client.Serializer);
                 jArgs.Add(new JProperty("albumartistsonly", jpropalbumartistsonly));
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
            return jRet;
        }
   public class GetArtistsfilter4
   {
       public string album {get;set;}
   }

        async public Task<GetArtistsResponse> GetArtists2(bool? albumartistsonly=null, XBMCRPC.Audio.Fields.Artist properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetArtistsfilter4 filter=null)
        {
            var jArgs = new JObject();
             if (albumartistsonly != null)
             {
                 var jpropalbumartistsonly = JToken.FromObject(albumartistsonly, _client.Serializer);
                 jArgs.Add(new JProperty("albumartistsonly", jpropalbumartistsonly));
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
            return jRet;
        }
   public class GetArtistsfilter5
   {
       public int songid {get;set;}
   }

        async public Task<GetArtistsResponse> GetArtists2(bool? albumartistsonly=null, XBMCRPC.Audio.Fields.Artist properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetArtistsfilter5 filter=null)
        {
            var jArgs = new JObject();
             if (albumartistsonly != null)
             {
                 var jpropalbumartistsonly = JToken.FromObject(albumartistsonly, _client.Serializer);
                 jArgs.Add(new JProperty("albumartistsonly", jpropalbumartistsonly));
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
            return jRet;
        }

        async public Task<GetArtistsResponse> GetArtists2(bool? albumartistsonly=null, XBMCRPC.Audio.Fields.Artist properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, XBMCRPC.List.Filter.Artists filter=null)
        {
            var jArgs = new JObject();
             if (albumartistsonly != null)
             {
                 var jpropalbumartistsonly = JToken.FromObject(albumartistsonly, _client.Serializer);
                 jArgs.Add(new JProperty("albumartistsonly", jpropalbumartistsonly));
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
            return jRet;
        }
   public class GetGenresResponse
   {
       public XBMCRPC.Library.Details.Genre[] genres {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetGenresResponse> GetGenres(XBMCRPC.Library.Fields.Genre properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();
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
            var jRet = await _client.GetData<GetGenresResponse>("AudioLibrary.GetGenres", jArgs);
            return jRet;
        }
   public class GetRecentlyAddedAlbumsResponse
   {
       public XBMCRPC.Audio.Details.Album[] albums {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetRecentlyAddedAlbumsResponse> GetRecentlyAddedAlbums(XBMCRPC.Audio.Fields.Album properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();
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
            var jRet = await _client.GetData<GetRecentlyAddedAlbumsResponse>("AudioLibrary.GetRecentlyAddedAlbums", jArgs);
            return jRet;
        }
   public class GetRecentlyAddedSongsResponse
   {
       public XBMCRPC.List.LimitsReturned limits {get;set;}
       public XBMCRPC.Audio.Details.Song[] songs {get;set;}
   }

        async public Task<GetRecentlyAddedSongsResponse> GetRecentlyAddedSongs(int albumlimit=0, XBMCRPC.Audio.Fields.Song properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();
             if (albumlimit != null)
             {
                 var jpropalbumlimit = JToken.FromObject(albumlimit, _client.Serializer);
                 jArgs.Add(new JProperty("albumlimit", jpropalbumlimit));
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
            var jRet = await _client.GetData<GetRecentlyAddedSongsResponse>("AudioLibrary.GetRecentlyAddedSongs", jArgs);
            return jRet;
        }
   public class GetRecentlyPlayedAlbumsResponse
   {
       public XBMCRPC.Audio.Details.Album[] albums {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetRecentlyPlayedAlbumsResponse> GetRecentlyPlayedAlbums(XBMCRPC.Audio.Fields.Album properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();
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
            var jRet = await _client.GetData<GetRecentlyPlayedAlbumsResponse>("AudioLibrary.GetRecentlyPlayedAlbums", jArgs);
            return jRet;
        }
   public class GetRecentlyPlayedSongsResponse
   {
       public XBMCRPC.List.LimitsReturned limits {get;set;}
       public XBMCRPC.Audio.Details.Song[] songs {get;set;}
   }

        async public Task<GetRecentlyPlayedSongsResponse> GetRecentlyPlayedSongs(XBMCRPC.Audio.Fields.Song properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();
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
            var jRet = await _client.GetData<GetRecentlyPlayedSongsResponse>("AudioLibrary.GetRecentlyPlayedSongs", jArgs);
            return jRet;
        }
   public class GetSongDetailsResponse
   {
       public XBMCRPC.Audio.Details.Song songdetails {get;set;}
   }

        async public Task<GetSongDetailsResponse> GetSongDetails(int songid=0, XBMCRPC.Audio.Fields.Song properties=null)
        {
            var jArgs = new JObject();
             if (songid != null)
             {
                 var jpropsongid = JToken.FromObject(songid, _client.Serializer);
                 jArgs.Add(new JProperty("songid", jpropsongid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<GetSongDetailsResponse>("AudioLibrary.GetSongDetails", jArgs);
            return jRet;
        }
   public class GetSongsResponse
   {
       public XBMCRPC.List.LimitsReturned limits {get;set;}
       public XBMCRPC.Audio.Details.Song[] songs {get;set;}
   }

        async public Task<GetSongsResponse> GetSongs(XBMCRPC.Audio.Fields.Song properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();
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
            var jRet = await _client.GetData<GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
            return jRet;
        }
   public class GetSongsfilter1
   {
       public int genreid {get;set;}
   }

        async public Task<GetSongsResponse> GetSongs2(XBMCRPC.Audio.Fields.Song properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetSongsfilter1 filter=null)
        {
            var jArgs = new JObject();
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
            return jRet;
        }
   public class GetSongsfilter2
   {
       public string genre {get;set;}
   }

        async public Task<GetSongsResponse> GetSongs2(XBMCRPC.Audio.Fields.Song properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetSongsfilter2 filter=null)
        {
            var jArgs = new JObject();
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
            return jRet;
        }
   public class GetSongsfilter3
   {
       public int artistid {get;set;}
   }

        async public Task<GetSongsResponse> GetSongs2(XBMCRPC.Audio.Fields.Song properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetSongsfilter3 filter=null)
        {
            var jArgs = new JObject();
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
            return jRet;
        }
   public class GetSongsfilter4
   {
       public string artist {get;set;}
   }

        async public Task<GetSongsResponse> GetSongs2(XBMCRPC.Audio.Fields.Song properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetSongsfilter4 filter=null)
        {
            var jArgs = new JObject();
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
            return jRet;
        }
   public class GetSongsfilter5
   {
       public int albumid {get;set;}
   }

        async public Task<GetSongsResponse> GetSongs2(XBMCRPC.Audio.Fields.Song properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetSongsfilter5 filter=null)
        {
            var jArgs = new JObject();
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
            return jRet;
        }
   public class GetSongsfilter6
   {
       public string album {get;set;}
   }

        async public Task<GetSongsResponse> GetSongs2(XBMCRPC.Audio.Fields.Song properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetSongsfilter6 filter=null)
        {
            var jArgs = new JObject();
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
            return jRet;
        }

        async public Task<GetSongsResponse> GetSongs2(XBMCRPC.Audio.Fields.Song properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, XBMCRPC.List.Filter.Songs filter=null)
        {
            var jArgs = new JObject();
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
             if (filter != null)
             {
                 var jpropfilter = JToken.FromObject(filter, _client.Serializer);
                 jArgs.Add(new JProperty("filter", jpropfilter));
             }
            var jRet = await _client.GetData<GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
            return jRet;
        }

        async public Task<string> Scan(string directory=null)
        {
            var jArgs = new JObject();
             if (directory != null)
             {
                 var jpropdirectory = JToken.FromObject(directory, _client.Serializer);
                 jArgs.Add(new JProperty("directory", jpropdirectory));
             }
            var jRet = await _client.GetData<string>("AudioLibrary.Scan", jArgs);
            return jRet;
        }

        async public Task<string> SetAlbumDetails(int albumid=0, string title=null, string[] artist=null, string description=null, string[] genre=null, string[] theme=null, string[] mood=null, string[] style=null, string type=null, string albumlabel=null, int? rating=null, int? year=null)
        {
            var jArgs = new JObject();
             if (albumid != null)
             {
                 var jpropalbumid = JToken.FromObject(albumid, _client.Serializer);
                 jArgs.Add(new JProperty("albumid", jpropalbumid));
             }
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             if (artist != null)
             {
                 var jpropartist = JToken.FromObject(artist, _client.Serializer);
                 jArgs.Add(new JProperty("artist", jpropartist));
             }
             if (description != null)
             {
                 var jpropdescription = JToken.FromObject(description, _client.Serializer);
                 jArgs.Add(new JProperty("description", jpropdescription));
             }
             if (genre != null)
             {
                 var jpropgenre = JToken.FromObject(genre, _client.Serializer);
                 jArgs.Add(new JProperty("genre", jpropgenre));
             }
             if (theme != null)
             {
                 var jproptheme = JToken.FromObject(theme, _client.Serializer);
                 jArgs.Add(new JProperty("theme", jproptheme));
             }
             if (mood != null)
             {
                 var jpropmood = JToken.FromObject(mood, _client.Serializer);
                 jArgs.Add(new JProperty("mood", jpropmood));
             }
             if (style != null)
             {
                 var jpropstyle = JToken.FromObject(style, _client.Serializer);
                 jArgs.Add(new JProperty("style", jpropstyle));
             }
             if (type != null)
             {
                 var jproptype = JToken.FromObject(type, _client.Serializer);
                 jArgs.Add(new JProperty("type", jproptype));
             }
             if (albumlabel != null)
             {
                 var jpropalbumlabel = JToken.FromObject(albumlabel, _client.Serializer);
                 jArgs.Add(new JProperty("albumlabel", jpropalbumlabel));
             }
             if (rating != null)
             {
                 var jproprating = JToken.FromObject(rating, _client.Serializer);
                 jArgs.Add(new JProperty("rating", jproprating));
             }
             if (year != null)
             {
                 var jpropyear = JToken.FromObject(year, _client.Serializer);
                 jArgs.Add(new JProperty("year", jpropyear));
             }
            var jRet = await _client.GetData<string>("AudioLibrary.SetAlbumDetails", jArgs);
            return jRet;
        }

        async public Task<string> SetArtistDetails(int artistid=0, string artist=null, string[] instrument=null, string[] style=null, string[] mood=null, string born=null, string formed=null, string description=null, string[] genre=null, string died=null, string disbanded=null, string[] yearsactive=null)
        {
            var jArgs = new JObject();
             if (artistid != null)
             {
                 var jpropartistid = JToken.FromObject(artistid, _client.Serializer);
                 jArgs.Add(new JProperty("artistid", jpropartistid));
             }
             if (artist != null)
             {
                 var jpropartist = JToken.FromObject(artist, _client.Serializer);
                 jArgs.Add(new JProperty("artist", jpropartist));
             }
             if (instrument != null)
             {
                 var jpropinstrument = JToken.FromObject(instrument, _client.Serializer);
                 jArgs.Add(new JProperty("instrument", jpropinstrument));
             }
             if (style != null)
             {
                 var jpropstyle = JToken.FromObject(style, _client.Serializer);
                 jArgs.Add(new JProperty("style", jpropstyle));
             }
             if (mood != null)
             {
                 var jpropmood = JToken.FromObject(mood, _client.Serializer);
                 jArgs.Add(new JProperty("mood", jpropmood));
             }
             if (born != null)
             {
                 var jpropborn = JToken.FromObject(born, _client.Serializer);
                 jArgs.Add(new JProperty("born", jpropborn));
             }
             if (formed != null)
             {
                 var jpropformed = JToken.FromObject(formed, _client.Serializer);
                 jArgs.Add(new JProperty("formed", jpropformed));
             }
             if (description != null)
             {
                 var jpropdescription = JToken.FromObject(description, _client.Serializer);
                 jArgs.Add(new JProperty("description", jpropdescription));
             }
             if (genre != null)
             {
                 var jpropgenre = JToken.FromObject(genre, _client.Serializer);
                 jArgs.Add(new JProperty("genre", jpropgenre));
             }
             if (died != null)
             {
                 var jpropdied = JToken.FromObject(died, _client.Serializer);
                 jArgs.Add(new JProperty("died", jpropdied));
             }
             if (disbanded != null)
             {
                 var jpropdisbanded = JToken.FromObject(disbanded, _client.Serializer);
                 jArgs.Add(new JProperty("disbanded", jpropdisbanded));
             }
             if (yearsactive != null)
             {
                 var jpropyearsactive = JToken.FromObject(yearsactive, _client.Serializer);
                 jArgs.Add(new JProperty("yearsactive", jpropyearsactive));
             }
            var jRet = await _client.GetData<string>("AudioLibrary.SetArtistDetails", jArgs);
            return jRet;
        }

        async public Task<string> SetSongDetails(int songid=0, string title=null, string[] artist=null, string[] albumartist=null, string[] genre=null, int? year=null, int? rating=null, string album=null, int? track=null, int? disc=null, int? duration=null, string comment=null, string musicbrainztrackid=null, string musicbrainzartistid=null, string musicbrainzalbumid=null, string musicbrainzalbumartistid=null)
        {
            var jArgs = new JObject();
             if (songid != null)
             {
                 var jpropsongid = JToken.FromObject(songid, _client.Serializer);
                 jArgs.Add(new JProperty("songid", jpropsongid));
             }
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             if (artist != null)
             {
                 var jpropartist = JToken.FromObject(artist, _client.Serializer);
                 jArgs.Add(new JProperty("artist", jpropartist));
             }
             if (albumartist != null)
             {
                 var jpropalbumartist = JToken.FromObject(albumartist, _client.Serializer);
                 jArgs.Add(new JProperty("albumartist", jpropalbumartist));
             }
             if (genre != null)
             {
                 var jpropgenre = JToken.FromObject(genre, _client.Serializer);
                 jArgs.Add(new JProperty("genre", jpropgenre));
             }
             if (year != null)
             {
                 var jpropyear = JToken.FromObject(year, _client.Serializer);
                 jArgs.Add(new JProperty("year", jpropyear));
             }
             if (rating != null)
             {
                 var jproprating = JToken.FromObject(rating, _client.Serializer);
                 jArgs.Add(new JProperty("rating", jproprating));
             }
             if (album != null)
             {
                 var jpropalbum = JToken.FromObject(album, _client.Serializer);
                 jArgs.Add(new JProperty("album", jpropalbum));
             }
             if (track != null)
             {
                 var jproptrack = JToken.FromObject(track, _client.Serializer);
                 jArgs.Add(new JProperty("track", jproptrack));
             }
             if (disc != null)
             {
                 var jpropdisc = JToken.FromObject(disc, _client.Serializer);
                 jArgs.Add(new JProperty("disc", jpropdisc));
             }
             if (duration != null)
             {
                 var jpropduration = JToken.FromObject(duration, _client.Serializer);
                 jArgs.Add(new JProperty("duration", jpropduration));
             }
             if (comment != null)
             {
                 var jpropcomment = JToken.FromObject(comment, _client.Serializer);
                 jArgs.Add(new JProperty("comment", jpropcomment));
             }
             if (musicbrainztrackid != null)
             {
                 var jpropmusicbrainztrackid = JToken.FromObject(musicbrainztrackid, _client.Serializer);
                 jArgs.Add(new JProperty("musicbrainztrackid", jpropmusicbrainztrackid));
             }
             if (musicbrainzartistid != null)
             {
                 var jpropmusicbrainzartistid = JToken.FromObject(musicbrainzartistid, _client.Serializer);
                 jArgs.Add(new JProperty("musicbrainzartistid", jpropmusicbrainzartistid));
             }
             if (musicbrainzalbumid != null)
             {
                 var jpropmusicbrainzalbumid = JToken.FromObject(musicbrainzalbumid, _client.Serializer);
                 jArgs.Add(new JProperty("musicbrainzalbumid", jpropmusicbrainzalbumid));
             }
             if (musicbrainzalbumartistid != null)
             {
                 var jpropmusicbrainzalbumartistid = JToken.FromObject(musicbrainzalbumartistid, _client.Serializer);
                 jArgs.Add(new JProperty("musicbrainzalbumartistid", jpropmusicbrainzalbumartistid));
             }
            var jRet = await _client.GetData<string>("AudioLibrary.SetSongDetails", jArgs);
            return jRet;
        }

        public delegate void OnCleanFinishedDelegate(string sender=null);
        public event OnCleanFinishedDelegate OnCleanFinished;
        internal void RaiseOnCleanFinished(string sender=null)
        {
            if (OnCleanFinished != null)
            {
                OnCleanFinished.BeginInvoke(sender, null, null);
            }
        }

        public delegate void OnCleanStartedDelegate(string sender=null);
        public event OnCleanStartedDelegate OnCleanStarted;
        internal void RaiseOnCleanStarted(string sender=null)
        {
            if (OnCleanStarted != null)
            {
                OnCleanStarted.BeginInvoke(sender, null, null);
            }
        }
   public class OnRemovedataType
   {
       public int id {get;set;}
       public string type {get;set;}
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

        public delegate void OnScanFinishedDelegate(string sender=null);
        public event OnScanFinishedDelegate OnScanFinished;
        internal void RaiseOnScanFinished(string sender=null)
        {
            if (OnScanFinished != null)
            {
                OnScanFinished.BeginInvoke(sender, null, null);
            }
        }

        public delegate void OnScanStartedDelegate(string sender=null);
        public event OnScanStartedDelegate OnScanStarted;
        internal void RaiseOnScanStarted(string sender=null)
        {
            if (OnScanStarted != null)
            {
                OnScanStarted.BeginInvoke(sender, null, null);
            }
        }
   public class OnUpdatedataType
   {
       public int id {get;set;}
       public string type {get;set;}
   }

        public delegate void OnUpdateDelegate(string sender=null, OnUpdatedataType data=null);
        public event OnUpdateDelegate OnUpdate;
        internal void RaiseOnUpdate(string sender=null, OnUpdatedataType data=null)
        {
            if (OnUpdate != null)
            {
                OnUpdate.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
