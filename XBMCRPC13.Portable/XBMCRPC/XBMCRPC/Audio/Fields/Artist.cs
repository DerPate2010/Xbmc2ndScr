using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Audio.Fields
{
   public enum ArtistItem
   {
       instrument,
       style,
       mood,
       born,
       formed,
       description,
       genre,
       died,
       disbanded,
       yearsactive,
       musicbrainzartistid,
       fanart,
       thumbnail,
       compilationartist,
       dateadded,
   }
   public class Artist : List<ArtistItem>
   {
         public static Artist AllFields()
         {
             var items = Enum.GetValues(typeof (ArtistItem));
             var list = new Artist();
             list.AddRange(items.Cast<ArtistItem>());
             return list;
         }
   }
}
