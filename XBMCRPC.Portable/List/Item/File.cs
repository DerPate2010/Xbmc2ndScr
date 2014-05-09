namespace XBMCRPC.List.Item
{
   public class FileBaseFile : XBMCRPC.List.Item.BaseFile,File
   {
       public string file {get;set;}
       public filetypeEnum filetype {get;set;}
       public string lastmodified {get;set;}
       public string mimetype {get;set;}
       public int size {get;set;}
   }
   public class FileBaseMedia : XBMCRPC.List.Item.BaseMedia,File
   {
       public string file {get;set;}
       public filetypeEnum filetype {get;set;}
       public string lastmodified {get;set;}
       public string mimetype {get;set;}
       public int size {get;set;}
   }
   public interface File : XBMCRPC.List.Item.Base
   {
        string file {get;set;}
        filetypeEnum filetype {get;set;}
        string lastmodified {get;set;}
        string mimetype {get;set;}
        int size {get;set;}
   }
   public enum filetypeEnum
   {
       file,
       directory,
   }
}
