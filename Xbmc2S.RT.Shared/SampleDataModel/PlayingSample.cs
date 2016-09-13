using KODIRPC.List.Item;
using KODIRPC.Player.Property;
using Xbmc2S.Model;

namespace Xbmc2S.RT.SampleDataModel
{
    internal class PlayingSample:CurrentPlaybackVm
    {
        public PlayingSample ()
        {
            //CurrentItem = new PlayingXbmcVideoVm( new AllFile(){ title = "Titel 123" }, 1, new AppContextSmaple());
            IsPlaying = false;
        }
    }
}