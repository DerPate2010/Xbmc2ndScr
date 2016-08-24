using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
{
   public partial class Profiles
   {
        private readonly Client _client;
          public Profiles(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Retrieve the current profile
                /// </summary>
                /// <param name="properties"> </param>
                /// <returns>XBMCRPC.Profiles.Details.Profile</returns>
        public async Task<XBMCRPC.Profiles.Details.Profile> GetCurrentProfile(XBMCRPC.Profiles.Fields.Profile properties=null)
        {
             var jArgs = new JObject();

             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<XBMCRPC.Profiles.Details.Profile>("Profiles.GetCurrentProfile", jArgs);
        }

                /// <summary>
                /// Retrieve all profiles
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>XBMCRPC.Profiles.GetProfilesResponse</returns>
        public async Task<XBMCRPC.Profiles.GetProfilesResponse> GetProfiles(XBMCRPC.Profiles.Fields.Profile properties=null, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
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
            return await _client.GetData<XBMCRPC.Profiles.GetProfilesResponse>("Profiles.GetProfiles", jArgs);
        }

                /// <summary>
                /// Load the specified profile
                /// </summary>
                /// <param name="profile"> REQUIRED Profile name</param>
                /// <param name="prompt"> Prompt for password</param>
                /// <param name="password"> </param>
                /// <returns>string</returns>
        public async Task<string> LoadProfile(string profile=null, bool? prompt=null, XBMCRPC.Profiles.Password password=null)
        {
             var jArgs = new JObject();

             if (profile == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null profile");
              }
             else
              {
                 var jpropprofile = JToken.FromObject(profile, _client.Serializer);
                 jArgs.Add(new JProperty("profile", jpropprofile));
              }
             if (prompt != null)
             {
                 var jpropprompt = JToken.FromObject(prompt, _client.Serializer);
                 jArgs.Add(new JProperty("prompt", jpropprompt));
             }
             if (password != null)
             {
                 var jproppassword = JToken.FromObject(password, _client.Serializer);
                 jArgs.Add(new JProperty("password", jproppassword));
             }
            return await _client.GetData<string>("Profiles.LoadProfile", jArgs);
        }
   }
}
