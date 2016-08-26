using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.JSONRPC
{
   public class VersionResponse_version
   {
       public int major { get; set; }
       public int minor { get; set; }
       public int patch { get; set; }
    }
}
