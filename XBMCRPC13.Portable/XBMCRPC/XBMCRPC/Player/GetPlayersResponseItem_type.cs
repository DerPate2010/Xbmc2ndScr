using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Player
{
   public enum GetPlayersResponseItem_type
   {
       [global::System.Runtime.Serialization.EnumMember(Value="internal")]
       Internal,
       external,
       remote,
   }
}
