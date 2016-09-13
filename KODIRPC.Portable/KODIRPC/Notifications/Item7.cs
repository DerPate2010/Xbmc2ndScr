using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Notifications
{
   public class Item7
   {
       public KODIRPC.PVR.Channel.Type channeltype { get; set; }
       public int id { get; set; }
       public string title { get; set; }
       public KODIRPC.Notifications.Item.Type type { get; set; }
    }
}
