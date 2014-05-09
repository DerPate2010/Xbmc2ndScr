using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okra.Data;
using TmdbWrapper;
using TmdbWrapper.Search;
using Xbmc2S.Model;

namespace Xbmc2S.RT
{
    internal class ActorFilter : Filter
    {
        private readonly string _query;
        private TmdbResultActor _tmdbResult;

        public ActorFilter(string query)
            : base("Actors")
        {
            _query = query;
            _tmdbResult = new TmdbResultActor(_query);
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