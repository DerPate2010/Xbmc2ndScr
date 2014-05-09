namespace XBMCRPC.List.Filter
{
   public class Songs1 : XBMCRPC.List.Filter.Songs
   {
       public XBMCRPC.List.Filter.Songs[] and {get;set;}
   }
   public class Songs2 : XBMCRPC.List.Filter.Songs
   {
       public XBMCRPC.List.Filter.Songs[] or {get;set;}
   }
   public class Songs3 : XBMCRPC.List.Filter.Rule.Songs, List.Filter.Songs
   {
   }
   public interface Songs
   {
   }
}
