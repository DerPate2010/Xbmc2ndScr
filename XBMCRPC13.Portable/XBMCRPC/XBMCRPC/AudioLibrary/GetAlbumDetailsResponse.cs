using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.AudioLibrary
{
   public class GetAlbumDetailsResponse
   {
       public XBMCRPC.Audio.Details.Album albumdetails { get; set; }
    }
}
