using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Setting.Details
{
   public class ControlSlider : KODIRPC.Setting.Details.ControlHeading
   {
       public string formatlabel { get; set; }
       public bool popup { get; set; }
       public KODIRPC.Setting.Details.ControlSlider_type type { get; set; }
    }
}
