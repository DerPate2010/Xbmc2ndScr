using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Files
{
   public class GetFileDetailsResponse
   {
       public KODIRPC.List.Item.File filedetails { get; set; }
    }
}
