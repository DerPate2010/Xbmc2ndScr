using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace KODIRPC.Methods
{
   public partial class AudioLibrary
   {
        private readonly Client _client;
          public AudioLibrary(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Cleans the audio library from non-existent items
                /// </summary>
                /// <param name="showdialogs"> Whether or not to show the progress bar or any other GUI dialog</param>
                /// <returns>string</returns>
        public async Task<string> Clean(bool? showdialogs=null)
        {
             var jArgs = new JObject();

             if (showdialogs != null)
             {
                 var jpropshowdialogs = JToken.FromObject(showdialogs, _client.Serializer);
                 jArgs.Add(new JProperty("showdialogs", jpropshowdialogs));
             }
            return await _client.GetData<string>("AudioLibrary.Clean", jArgs);
        }

                /// <summary>
                /// Exports all items from the audio library
                /// </summary>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Export(KODIRPC.AudioLibrary.Export_optionsPath options=null)
        {
             var jArgs = new JObject();

             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("AudioLibrary.Export", jArgs);
        }

                /// <summary>
                /// Exports all items from the audio library
                /// </summary>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Export(KODIRPC.AudioLibrary.Export_options1 options=null)
        {
             var jArgs = new JObject();

             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("AudioLibrary.Export", jArgs);
        }

                /// <summary>
                /// Exports all items from the audio library
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Export()
        {
            return await _client.GetData<string>("AudioLibrary.Export",null);
        }

                /// <summary>
                /// Retrieve details about a specific album
                /// </summary>
                /// <param name="albumid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetAlbumDetailsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetAlbumDetailsResponse> GetAlbumDetails(int? albumid=null, KODIRPC.Audio.Fields.Album properties=null)
        {
             var jArgs = new JObject();

             if (albumid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null albumid");
              }
             else
              {
                 var jpropalbumid = JToken.FromObject(albumid, _client.Serializer);
                 jArgs.Add(new JProperty("albumid", jpropalbumid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetAlbumDetailsResponse>("AudioLibrary.GetAlbumDetails", jArgs);
        }

                /// <summary>
                /// Retrieve all albums from specified artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetAlbumsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetAlbumsResponse> GetAlbums(KODIRPC.Audio.Fields.Album properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetAlbums_filterGenreid filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
        }

                /// <summary>
                /// Retrieve all albums from specified artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetAlbumsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetAlbumsResponse> GetAlbums(KODIRPC.Audio.Fields.Album properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetAlbums_filterGenre filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
        }

                /// <summary>
                /// Retrieve all albums from specified artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetAlbumsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetAlbumsResponse> GetAlbums(KODIRPC.Audio.Fields.Album properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetAlbums_filterArtistid filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
        }

                /// <summary>
                /// Retrieve all albums from specified artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetAlbumsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetAlbumsResponse> GetAlbums(KODIRPC.Audio.Fields.Album properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetAlbums_filterArtist filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
        }

                /// <summary>
                /// Retrieve all albums from specified artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetAlbumsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetAlbumsResponse> GetAlbums(KODIRPC.Audio.Fields.Album properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.AlbumsAnd filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
        }

                /// <summary>
                /// Retrieve all albums from specified artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetAlbumsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetAlbumsResponse> GetAlbums(KODIRPC.Audio.Fields.Album properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.AlbumsOr filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
        }

                /// <summary>
                /// Retrieve all albums from specified artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetAlbumsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetAlbumsResponse> GetAlbums(KODIRPC.Audio.Fields.Album properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.Rule.Albums filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
        }

                /// <summary>
                /// Retrieve all albums from specified artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetAlbumsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetAlbumsResponse> GetAlbums(KODIRPC.Audio.Fields.Album properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetAlbumsResponse>("AudioLibrary.GetAlbums", jArgs);
        }

                /// <summary>
                /// Retrieve details about a specific artist
                /// </summary>
                /// <param name="artistid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetArtistDetailsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetArtistDetailsResponse> GetArtistDetails(int? artistid=null, KODIRPC.Audio.Fields.Artist properties=null)
        {
             var jArgs = new JObject();

             if (artistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null artistid");
              }
             else
              {
                 var jpropartistid = JToken.FromObject(artistid, _client.Serializer);
                 jArgs.Add(new JProperty("artistid", jpropartistid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetArtistDetailsResponse>("AudioLibrary.GetArtistDetails", jArgs);
        }

                /// <summary>
                /// Retrieve all artists
                /// </summary>
                /// <param name="albumartistsonly"> Whether or not to include artists only appearing in compilations. If the parameter is not passed or is passed as null the GUI setting will be used</param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetArtistsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetArtistsResponse> GetArtists(bool? albumartistsonly=null, KODIRPC.Audio.Fields.Artist properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetArtists_filterGenreid filter=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
        }

                /// <summary>
                /// Retrieve all artists
                /// </summary>
                /// <param name="albumartistsonly"> Whether or not to include artists only appearing in compilations. If the parameter is not passed or is passed as null the GUI setting will be used</param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetArtistsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetArtistsResponse> GetArtists(bool? albumartistsonly=null, KODIRPC.Audio.Fields.Artist properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetArtists_filterGenre filter=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
        }

                /// <summary>
                /// Retrieve all artists
                /// </summary>
                /// <param name="albumartistsonly"> Whether or not to include artists only appearing in compilations. If the parameter is not passed or is passed as null the GUI setting will be used</param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetArtistsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetArtistsResponse> GetArtists(bool? albumartistsonly=null, KODIRPC.Audio.Fields.Artist properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetArtists_filterAlbumid filter=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
        }

                /// <summary>
                /// Retrieve all artists
                /// </summary>
                /// <param name="albumartistsonly"> Whether or not to include artists only appearing in compilations. If the parameter is not passed or is passed as null the GUI setting will be used</param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetArtistsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetArtistsResponse> GetArtists(bool? albumartistsonly=null, KODIRPC.Audio.Fields.Artist properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetArtists_filterAlbum filter=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
        }

                /// <summary>
                /// Retrieve all artists
                /// </summary>
                /// <param name="albumartistsonly"> Whether or not to include artists only appearing in compilations. If the parameter is not passed or is passed as null the GUI setting will be used</param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetArtistsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetArtistsResponse> GetArtists(bool? albumartistsonly=null, KODIRPC.Audio.Fields.Artist properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetArtists_filterSongid filter=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
        }

                /// <summary>
                /// Retrieve all artists
                /// </summary>
                /// <param name="albumartistsonly"> Whether or not to include artists only appearing in compilations. If the parameter is not passed or is passed as null the GUI setting will be used</param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetArtistsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetArtistsResponse> GetArtists(bool? albumartistsonly=null, KODIRPC.Audio.Fields.Artist properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.ArtistsAnd filter=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
        }

                /// <summary>
                /// Retrieve all artists
                /// </summary>
                /// <param name="albumartistsonly"> Whether or not to include artists only appearing in compilations. If the parameter is not passed or is passed as null the GUI setting will be used</param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetArtistsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetArtistsResponse> GetArtists(bool? albumartistsonly=null, KODIRPC.Audio.Fields.Artist properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.ArtistsOr filter=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
        }

                /// <summary>
                /// Retrieve all artists
                /// </summary>
                /// <param name="albumartistsonly"> Whether or not to include artists only appearing in compilations. If the parameter is not passed or is passed as null the GUI setting will be used</param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetArtistsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetArtistsResponse> GetArtists(bool? albumartistsonly=null, KODIRPC.Audio.Fields.Artist properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.Rule.Artists filter=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
        }

                /// <summary>
                /// Retrieve all artists
                /// </summary>
                /// <param name="albumartistsonly"> Whether or not to include artists only appearing in compilations. If the parameter is not passed or is passed as null the GUI setting will be used</param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetArtistsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetArtistsResponse> GetArtists(bool? albumartistsonly=null, KODIRPC.Audio.Fields.Artist properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetArtistsResponse>("AudioLibrary.GetArtists", jArgs);
        }

                /// <summary>
                /// Retrieve all genres
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetGenresResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetGenresResponse> GetGenres(KODIRPC.Library.Fields.Genre properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetGenresResponse>("AudioLibrary.GetGenres", jArgs);
        }

                /// <summary>
                /// Retrieve recently added albums
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetRecentlyAddedAlbumsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetRecentlyAddedAlbumsResponse> GetRecentlyAddedAlbums(KODIRPC.Audio.Fields.Album properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetRecentlyAddedAlbumsResponse>("AudioLibrary.GetRecentlyAddedAlbums", jArgs);
        }

                /// <summary>
                /// Retrieve recently added songs
                /// </summary>
                /// <param name="albumlimit"> The amount of recently added albums from which to return the songs</param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetRecentlyAddedSongsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetRecentlyAddedSongsResponse> GetRecentlyAddedSongs(int? albumlimit=null, KODIRPC.Audio.Fields.Song properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetRecentlyAddedSongsResponse>("AudioLibrary.GetRecentlyAddedSongs", jArgs);
        }

                /// <summary>
                /// Retrieve recently played albums
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetRecentlyPlayedAlbumsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetRecentlyPlayedAlbumsResponse> GetRecentlyPlayedAlbums(KODIRPC.Audio.Fields.Album properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetRecentlyPlayedAlbumsResponse>("AudioLibrary.GetRecentlyPlayedAlbums", jArgs);
        }

                /// <summary>
                /// Retrieve recently played songs
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetRecentlyPlayedSongsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetRecentlyPlayedSongsResponse> GetRecentlyPlayedSongs(KODIRPC.Audio.Fields.Song properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.AudioLibrary.GetRecentlyPlayedSongsResponse>("AudioLibrary.GetRecentlyPlayedSongs", jArgs);
        }

                /// <summary>
                /// Retrieve details about a specific song
                /// </summary>
                /// <param name="songid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetSongDetailsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetSongDetailsResponse> GetSongDetails(int? songid=null, KODIRPC.Audio.Fields.Song properties=null)
        {
             var jArgs = new JObject();

             if (songid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null songid");
              }
             else
              {
                 var jpropsongid = JToken.FromObject(songid, _client.Serializer);
                 jArgs.Add(new JProperty("songid", jpropsongid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetSongDetailsResponse>("AudioLibrary.GetSongDetails", jArgs);
        }

                /// <summary>
                /// Retrieve all songs from specified album, artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetSongsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetSongsResponse> GetSongs(KODIRPC.Audio.Fields.Song properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetSongs_filterGenreid filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
        }

                /// <summary>
                /// Retrieve all songs from specified album, artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetSongsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetSongsResponse> GetSongs(KODIRPC.Audio.Fields.Song properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetSongs_filterGenre filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
        }

                /// <summary>
                /// Retrieve all songs from specified album, artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetSongsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetSongsResponse> GetSongs(KODIRPC.Audio.Fields.Song properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetSongs_filterArtistid filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
        }

                /// <summary>
                /// Retrieve all songs from specified album, artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetSongsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetSongsResponse> GetSongs(KODIRPC.Audio.Fields.Song properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetSongs_filterArtist filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
        }

                /// <summary>
                /// Retrieve all songs from specified album, artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetSongsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetSongsResponse> GetSongs(KODIRPC.Audio.Fields.Song properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetSongs_filterAlbumid filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
        }

                /// <summary>
                /// Retrieve all songs from specified album, artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetSongsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetSongsResponse> GetSongs(KODIRPC.Audio.Fields.Song properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.AudioLibrary.GetSongs_filterAlbum filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
        }

                /// <summary>
                /// Retrieve all songs from specified album, artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetSongsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetSongsResponse> GetSongs(KODIRPC.Audio.Fields.Song properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.SongsAnd filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
        }

                /// <summary>
                /// Retrieve all songs from specified album, artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetSongsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetSongsResponse> GetSongs(KODIRPC.Audio.Fields.Song properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.SongsOr filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
        }

                /// <summary>
                /// Retrieve all songs from specified album, artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetSongsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetSongsResponse> GetSongs(KODIRPC.Audio.Fields.Song properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.Rule.Songs filter=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
        }

                /// <summary>
                /// Retrieve all songs from specified album, artist or genre
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="includesingles"> </param>
                /// <returns>KODIRPC.AudioLibrary.GetSongsResponse</returns>
        public async Task<KODIRPC.AudioLibrary.GetSongsResponse> GetSongs(KODIRPC.Audio.Fields.Song properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, bool? includesingles=null)
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
             if (includesingles != null)
             {
                 var jpropincludesingles = JToken.FromObject(includesingles, _client.Serializer);
                 jArgs.Add(new JProperty("includesingles", jpropincludesingles));
             }
            return await _client.GetData<KODIRPC.AudioLibrary.GetSongsResponse>("AudioLibrary.GetSongs", jArgs);
        }

                /// <summary>
                /// Scans the audio sources for new library items
                /// </summary>
                /// <param name="directory"> </param>
                /// <param name="showdialogs"> Whether or not to show the progress bar or any other GUI dialog</param>
                /// <returns>string</returns>
        public async Task<string> Scan(string directory=null, bool? showdialogs=null)
        {
             var jArgs = new JObject();

             if (directory != null)
             {
                 var jpropdirectory = JToken.FromObject(directory, _client.Serializer);
                 jArgs.Add(new JProperty("directory", jpropdirectory));
             }
             if (showdialogs != null)
             {
                 var jpropshowdialogs = JToken.FromObject(showdialogs, _client.Serializer);
                 jArgs.Add(new JProperty("showdialogs", jpropshowdialogs));
             }
            return await _client.GetData<string>("AudioLibrary.Scan", jArgs);
        }

                /// <summary>
                /// Update the given album with the given details
                /// </summary>
                /// <param name="albumid"> REQUIRED </param>
                /// <param name="title"> </param>
                /// <param name="artist"> </param>
                /// <param name="description"> </param>
                /// <param name="genre"> </param>
                /// <param name="theme"> </param>
                /// <param name="mood"> </param>
                /// <param name="style"> </param>
                /// <param name="type"> </param>
                /// <param name="albumlabel"> </param>
                /// <param name="rating"> </param>
                /// <param name="year"> </param>
                /// <returns>string</returns>
        public async Task<string> SetAlbumDetails(int? albumid=null, string title=null, global::System.Collections.Generic.List<string> artist=null, string description=null, global::System.Collections.Generic.List<string> genre=null, global::System.Collections.Generic.List<string> theme=null, global::System.Collections.Generic.List<string> mood=null, global::System.Collections.Generic.List<string> style=null, string type=null, string albumlabel=null, int? rating=null, int? year=null)
        {
             var jArgs = new JObject();

             if (albumid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null albumid");
              }
             else
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
            return await _client.GetData<string>("AudioLibrary.SetAlbumDetails", jArgs);
        }

                /// <summary>
                /// Update the given artist with the given details
                /// </summary>
                /// <param name="artistid"> REQUIRED </param>
                /// <param name="artist"> </param>
                /// <param name="instrument"> </param>
                /// <param name="style"> </param>
                /// <param name="mood"> </param>
                /// <param name="born"> </param>
                /// <param name="formed"> </param>
                /// <param name="description"> </param>
                /// <param name="genre"> </param>
                /// <param name="died"> </param>
                /// <param name="disbanded"> </param>
                /// <param name="yearsactive"> </param>
                /// <returns>string</returns>
        public async Task<string> SetArtistDetails(int? artistid=null, string artist=null, global::System.Collections.Generic.List<string> instrument=null, global::System.Collections.Generic.List<string> style=null, global::System.Collections.Generic.List<string> mood=null, string born=null, string formed=null, string description=null, global::System.Collections.Generic.List<string> genre=null, string died=null, string disbanded=null, global::System.Collections.Generic.List<string> yearsactive=null)
        {
             var jArgs = new JObject();

             if (artistid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null artistid");
              }
             else
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
            return await _client.GetData<string>("AudioLibrary.SetArtistDetails", jArgs);
        }

                /// <summary>
                /// Update the given song with the given details
                /// </summary>
                /// <param name="songid"> REQUIRED </param>
                /// <param name="title"> </param>
                /// <param name="artist"> </param>
                /// <param name="albumartist"> </param>
                /// <param name="genre"> </param>
                /// <param name="year"> </param>
                /// <param name="rating"> </param>
                /// <param name="album"> </param>
                /// <param name="track"> </param>
                /// <param name="disc"> </param>
                /// <param name="duration"> </param>
                /// <param name="comment"> </param>
                /// <param name="musicbrainztrackid"> </param>
                /// <param name="musicbrainzartistid"> </param>
                /// <param name="musicbrainzalbumid"> </param>
                /// <param name="musicbrainzalbumartistid"> </param>
                /// <param name="playcount"> </param>
                /// <param name="lastplayed"> </param>
                /// <returns>string</returns>
        public async Task<string> SetSongDetails(int? songid=null, string title=null, global::System.Collections.Generic.List<string> artist=null, global::System.Collections.Generic.List<string> albumartist=null, global::System.Collections.Generic.List<string> genre=null, int? year=null, int? rating=null, string album=null, int? track=null, int? disc=null, int? duration=null, string comment=null, string musicbrainztrackid=null, string musicbrainzartistid=null, string musicbrainzalbumid=null, string musicbrainzalbumartistid=null, int? playcount=null, string lastplayed=null)
        {
             var jArgs = new JObject();

             if (songid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null songid");
              }
             else
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
             if (playcount != null)
             {
                 var jpropplaycount = JToken.FromObject(playcount, _client.Serializer);
                 jArgs.Add(new JProperty("playcount", jpropplaycount));
             }
             if (lastplayed != null)
             {
                 var jproplastplayed = JToken.FromObject(lastplayed, _client.Serializer);
                 jArgs.Add(new JProperty("lastplayed", jproplastplayed));
             }
            return await _client.GetData<string>("AudioLibrary.SetSongDetails", jArgs);
        }

        public delegate void OnCleanFinishedDelegate(string sender=null, object data=null);
        public event OnCleanFinishedDelegate OnCleanFinished;
        internal void RaiseOnCleanFinished(string sender=null, object data=null)
        {
            if (OnCleanFinished != null)
            {
                OnCleanFinished.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnCleanStartedDelegate(string sender=null, object data=null);
        public event OnCleanStartedDelegate OnCleanStarted;
        internal void RaiseOnCleanStarted(string sender=null, object data=null)
        {
            if (OnCleanStarted != null)
            {
                OnCleanStarted.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnExportDelegate(string sender=null, KODIRPC.AudioLibrary.OnExport_data data=null);
        public event OnExportDelegate OnExport;
        internal void RaiseOnExport(string sender=null, KODIRPC.AudioLibrary.OnExport_data data=null)
        {
            if (OnExport != null)
            {
                OnExport.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnRemoveDelegate(string sender=null, KODIRPC.AudioLibrary.OnRemove_data data=null);
        public event OnRemoveDelegate OnRemove;
        internal void RaiseOnRemove(string sender=null, KODIRPC.AudioLibrary.OnRemove_data data=null)
        {
            if (OnRemove != null)
            {
                OnRemove.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnScanFinishedDelegate(string sender=null, object data=null);
        public event OnScanFinishedDelegate OnScanFinished;
        internal void RaiseOnScanFinished(string sender=null, object data=null)
        {
            if (OnScanFinished != null)
            {
                OnScanFinished.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnScanStartedDelegate(string sender=null, object data=null);
        public event OnScanStartedDelegate OnScanStarted;
        internal void RaiseOnScanStarted(string sender=null, object data=null)
        {
            if (OnScanStarted != null)
            {
                OnScanStarted.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnUpdateDelegate(string sender=null, KODIRPC.AudioLibrary.OnUpdate_data data=null);
        public event OnUpdateDelegate OnUpdate;
        internal void RaiseOnUpdate(string sender=null, KODIRPC.AudioLibrary.OnUpdate_data data=null)
        {
            if (OnUpdate != null)
            {
                OnUpdate.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
