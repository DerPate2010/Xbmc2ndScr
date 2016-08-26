using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Video.Fields
{
   public enum TVShowItem
   {
       title,
       genre,
       year,
       rating,
       plot,
       studio,
       mpaa,
       cast,
       playcount,
       episode,
       imdbnumber,
       premiered,
       votes,
       lastplayed,
       fanart,
       thumbnail,
       file,
       originaltitle,
       sorttitle,
       episodeguide,
       season,
       watchedepisodes,
       dateadded,
       tag,
       art,
       userrating,
   }
   public class TVShow : List<TVShowItem>
   {
         public static TVShow AllFields()
         {
             var items = Enum.GetValues(typeof (TVShowItem));
             var list = new TVShow();
             list.AddRange(items.Cast<TVShowItem>());
             return list;
         }
   }
}
