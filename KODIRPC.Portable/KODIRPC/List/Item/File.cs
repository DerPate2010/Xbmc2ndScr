using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.List.Item
{
   public class File : KODIRPC.List.Item.Base
   {
       public string file { get; set; }
       public KODIRPC.List.Item.File_filetype filetype { get; set; }
       public string lastmodified { get; set; }
       public string mimetype { get; set; }
       public int size { get; set; }
    }
}
