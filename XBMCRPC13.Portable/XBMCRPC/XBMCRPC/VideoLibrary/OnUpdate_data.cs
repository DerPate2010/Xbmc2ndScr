using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.VideoLibrary
{
   public class OnUpdate_data
   {
       public int id { get; set; }
       public int playcount { get; set; }
       public bool transaction { get; set; }
       public string type { get; set; }
    }
}
