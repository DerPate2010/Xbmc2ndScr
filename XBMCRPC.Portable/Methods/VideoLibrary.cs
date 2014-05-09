using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace XBMCRPC.Methods
{
   public partial class VideoLibrary
   {
        private readonly Client _client;
          public VideoLibrary(Client client)
          {
              _client = client;
          }

        async public Task<string> Clean()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("VideoLibrary.Clean", jArgs);
            return jRet;
        }

        async public Task<string> Export()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("VideoLibrary.Export", jArgs);
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
            var jRet = await _client.GetData<string>("VideoLibrary.Export", jArgs);
            return jRet;
        }
   public class Exportoptions2
   {
       public bool actorthumbs {get;set;}
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
            var jRet = await _client.GetData<string>("VideoLibrary.Export", jArgs);
            return jRet;
        }
   public class GetEpisodeDetailsResponse
   {
       public XBMCRPC.Video.Details.Episode episodedetails {get;set;}
   }

        async public Task<GetEpisodeDetailsResponse> GetEpisodeDetails(int episodeid=0, XBMCRPC.Video.Fields.Episode properties=null)
        {
            var jArgs = new JObject();
             if (episodeid != null)
             {
                 var jpropepisodeid = JToken.FromObject(episodeid, _client.Serializer);
                 jArgs.Add(new JProperty("episodeid", jpropepisodeid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<GetEpisodeDetailsResponse>("VideoLibrary.GetEpisodeDetails", jArgs);
            return jRet;
        }
   public class GetEpisodesResponse
   {
       public XBMCRPC.Video.Details.Episode[] episodes {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetEpisodesResponse> GetEpisodes(int tvshowid=0, int season=0, XBMCRPC.Video.Fields.Episode properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
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
            var jRet = await _client.GetData<GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
            return jRet;
        }
   public class GetEpisodesfilter1
   {
       public int genreid {get;set;}
   }

        async public Task<GetEpisodesResponse> GetEpisodes2(int tvshowid=0, int season=0, XBMCRPC.Video.Fields.Episode properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetEpisodesfilter1 filter=null)
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
            var jRet = await _client.GetData<GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
            return jRet;
        }
   public class GetEpisodesfilter2
   {
       public string genre {get;set;}
   }

        async public Task<GetEpisodesResponse> GetEpisodes2(int tvshowid=0, int season=0, XBMCRPC.Video.Fields.Episode properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetEpisodesfilter2 filter=null)
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
            var jRet = await _client.GetData<GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
            return jRet;
        }
   public class GetEpisodesfilter3
   {
       public int year {get;set;}
   }

        async public Task<GetEpisodesResponse> GetEpisodes2(int tvshowid=0, int season=0, XBMCRPC.Video.Fields.Episode properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetEpisodesfilter3 filter=null)
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
            var jRet = await _client.GetData<GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
            return jRet;
        }
   public class GetEpisodesfilter4
   {
       public string actor {get;set;}
   }

        async public Task<GetEpisodesResponse> GetEpisodes2(int? tvshowid=0, int? season=0, XBMCRPC.Video.Fields.Episode properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetEpisodesfilter4 filter=null)
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
            var jRet = await _client.GetData<GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
            return jRet;
        }
   public class GetEpisodesfilter5
   {
       public string director {get;set;}
   }

        async public Task<GetEpisodesResponse> GetEpisodes2(int tvshowid=0, int season=0, XBMCRPC.Video.Fields.Episode properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetEpisodesfilter5 filter=null)
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
            var jRet = await _client.GetData<GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
            return jRet;
        }

        async public Task<GetEpisodesResponse> GetEpisodes2(int? tvshowid=0, int? season=0, XBMCRPC.Video.Fields.Episode properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, XBMCRPC.List.Filter.Episodes filter=null)
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
            var jRet = await _client.GetData<GetEpisodesResponse>("VideoLibrary.GetEpisodes", jArgs);
            return jRet;
        }
   public class GetGenresResponse
   {
       public XBMCRPC.Library.Details.Genre[] genres {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }
   public enum typeEnum
   {
       movie,
       tvshow,
       musicvideo,
   }

        async public Task<GetGenresResponse> GetGenres(typeEnum type=0, XBMCRPC.Library.Fields.Genre properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
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
            var jRet = await _client.GetData<GetGenresResponse>("VideoLibrary.GetGenres", jArgs);
            return jRet;
        }
   public class GetMovieDetailsResponse
   {
       public XBMCRPC.Video.Details.Movie moviedetails {get;set;}
   }

        async public Task<GetMovieDetailsResponse> GetMovieDetails(int movieid=0, XBMCRPC.Video.Fields.Movie properties=null)
        {
            var jArgs = new JObject();
             if (movieid != null)
             {
                 var jpropmovieid = JToken.FromObject(movieid, _client.Serializer);
                 jArgs.Add(new JProperty("movieid", jpropmovieid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<GetMovieDetailsResponse>("VideoLibrary.GetMovieDetails", jArgs);
            return jRet;
        }
   public class GetMovieSetDetailsResponse
   {
       public XBMCRPC.Video.Details.MovieSet.Extended setdetails {get;set;}
   }
   public class moviesType
   {
       public XBMCRPC.List.Limits limits {get;set;}
       public XBMCRPC.Video.Fields.Movie properties {get;set;}
       public XBMCRPC.List.Sort sort {get;set;}
   }

        async public Task<GetMovieSetDetailsResponse> GetMovieSetDetails(int setid=0, XBMCRPC.Video.Fields.MovieSet properties=null, moviesType movies=null)
        {
            var jArgs = new JObject();
             if (setid != null)
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
            var jRet = await _client.GetData<GetMovieSetDetailsResponse>("VideoLibrary.GetMovieSetDetails", jArgs);
            return jRet;
        }
   public class GetMovieSetsResponse
   {
       public XBMCRPC.List.LimitsReturned limits {get;set;}
       public XBMCRPC.Video.Details.MovieSet[] sets {get;set;}
   }

        async public Task<GetMovieSetsResponse> GetMovieSets(XBMCRPC.Video.Fields.MovieSet properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
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
            var jRet = await _client.GetData<GetMovieSetsResponse>("VideoLibrary.GetMovieSets", jArgs);
            return jRet;
        }
   public class GetMoviesResponse
   {
       public XBMCRPC.List.LimitsReturned limits {get;set;}
       public XBMCRPC.Video.Details.Movie[] movies {get;set;}
   }

        async public Task<GetMoviesResponse> GetMovies(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
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
            var jRet = await _client.GetData<GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
            return jRet;
        }
   public class GetMoviesfilter1
   {
       public int genreid {get;set;}
   }

        async public Task<GetMoviesResponse> GetMovies2(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMoviesfilter1 filter=null)
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
            var jRet = await _client.GetData<GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
            return jRet;
        }
   public class GetMoviesfilter2
   {
       public string genre {get;set;}
   }

        async public Task<GetMoviesResponse> GetMovies2(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMoviesfilter2 filter=null)
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
            var jRet = await _client.GetData<GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
            return jRet;
        }
   public class GetMoviesfilter3
   {
       public int year {get;set;}
   }

        async public Task<GetMoviesResponse> GetMovies2(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMoviesfilter3 filter=null)
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
            var jRet = await _client.GetData<GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
            return jRet;
        }
   public class GetMoviesfilter4
   {
       public string actor {get;set;}
   }

        async public Task<GetMoviesResponse> GetMovies2(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMoviesfilter4 filter=null)
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
            var jRet = await _client.GetData<GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
            return jRet;
        }
   public class GetMoviesfilter5
   {
       public string director {get;set;}
   }

        async public Task<GetMoviesResponse> GetMovies2(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMoviesfilter5 filter=null)
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
            var jRet = await _client.GetData<GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
            return jRet;
        }
   public class GetMoviesfilter6
   {
       public string studio {get;set;}
   }

        async public Task<GetMoviesResponse> GetMovies2(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMoviesfilter6 filter=null)
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
            var jRet = await _client.GetData<GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
            return jRet;
        }
   public class GetMoviesfilter7
   {
       public string country {get;set;}
   }

        async public Task<GetMoviesResponse> GetMovies2(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMoviesfilter7 filter=null)
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
            var jRet = await _client.GetData<GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
            return jRet;
        }
   public class GetMoviesfilter8
   {
       public int setid {get;set;}
   }

        async public Task<GetMoviesResponse> GetMovies2(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMoviesfilter8 filter=null)
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
            var jRet = await _client.GetData<GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
            return jRet;
        }
   public class GetMoviesfilter9
   {
       public string set {get;set;}
   }

        async public Task<GetMoviesResponse> GetMovies2(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMoviesfilter9 filter=null)
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
            var jRet = await _client.GetData<GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
            return jRet;
        }
   public class GetMoviesfilter10
   {
       public string tag {get;set;}
   }

        async public Task<GetMoviesResponse> GetMovies2(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMoviesfilter10 filter=null)
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
            var jRet = await _client.GetData<GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
            return jRet;
        }

        async public Task<GetMoviesResponse> GetMovies2(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, XBMCRPC.List.Filter.Movies filter=null)
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
            var jRet = await _client.GetData<GetMoviesResponse>("VideoLibrary.GetMovies", jArgs);
            return jRet;
        }
   public class GetMusicVideoDetailsResponse
   {
       public XBMCRPC.Video.Details.MusicVideo musicvideodetails {get;set;}
   }

        async public Task<GetMusicVideoDetailsResponse> GetMusicVideoDetails(int musicvideoid=0, XBMCRPC.Video.Fields.MusicVideo properties=null)
        {
            var jArgs = new JObject();
             if (musicvideoid != null)
             {
                 var jpropmusicvideoid = JToken.FromObject(musicvideoid, _client.Serializer);
                 jArgs.Add(new JProperty("musicvideoid", jpropmusicvideoid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<GetMusicVideoDetailsResponse>("VideoLibrary.GetMusicVideoDetails", jArgs);
            return jRet;
        }
   public class GetMusicVideosResponse
   {
       public XBMCRPC.List.LimitsReturned limits {get;set;}
       public XBMCRPC.Video.Details.MusicVideo[] musicvideos {get;set;}
   }

        async public Task<GetMusicVideosResponse> GetMusicVideos(XBMCRPC.Video.Fields.MusicVideo properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
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
            var jRet = await _client.GetData<GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
            return jRet;
        }
   public class GetMusicVideosfilter1
   {
       public string artist {get;set;}
   }

        async public Task<GetMusicVideosResponse> GetMusicVideos2(XBMCRPC.Video.Fields.MusicVideo properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMusicVideosfilter1 filter=null)
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
            var jRet = await _client.GetData<GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
            return jRet;
        }
   public class GetMusicVideosfilter2
   {
       public int genreid {get;set;}
   }

        async public Task<GetMusicVideosResponse> GetMusicVideos2(XBMCRPC.Video.Fields.MusicVideo properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMusicVideosfilter2 filter=null)
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
            var jRet = await _client.GetData<GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
            return jRet;
        }
   public class GetMusicVideosfilter3
   {
       public string genre {get;set;}
   }

        async public Task<GetMusicVideosResponse> GetMusicVideos2(XBMCRPC.Video.Fields.MusicVideo properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMusicVideosfilter3 filter=null)
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
            var jRet = await _client.GetData<GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
            return jRet;
        }
   public class GetMusicVideosfilter4
   {
       public int year {get;set;}
   }

        async public Task<GetMusicVideosResponse> GetMusicVideos2(XBMCRPC.Video.Fields.MusicVideo properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMusicVideosfilter4 filter=null)
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
            var jRet = await _client.GetData<GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
            return jRet;
        }
   public class GetMusicVideosfilter5
   {
       public string director {get;set;}
   }

        async public Task<GetMusicVideosResponse> GetMusicVideos2(XBMCRPC.Video.Fields.MusicVideo properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMusicVideosfilter5 filter=null)
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
            var jRet = await _client.GetData<GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
            return jRet;
        }
   public class GetMusicVideosfilter6
   {
       public string studio {get;set;}
   }

        async public Task<GetMusicVideosResponse> GetMusicVideos2(XBMCRPC.Video.Fields.MusicVideo properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMusicVideosfilter6 filter=null)
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
            var jRet = await _client.GetData<GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
            return jRet;
        }
   public class GetMusicVideosfilter7
   {
       public string tag {get;set;}
   }

        async public Task<GetMusicVideosResponse> GetMusicVideos2(XBMCRPC.Video.Fields.MusicVideo properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetMusicVideosfilter7 filter=null)
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
            var jRet = await _client.GetData<GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
            return jRet;
        }

        async public Task<GetMusicVideosResponse> GetMusicVideos2(XBMCRPC.Video.Fields.MusicVideo properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, XBMCRPC.List.Filter.MusicVideos filter=null)
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
            var jRet = await _client.GetData<GetMusicVideosResponse>("VideoLibrary.GetMusicVideos", jArgs);
            return jRet;
        }
   public class GetRecentlyAddedEpisodesResponse
   {
       public XBMCRPC.Video.Details.Episode[] episodes {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetRecentlyAddedEpisodesResponse> GetRecentlyAddedEpisodes(XBMCRPC.Video.Fields.Episode properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
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
            var jRet = await _client.GetData<GetRecentlyAddedEpisodesResponse>("VideoLibrary.GetRecentlyAddedEpisodes", jArgs);
            return jRet;
        }
   public class GetRecentlyAddedMoviesResponse
   {
       public XBMCRPC.List.LimitsReturned limits {get;set;}
       public XBMCRPC.Video.Details.Movie[] movies {get;set;}
   }

        async public Task<GetRecentlyAddedMoviesResponse> GetRecentlyAddedMovies(XBMCRPC.Video.Fields.Movie properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
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
            var jRet = await _client.GetData<GetRecentlyAddedMoviesResponse>("VideoLibrary.GetRecentlyAddedMovies", jArgs);
            return jRet;
        }
   public class GetRecentlyAddedMusicVideosResponse
   {
       public XBMCRPC.List.LimitsReturned limits {get;set;}
       public XBMCRPC.Video.Details.MusicVideo[] musicvideos {get;set;}
   }

        async public Task<GetRecentlyAddedMusicVideosResponse> GetRecentlyAddedMusicVideos(XBMCRPC.Video.Fields.MusicVideo properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
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
            var jRet = await _client.GetData<GetRecentlyAddedMusicVideosResponse>("VideoLibrary.GetRecentlyAddedMusicVideos", jArgs);
            return jRet;
        }
   public class GetSeasonsResponse
   {
       public XBMCRPC.List.LimitsReturned limits {get;set;}
       public XBMCRPC.Video.Details.Season[] seasons {get;set;}
   }

        async public Task<GetSeasonsResponse> GetSeasons(int tvshowid=0, XBMCRPC.Video.Fields.Season properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();
             if (tvshowid != null)
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
            var jRet = await _client.GetData<GetSeasonsResponse>("VideoLibrary.GetSeasons", jArgs);
            return jRet;
        }
   public class GetTVShowDetailsResponse
   {
       public XBMCRPC.Video.Details.TVShow tvshowdetails {get;set;}
   }

        async public Task<GetTVShowDetailsResponse> GetTVShowDetails(int tvshowid=0, XBMCRPC.Video.Fields.TVShow properties=null)
        {
            var jArgs = new JObject();
             if (tvshowid != null)
             {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<GetTVShowDetailsResponse>("VideoLibrary.GetTVShowDetails", jArgs);
            return jRet;
        }
   public class GetTVShowsResponse
   {
       public XBMCRPC.List.LimitsReturned limits {get;set;}
       public XBMCRPC.Video.Details.TVShow[] tvshows {get;set;}
   }

        async public Task<GetTVShowsResponse> GetTVShows(XBMCRPC.Video.Fields.TVShow properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
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
            var jRet = await _client.GetData<GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
            return jRet;
        }
   public class GetTVShowsfilter1
   {
       public int genreid {get;set;}
   }

        async public Task<GetTVShowsResponse> GetTVShows2(XBMCRPC.Video.Fields.TVShow properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetTVShowsfilter1 filter=null)
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
            var jRet = await _client.GetData<GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
            return jRet;
        }
   public class GetTVShowsfilter2
   {
       public string genre {get;set;}
   }

        async public Task<GetTVShowsResponse> GetTVShows2(XBMCRPC.Video.Fields.TVShow properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetTVShowsfilter2 filter=null)
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
            var jRet = await _client.GetData<GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
            return jRet;
        }
   public class GetTVShowsfilter3
   {
       public int year {get;set;}
   }

        async public Task<GetTVShowsResponse> GetTVShows2(XBMCRPC.Video.Fields.TVShow properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetTVShowsfilter3 filter=null)
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
            var jRet = await _client.GetData<GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
            return jRet;
        }
   public class GetTVShowsfilter4
   {
       public string actor {get;set;}
   }

        async public Task<GetTVShowsResponse> GetTVShows2(XBMCRPC.Video.Fields.TVShow properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetTVShowsfilter4 filter=null)
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
            var jRet = await _client.GetData<GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
            return jRet;
        }
   public class GetTVShowsfilter5
   {
       public string studio {get;set;}
   }

        async public Task<GetTVShowsResponse> GetTVShows2(XBMCRPC.Video.Fields.TVShow properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetTVShowsfilter5 filter=null)
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
            var jRet = await _client.GetData<GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
            return jRet;
        }
   public class GetTVShowsfilter6
   {
       public string tag {get;set;}
   }

        async public Task<GetTVShowsResponse> GetTVShows2(XBMCRPC.Video.Fields.TVShow properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, GetTVShowsfilter6 filter=null)
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
            var jRet = await _client.GetData<GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
            return jRet;
        }

        async public Task<GetTVShowsResponse> GetTVShows2(XBMCRPC.Video.Fields.TVShow properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null, XBMCRPC.List.Filter.TVShows filter=null)
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
            var jRet = await _client.GetData<GetTVShowsResponse>("VideoLibrary.GetTVShows", jArgs);
            return jRet;
        }

        async public Task<string> RemoveEpisode(int episodeid=0)
        {
            var jArgs = new JObject();
             if (episodeid != null)
             {
                 var jpropepisodeid = JToken.FromObject(episodeid, _client.Serializer);
                 jArgs.Add(new JProperty("episodeid", jpropepisodeid));
             }
            var jRet = await _client.GetData<string>("VideoLibrary.RemoveEpisode", jArgs);
            return jRet;
        }

        async public Task<string> RemoveMovie(int movieid=0)
        {
            var jArgs = new JObject();
             if (movieid != null)
             {
                 var jpropmovieid = JToken.FromObject(movieid, _client.Serializer);
                 jArgs.Add(new JProperty("movieid", jpropmovieid));
             }
            var jRet = await _client.GetData<string>("VideoLibrary.RemoveMovie", jArgs);
            return jRet;
        }

        async public Task<string> RemoveMusicVideo(int musicvideoid=0)
        {
            var jArgs = new JObject();
             if (musicvideoid != null)
             {
                 var jpropmusicvideoid = JToken.FromObject(musicvideoid, _client.Serializer);
                 jArgs.Add(new JProperty("musicvideoid", jpropmusicvideoid));
             }
            var jRet = await _client.GetData<string>("VideoLibrary.RemoveMusicVideo", jArgs);
            return jRet;
        }

        async public Task<string> RemoveTVShow(int tvshowid=0)
        {
            var jArgs = new JObject();
             if (tvshowid != null)
             {
                 var jproptvshowid = JToken.FromObject(tvshowid, _client.Serializer);
                 jArgs.Add(new JProperty("tvshowid", jproptvshowid));
             }
            var jRet = await _client.GetData<string>("VideoLibrary.RemoveTVShow", jArgs);
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
            var jRet = await _client.GetData<string>("VideoLibrary.Scan", jArgs);
            return jRet;
        }

        async public Task<string> SetEpisodeDetails(int episodeid=0, string title=null, int? playcount=null, int? runtime=null, string[] director=null, string plot=null, double? rating=null, string votes=null, string lastplayed=null, string[] writer=null, string firstaired=null, string productioncode=null, int? season=null, int? episode=null, string originaltitle=null, string thumbnail=null, string fanart=null)
        {
            var jArgs = new JObject();
             if (episodeid != null)
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
            var jRet = await _client.GetData<string>("VideoLibrary.SetEpisodeDetails", jArgs);
            return jRet;
        }

        async public Task<string> SetEpisodeDetails2(int episodeid=0, string title=null, int? playcount=null, int? runtime=null, string[] director=null, string plot=null, double? rating=null, string votes=null, string lastplayed=null, string[] writer=null, string firstaired=null, string productioncode=null, int? season=null, int? episode=null, string originaltitle=null, string thumbnail=null, string fanart=null, XBMCRPC.Media.Artwork art=null)
        {
            var jArgs = new JObject();
             if (episodeid != null)
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
            var jRet = await _client.GetData<string>("VideoLibrary.SetEpisodeDetails", jArgs);
            return jRet;
        }

        async public Task<string> SetMovieDetails(int movieid=0, string title=null, int? playcount=null, int? runtime=null, string[] director=null, string[] studio=null, int? year=null, string plot=null, string[] genre=null, double? rating=null, string mpaa=null, string imdbnumber=null, string votes=null, string lastplayed=null, string originaltitle=null, string trailer=null, string tagline=null, string plotoutline=null, string[] writer=null, string[] country=null, int? top250=null, string sorttitle=null, string set=null, string[] showlink=null, string thumbnail=null, string fanart=null, string[] tag=null)
        {
            var jArgs = new JObject();
             if (movieid != null)
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
            var jRet = await _client.GetData<string>("VideoLibrary.SetMovieDetails", jArgs);
            return jRet;
        }

        async public Task<string> SetMovieDetails2(int movieid=0, string title=null, int? playcount=null, int? runtime=null, string[] director=null, string[] studio=null, int? year=null, string plot=null, string[] genre=null, double? rating=null, string mpaa=null, string imdbnumber=null, string votes=null, string lastplayed=null, string originaltitle=null, string trailer=null, string tagline=null, string plotoutline=null, string[] writer=null, string[] country=null, int? top250=null, string sorttitle=null, string set=null, string[] showlink=null, string thumbnail=null, string fanart=null, string[] tag=null, XBMCRPC.Media.Artwork art=null)
        {
            var jArgs = new JObject();
             if (movieid != null)
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
            var jRet = await _client.GetData<string>("VideoLibrary.SetMovieDetails", jArgs);
            return jRet;
        }

        async public Task<string> SetMusicVideoDetails(int musicvideoid=0, string title=null, int? playcount=null, int? runtime=null, string[] director=null, string[] studio=null, int? year=null, string plot=null, string album=null, string[] artist=null, string[] genre=null, int? track=null, string lastplayed=null, string thumbnail=null, string fanart=null, string[] tag=null)
        {
            var jArgs = new JObject();
             if (musicvideoid != null)
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
            var jRet = await _client.GetData<string>("VideoLibrary.SetMusicVideoDetails", jArgs);
            return jRet;
        }

        async public Task<string> SetMusicVideoDetails2(int musicvideoid=0, string title=null, int? playcount=null, int? runtime=null, string[] director=null, string[] studio=null, int? year=null, string plot=null, string album=null, string[] artist=null, string[] genre=null, int? track=null, string lastplayed=null, string thumbnail=null, string fanart=null, string[] tag=null, XBMCRPC.Media.Artwork art=null)
        {
            var jArgs = new JObject();
             if (musicvideoid != null)
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
            var jRet = await _client.GetData<string>("VideoLibrary.SetMusicVideoDetails", jArgs);
            return jRet;
        }

        async public Task<string> SetTVShowDetails(int tvshowid=0, string title=null, int? playcount=null, string[] studio=null, string plot=null, string[] genre=null, double? rating=null, string mpaa=null, string imdbnumber=null, string premiered=null, string votes=null, string lastplayed=null, string originaltitle=null, string sorttitle=null, string episodeguide=null, string thumbnail=null, string fanart=null, string[] tag=null)
        {
            var jArgs = new JObject();
             if (tvshowid != null)
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
            var jRet = await _client.GetData<string>("VideoLibrary.SetTVShowDetails", jArgs);
            return jRet;
        }

        async public Task<string> SetTVShowDetails2(int tvshowid=0, string title=null, int? playcount=null, string[] studio=null, string plot=null, string[] genre=null, double? rating=null, string mpaa=null, string imdbnumber=null, string premiered=null, string votes=null, string lastplayed=null, string originaltitle=null, string sorttitle=null, string episodeguide=null, string thumbnail=null, string fanart=null, string[] tag=null, XBMCRPC.Media.Artwork art=null)
        {
            var jArgs = new JObject();
             if (tvshowid != null)
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
            var jRet = await _client.GetData<string>("VideoLibrary.SetTVShowDetails", jArgs);
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
       public int playcount {get;set;}
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
