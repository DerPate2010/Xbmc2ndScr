using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
namespace XBMCRPC.VideoLibrary
{
   public class GetRecentlyAddedMoviesResponse
   {
       public XBMCRPC.List.LimitsReturned limits { get; set; }
       public global::System.Collections.Generic.List<XBMCRPC.Video.Details.Movie> movies { get; set; }
    }
}
