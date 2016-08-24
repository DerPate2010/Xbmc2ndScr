using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.GUI.Stereoscopy
{
   public class Mode
   {
       public string label { get; set; }
       public XBMCRPC.GUI.Stereoscopy.Mode_mode mode { get; set; }
    }
}
