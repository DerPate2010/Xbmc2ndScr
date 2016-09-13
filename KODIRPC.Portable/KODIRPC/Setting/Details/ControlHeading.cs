using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Setting.Details
{
   public class ControlHeading : KODIRPC.Setting.Details.ControlBase
   {
       public string heading { get; set; }
    }
}
