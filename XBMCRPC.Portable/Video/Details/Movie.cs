namespace XBMCRPC.Video.Details
{
   public class Movie : XBMCRPC.Video.Details.File
   {
       public XBMCRPC.Video.Cast cast {get;set;}
       public string[] country {get;set;}
       public string[] genre {get;set;}
       public string imdbnumber {get;set;}
       public int movieid {get;set;}
       public string mpaa {get;set;}
       public string originaltitle {get;set;}
       public string plotoutline {get;set;}
       public double rating {get;set;}
       public string set {get;set;}
       public int setid {get;set;}
       public string[] showlink {get;set;}
       public string sorttitle {get;set;}
       public string[] studio {get;set;}
       public string[] tag {get;set;}
       public string tagline {get;set;}
       public int top250 {get;set;}
       public string trailer {get;set;}
       public string votes {get;set;}
       public string[] writer {get;set;}
       public int year {get;set;}
   }
}
