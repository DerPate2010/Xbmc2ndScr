namespace XBMCRPC.List.Filter
{
   public class MusicVideos1 : XBMCRPC.List.Filter.MusicVideos
   {
       public XBMCRPC.List.Filter.MusicVideos[] and {get;set;}
   }
   public class MusicVideos2 : XBMCRPC.List.Filter.MusicVideos
   {
       public XBMCRPC.List.Filter.MusicVideos[] or {get;set;}
   }
   public class MusicVideos3 : XBMCRPC.List.Filter.Rule.MusicVideos, List.Filter.MusicVideos
   {
   }
   public interface MusicVideos
   {
   }
}
