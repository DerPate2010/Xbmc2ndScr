﻿using KODIRPC.List.Item;

namespace Xbmc2S.Model
{
    internal class FirstMovieVm:MovieVm, IMultiCellItem
    {
        public FirstMovieVm(KODIRPC.Video.Details.Movie movie, IAppContext appContext)
            : base(movie, appContext)
        {
            ColSpan = RowSpan = 2;
        }


        public int ColSpan { get; private set; }
        public int RowSpan { get; private set; }
    }
}