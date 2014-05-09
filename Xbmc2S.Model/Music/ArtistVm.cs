using System.Linq;
using XBMCRPC.Audio.Details;

namespace Xbmc2S.Model
{
    public class ArtistVm:BaseVM
    {
        private readonly Artist _artistItem;
        private readonly IAppContext _server;

        public ArtistVm(Artist artistItem, IAppContext server)
            : base(artistItem, server)
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