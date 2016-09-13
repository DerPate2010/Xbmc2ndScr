using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Video.Details
{
   public class Episode : KODIRPC.Video.Details.File
   {
       public global::System.Collections.Generic.List<KODIRPC.Video.CastItem> cast { get; set; }
       public int episode { get; set; }
       public int episodeid { get; set; }
       public string firstaired { get; set; }
       public string originaltitle { get; set; }
       public string productioncode { get; set; }
       public double rating { get; set; }
       public int season { get; set; }
       public int seasonid { get; set; }
       public string showtitle { get; set; }
       public int specialsortepisode { get; set; }
       public int specialsortseason { get; set; }
       public int tvshowid { get; set; }
       public KODIRPC.Video.Details.Episode_uniqueid uniqueid { get; set; }
       public int userrating { get; set; }
       public string votes { get; set; }
       public global::System.Collections.Generic.List<string> writer { get; set; }
    }
}
