using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Core;
using Xbmc2S.Model;
using Xbmc2S.RT.UPnP;
using KODIRPC.Video;

namespace Xbmc2S.RT.SampleDataModel
{
    public class DetailsSample: IItemDetails
    {
        public List<IItemDetails> Items { get; set; } 

        public DetailsSample()
        {
            Runtime = 112;
            Year = 1997;
            Content =
                "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";
            Genre = "Action";
            Country = "Germany";
            OriginalTitle = "Orig Title";
            Label = "Movie Title";
            SecondLabel = "Second Label";
            Rating = 9.8888888;
            Studio = "20th Century Fox";
            Writer = "Writer Tom";
            Director = "Writer Jerry";
            Items= new List<IItemDetails>(){this};
            IsWatched = true;
            Image =
                "http://homeserver:85/image/image://http%253a%252f%252fcf2.imgobject.com%252ft%252fp%252foriginal%252foScKqsh8rUp3Zbv7iDtrOoSKCUb.jpg/";
            FanArtImage =
                "http://homeserver:85/image/image://video@C%253a%255cArchiv%255cSchmalz1%255cEmilie%2520Richards%255cEmilie%2520Richards%2520%2520Der%2520Zauber%2520von%2520Neuseeland.2011.ts/";

            Cast = new List<CastVm>()
            {
                new CastVm(new CastItem(){name = "name", role = "role" , thumbnail = "http://homeserver:85/image/image://video@C%253a%255cArchiv%255cSchmalz1%255cEmilie%2520Richards%255cEmilie%2520Richards%2520%2520Der%2520Zauber%2520von%2520Neuseeland.2011.ts/"},null )
            };
        }

        public int Runtime { get; set; }
        public int Year { get; set; }
        public string Content { get; set; }
        public IEnumerable<ICastVm> Cast { get; private set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public string OriginalTitle { get; set; }
        public double Rating { get; set; }

        public double RatingBase5
        {
            get { return Rating/2; }
            set { Rating = value*2; }
        }

        public string Studio { get; set; }
        public string Writer { get; set; }
        public string Director { get; set; }
        public string Trailer { get; set; }
        public DelegateCommand PlayTrailer { get; private set; }
        public bool IsOffline { get; private set; }
        public bool IsWatched { get; set; }
        public ICommand Play { get; private set; }
        public ICommand PrepareDownload { get; private set; }
        public DelegateCommand ToWatchlist { get; private set; }
        public DelegateCommand FromWatchlist { get; private set; }
        public string Path { get; private set; }
        public int Id { get; set; }
        public object Image { get; private set; }
        public string Label { get; private set; }
        public string SecondLabel { get; private set; }
        public bool WatchedCheck { get; set; }
        public object FanArtImage { get; private set; }
        public void PrepareDownloadExecute()
        {
            throw new NotImplementedException();
        }

        public Task StartDownload(bool transcode, StorageType storage, string name, int audioTrack, int subtitleTrack)
        {
            throw new NotImplementedException();
        }

        public string GetDownloadName()
        {
            throw new NotImplementedException();
        }

        public PlayToVm[] GetPlayToTargets()
        {
            throw new NotImplementedException();
        }

        public void PlayTo(MediaRendererDevice renderer)
        {
            throw new NotImplementedException();
        }
        public void GoTo()
        {
            throw new NotImplementedException();
        }

        public VideoImages Images { get; private set; }

        public void PlayToLocal()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
