using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
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
                /// <returns>XBMCRPC.PVR.GetBroadcastDetailsResponse</returns>
        public async Task<XBMCRPC.PVR.GetBroadcastDetailsResponse> GetBroadcastDetails(int? broadcastid=null, XBMCRPC.PVR.Fields.Broadcast properties=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetBroadcastDetailsResponse>("PVR.GetBroadcastDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the program of a specific channel
                /// </summary>
                /// <param name="channelid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>XBMCRPC.PVR.GetBroadcastsResponse</returns>
        public async Task<XBMCRPC.PVR.GetBroadcastsResponse> GetBroadcasts(int? channelid=null, XBMCRPC.PVR.Fields.Broadcast properties=null, XBMCRPC.List.Limits limits=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetBroadcastsResponse>("PVR.GetBroadcasts", jArgs);
        }

                /// <summary>
                /// Retrieves the details of a specific channel
                /// </summary>
                /// <param name="channelid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>XBMCRPC.PVR.GetChannelDetailsResponse</returns>
        public async Task<XBMCRPC.PVR.GetChannelDetailsResponse> GetChannelDetails(int? channelid=null, XBMCRPC.PVR.Fields.Channel properties=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetChannelDetailsResponse>("PVR.GetChannelDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the details of a specific channel group
                /// </summary>
                /// <param name="channelgroupid"> REQUIRED </param>
                /// <param name="channels"> </param>
                /// <returns>XBMCRPC.PVR.GetChannelGroupDetailsResponse</returns>
        public async Task<XBMCRPC.PVR.GetChannelGroupDetailsResponse> GetChannelGroupDetails(int? channelgroupid=null, XBMCRPC.PVR.GetChannelGroupDetails_channels channels=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetChannelGroupDetailsResponse>("PVR.GetChannelGroupDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the details of a specific channel group
                /// </summary>
                /// <param name="channelgroupid"> REQUIRED </param>
                /// <param name="channels"> </param>
                /// <returns>XBMCRPC.PVR.GetChannelGroupDetailsResponse</returns>
        public async Task<XBMCRPC.PVR.GetChannelGroupDetailsResponse> GetChannelGroupDetails(XBMCRPC.PVR.ChannelGroup.Id1? channelgroupid=null, XBMCRPC.PVR.GetChannelGroupDetails_channels channels=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetChannelGroupDetailsResponse>("PVR.GetChannelGroupDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the details of a specific channel group
                /// </summary>
                /// <param name="channels"> </param>
                /// <returns>XBMCRPC.PVR.GetChannelGroupDetailsResponse</returns>
        public async Task<XBMCRPC.PVR.GetChannelGroupDetailsResponse> GetChannelGroupDetails(XBMCRPC.PVR.GetChannelGroupDetails_channels channels=null)
        {
             var jArgs = new JObject();

             if (channels != null)
             {
                 var jpropchannels = JToken.FromObject(channels, _client.Serializer);
                 jArgs.Add(new JProperty("channels", jpropchannels));
             }
            return await _client.GetData<XBMCRPC.PVR.GetChannelGroupDetailsResponse>("PVR.GetChannelGroupDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the channel groups for the specified type
                /// </summary>
                /// <param name="channeltype"> REQUIRED </param>
                /// <param name="limits"> </param>
                /// <returns>XBMCRPC.PVR.GetChannelGroupsResponse</returns>
        public async Task<XBMCRPC.PVR.GetChannelGroupsResponse> GetChannelGroups(XBMCRPC.PVR.Channel.Type? channeltype=null, XBMCRPC.List.Limits limits=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetChannelGroupsResponse>("PVR.GetChannelGroups", jArgs);
        }

                /// <summary>
                /// Retrieves the channel list
                /// </summary>
                /// <param name="channelgroupid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>XBMCRPC.PVR.GetChannelsResponse</returns>
        public async Task<XBMCRPC.PVR.GetChannelsResponse> GetChannels(int? channelgroupid=null, XBMCRPC.PVR.Fields.Channel properties=null, XBMCRPC.List.Limits limits=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetChannelsResponse>("PVR.GetChannels", jArgs);
        }

                /// <summary>
                /// Retrieves the channel list
                /// </summary>
                /// <param name="channelgroupid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>XBMCRPC.PVR.GetChannelsResponse</returns>
        public async Task<XBMCRPC.PVR.GetChannelsResponse> GetChannels(XBMCRPC.PVR.ChannelGroup.Id1? channelgroupid=null, XBMCRPC.PVR.Fields.Channel properties=null, XBMCRPC.List.Limits limits=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetChannelsResponse>("PVR.GetChannels", jArgs);
        }

                /// <summary>
                /// Retrieves the channel list
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>XBMCRPC.PVR.GetChannelsResponse</returns>
        public async Task<XBMCRPC.PVR.GetChannelsResponse> GetChannels(XBMCRPC.PVR.Fields.Channel properties=null, XBMCRPC.List.Limits limits=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetChannelsResponse>("PVR.GetChannels", jArgs);
        }

                /// <summary>
                /// Retrieves the values of the given properties
                /// </summary>
                /// <param name="properties"> REQUIRED </param>
                /// <returns>XBMCRPC.PVR.Property.Value</returns>
        public async Task<XBMCRPC.PVR.Property.Value> GetProperties(XBMCRPC.PVR.GetProperties_properties properties=null)
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
            return await _client.GetData<XBMCRPC.PVR.Property.Value>("PVR.GetProperties", jArgs);
        }

                /// <summary>
                /// Retrieves the details of a specific recording
                /// </summary>
                /// <param name="recordingid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>XBMCRPC.PVR.GetRecordingDetailsResponse</returns>
        public async Task<XBMCRPC.PVR.GetRecordingDetailsResponse> GetRecordingDetails(int? recordingid=null, XBMCRPC.PVR.Fields.Recording properties=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetRecordingDetailsResponse>("PVR.GetRecordingDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the recordings
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>XBMCRPC.PVR.GetRecordingsResponse</returns>
        public async Task<XBMCRPC.PVR.GetRecordingsResponse> GetRecordings(XBMCRPC.PVR.Fields.Recording properties=null, XBMCRPC.List.Limits limits=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetRecordingsResponse>("PVR.GetRecordings", jArgs);
        }

                /// <summary>
                /// Retrieves the details of a specific timer
                /// </summary>
                /// <param name="timerid"> REQUIRED </param>
                /// <param name="properties"> </param>
                /// <returns>XBMCRPC.PVR.GetTimerDetailsResponse</returns>
        public async Task<XBMCRPC.PVR.GetTimerDetailsResponse> GetTimerDetails(int? timerid=null, XBMCRPC.PVR.Fields.Timer properties=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetTimerDetailsResponse>("PVR.GetTimerDetails", jArgs);
        }

                /// <summary>
                /// Retrieves the timers
                /// </summary>
                /// <param name="properties"> </param>
                /// <param name="limits"> </param>
                /// <returns>XBMCRPC.PVR.GetTimersResponse</returns>
        public async Task<XBMCRPC.PVR.GetTimersResponse> GetTimers(XBMCRPC.PVR.Fields.Timer properties=null, XBMCRPC.List.Limits limits=null)
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
            return await _client.GetData<XBMCRPC.PVR.GetTimersResponse>("PVR.GetTimers", jArgs);
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
        public async Task<string> Record(XBMCRPC.Global.Toggle2? record=null, object channel=null)
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
