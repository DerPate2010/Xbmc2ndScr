using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.List.Item
{
   public enum Base_type
   {
       unknown,
       movie,
       episode,
       musicvideo,
       song,
       picture,
       channel,
   }
}
