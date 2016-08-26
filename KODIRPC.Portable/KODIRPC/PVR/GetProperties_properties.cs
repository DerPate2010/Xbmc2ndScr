using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.PVR
{
   public class GetProperties_properties : global::System.Collections.Generic.List<KODIRPC.PVR.Property.Name>
   {
         public static GetProperties_properties AllFields()
         {
             var items = Enum.GetValues(typeof (KODIRPC.PVR.Property.Name));
             var list = new GetProperties_properties();
             list.AddRange(items.Cast<KODIRPC.PVR.Property.Name>());
             return list;
         }
   }
}
