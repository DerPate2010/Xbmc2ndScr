using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Setting.Details
{
   public class ControlEdit : KODIRPC.Setting.Details.ControlHeading
   {
       public bool hidden { get; set; }
       public KODIRPC.Setting.Details.ControlEdit_type type { get; set; }
       public bool verifynewvalue { get; set; }
    }
}
