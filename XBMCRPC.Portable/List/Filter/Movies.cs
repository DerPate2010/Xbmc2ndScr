namespace XBMCRPC.List.Filter
{
   public class Movies1 : XBMCRPC.List.Filter.Movies
   {
       public XBMCRPC.List.Filter.Movies[] and {get;set;}
   }
   public class Movies2 : XBMCRPC.List.Filter.Movies
   {
       public XBMCRPC.List.Filter.Movies[] or {get;set;}
   }
   public class Movies3 : XBMCRPC.List.Filter.Rule.Movies, List.Filter.Movies
   {
   }
   public interface Movies
   {
   }
}
