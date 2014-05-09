namespace XBMCRPC.List
{
   public class Sort
   {
       public bool ignorearticle {get;set;}
   public enum methodEnum
   {
       none,
       label,
       date,
       size,
       file,
       path,
       drivetype,
       title,
       track,
       time,
       artist,
       album,
       albumtype,
       genre,
       country,
       year,
       rating,
       votes,
       top250,
       programcount,
       playlist,
       episode,
       season,
       totalepisodes,
       watchedepisodes,
       tvshowstatus,
       tvshowtitle,
       sorttitle,
       productioncode,
       mpaa,
       studio,
       dateadded,
       lastplayed,
       playcount,
       listeners,
       bitrate,
       random,
   }
       public methodEnum method {get;set;}
   public enum orderEnum
   {
       ascending,
       descending,
   }
       public orderEnum order {get;set;}
   }
}
