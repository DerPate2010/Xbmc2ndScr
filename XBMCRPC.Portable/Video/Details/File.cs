namespace XBMCRPC.Video.Details
{
   public class File : XBMCRPC.Video.Details.Item
   {
       public string[] director {get;set;}
       public XBMCRPC.Video.Resume resume {get;set;}
       public int runtime {get;set;}
       public XBMCRPC.Video.Streams streamdetails {get;set;}
   }
}
