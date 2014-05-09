namespace XBMCRPC.List.Filter
{
   public class TVShows1 : XBMCRPC.List.Filter.TVShows
   {
       public XBMCRPC.List.Filter.TVShows[] and {get;set;}
   }
   public class TVShows2 : XBMCRPC.List.Filter.TVShows
   {
       public XBMCRPC.List.Filter.TVShows[] or {get;set;}
   }
   public class TVShows3 : XBMCRPC.List.Filter.Rule.TVShows, List.Filter.TVShows
   {
   }
   public interface TVShows
   {
   }
}
