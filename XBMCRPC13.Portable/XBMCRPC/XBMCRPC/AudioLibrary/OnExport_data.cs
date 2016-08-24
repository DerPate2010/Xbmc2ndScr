using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.AudioLibrary
{
   public class OnExport_data
   {
       public int failcount { get; set; }
       public string file { get; set; }
    }
}
