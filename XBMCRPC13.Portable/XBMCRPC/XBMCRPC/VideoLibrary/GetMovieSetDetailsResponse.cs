using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.VideoLibrary
{
   public class GetMovieSetDetailsResponse
   {
       public XBMCRPC.Video.Details.MovieSet.Extended setdetails { get; set; }
    }
}
