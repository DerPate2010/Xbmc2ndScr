using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Input
{
   public class OnInputRequested_data
   {
       public string title { get; set; }
       public string type { get; set; }
       public string value { get; set; }
    }
}
