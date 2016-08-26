using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Notifications
{
   public class Item3
   {
       public int episode { get; set; }
       public int season { get; set; }
       public string showtitle { get; set; }
       public string title { get; set; }
       public KODIRPC.Notifications.Item.Type type { get; set; }
    }
}
