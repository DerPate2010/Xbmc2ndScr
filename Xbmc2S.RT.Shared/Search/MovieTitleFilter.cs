using Xbmc2S.Model;

namespace Xbmc2S.RT
{
    internal class MovieTitleFilter : Filter
    {

        public MovieTitleFilter(string query)
            : base("My Movie Titles", App.MainVm.SearchTitle(query))
        {
        }

    }
}