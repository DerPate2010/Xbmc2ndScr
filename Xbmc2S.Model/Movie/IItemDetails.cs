using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Core;
using Xbmc2S.RT.UPnP;

namespace Xbmc2S.Model
{
    public interface ICollectionDetails
    {
        IEnumerable<IItemDetails> Items { get; } 
        string ItemsLabel { get; } 
    }

    public interface ICollectionGroups
    {
        IEnumerable<ICollectionDetails> Groups { get; } 
    }

    public interface IItemDetails
    {
        int Runtime { get; }
        int Year { get; }
        string Content { get;  }
        IEnumerable<ICastVm> Cast { get; }
        string Genre { get;  }
        string Country { get;  }
        string OriginalTitle { get;  }
        double Rating { get;  }
        double RatingBase5 { get; set; }
        string Studio { get;  }
        string Writer { get;  }
        string Director { get;  }
        string Trailer { get;  }
        DelegateCommand PlayTrailer { get; }
        bool IsOffline { get; }
        bool IsWatched { get; set; }
        ICommand Play { get; }
        ICommand PrepareDownload { get; }
        DelegateCommand ToWatchlist { get; }
        DelegateCommand FromWatchlist { get; }
        string Path { get; }
        int Id { get;  }
        string Label { get; }
        string SecondLabel { get; }
        void GoTo();
        VideoImages Images { get; }
    }


}