using System.Threading.Tasks;
using Okra.Data;

namespace Xbmc2S.RT.Model
{
    class VirtualMovies: VirtualizingDataList<MovieVm>
    {

        public VirtualMovies(IDataListSource<MovieVm> dataListSource) : base(dataListSource)
        {
        }

        public async Task<int> LoadToChar(char c)
        {
            for (int i = 0; i < Count; i++)
            {
                var item = await GetItemAsync(i);
                var chr = item.Label[0].ToString().ToLowerInvariant()[0];
                if (chr>=c)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}