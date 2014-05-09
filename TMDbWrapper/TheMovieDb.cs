using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TmdbWrapper;
using TmdbWrapper.Cache;
using TmdbWrapper.Movies;
using TmdbWrapper.Search;
using TmdbWrapper.Utilities;


namespace TmdbWrapper
{
    /// <summary>
    /// The static that wraps The movie database service.
    /// It should be initilised with your API_KEY.
    /// You can apply for an API_KEY at www.TheMovieDb.org
    /// </summary>
    public static partial class TheMovieDb
    {
        private static Config _cfg;

        /// <summary>
        /// The apikey that is used in all requests.
        /// </summary>
        public static string ApiKey { get; private set; }
        /// <summary>
        /// Language all the request uses if entered.
        /// </summary>
        public static string Language { get; private set; }

        /// <summary>
        /// Initialises the wrapper.
        /// </summary>
        /// <param name="apiKey">The apikey the requests will use.</param>       
        public static void Initialise(string apiKey) 
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Initialises the wrapper.
        /// </summary>
        /// <param name="apiKey">The apikey the request will use.</param>       
        /// <param name="language">The language the requests will use.</param>
        /// <param name="requester"></param>
        public static void Initialise(string apiKey, string language, IRequester requester)
        {
            ApiKey = apiKey;
            Language = language;
            Requester = requester;
        }

        public static async Task<Config> GetConfiguration()
        {
            if (_cfg != null) return _cfg;
            Request<Config> request = new Request<Config>("configuration");

            _cfg = await request.ProcesRequestAsync();
            return _cfg;
        }

        public static IRequester Requester { get; private set; }
    }

    public class Config : ITmdbObject
    {
        public void ProcessJson(JObject jsonObject)
        {
            BaseUrl=jsonObject["images"]["base_url"].ToString();
            BaseUrlPoster = BaseUrl + "w500"; //jsonObject["images"]["poster_sizes"];
            BaseUrlBackdrop = BaseUrl + "w1280";
            BaseUrlProfile = BaseUrl + "w185"; 
        }

        private string BaseUrl { get; set; }
        public string BaseUrlPoster { get; set; }
        public string BaseUrlBackdrop { get; set; }
        public string BaseUrlProfile { get; set; }
    }


    public interface IRequester
    {
        Task<string> Get(string uri);
    }
}
