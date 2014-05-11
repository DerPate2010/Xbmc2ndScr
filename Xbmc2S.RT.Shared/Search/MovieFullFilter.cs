using System.Threading.Tasks;

namespace Xbmc2S.RT
{
    internal class MovieFullFilter : Filter
    {
        private readonly string _query;

        public MovieFullFilter(string query)
            : base("My Movies")
        {
            _query = query;
            GetResultCount(query);
        }

        private async Task GetResultCount(string query)
        {
            Count = await App.MainVm.GetSearchFullCount(query);
        }

        public override object GetSource()
        {
            return App.MainVm.SearchFullText(_query);
        }
    }
}