using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Files
{
   public class PrepareDownloadResponse
   {
       public object details { get; set; }
       public XBMCRPC.Files.PrepareDownloadResponse_mode mode { get; set; }
       public XBMCRPC.Files.PrepareDownloadResponse_protocol protocol { get; set; }
    }
}
