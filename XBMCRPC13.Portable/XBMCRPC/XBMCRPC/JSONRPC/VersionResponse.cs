using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.JSONRPC
{
   public class VersionResponse
   {
       public XBMCRPC.JSONRPC.VersionResponse_version version { get; set; }
    }
}
