using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Application.Property
{
   public class Value
   {
       public bool muted { get; set; }
       public string name { get; set; }
       public KODIRPC.Application.Property.Value_version version { get; set; }
       public int volume { get; set; }
    }
}
