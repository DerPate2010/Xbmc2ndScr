using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.List.Items
{
   public class SourcesItem : KODIRPC.Item.Details.Base
   {
       public string file { get; set; }
    }
}
