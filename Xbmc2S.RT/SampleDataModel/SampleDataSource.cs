using System;
using System.Collections.Generic;
using XBMCRPC.Audio.Details;
using XBMCRPC.Media;
using XBMCRPC.Video;
using XBMCRPC.Video.Details;
using Xbmc2S.Model;
using Xbmc2S.Model.Download;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace Xbmc2S.RT.SampleDataModel
{
    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// 
    /// SampleDataSource initializes with placeholder data rather than live production
    /// data so that sample data is provided at both design-time and run-time.
    /// </summary>
    internal sealed class SampleDataSource
    {



        public char[] ABC { get { return "#abcdefghijklmnopqrstuvwxyz".ToCharArray(); } }

        public List<MovieVm> MovieGroup { get; set; }

        public List<AlbumVm> MusicGroup { get; set; }
        public List<TVShowVm> TvGroup { get; set; }
        public List<CastVm> PeopleGroup { get; set; }

        public List<EpisodeVm> Episodes { get; private set; }
        public List<DownloadItem> Downloads { get; private set; }
        public WatchList Watchlist { get; private set; }




        public SampleDataSource()
        {
            FillDownloads();
            FillMovies();
            FillMusic();
            FillTv();
            FillCast();
            FillEpisodes();
            FillSeasons();

            Watchlist= new WatchList(_appContext);
            Watchlist.AddItem(MovieGroup[0]);


            String ITEM_CONTENT = String.Format("Item Content: {0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}",
                        "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam ");

        }

        private void FillDownloads()
        {
            Downloads = new List<DownloadItem>();
            Downloads.Add(GetDummyDownload());
            Downloads.Add(GetDummyDownload());
            Downloads.Add(GetDummyDownload());
            Downloads.Add(GetDummyDownload());
            Downloads.Add(GetDummyDownload());
            Downloads.Add(GetDummyDownload());
            Downloads.Add(GetDummyDownload());
            Downloads.Add(GetDummyDownload());
            Downloads.Add(GetDummyDownload());
        }

        private DownloadItem GetDummyDownload()
        {
            return new DownloadItem(){Url=new Uri("http://www.google.de"), Filename = "Air Force One 1.mp4", Transfer = new TransferInfo() {Size = 20102921}, Progress = 24, Label = "Air Force One"};
        }

        private void FillSeasons()
        {
            Seasons = new List<SeasonVm>();
            Seasons.Add(new SeasonVm(GetDummySeason(),_appContext, null));
        }

        private Season GetDummySeason()
        {
            return new Season(){art = new Artwork()};
        }

        public  List<SeasonVm> Seasons { get; set; }

        private void FillEpisodes()
        {
            Episodes = new List<EpisodeVm>();
            Episodes.Add(new EpisodeVm(GetDummyEpisode(), _appContext, null));
            Episodes.Add(new EpisodeVm(GetDummyEpisode(), _appContext, null) { });
        }

        private Episode GetDummyEpisode()
        {
            return new Episode(){ art= new Artwork(),title = "folge", plot = "mmm"};
        }

        private void FillCast()
        {
            PeopleGroup= new List<CastVm>();
            PeopleGroup.Add(new CastVm(GetDummyCast(), _appContext));
        }

        private CastItem GetDummyCast()
        {
            return new CastItem(){name = "Actor 1"};
        }

        private void FillTv()
        {
            TvGroup= new List<TVShowVm>();
            TvGroup.Add( new TVShowVm(GetDummyShow(),_appContext));
        }

        private TVShow GetDummyShow()
        {
            return new TVShow(){ art= new Artwork(){banner = null}, title = "Showy 1"};
        }

        private void FillMusic()
        {
            MusicGroup= new List<AlbumVm>();
            MusicGroup.Add(new AlbumVm(GetDummyAlbum(),_appContext));
            MusicGroup.Add(new AlbumVm(GetDummyAlbum(),_appContext));
        }

        private Album GetDummyAlbum()
        {
            return new Album(){artist = new List<string>()};
        }

        IAppContext  _appContext = new AppContextSmaple();

        private void FillMovies()
        {
            MovieGroup= new List<MovieVm>();

            //MovieGroup.Add(new FirstMovieVm(GetDummyMovie(), AppContext));
            MovieGroup.Add(new MovieVm(GetDummyMovie(), _appContext));
            MovieGroup.Add(new MovieVm(GetDummyMovie(), _appContext){WatchedCheck = true});
        }

        public Movie GetDummyMovie()
        {
            return new Movie()
            {
                title = "Titel 123",
                tagline="bla bla blub",
                art = new Artwork(),
                country = new List<string>() { "Germany" },
                year = 2000,
                genre = new List<string>() { "Schmalz" },
                writer = new List<string>() { "writer" },
                director = new List<string>() { "director" },
                studio = new List<string>() { "Warner Brows." },
                originaltitle = "ORigTitel",
                runtime = 122,
                plot = "test test test test test test test test test test test test test test test test test test test test test test test ",
                file = @"C:\Archiv\HD1gfdgfdgdggdfgdgdgdgfdfffgdg\film.mkv"
            };
        }
    }
}
