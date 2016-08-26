using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace KODIRPC.Methods
{
   public partial class PVR
   {
        private readonly Client _client;
          public PVR(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Retrieves the details of a specific broadcast
                /// </summary>
                /// <param name="broadcastid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.PVR.GetBroadcastDetailsResponse</returns>
        public async Task<KODIRPC.PVR.GetBroadcastDetailsResponse> GetBroadcastDetails(int? broadcastid=null, KODIRPC.PVR.Fields.Broadcast properties=null)
        {
             var jArgs = new JObject();

             if (broadcastid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null broadcastid");
              }
             else
              {
                 var jpropbroadcastid = JToken.FromObject(broadcastid, _client.Serializer);
                 jArgs.Add(new JProperty("broadcastid", jpropbroadcastid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.PVR.GetBroadcastDetailsResponse>("PVR.GetBroadcastDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the program of a specific channel
                /// </summary>
                /// <param name="channelid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>KODIRPC.PVR.GetBroadcastsResponse</returns>
        public async Task<KODIRPC.PVR.GetBroadcastsResponse> GetBroadcasts(int? channelid=null, KODIRPC.PVR.Fields.Broadcast properties=null, KODIRPC.List.Limits limits=null)
        {
             var jArgs = new JObject();

             if (channelid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null channelid");
              }
             else
              {
                 var jpropchannelid = JToken.FromObject(channelid, _client.Serializer);
                 jArgs.Add(new JProperty("channelid", jpropchannelid));
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
            return await _client.GetData<KODIRPC.PVR.GetBroadcastsResponse>("PVR.GetBroadcasts", jArgs);
        }

                /// <summary>
                /// Retrieves the details of a specific channel
                /// </summary>
                /// <param name="channelid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.PVR.GetChannelDetailsResponse</returns>
        public async Task<KODIRPC.PVR.GetChannelDetailsResponse> GetChannelDetails(int? channelid=null, KODIRPC.PVR.Fields.Channel properties=null)
        {
             var jArgs = new JObject();

             if (channelid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null channelid");
              }
             else
              {
                 var jpropchannelid = JToken.FromObject(channelid, _client.Serializer);
                 jArgs.Add(new JProperty("channelid", jpropchannelid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.PVR.GetChannelDetailsResponse>("PVR.GetChannelDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the details of a specific channel group
                /// </summary>
                /// <param name="channelgroupid"> REQUIRED </param>
                /// <param name="channels"> </param>
                /// <returns>KODIRPC.PVR.GetChannelGroupDetailsResponse</returns>
        public async Task<KODIRPC.PVR.GetChannelGroupDetailsResponse> GetChannelGroupDetails(int? channelgroupid=null, KODIRPC.PVR.GetChannelGroupDetails_channels channels=null)
        {
             var jArgs = new JObject();

             if (channelgroupid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null channelgroupid");
              }
             else
              {
                 var jpropchannelgroupid = JToken.FromObject(channelgroupid, _client.Serializer);
                 jArgs.Add(new JProperty("channelgroupid", jpropchannelgroupid));
              }
             if (channels != null)
             {
                 var jpropchannels = JToken.FromObject(channels, _client.Serializer);
                 jArgs.Add(new JProperty("channels", jpropchannels));
             }
            return await _client.GetData<KODIRPC.PVR.GetChannelGroupDetailsResponse>("PVR.GetChannelGroupDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the details of a specific channel group
                /// </summary>
                /// <param name="channelgroupid"> REQUIRED </param>
                /// <param name="channels"> </param>
                /// <returns>KODIRPC.PVR.GetChannelGroupDetailsResponse</returns>
        public async Task<KODIRPC.PVR.GetChannelGroupDetailsResponse> GetChannelGroupDetails(KODIRPC.PVR.ChannelGroup.Id1? channelgroupid=null, KODIRPC.PVR.GetChannelGroupDetails_channels channels=null)
        {
             var jArgs = new JObject();

             if (channelgroupid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null channelgroupid");
              }
             else
              {
                 var jpropchannelgroupid = JToken.FromObject(channelgroupid, _client.Serializer);
                 jArgs.Add(new JProperty("channelgroupid", jpropchannelgroupid));
              }
             if (channels != null)
             {
                 var jpropchannels = JToken.FromObject(channels, _client.Serializer);
                 jArgs.Add(new JProperty("channels", jpropchannels));
             }
            return await _client.GetData<KODIRPC.PVR.GetChannelGroupDetailsResponse>("PVR.GetChannelGroupDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the details of a specific channel group
                /// </summary>
                /// <param name="channels"> </param>
                /// <returns>KODIRPC.PVR.GetChannelGroupDetailsResponse</returns>
        public async Task<KODIRPC.PVR.GetChannelGroupDetailsResponse> GetChannelGroupDetails(KODIRPC.PVR.GetChannelGroupDetails_channels channels=null)
        {
             var jArgs = new JObject();

             if (channels != null)
             {
                 var jpropchannels = JToken.FromObject(channels, _client.Serializer);
                 jArgs.Add(new JProperty("channels", jpropchannels));
             }
            return await _client.GetData<KODIRPC.PVR.GetChannelGroupDetailsResponse>("PVR.GetChannelGroupDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the channel groups for the specified type
                /// </summary>
                /// <param name="channeltype"> REQUIRED </param>
                /// <param name="limits"> </param>
                /// <returns>KODIRPC.PVR.GetChannelGroupsResponse</returns>
        public async Task<KODIRPC.PVR.GetChannelGroupsResponse> GetChannelGroups(KODIRPC.PVR.Channel.Type? channeltype=null, KODIRPC.List.Limits limits=null)
        {
             var jArgs = new JObject();

             if (channeltype == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null channeltype");
              }
             else
              {
                 var jpropchanneltype = JToken.FromObject(channeltype, _client.Serializer);
                 jArgs.Add(new JProperty("channeltype", jpropchanneltype));
              }
             if (limits != null)
             {
                 var jproplimits = JToken.FromObject(limits, _client.Serializer);
                 jArgs.Add(new JProperty("limits", jproplimits));
             }
            return await _client.GetData<KODIRPC.PVR.GetChannelGroupsResponse>("PVR.GetChannelGroups", jArgs);
        }

                /// <summary>
                /// Retrieves the channel list
                /// </summary>
                /// <param name="channelgroupid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>KODIRPC.PVR.GetChannelsResponse</returns>
        public async Task<KODIRPC.PVR.GetChannelsResponse> GetChannels(int? channelgroupid=null, KODIRPC.PVR.Fields.Channel properties=null, KODIRPC.List.Limits limits=null)
        {
             var jArgs = new JObject();

             if (channelgroupid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null channelgroupid");
              }
             else
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
            return await _client.GetData<KODIRPC.PVR.GetChannelsResponse>("PVR.GetChannels", jArgs);
        }

                /// <summary>
                /// Retrieves the channel list
                /// </summary>
                /// <param name="channelgroupid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>KODIRPC.PVR.GetChannelsResponse</returns>
        public async Task<KODIRPC.PVR.GetChannelsResponse> GetChannels(KODIRPC.PVR.ChannelGroup.Id1? channelgroupid=null, KODIRPC.PVR.Fields.Channel properties=null, KODIRPC.List.Limits limits=null)
        {
             var jArgs = new JObject();

             if (channelgroupid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null channelgroupid");
              }
             else
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
            return await _client.GetData<KODIRPC.PVR.GetChannelsResponse>("PVR.GetChannels", jArgs);
        }

                /// <summary>
                /// Retrieves the channel list
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>KODIRPC.PVR.GetChannelsResponse</returns>
        public async Task<KODIRPC.PVR.GetChannelsResponse> GetChannels(KODIRPC.PVR.Fields.Channel properties=null, KODIRPC.List.Limits limits=null)
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
            return await _client.GetData<KODIRPC.PVR.GetChannelsResponse>("PVR.GetChannels", jArgs);
        }

                /// <summary>
                /// Retrieves the values of the given properties
                /// </summary>
                /// <param name="properties"> REQUIRED </param>
                /// <returns>KODIRPC.PVR.Property.Value</returns>
        public async Task<KODIRPC.PVR.Property.Value> GetProperties(KODIRPC.PVR.GetProperties_properties properties=null)
        {
             var jArgs = new JObject();

             if (properties == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null properties");
              }
             else
              {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
              }
            return await _client.GetData<KODIRPC.PVR.Property.Value>("PVR.GetProperties", jArgs);
        }

                /// <summary>
                /// Retrieves the details of a specific recording
                /// </summary>
                /// <param name="recordingid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.PVR.GetRecordingDetailsResponse</returns>
        public async Task<KODIRPC.PVR.GetRecordingDetailsResponse> GetRecordingDetails(int? recordingid=null, KODIRPC.PVR.Fields.Recording properties=null)
        {
             var jArgs = new JObject();

             if (recordingid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null recordingid");
              }
             else
              {
                 var jproprecordingid = JToken.FromObject(recordingid, _client.Serializer);
                 jArgs.Add(new JProperty("recordingid", jproprecordingid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.PVR.GetRecordingDetailsResponse>("PVR.GetRecordingDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the recordings
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>KODIRPC.PVR.GetRecordingsResponse</returns>
        public async Task<KODIRPC.PVR.GetRecordingsResponse> GetRecordings(KODIRPC.PVR.Fields.Recording properties=null, KODIRPC.List.Limits limits=null)
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
            return await _client.GetData<KODIRPC.PVR.GetRecordingsResponse>("PVR.GetRecordings", jArgs);
        }

                /// <summary>
                /// Retrieves the details of a specific timer
                /// </summary>
                /// <param name="timerid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>KODIRPC.PVR.GetTimerDetailsResponse</returns>
        public async Task<KODIRPC.PVR.GetTimerDetailsResponse> GetTimerDetails(int? timerid=null, KODIRPC.PVR.Fields.Timer properties=null)
        {
             var jArgs = new JObject();

             if (timerid == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null timerid");
              }
             else
              {
                 var jproptimerid = JToken.FromObject(timerid, _client.Serializer);
                 jArgs.Add(new JProperty("timerid", jproptimerid));
              }
             if (properties != null)
             {
                 var jpropproperties = JToken.FromObject(properties, _client.Serializer);
                 jArgs.Add(new JProperty("properties", jpropproperties));
             }
            return await _client.GetData<KODIRPC.PVR.GetTimerDetailsResponse>("PVR.GetTimerDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the timers
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>KODIRPC.PVR.GetTimersResponse</returns>
        public async Task<KODIRPC.PVR.GetTimersResponse> GetTimers(KODIRPC.PVR.Fields.Timer properties=null, KODIRPC.List.Limits limits=null)
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
            return await _client.GetData<KODIRPC.PVR.GetTimersResponse>("PVR.GetTimers", jArgs);
        }

                /// <summary>
                /// Toggle recording of a channel
                /// </summary>
                /// <param name="record"> </param>
                /// <param name="channel"> </param>
                /// <returns>string</returns>
        public async Task<string> Record(bool? record=null, object channel=null)
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
            return await _client.GetData<string>("PVR.Record", jArgs);
        }

                /// <summary>
                /// Toggle recording of a channel
                /// </summary>
                /// <param name="record"> </param>
                /// <param name="channel"> </param>
                /// <returns>string</returns>
        public async Task<string> Record(KODIRPC.Global.Toggle2? record=null, object channel=null)
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
            return await _client.GetData<string>("PVR.Record", jArgs);
        }

                /// <summary>
                /// Toggle recording of a channel
                /// </summary>
                /// <param name="channel"> </param>
                /// <returns>string</returns>
        public async Task<string> Record(object channel=null)
        {
             var jArgs = new JObject();

             if (channel != null)
             {
                 var jpropchannel = JToken.FromObject(channel, _client.Serializer);
                 jArgs.Add(new JProperty("channel", jpropchannel));
             }
            return await _client.GetData<string>("PVR.Record", jArgs);
        }

                /// <summary>
                /// Starts a channel scan
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Scan()
        {
            return await _client.GetData<string>("PVR.Scan",null);
        }
   }
}
