using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.AudioLibrary
{
   public class GetGenresResponse
   {
       public global::System.Collections.Generic.List<KODIRPC.Library.Details.Genre> genres { get; set; }
       public KODIRPC.List.LimitsReturned limits { get; set; }
    }
}
