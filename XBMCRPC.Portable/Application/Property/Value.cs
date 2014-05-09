namespace XBMCRPC.Application.Property
{
   public class Value
   {
       public bool muted {get;set;}
       public string name {get;set;}
   public class Valueversion
   {
       public int major {get;set;}
       public int minor {get;set;}
       public string revision {get;set;}
   public enum tagEnum
   {
       prealpha,
       alpha,
       beta,
       releasecandidate,
       stable,
   }
       public tagEnum tag {get;set;}
   }
       public Valueversion version {get;set;}
       public int volume {get;set;}
   }
}
