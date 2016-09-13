using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Addons
{
   public class GetAddonsResponse
   {
       public global::System.Collections.Generic.List<KODIRPC.Addon.Details> addons { get; set; }
       public KODIRPC.List.LimitsReturned limits { get; set; }
    }
}
