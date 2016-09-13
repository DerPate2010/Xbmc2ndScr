using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Textures
{
   public class GetTexturesResponse
   {
       public global::System.Collections.Generic.List<KODIRPC.Textures.Details.Texture> textures { get; set; }
    }
}
