using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Addons
{
   public class GetAddonsResponse
   {
       public global::System.Collections.Generic.List<XBMCRPC.Addon.Details> addons { get; set; }
       public XBMCRPC.List.LimitsReturned limits { get; set; }
    }
}
