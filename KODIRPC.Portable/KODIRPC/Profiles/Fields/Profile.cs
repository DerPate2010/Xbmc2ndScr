using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Profiles.Fields
{
   public enum ProfileItem
   {
       thumbnail,
       lockmode,
   }
   public class Profile : List<ProfileItem>
   {
         public static Profile AllFields()
         {
             var items = Enum.GetValues(typeof (ProfileItem));
             var list = new Profile();
             list.AddRange(items.Cast<ProfileItem>());
             return list;
         }
   }
}
