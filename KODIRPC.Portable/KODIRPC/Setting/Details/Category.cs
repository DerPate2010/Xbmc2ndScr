using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Setting.Details
{
   public class Category : KODIRPC.Setting.Details.Base
   {
       public global::System.Collections.Generic.List<KODIRPC.Setting.Details.Group> groups { get; set; }
    }
}
