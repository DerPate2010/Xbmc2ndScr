namespace XBMCRPC.Audio.Details
{
   public class Album : XBMCRPC.Audio.Details.Media
   {
       public int albumid {get;set;}
       public string albumlabel {get;set;}
       public string description {get;set;}
       public string[] mood {get;set;}
       public int playcount {get;set;}
       public string[] style {get;set;}
       public string[] theme {get;set;}
       public string type {get;set;}
   }
}
