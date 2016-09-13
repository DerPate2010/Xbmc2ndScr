using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Player
{
   public class OnPropertyChanged_data
   {
       public KODIRPC.Player.Notifications.Player player { get; set; }
       public KODIRPC.Player.Property.Value property { get; set; }
    }
}
