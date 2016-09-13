using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Favourite.Details
{
   public class Favourite
   {
       public string path { get; set; }
       public string thumbnail { get; set; }
       public string title { get; set; }
       public KODIRPC.Favourite.Type type { get; set; }
       public string window { get; set; }
       public string windowparameter { get; set; }
    }
}
