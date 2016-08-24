using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Application.Property
{
   public enum Value_version_tag
   {
       prealpha,
       alpha,
       beta,
       releasecandidate,
       stable,
   }
}
