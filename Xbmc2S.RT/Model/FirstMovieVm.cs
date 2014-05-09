using XBMCRPC.List.Item;

namespace Xbmc2S.RT.Model
{
    internal class FirstMovieVm:MovieVm, IMultiCellItem
    {
        public FirstMovieVm(XBMCRPC.Video.Details.Movie movie, IServerInfo server)
            : base(movie, server)
        {
            ColSpan = RowSpan = 2;
        }

        public FirstMovieVm(AllFile movie, IServerInfo server)
            : base(movie, server)
        {
            ColSpan = RowSpan = 2;
        }

        public int ColSpan { get; private set; }
        public int RowSpan { get; private set; }
    }
}