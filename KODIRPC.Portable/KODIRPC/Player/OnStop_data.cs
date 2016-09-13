using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Player
{
   public class OnStop_data
   {
       public bool end { get; set; }
       public object item { get; set; }
    }
}
