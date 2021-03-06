using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.PVR
{
   public enum TimerState
   {
       unknown,
       [global::System.Runtime.Serialization.EnumMember(Value="new")]
       New,
       scheduled,
       recording,
       completed,
       aborted,
       cancelled,
       conflict_ok,
       conflict_notok,
       error,
   }
}
