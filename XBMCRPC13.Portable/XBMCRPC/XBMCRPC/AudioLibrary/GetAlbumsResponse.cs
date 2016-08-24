using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.AudioLibrary
{
   public class GetAlbumsResponse
   {
       public global::System.Collections.Generic.List<XBMCRPC.Audio.Details.Album> albums { get; set; }
       public XBMCRPC.List.LimitsReturned limits { get; set; }
    }
}
