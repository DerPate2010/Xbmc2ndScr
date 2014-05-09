using XBMCRPC.Video;

namespace Xbmc2S.RT.Model
{
    class FirstCastVm:CastVm,IMultiCellItem
    {
        public FirstCastVm(CastItem castItem, ServerInfo server) : base(castItem, server)
        {
            ColSpan = 2;
            RowSpan = 2;
        }

        public int ColSpan { get; private set; }
        public int RowSpan { get; private set; }
    }
}