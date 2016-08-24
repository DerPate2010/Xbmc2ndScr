using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Playlist
{
   public class GetPlaylistsResponseItem
   {
       public int playlistid { get; set; }
       public XBMCRPC.Playlist.Type type { get; set; }
    }
}
