using System;
using System.Collections.Generic;
using System.Linq;
namespace XBMCRPC.Library.Fields
{
   public enum GenreItem
   {
       title,
       thumbnail,
   }
   public class Genre : List<GenreItem>
   {
         public static Genre AllFields()
         {
             var items = Enum.GetValues(typeof (GenreItem));
             var list = new Genre();
             list.AddRange(items.Cast<GenreItem>());
             return list;
         }
   }
}
