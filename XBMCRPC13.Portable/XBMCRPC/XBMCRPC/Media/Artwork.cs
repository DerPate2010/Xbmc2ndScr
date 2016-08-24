using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Media
{
   public class Artwork
   {
       public string banner { get; set; }
       public string fanart { get; set; }
       public string poster { get; set; }
       public string thumb { get; set; }
   public class Set
   {
       public object banner { get; set; }
       public object fanart { get; set; }
       public object poster { get; set; }
       public object thumb { get; set; }
    }
    }
}
