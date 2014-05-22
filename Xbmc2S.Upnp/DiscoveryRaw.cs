using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Xbmc2S.RT.UPnP
{
    public class DiscoveryRaw : DiscoveryBase
    {
        public override Task<MediaRendererDevice[]> GetMediaRenderer()
        {
            return Platform.Current.GetMediaRenderer();
        }   
        
        public Task<MediaServerDevice[]> GetMediaServer()
        {
            return Platform.Current.GetMediaServer();
        }
    }
}