using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
namespace XBMCRPC.VideoLibrary
{
   public class GetRecentlyAddedMusicVideosResponse
   {
       public XBMCRPC.List.LimitsReturned limits { get; set; }
       public global::System.Collections.Generic.List<XBMCRPC.Video.Details.MusicVideo> musicvideos { get; set; }
    }
}
