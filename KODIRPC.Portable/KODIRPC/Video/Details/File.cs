using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Video.Details
{
   public class File : KODIRPC.Video.Details.Item
   {
       public global::System.Collections.Generic.List<string> director { get; set; }
       public KODIRPC.Video.Resume resume { get; set; }
       public int runtime { get; set; }
       public KODIRPC.Video.Streams streamdetails { get; set; }
    }
}
