using XBMCRPC.Video;

namespace Xbmc2S.Model
{
    class FirstCastVm:CastVm,IMultiCellItem
    {
        public FirstCastVm(CastItem castItem, AppContext appContext) : base(castItem, appContext)
        {
            ColSpan = 2;
            RowSpan = 2;
        }

        public int ColSpan { get; private set; }
        public int RowSpan { get; private set; }
    }
}