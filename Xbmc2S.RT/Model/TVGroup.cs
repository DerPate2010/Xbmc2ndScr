using System;
using System.Linq;
using System.Threading.Tasks;
using XBMCRPC.List;
using XBMCRPC.Video.Fields;

namespace Xbmc2S.RT.Model
{
    class TVGroup:GroupBase
    {
        private readonly ServerInfo _server;


        private async Task GetRecent()
        {
            try
            {
                var movies = await _server.XBMC.VideoLibrary.GetTVShows(TVShow.AllFields(), new Limits() { end = 12, start = 0 }, new Sort() { method = Sort.methodEnum.dateadded, ignorearticle = true, order = Sort.orderEnum.descending });
                RefreshTops(movies.tvshows.Select(MovieFactory).ToList());

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private TVShowVm MovieFactory(XBMCRPC.Video.Details.TVShow arg)
        {
            return new TVShowVm(arg, _server);
        }

        private bool first = true;

        public TVGroup(ServerInfo server)
        {
            _server = server;

            GetRecent();
        }
    }
}