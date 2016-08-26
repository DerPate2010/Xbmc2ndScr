using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Setting.Details
{
   public class ControlSpinner : KODIRPC.Setting.Details.ControlBase
   {
       public string formatlabel { get; set; }
       public string minimumlabel { get; set; }
       public KODIRPC.Setting.Details.ControlSpinner_type type { get; set; }
    }
}
