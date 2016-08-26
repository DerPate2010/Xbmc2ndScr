using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Playlist
{
   public class GetProperties_properties : global::System.Collections.Generic.List<KODIRPC.Playlist.Property.Name>
   {
         public static GetProperties_properties AllFields()
         {
             var items = Enum.GetValues(typeof (KODIRPC.Playlist.Property.Name));
             var list = new GetProperties_properties();
             list.AddRange(items.Cast<KODIRPC.Playlist.Property.Name>());
             return list;
         }
   }
}
