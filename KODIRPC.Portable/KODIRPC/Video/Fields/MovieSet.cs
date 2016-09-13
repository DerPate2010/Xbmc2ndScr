using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Video.Fields
{
   public enum MovieSetItem
   {
       title,
       playcount,
       fanart,
       thumbnail,
       art,
       plot,
   }
   public class MovieSet : List<MovieSetItem>
   {
         public static MovieSet AllFields()
         {
             var items = Enum.GetValues(typeof (MovieSetItem));
             var list = new MovieSet();
             list.AddRange(items.Cast<MovieSetItem>());
             return list;
         }
   }
}
