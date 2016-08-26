using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Files
{
   public class GetSourcesResponse
   {
       public KODIRPC.List.LimitsReturned limits { get; set; }
       public global::System.Collections.Generic.List<KODIRPC.List.Items.SourcesItem> sources { get; set; }
    }
}
