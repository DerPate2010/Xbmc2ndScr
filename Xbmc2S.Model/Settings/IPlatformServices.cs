using TmdbWrapper;
using XBMCRPC;

namespace Xbmc2S.Model
{
    public interface IPlatformServices: XBMCRPC.IPlatformServices,IRequester
    {
        ISettingsManager SettingsManager { get; }
        IImageManager GetImageManager(Client xbmc, bool needsLogin);
        IBackgroundTransfer BackgroundTransfer { get; }
        ILauncher Launcher { get; }
    }
}