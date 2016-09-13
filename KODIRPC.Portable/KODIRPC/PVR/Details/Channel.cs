using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.PVR.Details
{
   public class Channel : KODIRPC.Item.Details.Base
   {
       public KODIRPC.PVR.Details.Broadcast broadcastnext { get; set; }
       public KODIRPC.PVR.Details.Broadcast broadcastnow { get; set; }
       public string channel { get; set; }
       public int channelid { get; set; }
       public KODIRPC.PVR.Channel.Type channeltype { get; set; }
       public bool hidden { get; set; }
       public string lastplayed { get; set; }
       public bool locked { get; set; }
       public string thumbnail { get; set; }
    }
}
