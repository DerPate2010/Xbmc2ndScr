namespace XBMCRPC.PVR.Details
{
   public class ChannelGroup : XBMCRPC.Item.Details.Base
   {
       public int channelgroupid {get;set;}
       public XBMCRPC.PVR.Channel.Type channeltype {get;set;}
   public class Extended : XBMCRPC.PVR.Details.ChannelGroup
   {
       public XBMCRPC.PVR.Details.Channel[] channels {get;set;}
       public XBMCRPC.List.LimitsReturned limits {get;set;}
   }
    }
}
