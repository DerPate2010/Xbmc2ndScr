namespace XBMCRPC.List.Filter
{
   public class Episodes1 : XBMCRPC.List.Filter.Episodes
   {
       public XBMCRPC.List.Filter.Episodes[] and {get;set;}
   }
   public class Episodes2 : XBMCRPC.List.Filter.Episodes
   {
       public XBMCRPC.List.Filter.Episodes[] or {get;set;}
   }
   public class Episodes3 : XBMCRPC.List.Filter.Rule.Episodes, List.Filter.Episodes
   {
   }
   public interface Episodes
   {
   }
}
