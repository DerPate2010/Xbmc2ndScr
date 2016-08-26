using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.PVR.Details
{
   public class ChannelGroup : KODIRPC.Item.Details.Base
   {
       public int channelgroupid { get; set; }
       public KODIRPC.PVR.Channel.Type channeltype { get; set; }
   public class Extended : KODIRPC.PVR.Details.ChannelGroup
   {
       public global::System.Collections.Generic.List<KODIRPC.PVR.Details.Channel> channels { get; set; }
       public KODIRPC.List.LimitsReturned limits { get; set; }
    }
    }
}
