using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.VideoLibrary
{
   public class Export_options1
   {
       public bool actorthumbs { get; set; }
       public bool images { get; set; }
       public bool overwrite { get; set; }
    }
}
