using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Settings
{
   public class GetSectionsResponse
   {
       public global::System.Collections.Generic.List<KODIRPC.Setting.Details.Section> sections { get; set; }
    }
}
