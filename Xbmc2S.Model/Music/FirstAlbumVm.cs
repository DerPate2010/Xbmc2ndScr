using XBMCRPC.Audio.Details;

namespace Xbmc2S.Model
{
    class FirstAlbumVm:AlbumVm, IMultiCellItem
    {
        public FirstAlbumVm(Album albumItem, IAppContext appContext) : base(albumItem, appContext)
        {
            ColSpan = RowSpan = 2;
        }

        public int ColSpan { get; private set; }
        public int RowSpan { get; private set; }
    }
}