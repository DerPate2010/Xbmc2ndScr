using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.PVR.Fields
{
   public enum BroadcastItem
   {
       title,
       plot,
       plotoutline,
       starttime,
       endtime,
       runtime,
       progress,
       progresspercentage,
       genre,
       episodename,
       episodenum,
       episodepart,
       firstaired,
       hastimer,
       isactive,
       parentalrating,
       wasactive,
       thumbnail,
       rating,
   }
   public class Broadcast : List<BroadcastItem>
   {
         public static Broadcast AllFields()
         {
             var items = Enum.GetValues(typeof (BroadcastItem));
             var list = new Broadcast();
             list.AddRange(items.Cast<BroadcastItem>());
             return list;
         }
   }
}
