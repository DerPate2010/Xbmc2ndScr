using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace KODIRPC.Methods
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
                /// <returns>KODIRPC.Files.GetDirectoryResponse</returns>
        public async Task<KODIRPC.Files.GetDirectoryResponse> GetDirectory(string directory=null, KODIRPC.Files.Media? media=null, KODIRPC.List.Fields.Files properties=null, KODIRPC.List.Sort sort=null, KODIRPC.List.Limits limits=null)
        {
             var jArgs = new JObject();

             if (directory == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null directory");
              }
             else
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
            return await _client.GetData<KODIRPC.Files.GetDirectoryResponse>("Files.GetDirectory", jArgs);
        }

                /// <summary>
                /// Get details for a specific file
                /// </summary>
                /// <param name="file"> REQUIRED Full path to the file</param>
                /// <param name="media"> </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.Files.GetFileDetailsResponse</returns>
        public async Task<KODIRPC.Files.GetFileDetailsResponse> GetFileDetails(string file=null, KODIRPC.Files.Media? media=null, KODIRPC.List.Fields.Files properties=null)
        {
             var jArgs = new JObject();

             if (file == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null file");
              }
             else
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
            return await _client.GetData<KODIRPC.Files.GetFileDetailsResponse>("Files.GetFileDetails", jArgs);
        }

                /// <summary>
                /// Get the sources of the media windows
                /// </summary>
                /// <param name="media"> REQUIRED </param>
                /// <param name="limits"> </param>
                /// <param name="sort"> </param>
                /// <returns>KODIRPC.Files.GetSourcesResponse</returns>
        public async Task<KODIRPC.Files.GetSourcesResponse> GetSources(KODIRPC.Files.Media? media=null, KODIRPC.List.Limits limits=null, KODIRPC.List.Sort sort=null)
        {
             var jArgs = new JObject();

             if (media == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null media");
              }
             else
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
            return await _client.GetData<KODIRPC.Files.GetSourcesResponse>("Files.GetSources", jArgs);
        }

                /// <summary>
                /// Provides a way to download a given file (e.g. providing an URL to the real file location)
                /// </summary>
                /// <param name="path"> REQUIRED </param>
                /// <returns>KODIRPC.Files.PrepareDownloadResponse</returns>
        public async Task<KODIRPC.Files.PrepareDownloadResponse> PrepareDownload(string path=null)
        {
             var jArgs = new JObject();

             if (path == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null path");
              }
             else
              {
                 var jproppath = JToken.FromObject(path, _client.Serializer);
                 jArgs.Add(new JProperty("path", jproppath));
              }
            return await _client.GetData<KODIRPC.Files.PrepareDownloadResponse>("Files.PrepareDownload", jArgs);
        }
   }
}
