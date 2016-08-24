using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Setting.Details
{
   public class Section : XBMCRPC.Setting.Details.Base
   {
       public global::System.Collections.Generic.List<XBMCRPC.Setting.Details.Category> categories { get; set; }
    }
}
