using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.PVR.Fields
{
   public enum TimerItem
   {
       title,
       summary,
       channelid,
       isradio,
       repeating,
       starttime,
       endtime,
       runtime,
       lifetime,
       firstday,
       weekdays,
       priority,
       startmargin,
       endmargin,
       state,
       file,
       directory,
   }
   public class Timer : List<TimerItem>
   {
         public static Timer AllFields()
         {
             var items = Enum.GetValues(typeof (TimerItem));
             var list = new Timer();
             list.AddRange(items.Cast<TimerItem>());
             return list;
         }
   }
}
