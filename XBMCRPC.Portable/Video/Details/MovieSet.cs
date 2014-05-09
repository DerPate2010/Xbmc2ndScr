namespace XBMCRPC.Video.Details
{
   public class MovieSet : XBMCRPC.Video.Details.Media
   {
       public int setid {get;set;}
   public class Extended : XBMCRPC.Video.Details.MovieSet
   {
       public XBMCRPC.List.LimitsReturned limits {get;set;}
       public XBMCRPC.Video.Details.Movie[] movies {get;set;}
   }
    }
}
