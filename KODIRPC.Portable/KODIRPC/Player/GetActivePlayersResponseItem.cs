using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Player
{
   public class GetActivePlayersResponseItem
   {
       public int playerid { get; set; }
       public KODIRPC.Player.Type type { get; set; }
    }
}
