using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Video.Details
{
   public class Base : KODIRPC.Media.Details.Base
   {
       public KODIRPC.Media.Artwork art { get; set; }
       public int playcount { get; set; }
    }
}
