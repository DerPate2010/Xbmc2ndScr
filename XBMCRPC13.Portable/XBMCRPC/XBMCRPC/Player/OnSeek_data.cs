using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Player
{
   public class OnSeek_data
   {
       public object item { get; set; }
       public XBMCRPC.Player.Notifications.Player.Seek player { get; set; }
    }
}
