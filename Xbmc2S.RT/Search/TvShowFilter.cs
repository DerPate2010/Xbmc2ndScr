using Xbmc2S.Model;

namespace Xbmc2S.RT
{
    internal class TvShowFilter : Filter
    {



        public TvShowFilter(string queryText)
            : base("TV Shows", App.MainVm.SearchShow(queryText))
        {
            
        }
    }
}