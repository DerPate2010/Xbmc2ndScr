using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.PVR.Fields
{
   public enum ChannelItem
   {
       thumbnail,
       channeltype,
       hidden,
       locked,
       channel,
       lastplayed,
       broadcastnow,
       broadcastnext,
   }
   public class Channel : List<ChannelItem>
   {
         public static Channel AllFields()
         {
             var items = Enum.GetValues(typeof (ChannelItem));
             var list = new Channel();
             list.AddRange(items.Cast<ChannelItem>());
             return list;
         }
   }
}
