using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.System
{
   public class GetProperties_properties : global::System.Collections.Generic.List<KODIRPC.System.Property.Name>
   {
         public static GetProperties_properties AllFields()
         {
             var items = Enum.GetValues(typeof (KODIRPC.System.Property.Name));
             var list = new GetProperties_properties();
             list.AddRange(items.Cast<KODIRPC.System.Property.Name>());
             return list;
         }
   }
}
