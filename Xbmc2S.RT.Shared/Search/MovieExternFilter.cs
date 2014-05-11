using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Okra.Data;
using TmdbWrapper;
using TmdbWrapper.Search;
using Xbmc2S.Model;

namespace Xbmc2S.RT
{
    internal class MovieExternFilter : Filter
    {
        private readonly string _query;
        private TmdbResult _tmdbResult;

        public MovieExternFilter(string query)
            : base("Other Movies")
        {
            _query = query;
            _tmdbResult = (TmdbResult)App.MainVm.SearchExtern(_query);
            GetResultCount();
        }

        private async Task GetResultCount()
        {
            Count = await _tmdbResult.GetCountAsync();
        }

        public override object GetSource()
        {
            return _tmdbResult;
        }
    }

}