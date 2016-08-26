using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Setting.Details
{
   public class ControlList : KODIRPC.Setting.Details.ControlHeading
   {
       public bool multiselect { get; set; }
       public KODIRPC.Setting.Details.ControlList_type type { get; set; }
    }
}
