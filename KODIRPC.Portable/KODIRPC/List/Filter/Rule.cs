using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.List.Filter
{
   public class Rule
   {
       [Newtonsoft.Json.JsonProperty("operator")]
       public KODIRPC.List.Filter.Operators Operator { get; set; }
       public object value { get; set; }
   public class Albums : KODIRPC.List.Filter.Rule
   {
       public KODIRPC.List.Filter.Fields.Albums field { get; set; }
    }
   public class Artists : KODIRPC.List.Filter.Rule
   {
       public KODIRPC.List.Filter.Fields.Artists field { get; set; }
    }
   public class Episodes : KODIRPC.List.Filter.Rule
   {
       public KODIRPC.List.Filter.Fields.Episodes field { get; set; }
    }
   public class Movies : KODIRPC.List.Filter.Rule
   {
       public KODIRPC.List.Filter.Fields.Movies field { get; set; }
    }
   public class MusicVideos : KODIRPC.List.Filter.Rule
   {
       public KODIRPC.List.Filter.Fields.MusicVideos field { get; set; }
    }
   public class Songs : KODIRPC.List.Filter.Rule
   {
       public KODIRPC.List.Filter.Fields.Songs field { get; set; }
    }
   public class TVShows : KODIRPC.List.Filter.Rule
   {
       public KODIRPC.List.Filter.Fields.TVShows field { get; set; }
    }
   public class Textures : KODIRPC.List.Filter.Rule
   {
       public KODIRPC.List.Filter.Fields.Textures field { get; set; }
    }
    }
}
