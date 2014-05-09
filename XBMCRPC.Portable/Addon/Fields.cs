using System;
using System.Collections.Generic;
using System.Linq;
namespace XBMCRPC.Addon
{
   public enum FieldsItem
   {
       name,
       version,
       summary,
       description,
       path,
       author,
       thumbnail,
       disclaimer,
       fanart,
       dependencies,
       broken,
       extrainfo,
       rating,
       enabled,
   }
   public class Fields : List<FieldsItem>
   {
         public static Fields AllFields()
         {
             var items = Enum.GetValues(typeof (FieldsItem));
             var list = new Fields();
             list.AddRange(items.Cast<FieldsItem>());
             return list;
         }
   }
}
