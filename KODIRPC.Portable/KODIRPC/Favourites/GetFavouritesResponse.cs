using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.Favourites
{
   public class GetFavouritesResponse
   {
       public global::System.Collections.Generic.List<KODIRPC.Favourite.Details.Favourite> favourites { get; set; }
       public KODIRPC.List.LimitsReturned limits { get; set; }
    }
}
