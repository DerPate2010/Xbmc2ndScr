using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.GUI
{
   public class GetStereoscopicModesResponse
   {
       public global::System.Collections.Generic.List<KODIRPC.GUI.Stereoscopy.Mode> stereoscopicmodes { get; set; }
    }
}
