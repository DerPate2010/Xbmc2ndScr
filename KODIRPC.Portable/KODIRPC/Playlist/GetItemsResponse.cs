using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Playlist
{
   public class GetItemsResponse
   {
       public global::System.Collections.Generic.List<KODIRPC.List.Item.All> items { get; set; }
       public KODIRPC.List.LimitsReturned limits { get; set; }
    }
}
