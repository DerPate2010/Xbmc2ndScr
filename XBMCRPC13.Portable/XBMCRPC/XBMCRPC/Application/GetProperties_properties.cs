using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Application
{
   public class GetProperties_properties : global::System.Collections.Generic.List<XBMCRPC.Application.Property.Name>
   {
         public static GetProperties_properties AllFields()
         {
             var items = Enum.GetValues(typeof (XBMCRPC.Application.Property.Name));
             var list = new GetProperties_properties();
             list.AddRange(items.Cast<XBMCRPC.Application.Property.Name>());
             return list;
         }
   }
}
