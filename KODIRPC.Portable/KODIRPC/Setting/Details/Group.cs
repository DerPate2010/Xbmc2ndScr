using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Setting.Details
{
   public class Group
   {
       public string id { get; set; }
       public global::System.Collections.Generic.List<object> settings { get; set; }
    }
}
