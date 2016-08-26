using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Audio.Details
{
   public class Album : KODIRPC.Audio.Details.Media
   {
       public int albumid { get; set; }
       public string albumlabel { get; set; }
       public bool compilation { get; set; }
       public string description { get; set; }
       public global::System.Collections.Generic.List<string> mood { get; set; }
       public int playcount { get; set; }
       public KODIRPC.Audio.Album.ReleaseType releasetype { get; set; }
       public global::System.Collections.Generic.List<string> style { get; set; }
       public global::System.Collections.Generic.List<string> theme { get; set; }
       public string type { get; set; }
    }
}
