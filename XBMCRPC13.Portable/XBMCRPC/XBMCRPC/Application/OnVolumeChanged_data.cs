using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Application
{
   public class OnVolumeChanged_data
   {
       public bool muted { get; set; }
       public int volume { get; set; }
    }
}
