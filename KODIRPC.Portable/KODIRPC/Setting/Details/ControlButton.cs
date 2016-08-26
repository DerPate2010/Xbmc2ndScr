using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Setting.Details
{
   public class ControlButton : KODIRPC.Setting.Details.ControlHeading
   {
       public KODIRPC.Setting.Details.ControlButton_type type { get; set; }
    }
}
