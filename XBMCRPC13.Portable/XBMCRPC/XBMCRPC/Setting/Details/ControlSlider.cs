using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Setting.Details
{
   public class ControlSlider : XBMCRPC.Setting.Details.ControlHeading
   {
       public string formatlabel { get; set; }
       public bool popup { get; set; }
       public XBMCRPC.Setting.Details.ControlSlider_type type { get; set; }
    }
}
