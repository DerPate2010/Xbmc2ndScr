using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Setting.Details
{
   public class SettingString : KODIRPC.Setting.Details.SettingBase
   {
       public bool allowempty { get; set; }
       [Newtonsoft.Json.JsonProperty("default")]
       public string Default { get; set; }
       public global::System.Collections.Generic.List<KODIRPC.Setting.Details.SettingString_optionsItem> options { get; set; }
       public string value { get; set; }
    }
}
