using XBMCRPC;

namespace Xbmc2S.RT.Model
{
    internal interface IServerInfo
    {
        Client XBMC { get; }
        IImageManager ImageManager { get; }
    }
}