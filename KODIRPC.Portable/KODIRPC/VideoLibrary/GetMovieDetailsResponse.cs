using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.VideoLibrary
{
   public class GetMovieDetailsResponse
   {
       public KODIRPC.Video.Details.Movie moviedetails { get; set; }
    }
}
