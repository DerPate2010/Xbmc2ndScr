using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.PVR
{
   public class GetChannelGroupsResponse
   {
       public global::System.Collections.Generic.List<KODIRPC.PVR.Details.ChannelGroup> channelgroups { get; set; }
       public KODIRPC.List.LimitsReturned limits { get; set; }
    }
}
