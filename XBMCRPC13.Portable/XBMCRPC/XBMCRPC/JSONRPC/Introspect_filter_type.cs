using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.JSONRPC
{
   public enum Introspect_filter_type
   {
       method,
       [global::System.Runtime.Serialization.EnumMember(Value="namespace")]
       Namespace,
       type,
       notification,
   }
}
