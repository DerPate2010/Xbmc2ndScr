using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace KODIRPC.Methods
{
   public partial class VideoLibrary
   {
        private readonly Client _client;
          public VideoLibrary(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Cleans the video library from non-existent items
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
            return await _client.GetData<string>("VideoLibrary.Clean", jArgs);
        }

                /// <summary>
                /// Exports all items from the video library
                /// </summary>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Export(KODIRPC.VideoLibrary.Export_optionsPath options=null)
        {
             var jArgs = new JObject();

             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("VideoLibrary.Export", jArgs);
        }

                /// <summary>
                /// Exports all items from the video library
                /// </summary>
                /// <param name="options"> </param>
                /// <returns>string</returns>
        public async Task<string> Export(KODIRPC.VideoLibrary.Export_options1 options=null)
        {
             var jArgs = new JObject();

             if (options != null)
             {
                 var jpropoptions = JToken.FromObject(options, _client.Serializer);
                 jArgs.Add(new JProperty("options", jpropoptions));
             }
            return await _client.GetData<string>("VideoLibrary.Export", jArgs);
        }

                /// <summary>
                /// Exports all items from the video library
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Export()
        {
            return await _client.GetData<string>("VideoLibrary.Export",null);
        }

                /// <summary>
                /// Retrieve details about a specific tv show episode
                /// </summary>
                /// <param name="episodeid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetEpisodeDetailsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetEpisodeDetailsResponse> GetEpisodeDetails(int? episodeid=null, KODIRPC.Video.Fields.Episode properties=null)
        {
             var jArgs = new JObject();

             if (episodeid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null episodeid");
              }
             else
              {
                 var jpropepisodeid = JToken.FromObject(episodeid, _client.Serializer);
                 jArgs.Add(new JProperty("episodeid", jpropepisodeid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.VideoLibrary.GetEpisodeDetailsResponse>("VideoLibrary.GetEpisodeDetails", jArgs);
        }

                /// <summary>
                /// Retrieve all tv show episodes
                /// </summary>
                /// <param name="tvshowid"> </param>
                /// <param name="season"> </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetEpisodesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetEpisodesResponse> GetEpisodes(int? tvshowid=null, int? season=null, KODIRPC.Video.Fields.Episode properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetEpisodes_filterGenreid filter=null)
        {
             var jArgs = new JObject();

             if (tvshowid != null)
             {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
             }
             if (season != null)
             {
                 var jpropseason = JToken.FromObject(season, _client.Serializer);
                 jArgs.Add(new JProperty("season", jpropseason));
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
        }

                /// <summary>
                /// Retrieve all tv show episodes
                /// </summary>
                /// <param name="tvshowid"> </param>
                /// <param name="season"> </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetEpisodesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetEpisodesResponse> GetEpisodes(int? tvshowid=null, int? season=null, KODIRPC.Video.Fields.Episode properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetEpisodes_filterGenre filter=null)
        {
             var jArgs = new JObject();

             if (tvshowid != null)
             {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
             }
             if (season != null)
             {
                 var jpropseason = JToken.FromObject(season, _client.Serializer);
                 jArgs.Add(new JProperty("season", jpropseason));
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
        }

                /// <summary>
                /// Retrieve all tv show episodes
                /// </summary>
                /// <param name="tvshowid"> </param>
                /// <param name="season"> </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetEpisodesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetEpisodesResponse> GetEpisodes(int? tvshowid=null, int? season=null, KODIRPC.Video.Fields.Episode properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetEpisodes_filterYear filter=null)
        {
             var jArgs = new JObject();

             if (tvshowid != null)
             {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
             }
             if (season != null)
             {
                 var jpropseason = JToken.FromObject(season, _client.Serializer);
                 jArgs.Add(new JProperty("season", jpropseason));
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
        }

                /// <summary>
                /// Retrieve all tv show episodes
                /// </summary>
                /// <param name="tvshowid"> </param>
                /// <param name="season"> </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetEpisodesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetEpisodesResponse> GetEpisodes(int? tvshowid=null, int? season=null, KODIRPC.Video.Fields.Episode properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetEpisodes_filterActor filter=null)
        {
             var jArgs = new JObject();

             if (tvshowid != null)
             {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
             }
             if (season != null)
             {
                 var jpropseason = JToken.FromObject(season, _client.Serializer);
                 jArgs.Add(new JProperty("season", jpropseason));
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
        }

                /// <summary>
                /// Retrieve all tv show episodes
                /// </summary>
                /// <param name="tvshowid"> </param>
                /// <param name="season"> </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetEpisodesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetEpisodesResponse> GetEpisodes(int? tvshowid=null, int? season=null, KODIRPC.Video.Fields.Episode properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetEpisodes_filterDirector filter=null)
        {
             var jArgs = new JObject();

             if (tvshowid != null)
             {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
             }
             if (season != null)
             {
                 var jpropseason = JToken.FromObject(season, _client.Serializer);
                 jArgs.Add(new JProperty("season", jpropseason));
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
        }

                /// <summary>
                /// Retrieve all tv show episodes
                /// </summary>
                /// <param name="tvshowid"> </param>
                /// <param name="season"> </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetEpisodesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetEpisodesResponse> GetEpisodes(int? tvshowid=null, int? season=null, KODIRPC.Video.Fields.Episode properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.EpisodesAnd filter=null)
        {
             var jArgs = new JObject();

             if (tvshowid != null)
             {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
             }
             if (season != null)
             {
                 var jpropseason = JToken.FromObject(season, _client.Serializer);
                 jArgs.Add(new JProperty("season", jpropseason));
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
        }

                /// <summary>
                /// Retrieve all tv show episodes
                /// </summary>
                /// <param name="tvshowid"> </param>
                /// <param name="season"> </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetEpisodesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetEpisodesResponse> GetEpisodes(int? tvshowid=null, int? season=null, KODIRPC.Video.Fields.Episode properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.EpisodesOr filter=null)
        {
             var jArgs = new JObject();

             if (tvshowid != null)
             {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
             }
             if (season != null)
             {
                 var jpropseason = JToken.FromObject(season, _client.Serializer);
                 jArgs.Add(new JProperty("season", jpropseason));
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
        }

                /// <summary>
                /// Retrieve all tv show episodes
                /// </summary>
                /// <param name="tvshowid"> </param>
                /// <param name="season"> </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetEpisodesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetEpisodesResponse> GetEpisodes(int? tvshowid=null, int? season=null, KODIRPC.Video.Fields.Episode properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.Rule.Episodes filter=null)
        {
             var jArgs = new JObject();

             if (tvshowid != null)
             {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
             }
             if (season != null)
             {
                 var jpropseason = JToken.FromObject(season, _client.Serializer);
                 jArgs.Add(new JProperty("season", jpropseason));
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
        }

                /// <summary>
                /// Retrieve all tv show episodes
                /// </summary>
                /// <param name="tvshowid"> </param>
                /// <param name="season"> </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetEpisodesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetEpisodesResponse> GetEpisodes(int? tvshowid=null, int? season=null, KODIRPC.Video.Fields.Episode properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
        {
             var jArgs = new JObject();

             if (tvshowid != null)
             {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
             }
             if (season != null)
             {
                 var jpropseason = JToken.FromObject(season, _client.Serializer);
                 jArgs.Add(new JProperty("season", jpropseason));
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
        }

                /// <summary>
                /// Retrieve all genres
                /// </summary>
                /// <param name="type"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetGenresResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetGenresResponse> GetGenres(KODIRPC.VideoLibrary.GetGenres_type? type=null, KODIRPC.Library.Fields.Genre properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
        {
             var jArgs = new JObject();

             if (type == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null type");
              }
             else
              {
                 var jproptype = JToken.FromObject(type, _client.Serializer);
                 jArgs.Add(new JProperty("type", jproptype));
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetGenresResponse>("VideoLibrary.GetGenres", jArgs);
        }

                /// <summary>
                /// Retrieve details about a specific movie
                /// </summary>
                /// <param name="movieid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMovieDetailsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMovieDetailsResponse> GetMovieDetails(int? movieid=null, KODIRPC.Video.Fields.Movie properties=null)
        {
             var jArgs = new JObject();

             if (movieid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null movieid");
              }
             else
              {
                 var jpropmovieid = JToken.FromObject(movieid, _client.Serializer);
                 jArgs.Add(new JProperty("movieid", jpropmovieid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.VideoLibrary.GetMovieDetailsResponse>("VideoLibrary.GetMovieDetails", jArgs);
        }

                /// <summary>
                /// Retrieve details about a specific movie set
                /// </summary>
                /// <param name="setid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <param name="movies"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMovieSetDetailsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMovieSetDetailsResponse> GetMovieSetDetails(int? setid=null, KODIRPC.Video.Fields.MovieSet properties=null, KODIRPC.VideoLibrary.GetMovieSetDetails_movies movies=null)
        {
             var jArgs = new JObject();

             if (setid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null setid");
              }
             else
              {
                 var jpropsetid = JToken.FromObject(setid, _client.Serializer);
                 jArgs.Add(new JProperty("setid", jpropsetid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
             if (movies != null)
             {
                 var jpropmovies = JToken.FromObject(movies, _client.Serializer);
                 jArgs.Add(new JProperty("movies", jpropmovies));
             }
            return await _client.GetData<KODIRPC.VideoLibrary.GetMovieSetDetailsResponse>("VideoLibrary.GetMovieSetDetails", jArgs);
        }

                /// <summary>
                /// Retrieve all movie sets
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMovieSetsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMovieSetsResponse> GetMovieSets(KODIRPC.Video.Fields.MovieSet properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMovieSetsResponse>("VideoLibrary.GetMovieSets", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMovies_filterGenreid filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMovies_filterGenre filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMovies_filterYear filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMovies_filterActor filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMovies_filterDirector filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMovies_filterStudio filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMovies_filterCountry filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMovies_filterSetid filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMovies_filterSet filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMovies_filterTag filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.MoviesAnd filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.MoviesOr filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.Rule.Movies filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMoviesResponse> GetMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
        }

                /// <summary>
                /// Retrieve details about a specific music video
                /// </summary>
                /// <param name="musicvideoid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMusicVideoDetailsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMusicVideoDetailsResponse> GetMusicVideoDetails(int? musicvideoid=null, KODIRPC.Video.Fields.MusicVideo properties=null)
        {
             var jArgs = new JObject();

             if (musicvideoid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null musicvideoid");
              }
             else
              {
                 var jpropmusicvideoid = JToken.FromObject(musicvideoid, _client.Serializer);
                 jArgs.Add(new JProperty("musicvideoid", jpropmusicvideoid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.VideoLibrary.GetMusicVideoDetailsResponse>("VideoLibrary.GetMusicVideoDetails", jArgs);
        }

                /// <summary>
                /// Retrieve all music videos
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMusicVideosResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMusicVideosResponse> GetMusicVideos(KODIRPC.Video.Fields.MusicVideo properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMusicVideos_filterArtist filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
        }

                /// <summary>
                /// Retrieve all music videos
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMusicVideosResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMusicVideosResponse> GetMusicVideos(KODIRPC.Video.Fields.MusicVideo properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMusicVideos_filterGenreid filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
        }

                /// <summary>
                /// Retrieve all music videos
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMusicVideosResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMusicVideosResponse> GetMusicVideos(KODIRPC.Video.Fields.MusicVideo properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMusicVideos_filterGenre filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
        }

                /// <summary>
                /// Retrieve all music videos
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMusicVideosResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMusicVideosResponse> GetMusicVideos(KODIRPC.Video.Fields.MusicVideo properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMusicVideos_filterYear filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
        }

                /// <summary>
                /// Retrieve all music videos
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMusicVideosResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMusicVideosResponse> GetMusicVideos(KODIRPC.Video.Fields.MusicVideo properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMusicVideos_filterDirector filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
        }

                /// <summary>
                /// Retrieve all music videos
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMusicVideosResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMusicVideosResponse> GetMusicVideos(KODIRPC.Video.Fields.MusicVideo properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMusicVideos_filterStudio filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
        }

                /// <summary>
                /// Retrieve all music videos
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMusicVideosResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMusicVideosResponse> GetMusicVideos(KODIRPC.Video.Fields.MusicVideo properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetMusicVideos_filterTag filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
        }

                /// <summary>
                /// Retrieve all music videos
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMusicVideosResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMusicVideosResponse> GetMusicVideos(KODIRPC.Video.Fields.MusicVideo properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.MusicVideosAnd filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
        }

                /// <summary>
                /// Retrieve all music videos
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMusicVideosResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMusicVideosResponse> GetMusicVideos(KODIRPC.Video.Fields.MusicVideo properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.MusicVideosOr filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
        }

                /// <summary>
                /// Retrieve all music videos
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMusicVideosResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMusicVideosResponse> GetMusicVideos(KODIRPC.Video.Fields.MusicVideo properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.Rule.MusicVideos filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
        }

                /// <summary>
                /// Retrieve all music videos
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetMusicVideosResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetMusicVideosResponse> GetMusicVideos(KODIRPC.Video.Fields.MusicVideo properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
        }

                /// <summary>
                /// Retrieve all recently added tv episodes
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetRecentlyAddedEpisodesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetRecentlyAddedEpisodesResponse> GetRecentlyAddedEpisodes(KODIRPC.Video.Fields.Episode properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetRecentlyAddedEpisodesResponse>("VideoLibrary.GetRecentlyAddedEpisodes", jArgs);
        }

                /// <summary>
                /// Retrieve all recently added movies
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetRecentlyAddedMoviesResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetRecentlyAddedMoviesResponse> GetRecentlyAddedMovies(KODIRPC.Video.Fields.Movie properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetRecentlyAddedMoviesResponse>("VideoLibrary.GetRecentlyAddedMovies", jArgs);
        }

                /// <summary>
                /// Retrieve all recently added music videos
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetRecentlyAddedMusicVideosResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetRecentlyAddedMusicVideosResponse> GetRecentlyAddedMusicVideos(KODIRPC.Video.Fields.MusicVideo properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetRecentlyAddedMusicVideosResponse>("VideoLibrary.GetRecentlyAddedMusicVideos", jArgs);
        }

                /// <summary>
                /// Retrieve details about a specific tv show season
                /// </summary>
                /// <param name="seasonid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetSeasonDetailsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetSeasonDetailsResponse> GetSeasonDetails(int? seasonid=null, KODIRPC.Video.Fields.Season properties=null)
        {
             var jArgs = new JObject();

             if (seasonid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null seasonid");
              }
             else
              {
                 var jpropseasonid = JToken.FromObject(seasonid, _client.Serializer);
                 jArgs.Add(new JProperty("seasonid", jpropseasonid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.VideoLibrary.GetSeasonDetailsResponse>("VideoLibrary.GetSeasonDetails", jArgs);
        }

                /// <summary>
                /// Retrieve all tv seasons
                /// </summary>
                /// <param name="tvshowid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetSeasonsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetSeasonsResponse> GetSeasons(int? tvshowid=null, KODIRPC.Video.Fields.Season properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
        {
             var jArgs = new JObject();

             if (tvshowid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null tvshowid");
              }
             else
              {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetSeasonsResponse>("VideoLibrary.GetSeasons", jArgs);
        }

                /// <summary>
                /// Retrieve details about a specific tv show
                /// </summary>
                /// <param name="tvshowid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetTVShowDetailsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetTVShowDetailsResponse> GetTVShowDetails(int? tvshowid=null, KODIRPC.Video.Fields.TVShow properties=null)
        {
             var jArgs = new JObject();

             if (tvshowid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null tvshowid");
              }
             else
              {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.VideoLibrary.GetTVShowDetailsResponse>("VideoLibrary.GetTVShowDetails", jArgs);
        }

                /// <summary>
                /// Retrieve all tv shows
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetTVShowsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetTVShowsResponse> GetTVShows(KODIRPC.Video.Fields.TVShow properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetTVShows_filterGenreid filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
        }

                /// <summary>
                /// Retrieve all tv shows
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetTVShowsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetTVShowsResponse> GetTVShows(KODIRPC.Video.Fields.TVShow properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetTVShows_filterGenre filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
        }

                /// <summary>
                /// Retrieve all tv shows
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetTVShowsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetTVShowsResponse> GetTVShows(KODIRPC.Video.Fields.TVShow properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetTVShows_filterYear filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
        }

                /// <summary>
                /// Retrieve all tv shows
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetTVShowsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetTVShowsResponse> GetTVShows(KODIRPC.Video.Fields.TVShow properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetTVShows_filterActor filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
        }

                /// <summary>
                /// Retrieve all tv shows
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetTVShowsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetTVShowsResponse> GetTVShows(KODIRPC.Video.Fields.TVShow properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetTVShows_filterStudio filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
        }

                /// <summary>
                /// Retrieve all tv shows
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetTVShowsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetTVShowsResponse> GetTVShows(KODIRPC.Video.Fields.TVShow properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.VideoLibrary.GetTVShows_filterTag filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
        }

                /// <summary>
                /// Retrieve all tv shows
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetTVShowsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetTVShowsResponse> GetTVShows(KODIRPC.Video.Fields.TVShow properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.TVShowsAnd filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
        }

                /// <summary>
                /// Retrieve all tv shows
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetTVShowsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetTVShowsResponse> GetTVShows(KODIRPC.Video.Fields.TVShow properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.TVShowsOr filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
        }

                /// <summary>
                /// Retrieve all tv shows
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <param name="filter"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetTVShowsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetTVShowsResponse> GetTVShows(KODIRPC.Video.Fields.TVShow properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Filter.Rule.TVShows filter=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
        }

                /// <summary>
                /// Retrieve all tv shows
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.VideoLibrary.GetTVShowsResponse</returns>
        public async Task<KODIRPC.VideoLibrary.GetTVShowsResponse> GetTVShows(KODIRPC.Video.Fields.TVShow properties=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
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
            return await _client.GetData<KODIRPC.VideoLibrary.GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
        }

                /// <summary>
                /// Refresh the given episode in the library
                /// </summary>
                /// <param name="episodeid"> REQUIRED </param>
                /// <param name="ignorenfo"> Whether or not to ignore a local NFO if present.</param>
                /// <param name="title"> Title to use for searching (instead of determining it from the item's filename/path).</param>
                /// <returns>string</returns>
        public async Task<string> RefreshEpisode(int? episodeid=null, bool? ignorenfo=null, string title=null)
        {
             var jArgs = new JObject();

             if (episodeid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null episodeid");
              }
             else
              {
                 var jpropepisodeid = JToken.FromObject(episodeid, _client.Serializer);
                 jArgs.Add(new JProperty("episodeid", jpropepisodeid));
              }
             if (ignorenfo != null)
             {
                 var jpropignorenfo = JToken.FromObject(ignorenfo, _client.Serializer);
                 jArgs.Add(new JProperty("ignorenfo", jpropignorenfo));
             }
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
            return await _client.GetData<string>("VideoLibrary.RefreshEpisode", jArgs);
        }

                /// <summary>
                /// Refresh the given movie in the library
                /// </summary>
                /// <param name="movieid"> REQUIRED </param>
                /// <param name="ignorenfo"> Whether or not to ignore a local NFO if present.</param>
                /// <param name="title"> Title to use for searching (instead of determining it from the item's filename/path).</param>
                /// <returns>string</returns>
        public async Task<string> RefreshMovie(int? movieid=null, bool? ignorenfo=null, string title=null)
        {
             var jArgs = new JObject();

             if (movieid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null movieid");
              }
             else
              {
                 var jpropmovieid = JToken.FromObject(movieid, _client.Serializer);
                 jArgs.Add(new JProperty("movieid", jpropmovieid));
              }
             if (ignorenfo != null)
             {
                 var jpropignorenfo = JToken.FromObject(ignorenfo, _client.Serializer);
                 jArgs.Add(new JProperty("ignorenfo", jpropignorenfo));
             }
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
            return await _client.GetData<string>("VideoLibrary.RefreshMovie", jArgs);
        }

                /// <summary>
                /// Refresh the given music video in the library
                /// </summary>
                /// <param name="musicvideoid"> REQUIRED </param>
                /// <param name="ignorenfo"> Whether or not to ignore a local NFO if present.</param>
                /// <param name="title"> Title to use for searching (instead of determining it from the item's filename/path).</param>
                /// <returns>string</returns>
        public async Task<string> RefreshMusicVideo(int? musicvideoid=null, bool? ignorenfo=null, string title=null)
        {
             var jArgs = new JObject();

             if (musicvideoid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null musicvideoid");
              }
             else
              {
                 var jpropmusicvideoid = JToken.FromObject(musicvideoid, _client.Serializer);
                 jArgs.Add(new JProperty("musicvideoid", jpropmusicvideoid));
              }
             if (ignorenfo != null)
             {
                 var jpropignorenfo = JToken.FromObject(ignorenfo, _client.Serializer);
                 jArgs.Add(new JProperty("ignorenfo", jpropignorenfo));
             }
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
            return await _client.GetData<string>("VideoLibrary.RefreshMusicVideo", jArgs);
        }

                /// <summary>
                /// Refresh the given tv show in the library
                /// </summary>
                /// <param name="tvshowid"> REQUIRED </param>
                /// <param name="ignorenfo"> Whether or not to ignore a local NFO if present.</param>
                /// <param name="refreshepisodes"> Whether or not to refresh all episodes belonging to the TV show.</param>
                /// <param name="title"> Title to use for searching (instead of determining it from the item's filename/path).</param>
                /// <returns>string</returns>
        public async Task<string> RefreshTVShow(int? tvshowid=null, bool? ignorenfo=null, bool? refreshepisodes=null, string title=null)
        {
             var jArgs = new JObject();

             if (tvshowid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null tvshowid");
              }
             else
              {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
              }
             if (ignorenfo != null)
             {
                 var jpropignorenfo = JToken.FromObject(ignorenfo, _client.Serializer);
                 jArgs.Add(new JProperty("ignorenfo", jpropignorenfo));
             }
             if (refreshepisodes != null)
             {
                 var jproprefreshepisodes = JToken.FromObject(refreshepisodes, _client.Serializer);
                 jArgs.Add(new JProperty("refreshepisodes", jproprefreshepisodes));
             }
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
            return await _client.GetData<string>("VideoLibrary.RefreshTVShow", jArgs);
        }

                /// <summary>
                /// Removes the given episode from the library
                /// </summary>
                /// <param name="episodeid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> RemoveEpisode(int? episodeid=null)
        {
             var jArgs = new JObject();

             if (episodeid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null episodeid");
              }
             else
              {
                 var jpropepisodeid = JToken.FromObject(episodeid, _client.Serializer);
                 jArgs.Add(new JProperty("episodeid", jpropepisodeid));
              }
            return await _client.GetData<string>("VideoLibrary.RemoveEpisode", jArgs);
        }

                /// <summary>
                /// Removes the given movie from the library
                /// </summary>
                /// <param name="movieid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> RemoveMovie(int? movieid=null)
        {
             var jArgs = new JObject();

             if (movieid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null movieid");
              }
             else
              {
                 var jpropmovieid = JToken.FromObject(movieid, _client.Serializer);
                 jArgs.Add(new JProperty("movieid", jpropmovieid));
              }
            return await _client.GetData<string>("VideoLibrary.RemoveMovie", jArgs);
        }

                /// <summary>
                /// Removes the given music video from the library
                /// </summary>
                /// <param name="musicvideoid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> RemoveMusicVideo(int? musicvideoid=null)
        {
             var jArgs = new JObject();

             if (musicvideoid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null musicvideoid");
              }
             else
              {
                 var jpropmusicvideoid = JToken.FromObject(musicvideoid, _client.Serializer);
                 jArgs.Add(new JProperty("musicvideoid", jpropmusicvideoid));
              }
            return await _client.GetData<string>("VideoLibrary.RemoveMusicVideo", jArgs);
        }

                /// <summary>
                /// Removes the given tv show from the library
                /// </summary>
                /// <param name="tvshowid"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> RemoveTVShow(int? tvshowid=null)
        {
             var jArgs = new JObject();

             if (tvshowid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null tvshowid");
              }
             else
              {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
              }
            return await _client.GetData<string>("VideoLibrary.RemoveTVShow", jArgs);
        }

                /// <summary>
                /// Scans the video sources for new library items
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
            return await _client.GetData<string>("VideoLibrary.Scan", jArgs);
        }

                /// <summary>
                /// Update the given episode with the given details
                /// </summary>
                /// <param name="episodeid"> REQUIRED </param>
                /// <param name="title"> </param>
                /// <param name="playcount"> </param>
                /// <param name="runtime"> Runtime in seconds</param>
                /// <param name="director"> </param>
                /// <param name="plot"> </param>
                /// <param name="rating"> </param>
                /// <param name="votes"> </param>
                /// <param name="lastplayed"> </param>
                /// <param name="writer"> </param>
                /// <param name="firstaired"> </param>
                /// <param name="productioncode"> </param>
                /// <param name="season"> </param>
                /// <param name="episode"> </param>
                /// <param name="originaltitle"> </param>
                /// <param name="thumbnail"> </param>
                /// <param name="fanart"> </param>
                /// <param name="art"> </param>
                /// <param name="resume"> </param>
                /// <param name="userrating"> </param>
                /// <returns>string</returns>
        public async Task<string> SetEpisodeDetails(int? episodeid=null, string title=null, int? playcount=null, int? runtime=null, global::System.Collections.Generic.List<string> director=null, string plot=null, double? rating=null, string votes=null, string lastplayed=null, global::System.Collections.Generic.List<string> writer=null, string firstaired=null, string productioncode=null, int? season=null, int? episode=null, string originaltitle=null, string thumbnail=null, string fanart=null, KODIRPC.Media.Artwork.Set art=null, KODIRPC.Video.Resume resume=null, int? userrating=null)
        {
             var jArgs = new JObject();

             if (episodeid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null episodeid");
              }
             else
              {
                 var jpropepisodeid = JToken.FromObject(episodeid, _client.Serializer);
                 jArgs.Add(new JProperty("episodeid", jpropepisodeid));
              }
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             if (playcount != null)
             {
                 var jpropplaycount = JToken.FromObject(playcount, _client.Serializer);
                 jArgs.Add(new JProperty("playcount", jpropplaycount));
             }
             if (runtime != null)
             {
                 var jpropruntime = JToken.FromObject(runtime, _client.Serializer);
                 jArgs.Add(new JProperty("runtime", jpropruntime));
             }
             if (director != null)
             {
                 var jpropdirector = JToken.FromObject(director, _client.Serializer);
                 jArgs.Add(new JProperty("director", jpropdirector));
             }
             if (plot != null)
             {
                 var jpropplot = JToken.FromObject(plot, _client.Serializer);
                 jArgs.Add(new JProperty("plot", jpropplot));
             }
             if (rating != null)
             {
                 var jproprating = JToken.FromObject(rating, _client.Serializer);
                 jArgs.Add(new JProperty("rating", jproprating));
             }
             if (votes != null)
             {
                 var jpropvotes = JToken.FromObject(votes, _client.Serializer);
                 jArgs.Add(new JProperty("votes", jpropvotes));
             }
             if (lastplayed != null)
             {
                 var jproplastplayed = JToken.FromObject(lastplayed, _client.Serializer);
                 jArgs.Add(new JProperty("lastplayed", jproplastplayed));
             }
             if (writer != null)
             {
                 var jpropwriter = JToken.FromObject(writer, _client.Serializer);
                 jArgs.Add(new JProperty("writer", jpropwriter));
             }
             if (firstaired != null)
             {
                 var jpropfirstaired = JToken.FromObject(firstaired, _client.Serializer);
                 jArgs.Add(new JProperty("firstaired", jpropfirstaired));
             }
             if (productioncode != null)
             {
                 var jpropproductioncode = JToken.FromObject(productioncode, _client.Serializer);
                 jArgs.Add(new JProperty("productioncode", jpropproductioncode));
             }
             if (season != null)
             {
                 var jpropseason = JToken.FromObject(season, _client.Serializer);
                 jArgs.Add(new JProperty("season", jpropseason));
             }
             if (episode != null)
             {
                 var jpropepisode = JToken.FromObject(episode, _client.Serializer);
                 jArgs.Add(new JProperty("episode", jpropepisode));
             }
             if (originaltitle != null)
             {
                 var jproporiginaltitle = JToken.FromObject(originaltitle, _client.Serializer);
                 jArgs.Add(new JProperty("originaltitle", jproporiginaltitle));
             }
             if (thumbnail != null)
             {
                 var jpropthumbnail = JToken.FromObject(thumbnail, _client.Serializer);
                 jArgs.Add(new JProperty("thumbnail", jpropthumbnail));
             }
             if (fanart != null)
             {
                 var jpropfanart = JToken.FromObject(fanart, _client.Serializer);
                 jArgs.Add(new JProperty("fanart", jpropfanart));
             }
             if (art != null)
             {
                 var jpropart = JToken.FromObject(art, _client.Serializer);
                 jArgs.Add(new JProperty("art", jpropart));
             }
             if (resume != null)
             {
                 var jpropresume = JToken.FromObject(resume, _client.Serializer);
                 jArgs.Add(new JProperty("resume", jpropresume));
             }
             if (userrating != null)
             {
                 var jpropuserrating = JToken.FromObject(userrating, _client.Serializer);
                 jArgs.Add(new JProperty("userrating", jpropuserrating));
             }
            return await _client.GetData<string>("VideoLibrary.SetEpisodeDetails", jArgs);
        }

                /// <summary>
                /// Update the given movie with the given details
                /// </summary>
                /// <param name="movieid"> REQUIRED </param>
                /// <param name="title"> </param>
                /// <param name="playcount"> </param>
                /// <param name="runtime"> Runtime in seconds</param>
                /// <param name="director"> </param>
                /// <param name="studio"> </param>
                /// <param name="year"> </param>
                /// <param name="plot"> </param>
                /// <param name="genre"> </param>
                /// <param name="rating"> </param>
                /// <param name="mpaa"> </param>
                /// <param name="imdbnumber"> </param>
                /// <param name="votes"> </param>
                /// <param name="lastplayed"> </param>
                /// <param name="originaltitle"> </param>
                /// <param name="trailer"> </param>
                /// <param name="tagline"> </param>
                /// <param name="plotoutline"> </param>
                /// <param name="writer"> </param>
                /// <param name="country"> </param>
                /// <param name="top250"> </param>
                /// <param name="sorttitle"> </param>
                /// <param name="set"> </param>
                /// <param name="showlink"> </param>
                /// <param name="thumbnail"> </param>
                /// <param name="fanart"> </param>
                /// <param name="tag"> </param>
                /// <param name="art"> </param>
                /// <param name="resume"> </param>
                /// <param name="userrating"> </param>
                /// <returns>string</returns>
        public async Task<string> SetMovieDetails(int? movieid=null, string title=null, int? playcount=null, int? runtime=null, global::System.Collections.Generic.List<string> director=null, global::System.Collections.Generic.List<string> studio=null, int? year=null, string plot=null, global::System.Collections.Generic.List<string> genre=null, double? rating=null, string mpaa=null, string imdbnumber=null, string votes=null, string lastplayed=null, string originaltitle=null, string trailer=null, string tagline=null, string plotoutline=null, global::System.Collections.Generic.List<string> writer=null, global::System.Collections.Generic.List<string> country=null, int? top250=null, string sorttitle=null, string set=null, global::System.Collections.Generic.List<string> showlink=null, string thumbnail=null, string fanart=null, global::System.Collections.Generic.List<string> tag=null, KODIRPC.Media.Artwork.Set art=null, KODIRPC.Video.Resume resume=null, int? userrating=null)
        {
             var jArgs = new JObject();

             if (movieid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null movieid");
              }
             else
              {
                 var jpropmovieid = JToken.FromObject(movieid, _client.Serializer);
                 jArgs.Add(new JProperty("movieid", jpropmovieid));
              }
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             if (playcount != null)
             {
                 var jpropplaycount = JToken.FromObject(playcount, _client.Serializer);
                 jArgs.Add(new JProperty("playcount", jpropplaycount));
             }
             if (runtime != null)
             {
                 var jpropruntime = JToken.FromObject(runtime, _client.Serializer);
                 jArgs.Add(new JProperty("runtime", jpropruntime));
             }
             if (director != null)
             {
                 var jpropdirector = JToken.FromObject(director, _client.Serializer);
                 jArgs.Add(new JProperty("director", jpropdirector));
             }
             if (studio != null)
             {
                 var jpropstudio = JToken.FromObject(studio, _client.Serializer);
                 jArgs.Add(new JProperty("studio", jpropstudio));
             }
             if (year != null)
             {
                 var jpropyear = JToken.FromObject(year, _client.Serializer);
                 jArgs.Add(new JProperty("year", jpropyear));
             }
             if (plot != null)
             {
                 var jpropplot = JToken.FromObject(plot, _client.Serializer);
                 jArgs.Add(new JProperty("plot", jpropplot));
             }
             if (genre != null)
             {
                 var jpropgenre = JToken.FromObject(genre, _client.Serializer);
                 jArgs.Add(new JProperty("genre", jpropgenre));
             }
             if (rating != null)
             {
                 var jproprating = JToken.FromObject(rating, _client.Serializer);
                 jArgs.Add(new JProperty("rating", jproprating));
             }
             if (mpaa != null)
             {
                 var jpropmpaa = JToken.FromObject(mpaa, _client.Serializer);
                 jArgs.Add(new JProperty("mpaa", jpropmpaa));
             }
             if (imdbnumber != null)
             {
                 var jpropimdbnumber = JToken.FromObject(imdbnumber, _client.Serializer);
                 jArgs.Add(new JProperty("imdbnumber", jpropimdbnumber));
             }
             if (votes != null)
             {
                 var jpropvotes = JToken.FromObject(votes, _client.Serializer);
                 jArgs.Add(new JProperty("votes", jpropvotes));
             }
             if (lastplayed != null)
             {
                 var jproplastplayed = JToken.FromObject(lastplayed, _client.Serializer);
                 jArgs.Add(new JProperty("lastplayed", jproplastplayed));
             }
             if (originaltitle != null)
             {
                 var jproporiginaltitle = JToken.FromObject(originaltitle, _client.Serializer);
                 jArgs.Add(new JProperty("originaltitle", jproporiginaltitle));
             }
             if (trailer != null)
             {
                 var jproptrailer = JToken.FromObject(trailer, _client.Serializer);
                 jArgs.Add(new JProperty("trailer", jproptrailer));
             }
             if (tagline != null)
             {
                 var jproptagline = JToken.FromObject(tagline, _client.Serializer);
                 jArgs.Add(new JProperty("tagline", jproptagline));
             }
             if (plotoutline != null)
             {
                 var jpropplotoutline = JToken.FromObject(plotoutline, _client.Serializer);
                 jArgs.Add(new JProperty("plotoutline", jpropplotoutline));
             }
             if (writer != null)
             {
                 var jpropwriter = JToken.FromObject(writer, _client.Serializer);
                 jArgs.Add(new JProperty("writer", jpropwriter));
             }
             if (country != null)
             {
                 var jpropcountry = JToken.FromObject(country, _client.Serializer);
                 jArgs.Add(new JProperty("country", jpropcountry));
             }
             if (top250 != null)
             {
                 var jproptop250 = JToken.FromObject(top250, _client.Serializer);
                 jArgs.Add(new JProperty("top250", jproptop250));
             }
             if (sorttitle != null)
             {
                 var jpropsorttitle = JToken.FromObject(sorttitle, _client.Serializer);
                 jArgs.Add(new JProperty("sorttitle", jpropsorttitle));
             }
             if (set != null)
             {
                 var jpropset = JToken.FromObject(set, _client.Serializer);
                 jArgs.Add(new JProperty("set", jpropset));
             }
             if (showlink != null)
             {
                 var jpropshowlink = JToken.FromObject(showlink, _client.Serializer);
                 jArgs.Add(new JProperty("showlink", jpropshowlink));
             }
             if (thumbnail != null)
             {
                 var jpropthumbnail = JToken.FromObject(thumbnail, _client.Serializer);
                 jArgs.Add(new JProperty("thumbnail", jpropthumbnail));
             }
             if (fanart != null)
             {
                 var jpropfanart = JToken.FromObject(fanart, _client.Serializer);
                 jArgs.Add(new JProperty("fanart", jpropfanart));
             }
             if (tag != null)
             {
                 var jproptag = JToken.FromObject(tag, _client.Serializer);
                 jArgs.Add(new JProperty("tag", jproptag));
             }
             if (art != null)
             {
                 var jpropart = JToken.FromObject(art, _client.Serializer);
                 jArgs.Add(new JProperty("art", jpropart));
             }
             if (resume != null)
             {
                 var jpropresume = JToken.FromObject(resume, _client.Serializer);
                 jArgs.Add(new JProperty("resume", jpropresume));
             }
             if (userrating != null)
             {
                 var jpropuserrating = JToken.FromObject(userrating, _client.Serializer);
                 jArgs.Add(new JProperty("userrating", jpropuserrating));
             }
            return await _client.GetData<string>("VideoLibrary.SetMovieDetails", jArgs);
        }

                /// <summary>
                /// Update the given movie set with the given details
                /// </summary>
                /// <param name="setid"> REQUIRED </param>
                /// <param name="title"> </param>
                /// <param name="art"> </param>
                /// <returns>string</returns>
        public async Task<string> SetMovieSetDetails(int? setid=null, string title=null, KODIRPC.Media.Artwork.Set art=null)
        {
             var jArgs = new JObject();

             if (setid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null setid");
              }
             else
              {
                 var jpropsetid = JToken.FromObject(setid, _client.Serializer);
                 jArgs.Add(new JProperty("setid", jpropsetid));
              }
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             if (art != null)
             {
                 var jpropart = JToken.FromObject(art, _client.Serializer);
                 jArgs.Add(new JProperty("art", jpropart));
             }
            return await _client.GetData<string>("VideoLibrary.SetMovieSetDetails", jArgs);
        }

                /// <summary>
                /// Update the given music video with the given details
                /// </summary>
                /// <param name="musicvideoid"> REQUIRED </param>
                /// <param name="title"> </param>
                /// <param name="playcount"> </param>
                /// <param name="runtime"> Runtime in seconds</param>
                /// <param name="director"> </param>
                /// <param name="studio"> </param>
                /// <param name="year"> </param>
                /// <param name="plot"> </param>
                /// <param name="album"> </param>
                /// <param name="artist"> </param>
                /// <param name="genre"> </param>
                /// <param name="track"> </param>
                /// <param name="lastplayed"> </param>
                /// <param name="thumbnail"> </param>
                /// <param name="fanart"> </param>
                /// <param name="tag"> </param>
                /// <param name="art"> </param>
                /// <param name="resume"> </param>
                /// <param name="userrating"> </param>
                /// <returns>string</returns>
        public async Task<string> SetMusicVideoDetails(int? musicvideoid=null, string title=null, int? playcount=null, int? runtime=null, global::System.Collections.Generic.List<string> director=null, global::System.Collections.Generic.List<string> studio=null, int? year=null, string plot=null, string album=null, global::System.Collections.Generic.List<string> artist=null, global::System.Collections.Generic.List<string> genre=null, int? track=null, string lastplayed=null, string thumbnail=null, string fanart=null, global::System.Collections.Generic.List<string> tag=null, KODIRPC.Media.Artwork.Set art=null, KODIRPC.Video.Resume resume=null, int? userrating=null)
        {
             var jArgs = new JObject();

             if (musicvideoid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null musicvideoid");
              }
             else
              {
                 var jpropmusicvideoid = JToken.FromObject(musicvideoid, _client.Serializer);
                 jArgs.Add(new JProperty("musicvideoid", jpropmusicvideoid));
              }
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             if (playcount != null)
             {
                 var jpropplaycount = JToken.FromObject(playcount, _client.Serializer);
                 jArgs.Add(new JProperty("playcount", jpropplaycount));
             }
             if (runtime != null)
             {
                 var jpropruntime = JToken.FromObject(runtime, _client.Serializer);
                 jArgs.Add(new JProperty("runtime", jpropruntime));
             }
             if (director != null)
             {
                 var jpropdirector = JToken.FromObject(director, _client.Serializer);
                 jArgs.Add(new JProperty("director", jpropdirector));
             }
             if (studio != null)
             {
                 var jpropstudio = JToken.FromObject(studio, _client.Serializer);
                 jArgs.Add(new JProperty("studio", jpropstudio));
             }
             if (year != null)
             {
                 var jpropyear = JToken.FromObject(year, _client.Serializer);
                 jArgs.Add(new JProperty("year", jpropyear));
             }
             if (plot != null)
             {
                 var jpropplot = JToken.FromObject(plot, _client.Serializer);
                 jArgs.Add(new JProperty("plot", jpropplot));
             }
             if (album != null)
             {
                 var jpropalbum = JToken.FromObject(album, _client.Serializer);
                 jArgs.Add(new JProperty("album", jpropalbum));
             }
             if (artist != null)
             {
                 var jpropartist = JToken.FromObject(artist, _client.Serializer);
                 jArgs.Add(new JProperty("artist", jpropartist));
             }
             if (genre != null)
             {
                 var jpropgenre = JToken.FromObject(genre, _client.Serializer);
                 jArgs.Add(new JProperty("genre", jpropgenre));
             }
             if (track != null)
             {
                 var jproptrack = JToken.FromObject(track, _client.Serializer);
                 jArgs.Add(new JProperty("track", jproptrack));
             }
             if (lastplayed != null)
             {
                 var jproplastplayed = JToken.FromObject(lastplayed, _client.Serializer);
                 jArgs.Add(new JProperty("lastplayed", jproplastplayed));
             }
             if (thumbnail != null)
             {
                 var jpropthumbnail = JToken.FromObject(thumbnail, _client.Serializer);
                 jArgs.Add(new JProperty("thumbnail", jpropthumbnail));
             }
             if (fanart != null)
             {
                 var jpropfanart = JToken.FromObject(fanart, _client.Serializer);
                 jArgs.Add(new JProperty("fanart", jpropfanart));
             }
             if (tag != null)
             {
                 var jproptag = JToken.FromObject(tag, _client.Serializer);
                 jArgs.Add(new JProperty("tag", jproptag));
             }
             if (art != null)
             {
                 var jpropart = JToken.FromObject(art, _client.Serializer);
                 jArgs.Add(new JProperty("art", jpropart));
             }
             if (resume != null)
             {
                 var jpropresume = JToken.FromObject(resume, _client.Serializer);
                 jArgs.Add(new JProperty("resume", jpropresume));
             }
             if (userrating != null)
             {
                 var jpropuserrating = JToken.FromObject(userrating, _client.Serializer);
                 jArgs.Add(new JProperty("userrating", jpropuserrating));
             }
            return await _client.GetData<string>("VideoLibrary.SetMusicVideoDetails", jArgs);
        }

                /// <summary>
                /// Update the given season with the given details
                /// </summary>
                /// <param name="seasonid"> REQUIRED </param>
                /// <param name="art"> </param>
                /// <returns>string</returns>
        public async Task<string> SetSeasonDetails(int? seasonid=null, KODIRPC.Media.Artwork.Set art=null)
        {
             var jArgs = new JObject();

             if (seasonid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null seasonid");
              }
             else
              {
                 var jpropseasonid = JToken.FromObject(seasonid, _client.Serializer);
                 jArgs.Add(new JProperty("seasonid", jpropseasonid));
              }
             if (art != null)
             {
                 var jpropart = JToken.FromObject(art, _client.Serializer);
                 jArgs.Add(new JProperty("art", jpropart));
             }
            return await _client.GetData<string>("VideoLibrary.SetSeasonDetails", jArgs);
        }

                /// <summary>
                /// Update the given tvshow with the given details
                /// </summary>
                /// <param name="tvshowid"> REQUIRED </param>
                /// <param name="title"> </param>
                /// <param name="playcount"> </param>
                /// <param name="studio"> </param>
                /// <param name="plot"> </param>
                /// <param name="genre"> </param>
                /// <param name="rating"> </param>
                /// <param name="mpaa"> </param>
                /// <param name="imdbnumber"> </param>
                /// <param name="premiered"> </param>
                /// <param name="votes"> </param>
                /// <param name="lastplayed"> </param>
                /// <param name="originaltitle"> </param>
                /// <param name="sorttitle"> </param>
                /// <param name="episodeguide"> </param>
                /// <param name="thumbnail"> </param>
                /// <param name="fanart"> </param>
                /// <param name="tag"> </param>
                /// <param name="art"> </param>
                /// <param name="userrating"> </param>
                /// <returns>string</returns>
        public async Task<string> SetTVShowDetails(int? tvshowid=null, string title=null, int? playcount=null, global::System.Collections.Generic.List<string> studio=null, string plot=null, global::System.Collections.Generic.List<string> genre=null, double? rating=null, string mpaa=null, string imdbnumber=null, string premiered=null, string votes=null, string lastplayed=null, string originaltitle=null, string sorttitle=null, string episodeguide=null, string thumbnail=null, string fanart=null, global::System.Collections.Generic.List<string> tag=null, KODIRPC.Media.Artwork.Set art=null, int? userrating=null)
        {
             var jArgs = new JObject();

             if (tvshowid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null tvshowid");
              }
             else
              {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
              }
             if (title != null)
             {
                 var jproptitle = JToken.FromObject(title, _client.Serializer);
                 jArgs.Add(new JProperty("title", jproptitle));
             }
             if (playcount != null)
             {
                 var jpropplaycount = JToken.FromObject(playcount, _client.Serializer);
                 jArgs.Add(new JProperty("playcount", jpropplaycount));
             }
             if (studio != null)
             {
                 var jpropstudio = JToken.FromObject(studio, _client.Serializer);
                 jArgs.Add(new JProperty("studio", jpropstudio));
             }
             if (plot != null)
             {
                 var jpropplot = JToken.FromObject(plot, _client.Serializer);
                 jArgs.Add(new JProperty("plot", jpropplot));
             }
             if (genre != null)
             {
                 var jpropgenre = JToken.FromObject(genre, _client.Serializer);
                 jArgs.Add(new JProperty("genre", jpropgenre));
             }
             if (rating != null)
             {
                 var jproprating = JToken.FromObject(rating, _client.Serializer);
                 jArgs.Add(new JProperty("rating", jproprating));
             }
             if (mpaa != null)
             {
                 var jpropmpaa = JToken.FromObject(mpaa, _client.Serializer);
                 jArgs.Add(new JProperty("mpaa", jpropmpaa));
             }
             if (imdbnumber != null)
             {
                 var jpropimdbnumber = JToken.FromObject(imdbnumber, _client.Serializer);
                 jArgs.Add(new JProperty("imdbnumber", jpropimdbnumber));
             }
             if (premiered != null)
             {
                 var jproppremiered = JToken.FromObject(premiered, _client.Serializer);
                 jArgs.Add(new JProperty("premiered", jproppremiered));
             }
             if (votes != null)
             {
                 var jpropvotes = JToken.FromObject(votes, _client.Serializer);
                 jArgs.Add(new JProperty("votes", jpropvotes));
             }
             if (lastplayed != null)
             {
                 var jproplastplayed = JToken.FromObject(lastplayed, _client.Serializer);
                 jArgs.Add(new JProperty("lastplayed", jproplastplayed));
             }
             if (originaltitle != null)
             {
                 var jproporiginaltitle = JToken.FromObject(originaltitle, _client.Serializer);
                 jArgs.Add(new JProperty("originaltitle", jproporiginaltitle));
             }
             if (sorttitle != null)
             {
                 var jpropsorttitle = JToken.FromObject(sorttitle, _client.Serializer);
                 jArgs.Add(new JProperty("sorttitle", jpropsorttitle));
             }
             if (episodeguide != null)
             {
                 var jpropepisodeguide = JToken.FromObject(episodeguide, _client.Serializer);
                 jArgs.Add(new JProperty("episodeguide", jpropepisodeguide));
             }
             if (thumbnail != null)
             {
                 var jpropthumbnail = JToken.FromObject(thumbnail, _client.Serializer);
                 jArgs.Add(new JProperty("thumbnail", jpropthumbnail));
             }
             if (fanart != null)
             {
                 var jpropfanart = JToken.FromObject(fanart, _client.Serializer);
                 jArgs.Add(new JProperty("fanart", jpropfanart));
             }
             if (tag != null)
             {
                 var jproptag = JToken.FromObject(tag, _client.Serializer);
                 jArgs.Add(new JProperty("tag", jproptag));
             }
             if (art != null)
             {
                 var jpropart = JToken.FromObject(art, _client.Serializer);
                 jArgs.Add(new JProperty("art", jpropart));
             }
             if (userrating != null)
             {
                 var jpropuserrating = JToken.FromObject(userrating, _client.Serializer);
                 jArgs.Add(new JProperty("userrating", jpropuserrating));
             }
            return await _client.GetData<string>("VideoLibrary.SetTVShowDetails", jArgs);
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

        public delegate void OnExportDelegate(string sender=null, KODIRPC.VideoLibrary.OnExport_data data=null);
        public event OnExportDelegate OnExport;
        internal void RaiseOnExport(string sender=null, KODIRPC.VideoLibrary.OnExport_data data=null)
        {
            if (OnExport != null)
            {
                OnExport.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnRemoveDelegate(string sender=null, KODIRPC.VideoLibrary.OnRemove_data data=null);
        public event OnRemoveDelegate OnRemove;
        internal void RaiseOnRemove(string sender=null, KODIRPC.VideoLibrary.OnRemove_data data=null)
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

        public delegate void OnUpdateDelegate(string sender=null, KODIRPC.VideoLibrary.OnUpdate_data data=null);
        public event OnUpdateDelegate OnUpdate;
        internal void RaiseOnUpdate(string sender=null, KODIRPC.VideoLibrary.OnUpdate_data data=null)
        {
            if (OnUpdate != null)
            {
                OnUpdate.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
