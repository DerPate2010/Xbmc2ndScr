using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace XBMCRPC.Methods
{
   public partial class PVR
   {
        private readonly Client _client;
          public PVR(Client client)
          {
              _client = client;
          }
   public class GetChannelDetailsResponse
   {
       public XBMCRPC.PVR.Details.Channel channeldetails {get;set;}
   }

        async public Task<GetChannelDetailsResponse> GetChannelDetails(int channelid=0, XBMCRPC.PVR.Fields.Channel properties=null)
        {
            var jArgs = new JObject();
             if (channelid != null)
             {
                 var jpropchannelid = JToken.FromObject(channelid, _client.Serializer);
                 jArgs.Add(new JProperty("channelid", jpropchannelid));
             }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<GetChannelDetailsResponse>("PVR.GetChannelDetails", jArgs);
            return jRet;
        }
   public class GetChannelGroupDetailsResponse
   {
       public XBMCRPC.PVR.Details.ChannelGroup.Extended channelgroupdetails {get;set;}
   }
   public class channelsType
   {
       public XBMCRPC.List.Limits limits {get;set;}
       public XBMCRPC.PVR.Fields.Channel properties {get;set;}
   }

        async public Task<GetChannelGroupDetailsResponse> GetChannelGroupDetails(int channelgroupid=0, channelsType channels=null)
        {
            var jArgs = new JObject();
             if (channelgroupid != null)
             {
                 var jpropchannelgroupid = JToken.FromObject(channelgroupid, _client.Serializer);
                 jArgs.Add(new JProperty("channelgroupid", jpropchannelgroupid));
             }
             if (channels != null)
             {
                 var jpropchannels = JToken.FromObject(channels, _client.Serializer);
                 jArgs.Add(new JProperty("channels", jpropchannels));
             }
            var jRet = await _client.GetData<GetChannelGroupDetailsResponse>("PVR.GetChannelGroupDetails", jArgs);
            return jRet;
        }
   public class GetChannelGroupsResponse
   {
       public XBMCRPC.PVR.Details.ChannelGroup[] channelgroups {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetChannelGroupsResponse> GetChannelGroups(XBMCRPC.PVR.Channel.Type channeltype=0, XBMCRPC.List.Limits limits=null)
        {
            var jArgs = new JObject();
             if (channeltype != null)
             {
                 var jpropchanneltype = JToken.FromObject(channeltype, _client.Serializer);
                 jArgs.Add(new JProperty("channeltype", jpropchanneltype));
             }
             if (limits != null)
             {
                 var jproplimits = JToken.FromObject(limits, _client.Serializer);
                 jArgs.Add(new JProperty("limits", jproplimits));
             }
            var jRet = await _client.GetData<GetChannelGroupsResponse>("PVR.GetChannelGroups", jArgs);
            return jRet;
        }
   public class GetChannelsResponse
   {
       public XBMCRPC.PVR.Details.Channel[] channels {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }

        async public Task<GetChannelsResponse> GetChannels(int channelgroupid=0, XBMCRPC.PVR.Fields.Channel properties=null, XBMCRPC.List.Limits limits=null)
        {
            var jArgs = new JObject();
             if (channelgroupid != null)
             {
                 var jpropchannelgroupid = JToken.FromObject(channelgroupid, _client.Serializer);
                 jArgs.Add(new JProperty("channelgroupid", jpropchannelgroupid));
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
            var jRet = await _client.GetData<GetChannelsResponse>("PVR.GetChannels", jArgs);
            return jRet;
        }

        async public Task<XBMCRPC.PVR.Property.Value> GetProperties(XBMCRPC.PVR.Property.Name[] properties=null)
        {
            var jArgs = new JObject();
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            var jRet = await _client.GetData<XBMCRPC.PVR.Property.Value>("PVR.GetProperties", jArgs);
            return jRet;
        }

        async public Task<string> Record(XBMCRPC.Global.Toggle record=0)
        {
            var jArgs = new JObject();
             if (record != null)
             {
                 var jproprecord = JToken.FromObject(record, _client.Serializer);
                 jArgs.Add(new JProperty("record", jproprecord));
             }
            var jRet = await _client.GetData<string>("PVR.Record", jArgs);
            return jRet;
        }
   public enum Recordchannel
   {
       current,
   }

        async public Task<string> Record2(XBMCRPC.Global.Toggle record=0, Recordchannel channel=0)
        {
            var jArgs = new JObject();
             if (record != null)
             {
                 var jproprecord = JToken.FromObject(record, _client.Serializer);
                 jArgs.Add(new JProperty("record", jproprecord));
             }
             if (channel != null)
             {
                 var jpropchannel = JToken.FromObject(channel, _client.Serializer);
                 jArgs.Add(new JProperty("channel", jpropchannel));
             }
            var jRet = await _client.GetData<string>("PVR.Record", jArgs);
            return jRet;
        }

        async public Task<string> Record2(XBMCRPC.Global.Toggle record=0, int channel=0)
        {
            var jArgs = new JObject();
             if (record != null)
             {
                 var jproprecord = JToken.FromObject(record, _client.Serializer);
                 jArgs.Add(new JProperty("record", jproprecord));
             }
             if (channel != null)
             {
                 var jpropchannel = JToken.FromObject(channel, _client.Serializer);
                 jArgs.Add(new JProperty("channel", jpropchannel));
             }
            var jRet = await _client.GetData<string>("PVR.Record", jArgs);
            return jRet;
        }

        async public Task<string> Scan()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("PVR.Scan", jArgs);
            return jRet;
        }
   }
}
