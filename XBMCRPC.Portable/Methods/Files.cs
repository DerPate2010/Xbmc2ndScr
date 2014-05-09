using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace XBMCRPC.Methods
{
   public partial class Files
   {
        private readonly Client _client;
          public Files(Client client)
          {
              _client = client;
          }
   public class GetDirectoryResponse
   {
       public XBMCRPC.List.Item.File[] files {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetDirectoryResponse> GetDirectory(string directory=null, XBMCRPC.Files.Media media=0, XBMCRPC.List.Fields.Files properties=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();
             if (directory != null)
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
            var jRet = await _client.GetData<GetDirectoryResponse>("Files.GetDirectory", jArgs);
            return jRet;
        }
   public class GetFileDetailsResponse
   {
       public XBMCRPC.List.Item.File filedetails {get;set;}
   }

        async public Task<GetFileDetailsResponse> GetFileDetails(string file=null, XBMCRPC.Files.Media media=0, XBMCRPC.List.Fields.Files properties=null)
        {
            var jArgs = new JObject();
             if (file != null)
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
            var jRet = await _client.GetData<GetFileDetailsResponse>("Files.GetFileDetails", jArgs);
            return jRet;
        }
   public class GetSourcesResponse
   {
       public XBMCRPC.List.LimitsReturned limits {get;set;}
       public XBMCRPC.List.Items.Sources sources {get;set;}
   }

        async public Task<GetSourcesResponse> GetSources(XBMCRPC.Files.Media media=0, XBMCRPC.List.Limits limits=null, XBMCRPC.List.Sort sort=null)
        {
            var jArgs = new JObject();
             if (media != null)
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
            var jRet = await _client.GetData<GetSourcesResponse>("Files.GetSources", jArgs);
            return jRet;
        }
   public class PrepareDownloadResponse
   {
       public JObject details {get;set;}
   public enum modeEnum
   {
       redirect,
       direct,
   }
       public modeEnum mode {get;set;}
   public enum protocolEnum
   {
       http,
   }
       public protocolEnum protocol {get;set;}
   }

        async public Task<PrepareDownloadResponse> PrepareDownload(string path=null)
        {
            var jArgs = new JObject();
             if (path != null)
             {
                 var jproppath = JToken.FromObject(path, _client.Serializer);
                 jArgs.Add(new JProperty("path", jproppath));
             }
            var jRet = await _client.GetData<PrepareDownloadResponse>("Files.PrepareDownload", jArgs);
            return jRet;
        }
   }
}
