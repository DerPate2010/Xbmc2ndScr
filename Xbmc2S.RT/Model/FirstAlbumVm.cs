using XBMCRPC.Audio.Details;

namespace Xbmc2S.RT.Model
{
    class FirstAlbumVm:AlbumVm, IMultiCellItem
    {
        public FirstAlbumVm(Album albumItem, IServerInfo server) : base(albumItem, server)
        {
            ColSpan = RowSpan = 2;
        }

        public int ColSpan { get; private set; }
        public int RowSpan { get; private set; }
    }
}