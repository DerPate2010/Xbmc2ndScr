using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Okra.Core;
using Windows.System;
using Windows.UI.Xaml.Controls;
using XBMCRPC.List.Item;
using XBMCRPC.Playlist;
using XBMCRPC.Video.Details;

namespace Xbmc2S.RT.Model
{
    internal class MovieVm : PlayableItemVm
    {
        private readonly IServerInfo _server;


        public MovieVm(XBMCRPC.Video.Details.Movie movie, IServerInfo server)
            : this((XBMCRPC.Video.Details.File)movie, server)
        {
            _movie = movie;
            SecondLabel = movie.tagline;
            Year = movie.year;
            Id = movie.movieid;
            Country = string.Join(", ",movie.country);
            Genre = string.Join(", ",movie.genre);
            OriginalTitle=movie.originaltitle;
            Rating=movie.rating;
            Studio=string.Join(", ",movie.studio);
            Writer=string.Join(", ",movie.writer);
            Director=string.Join(", ",movie.director);
            Trailer=movie.trailer;
            PlayTrailer= new DelegateCommand(TrailerExecute);
        }

        private void TrailerExecute()
        {
            var t = "plugin://plugin.video.youtube/?action=play_video&videoid=";
            if (Trailer!=null && Trailer.Contains(t))
            {
                Launcher.LaunchUriAsync(new Uri("http://www.youtube.com/watch?hd=1&v=" + Trailer.Replace(t,"")));
            }
            else
            {
                Launcher.LaunchUriAsync(new Uri("http://www.youtube.com/results?search_query=" + Uri.EscapeDataString(Label)));
            }
            
        }

        private MovieVm(XBMCRPC.Video.Details.File movie, IServerInfo server) : base(movie, server)
        {

            _server = server;
            Label = movie.title;
            Runtime = movie.runtime;
            Content = movie.plot;
            File = movie.file;
        }

        public int Runtime { get; set; }
        public int Year { get; set; }
        public string Content { get; set; }
        public string File { get; set; }

        public IEnumerable<CastVm> Cast
        {
            get
            {
                if (_cast == null)
                {
                    LoadCast();
                }
                return _cast;
            }
        }

        private void LoadCast()
        {
            _cast = _movie.cast.Select(c=>new CastVm(c,_server));
        }
        
        private IEnumerable<CastVm> _cast;
        private Movie _movie;

        public MovieVm(All movie, IServerInfo server)
            : this((XBMCRPC.Video.Details.File)movie, server)
        {
            SecondLabel = movie.tagline;
            Id = movie.id;
        }



        public int Id { get; set; }

        protected override async void PlayExecute()
        {
            await _server.XBMC.Player.Open2(new Item3() { movieid = _movie.movieid }, null);
        }

        protected override async void SetWatched(bool value)
        {
            await _server.XBMC.VideoLibrary.SetMovieDetails(_movie.movieid, playcount: value ? 1 : 0);
        }

        public string Genre { get; set; }

        public string Country { get; set; }

        public string OriginalTitle { get; set; }

        public double Rating { get; set; }

        public string Studio { get; set; }

        public string Writer { get; set; }

        public string Director { get; set; }

        public string Trailer { get; set; }

        public ICommand PlayTrailer { get; private set; }
        public override void NavigateToDetails(Frame frame)
        {
            MainVm.Current.DirectToMovie(Id);
            frame.Navigate(typeof(MovieDetailPage));
        }
    }
}