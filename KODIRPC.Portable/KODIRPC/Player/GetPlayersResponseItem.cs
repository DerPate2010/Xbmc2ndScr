using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Player
{
   public class GetPlayersResponseItem
   {
       public string name { get; set; }
       public int playercoreid { get; set; }
       public bool playsaudio { get; set; }
       public bool playsvideo { get; set; }
       public KODIRPC.Player.GetPlayersResponseItem_type type { get; set; }
    }
}
