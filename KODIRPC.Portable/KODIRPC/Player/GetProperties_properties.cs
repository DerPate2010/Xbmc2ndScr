using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Player
{
   public class GetProperties_properties : global::System.Collections.Generic.List<KODIRPC.Player.Property.Name>
   {
         public static GetProperties_properties AllFields()
         {
             var items = Enum.GetValues(typeof (KODIRPC.Player.Property.Name));
             var list = new GetProperties_properties();
             list.AddRange(items.Cast<KODIRPC.Player.Property.Name>());
             return list;
         }
   }
}
