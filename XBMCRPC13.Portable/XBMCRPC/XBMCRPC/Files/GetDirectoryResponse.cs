using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Files
{
   public class GetDirectoryResponse
   {
       public global::System.Collections.Generic.List<XBMCRPC.List.Item.File> files { get; set; }
       public XBMCRPC.List.LimitsReturned limits { get; set; }
    }
}
