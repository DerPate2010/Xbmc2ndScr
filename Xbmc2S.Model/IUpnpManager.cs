using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xbmc2S.RT.UPnP;

namespace Xbmc2S.Model
{
    public interface IUpnpManager
    {
        MediaRendererDevice[] AvailableRenderDevices { get; }
        Dictionary<string, string> PathLookup { get; }
        Task PlayItem(PlayableItemVm playableItem, MediaRendererDevice renderDevice);
        Task<string> GetPlaybackUri(PlayableItemVm playableItem);
        Task<bool> IsXbmcHost(Uri uriToCheck);
        List<XbmcServer> DiscoveredXBMCs { get;  }
        Task WaitForInit();
        bool IsAvailable { get; }
    }
}