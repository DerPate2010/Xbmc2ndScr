namespace XBMCRPC.List.Filter
{
   public class Artists1 : XBMCRPC.List.Filter.Artists
   {
       public XBMCRPC.List.Filter.Artists[] and {get;set;}
   }
   public class Artists2 : XBMCRPC.List.Filter.Artists
   {
       public XBMCRPC.List.Filter.Artists[] or {get;set;}
   }
   public class Artists3 : XBMCRPC.List.Filter.Rule.Artists, List.Filter.Artists
   {
   }
   public interface Artists
   {
   }
}
