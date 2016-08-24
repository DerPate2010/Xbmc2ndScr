using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.VideoLibrary
{
   public class GetMovieSetDetails_movies
   {
       public XBMCRPC.List.Limits limits { get; set; }
       public XBMCRPC.Video.Fields.Movie properties { get; set; }
       public XBMCRPC.List.Sort sort { get; set; }
    }
}
