namespace XBMCRPC.List.Filter
{
   public class Albums1 : XBMCRPC.List.Filter.Albums
   {
       public XBMCRPC.List.Filter.Albums[] and {get;set;}
   }
   public class Albums2 : XBMCRPC.List.Filter.Albums
   {
       public XBMCRPC.List.Filter.Albums[] or {get;set;}
   }
   public class Albums3 : XBMCRPC.List.Filter.Rule.Albums, List.Filter.Albums
   {
   }
   public interface Albums
   {
   }
}
