using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Player
{
   public class GetItemResponse
   {
       public XBMCRPC.List.Item.All item { get; set; }
    }
}
