using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.PVR.Details
{
   public class Timer_weekdays : global::System.Collections.Generic.List<KODIRPC.Global.Weekday>
   {
         public static Timer_weekdays AllFields()
         {
             var items = Enum.GetValues(typeof (KODIRPC.Global.Weekday));
             var list = new Timer_weekdays();
             list.AddRange(items.Cast<KODIRPC.Global.Weekday>());
             return list;
         }
   }
}
