using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Video.Details
{
   public class MovieSet : KODIRPC.Video.Details.Media
   {
       public string plot { get; set; }
       public int setid { get; set; }
   public class Extended : KODIRPC.Video.Details.MovieSet
   {
       public KODIRPC.List.LimitsReturned limits { get; set; }
       public global::System.Collections.Generic.List<KODIRPC.Video.Details.Movie> movies { get; set; }
    }
    }
}
