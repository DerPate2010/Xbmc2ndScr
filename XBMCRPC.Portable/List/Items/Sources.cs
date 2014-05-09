using System.Collections.Generic;
namespace XBMCRPC.List.Items
{
   public class SourcesItem:XBMCRPC.Item.Details.Base
   {
       public string file {get;set;}
   }
   public class Sources : List<SourcesItem>
   {
   }
}
