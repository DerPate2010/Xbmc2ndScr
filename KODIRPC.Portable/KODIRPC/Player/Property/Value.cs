using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Player.Property
{
   public class Value
   {
       public global::System.Collections.Generic.List<KODIRPC.Player.Audio.Stream> audiostreams { get; set; }
       public bool canchangespeed { get; set; }
       public bool canmove { get; set; }
       public bool canrepeat { get; set; }
       public bool canrotate { get; set; }
       public bool canseek { get; set; }
       public bool canshuffle { get; set; }
       public bool canzoom { get; set; }
       public KODIRPC.Player.Audio.Stream currentaudiostream { get; set; }
       public KODIRPC.Player.Subtitle currentsubtitle { get; set; }
       public bool live { get; set; }
       public bool partymode { get; set; }
       public double percentage { get; set; }
       public int playlistid { get; set; }
       public int position { get; set; }
       public KODIRPC.Player.Repeat repeat { get; set; }
       public bool shuffled { get; set; }
       public int speed { get; set; }
       public bool subtitleenabled { get; set; }
       public global::System.Collections.Generic.List<KODIRPC.Player.Subtitle> subtitles { get; set; }
       public KODIRPC.Global.Time time { get; set; }
       public KODIRPC.Global.Time totaltime { get; set; }
       public KODIRPC.Player.Type type { get; set; }
    }
}
