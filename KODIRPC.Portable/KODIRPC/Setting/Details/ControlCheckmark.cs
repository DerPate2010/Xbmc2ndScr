using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Setting.Details
{
   public class ControlCheckmark : KODIRPC.Setting.Details.ControlBase
   {
       public KODIRPC.Setting.Details.ControlCheckmark_format format { get; set; }
       public KODIRPC.Setting.Details.ControlCheckmark_type type { get; set; }
    }
}
