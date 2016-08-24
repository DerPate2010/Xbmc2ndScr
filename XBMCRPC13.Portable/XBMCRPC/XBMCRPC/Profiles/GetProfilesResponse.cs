using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Profiles
{
   public class GetProfilesResponse
   {
       public XBMCRPC.List.LimitsReturned limits { get; set; }
       public global::System.Collections.Generic.List<XBMCRPC.Profiles.Details.Profile> profiles { get; set; }
    }
}
