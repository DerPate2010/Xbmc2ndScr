using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.VideoLibrary
{
   public class GetMovieSetDetails_movies
   {
       public KODIRPC.List.Limits limits { get; set; }
       public KODIRPC.Video.Fields.Movie properties { get; set; }
       public KODIRPC.List.Sort sort { get; set; }
    }
}
