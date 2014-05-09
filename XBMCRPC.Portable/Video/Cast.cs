using System.Collections.Generic;
namespace XBMCRPC.Video
{
   public class CastItem
   {
       public string name {get;set;}
       public string role {get;set;}
       public string thumbnail {get;set;}
   }
   public class Cast : List<CastItem>
   {
   }
}
