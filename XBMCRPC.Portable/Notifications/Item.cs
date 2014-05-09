namespace XBMCRPC.Notifications
{
   public class Item1 : XBMCRPC.Notifications.Item
   {
       public XBMCRPC.Notifications.Item.Type type {get;set;}
   }
   public class Item2 : XBMCRPC.Notifications.Item
   {
       public int id {get;set;}
       public XBMCRPC.Notifications.Item.Type type {get;set;}
   }
   public class Item3 : XBMCRPC.Notifications.Item
   {
       public string title {get;set;}
       public XBMCRPC.Notifications.Item.Type type {get;set;}
       public int year {get;set;}
   }
   public class Item4 : XBMCRPC.Notifications.Item
   {
       public int episode {get;set;}
       public int season {get;set;}
       public string showtitle {get;set;}
       public string title {get;set;}
       public XBMCRPC.Notifications.Item.Type type {get;set;}
   }
   public class Item5 : XBMCRPC.Notifications.Item
   {
       public string album {get;set;}
       public string artist {get;set;}
       public string title {get;set;}
       public XBMCRPC.Notifications.Item.Type type {get;set;}
   }
   public class Item6 : XBMCRPC.Notifications.Item
   {
       public string album {get;set;}
       public string artist {get;set;}
       public string title {get;set;}
       public int track {get;set;}
       public XBMCRPC.Notifications.Item.Type type {get;set;}
   }
   public class Item7 : XBMCRPC.Notifications.Item
   {
       public string file {get;set;}
       public XBMCRPC.Notifications.Item.Type type {get;set;}
   }
   public class Item8 : XBMCRPC.Notifications.Item
   {
       public XBMCRPC.PVR.Channel.Type channeltype {get;set;}
       public int id {get;set;}
       public string title {get;set;}
       public XBMCRPC.Notifications.Item.Type type {get;set;}
   }
   public class Item
   {
   public enum Type
   {
       unknown,
       movie,
       episode,
       musicvideo,
       song,
       picture,
       channel,
   }
    }
}
