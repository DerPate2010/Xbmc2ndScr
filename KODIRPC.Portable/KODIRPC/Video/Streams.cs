using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Video
{
   public class Streams
   {
       public global::System.Collections.Generic.List<KODIRPC.Video.Streams_audioItem> audio { get; set; }
       public global::System.Collections.Generic.List<KODIRPC.Video.Streams_subtitleItem> subtitle { get; set; }
       public global::System.Collections.Generic.List<KODIRPC.Video.Streams_videoItem> video { get; set; }
    }
}
