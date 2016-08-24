using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.PVR
{
   public class GetChannelsResponse
   {
       public global::System.Collections.Generic.List<XBMCRPC.PVR.Details.Channel> channels { get; set; }
       public XBMCRPC.List.LimitsReturned limits { get; set; }
    }
}
