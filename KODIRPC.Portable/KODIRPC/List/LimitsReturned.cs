using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.List
{
   public class LimitsReturned
   {
       public int end { get; set; }
       public int start { get; set; }
       public int total { get; set; }
    }
}
