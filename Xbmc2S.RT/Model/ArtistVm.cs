using System.Linq;
using XBMCRPC.Audio.Details;

namespace Xbmc2S.RT.Model
{
    class ArtistVm:BaseVM
    {
        private readonly Artist _artistItem;
        private readonly IServerInfo _server;

        public ArtistVm(Artist artistItem, IServerInfo server)
            : base(artistItem.thumbnail,artistItem.fanart, server)
        {
            _artistItem = artistItem;
            _server = server;
            ID = _artistItem.artistid;
            Label=_artistItem.artist;
            SecondLabel = _artistItem.style.FirstOrDefault();
        }

        public int ID { get; set; }
    }
}