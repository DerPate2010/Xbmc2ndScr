using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Textures
{
   public class GetTexturesResponse
   {
       public global::System.Collections.Generic.List<XBMCRPC.Textures.Details.Texture> textures { get; set; }
    }
}
