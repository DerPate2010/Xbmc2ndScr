using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Textures.Details
{
   public class Size
   {
       public int height { get; set; }
       public string lastused { get; set; }
       public int size { get; set; }
       public int usecount { get; set; }
       public int width { get; set; }
    }
}
