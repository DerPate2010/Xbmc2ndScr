using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.List.Filter
{
   public enum Operators
   {
       contains,
       doesnotcontain,
       [global::System.Runtime.Serialization.EnumMember(Value="is")]
       Is,
       isnot,
       startswith,
       endswith,
       greaterthan,
       lessthan,
       after,
       before,
       inthelast,
       notinthelast,
       [global::System.Runtime.Serialization.EnumMember(Value="true")]
       True,
       [global::System.Runtime.Serialization.EnumMember(Value="false")]
       False,
       between,
   }
}
