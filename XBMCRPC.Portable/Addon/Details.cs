namespace XBMCRPC.Addon
{
   public class Details : XBMCRPC.Item.Details.Base
   {
       public string addonid {get;set;}
       public string author {get;set;}
       public string broken {get;set;}
   public class dependenciesItem
   {
       public string addonid {get;set;}
       public bool optional {get;set;}
       public string version {get;set;}
   }
       public dependenciesItem[] dependencies {get;set;}
       public string description {get;set;}
       public string disclaimer {get;set;}
       public bool enabled {get;set;}
   public class extrainfoItem
   {
       public string key {get;set;}
       public string value {get;set;}
   }
       public extrainfoItem[] extrainfo {get;set;}
       public string fanart {get;set;}
       public string name {get;set;}
       public string path {get;set;}
       public int rating {get;set;}
       public string summary {get;set;}
       public string thumbnail {get;set;}
       public XBMCRPC.Addon.Types type {get;set;}
       public string version {get;set;}
   }
}
