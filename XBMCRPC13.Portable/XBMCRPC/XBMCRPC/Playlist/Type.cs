using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Playlist
{
   public enum Type
   {
       unknown,
       video,
       audio,
       picture,
       mixed,
   }
}
