using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.GUI.Property
{
   public class Value
   {
       public KODIRPC.GUI.Property.Value_currentcontrol currentcontrol { get; set; }
       public KODIRPC.GUI.Property.Value_currentwindow currentwindow { get; set; }
       public bool fullscreen { get; set; }
       public KODIRPC.GUI.Property.Value_skin skin { get; set; }
       public KODIRPC.GUI.Stereoscopy.Mode stereoscopicmode { get; set; }
    }
}
