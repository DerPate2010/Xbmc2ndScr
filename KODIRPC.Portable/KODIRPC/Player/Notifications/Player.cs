using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Player.Notifications
{
   public class Player
   {
       public int playerid { get; set; }
       public int speed { get; set; }
   public class Seek : KODIRPC.Player.Notifications.Player
   {
       public KODIRPC.Global.Time seekoffset { get; set; }
       public KODIRPC.Global.Time time { get; set; }
    }
    }
}
