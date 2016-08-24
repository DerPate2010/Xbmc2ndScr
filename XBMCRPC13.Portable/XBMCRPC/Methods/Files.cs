using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
{
   public partial class Files
   {
        private readonly Client _client;
          public Files(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Get the directories and files in the given directory
                /// </summary>
                /// <param name="directory"> REQUIRED </param>
                /// <param name="media"> </param>
                /// <param name="properties"> </param>
                /// <param name="sort"> </param>
                /// <param name="limits"> Limits are applied after getting the directory content thus retrieval is not faster when they are applied.</param>
                /// <returns>XBMCRPC.Files.GetDirectoryResponse</returns>
        public async Task<XBMCRPC.Files.GetDirectoryResponse> GetDirectory(string directory, XBMCRPC.Files.Media? media=null, XBMCRPC.List.Fields.Files properties=null, XBMCRPC.List.Sort sort=null, XBMCRPC.List.Limits limits=null)
        {
            var jArgs = new JObject();

             {
                 var jpropdirectory = JToken.FromObject(directory, _client.Serializer);
                 jArgs.Add(new JProperty("directory", jpropdirectory));
             }
             if (media != null)
             {
                 var jpropmedia = JToken.FromObject(media, _client.Serializer);
                 jArgs.Add(new JProperty("media", jpropmedia));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
             if (sort != null)
             {
                 var jpropsort = JToken.FromObject(sort, _client.Serializer);
                 jArgs.Add(new JProperty("sort", jpropsort));
             }
             if (limits != null)
             {
                 var jproplimits = JToken.FromObject(limits, _client.Serializer);
                 jArgs.Add(new JProperty("limits", jproplimits));
             }
            return await _client.GetData<XBMCRPC.Files.GetDirectoryResponse>("Files.GetDirectory", jArgs);
        }

                /// <summary>
                /// Get details for a specific file
                /// </summary>
                /// <param name="file"> REQUIRED Full path to the file</param>
                /// <param name="media"> </param>
                /// <param name="properties"> </param>
                /// <returns>XBMCRPC.Files.GetFileDetailsResponse</returns>
        public async Task<XBMCRPC.Files.GetFileDetailsResponse> GetFileDetails(string file, XBMCRPC.Files.Media? media=null, XBMCRPC.List.Fields.Files properties=null)
        {
            var jArgs = new JObject();

             {
                 var jpropfile = JToken.FromObject(file, _client.Serializer);
                 jArgs.Add(new JProperty("file", jpropfile));
             }
             if (media != null)
             {
                 var jpropmedia = JToken.FromObject(media, _client.Serializer);
                 jArgs.Add(new JProperty("media", jpropmedia));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<XBMCRPC.Files.GetFileDetailsResponse>("Files.GetFileDetails", jArgs);
        }

                /// <summary>
                /// Get the sources of the media windows
                /// </summary>
                /// <param name="media"> REQUIRED </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>XBMCRPC.Files.GetSourcesResponse</returns>
        public async Task<XBMCRPC.Files.GetSourcesResponse> GetSources(XBMCRPC.Files.Media? media, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();

             {
                 var jpropmedia = JToken.FromObject(media, _client.Serializer);
                 jArgs.Add(new JProperty("media", jpropmedia));
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
            return await _client.GetData<XBMCRPC.Files.GetSourcesResponse>("Files.GetSources", jArgs);
        }

                /// <summary>
                /// Provides a way to download a given file (e.g. providing an URL to the real file location)
                /// </summary>
                /// <param name="path"> REQUIRED </param>
                /// <returns>XBMCRPC.Files.PrepareDownloadResponse</returns>
        public async Task<XBMCRPC.Files.PrepareDownloadResponse> PrepareDownload(string path)
        {
            var jArgs = new JObject();

             {
                 var jproppath = JToken.FromObject(path, _client.Serializer);
                 jArgs.Add(new JProperty("path", jproppath));
             }
            return await _client.GetData<XBMCRPC.Files.PrepareDownloadResponse>("Files.PrepareDownload", jArgs);
        }
   }
}
