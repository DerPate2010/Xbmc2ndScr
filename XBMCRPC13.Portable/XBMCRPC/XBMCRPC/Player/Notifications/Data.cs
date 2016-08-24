using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Player.Notifications
{
   public class Data
   {
       public object item { get; set; }
       public XBMCRPC.Player.Notifications.Player player { get; set; }
    }
}
