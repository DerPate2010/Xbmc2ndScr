using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Notifications
{
   public class Item4
   {
       public string album { get; set; }
       public string artist { get; set; }
       public string title { get; set; }
       public XBMCRPC.Notifications.Item.Type type { get; set; }
    }
}
