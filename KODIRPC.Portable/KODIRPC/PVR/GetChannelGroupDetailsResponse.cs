using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.PVR
{
   public class GetChannelGroupDetailsResponse
   {
       public KODIRPC.PVR.Details.ChannelGroup.Extended channelgroupdetails { get; set; }
    }
}
