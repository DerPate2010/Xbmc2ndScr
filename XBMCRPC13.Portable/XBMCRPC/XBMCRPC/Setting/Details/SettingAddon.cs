using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Setting.Details
{
   public class SettingAddon : XBMCRPC.Setting.Details.SettingString
   {
       public XBMCRPC.Addon.Types addontype { get; set; }
    }
}
