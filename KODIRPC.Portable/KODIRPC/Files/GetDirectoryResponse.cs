using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Files
{
   public class GetDirectoryResponse
   {
       public global::System.Collections.Generic.List<KODIRPC.List.Item.File> files { get; set; }
       public KODIRPC.List.LimitsReturned limits { get; set; }
    }
}
