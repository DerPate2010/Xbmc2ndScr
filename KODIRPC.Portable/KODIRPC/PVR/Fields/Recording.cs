using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.PVR.Fields
{
   public enum RecordingItem
   {
       title,
       plot,
       plotoutline,
       genre,
       playcount,
       resume,
       channel,
       starttime,
       endtime,
       runtime,
       lifetime,
       icon,
       art,
       streamurl,
       file,
       directory,
   }
   public class Recording : List<RecordingItem>
   {
         public static Recording AllFields()
         {
             var items = Enum.GetValues(typeof (RecordingItem));
             var list = new Recording();
             list.AddRange(items.Cast<RecordingItem>());
             return list;
         }
   }
}
