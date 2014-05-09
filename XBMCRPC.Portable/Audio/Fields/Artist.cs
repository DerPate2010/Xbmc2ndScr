using System;
using System.Collections.Generic;
using System.Linq;
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
