namespace XBMCRPC.Player.Notifications
{
   public class Item1 : XBMCRPC.Player.Notifications.Item
   {
       public XBMCRPC.Player.Notifications.Item.Type type {get;set;}
   }
   public class Item2 : XBMCRPC.Player.Notifications.Item
   {
       public int id {get;set;}
       public XBMCRPC.Player.Notifications.Item.Type type {get;set;}
   }
   public class Item3 : XBMCRPC.Player.Notifications.Item
   {
       public string title {get;set;}
       public XBMCRPC.Player.Notifications.Item.Type type {get;set;}
       public int year {get;set;}
   }
   public class Item4 : XBMCRPC.Player.Notifications.Item
   {
       public int episode {get;set;}
       public int season {get;set;}
       public string showtitle {get;set;}
       public string title {get;set;}
       public XBMCRPC.Player.Notifications.Item.Type type {get;set;}
   }
   public class Item5 : XBMCRPC.Player.Notifications.Item
   {
       public string album {get;set;}
       public string artist {get;set;}
       public string title {get;set;}
       public XBMCRPC.Player.Notifications.Item.Type type {get;set;}
   }
   public class Item6 : XBMCRPC.Player.Notifications.Item
   {
       public string album {get;set;}
       public string artist {get;set;}
       public string title {get;set;}
       public int track {get;set;}
       public XBMCRPC.Player.Notifications.Item.Type type {get;set;}
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
   }
    }
}
