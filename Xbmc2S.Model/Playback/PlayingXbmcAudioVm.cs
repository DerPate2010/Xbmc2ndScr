using KODIRPC.Audio.Details;
using KODIRPC.List.Item;

namespace Xbmc2S.Model
{
    class PlayingXbmcAudioVm : PlayingXbmcItemVm
    {
        private readonly All _baseDetails;

        public PlayingXbmcAudioVm(All baseDetails, int playerid, IAppContext server)
            : base(baseDetails.AsMediaDetailsBase, playerid, server)
        {
            _baseDetails = baseDetails;
            Label = baseDetails.AsAudioDetailsMedia.title;
        }
        public override string Id
        {
            get { return _baseDetails.id.ToString(); }
        }

        public override void GotoDetails()
        {
            _appContext.View.GotoAlbum(_baseDetails.albumid);

        }
    }
}