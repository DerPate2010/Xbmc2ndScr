using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
namespace XBMCRPC.AudioLibrary
{
   public class GetRecentlyPlayedAlbumsResponse
   {
       public global::System.Collections.Generic.List<XBMCRPC.Audio.Details.Album> albums { get; set; }
       public XBMCRPC.List.LimitsReturned limits { get; set; }
    }
}
