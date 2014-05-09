namespace XBMCRPC.Player.Audio
{
   public class Stream
   {
       public int index {get;set;}
       public string language {get;set;}
       public string name {get;set;}
   public class Extended : XBMCRPC.Player.Audio.Stream
   {
       public int bitrate {get;set;}
       public int channels {get;set;}
       public string codec {get;set;}
   }
    }
}
