using System.Threading.Tasks;

namespace Xbmc2S.RT.UPnP
{
    public abstract class DiscoveryBase
    {
        public abstract Task<MediaRendererDevice[]> GetMediaRenderer();
    }
}