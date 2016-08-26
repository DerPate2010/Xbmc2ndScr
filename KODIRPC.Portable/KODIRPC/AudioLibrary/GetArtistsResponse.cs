using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.AudioLibrary
{
   public class GetArtistsResponse
   {
       public global::System.Collections.Generic.List<KODIRPC.Audio.Details.Artist> artists { get; set; }
       public KODIRPC.List.LimitsReturned limits { get; set; }
    }
}
