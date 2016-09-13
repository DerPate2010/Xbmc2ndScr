using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Setting.Details
{
   public class SettingBase : KODIRPC.Setting.Details.Base
   {
       public object control { get; set; }
       public bool enabled { get; set; }
       public KODIRPC.Setting.Level level { get; set; }
       public string parent { get; set; }
       public KODIRPC.Setting.Type type { get; set; }
    }
}
