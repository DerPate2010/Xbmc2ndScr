namespace XBMCRPC.Video.Details
{
   public class Episode : XBMCRPC.Video.Details.File
   {
       public XBMCRPC.Video.Cast cast {get;set;}
       public int episode {get;set;}
       public int episodeid {get;set;}
       public string firstaired {get;set;}
       public string originaltitle {get;set;}
       public string productioncode {get;set;}
       public double rating {get;set;}
       public int season {get;set;}
       public string showtitle {get;set;}
       public int tvshowid {get;set;}
       public global::System.Collections.Generic.Dictionary<string,string> uniqueid {get;set;}
       public string votes {get;set;}
       public string[] writer {get;set;}
   }
}
