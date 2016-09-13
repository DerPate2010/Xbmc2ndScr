using TmdbWrapper;
using KODIRPC;

namespace Xbmc2S.Model
{
    public interface IPlatformServices: KODIRPC.IPlatformServices,IRequester
    {
        ISettingsManager SettingsManager { get; }
        IImageManager GetImageManager(Client xbmc, bool needsLogin);
        IBackgroundTransfer BackgroundTransfer { get; }
        ILauncher Launcher { get; }
    }
}