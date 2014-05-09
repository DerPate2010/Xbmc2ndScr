using System;
using System.Collections.Generic;
using System.Linq;
namespace XBMCRPC.PVR.Fields
{
   public enum ChannelItem
   {
       thumbnail,
       channeltype,
       hidden,
       locked,
       channel,
       lastplayed,
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
