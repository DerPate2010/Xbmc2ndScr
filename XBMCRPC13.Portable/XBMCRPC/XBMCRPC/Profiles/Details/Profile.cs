using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Profiles.Details
{
   public class Profile : XBMCRPC.Item.Details.Base
   {
       public int lockmode { get; set; }
       public string thumbnail { get; set; }
    }
}
