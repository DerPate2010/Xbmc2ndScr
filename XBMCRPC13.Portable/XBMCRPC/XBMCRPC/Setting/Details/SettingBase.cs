using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Setting.Details
{
   public class SettingBase : XBMCRPC.Setting.Details.Base
   {
       public object control { get; set; }
       public bool enabled { get; set; }
       public XBMCRPC.Setting.Level level { get; set; }
       public string parent { get; set; }
       public XBMCRPC.Setting.Type type { get; set; }
    }
}
