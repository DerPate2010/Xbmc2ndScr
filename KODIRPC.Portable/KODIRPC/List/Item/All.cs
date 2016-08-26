using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.List.Item
{
   public class All : KODIRPC.List.Item.Base
   {
       public string channel { get; set; }
       public int channelnumber { get; set; }
       public KODIRPC.PVR.Channel.Type channeltype { get; set; }
       public string endtime { get; set; }
       public bool hidden { get; set; }
       public bool locked { get; set; }
       public string starttime { get; set; }
    }
}
