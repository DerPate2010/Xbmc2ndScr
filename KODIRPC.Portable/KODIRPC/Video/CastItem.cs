using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Video
{
   public class CastItem
   {
       public string name { get; set; }
       public int order { get; set; }
       public string role { get; set; }
       public string thumbnail { get; set; }
    }
}
