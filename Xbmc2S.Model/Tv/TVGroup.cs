using System;
using System.Linq;
using System.Threading.Tasks;
using KODIRPC.List;
using KODIRPC.Video.Fields;

namespace Xbmc2S.Model
{
    public class TVGroup:GroupBase
    {
        private readonly AppContext _server;


        private async Task GetRecent()
        {
            try
            {
                var movies = await _server.XBMC.VideoLibrary.GetTVShows(TVShow.AllFields(), new Limits() { end = 12, start = 0 }, new Sort() { method = Sort_method.dateadded, ignorearticle = true, order = Sort_order.descending });
                RefreshTops(movies.tvshows.Select(MovieFactory).ToList());

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private TVShowVm MovieFactory(KODIRPC.Video.Details.TVShow arg)
        {
            return new TVShowVm(arg, _server);
        }

        private bool first = true;

        public TVGroup(AppContext server)
        {
            _server = server;

            GetRecent();
        }
    }
}