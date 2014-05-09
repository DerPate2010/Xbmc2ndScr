namespace XBMCRPC.Video
{
   public class Streams
   {
   public class audioItem
   {
       public int channels {get;set;}
       public string codec {get;set;}
       public string language {get;set;}
   }
       public audioItem[] audio {get;set;}
   public class subtitleItem
   {
       public string language {get;set;}
   }
       public subtitleItem[] subtitle {get;set;}
   public class videoItem
   {
       public double aspect {get;set;}
       public string codec {get;set;}
       public int duration {get;set;}
       public int height {get;set;}
       public int width {get;set;}
   }
       public videoItem[] video {get;set;}
   }
}
