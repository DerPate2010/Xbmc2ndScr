using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.PVR
{
   public class GetBroadcastDetailsResponse
   {
       public XBMCRPC.PVR.Details.Broadcast broadcastdetails { get; set; }
    }
}
