using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.AudioLibrary
{
   public class GetAlbumsResponse
   {
       public global::System.Collections.Generic.List<KODIRPC.Audio.Details.Album> albums { get; set; }
       public KODIRPC.List.LimitsReturned limits { get; set; }
    }
}
