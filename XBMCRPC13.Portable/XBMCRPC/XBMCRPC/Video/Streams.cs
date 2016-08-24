using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Video
{
   public class Streams
   {
       public global::System.Collections.Generic.List<XBMCRPC.Video.Streams_audioItem> audio { get; set; }
       public global::System.Collections.Generic.List<XBMCRPC.Video.Streams_subtitleItem> subtitle { get; set; }
       public global::System.Collections.Generic.List<XBMCRPC.Video.Streams_videoItem> video { get; set; }
    }
}
