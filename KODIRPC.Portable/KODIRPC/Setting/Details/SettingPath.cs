using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Setting.Details
{
   public class SettingPath : KODIRPC.Setting.Details.SettingString
   {
       public global::System.Collections.Generic.List<string> sources { get; set; }
       public bool writable { get; set; }
    }
}
