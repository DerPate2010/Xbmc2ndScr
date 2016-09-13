using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.PVR
{
   public class GetChannelGroupDetails_channels
   {
       public KODIRPC.List.Limits limits { get; set; }
       public KODIRPC.PVR.Fields.Channel properties { get; set; }
    }
}
