using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.List.Filter.Fields
{
   public enum Songs
   {
       genre,
       album,
       artist,
       albumartist,
       title,
       year,
       time,
       tracknumber,
       filename,
       path,
       playcount,
       lastplayed,
       rating,
       comment,
       moods,
       playlist,
       virtualfolder,
   }
}
