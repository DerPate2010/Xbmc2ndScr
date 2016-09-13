using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Okra.Core;
using KODIRPC.List.Item;
using KODIRPC.Methods;
using KODIRPC.Playlist;
using KODIRPC.Video.Details;

namespace Xbmc2S.Model
{
    public class MovieVm : PlayableItemVm, IItemDetails
    {
        private readonly IAppContext _appContext;


        public MovieVm(KODIRPC.Video.Details.Movie movie, IAppContext appContext)
            : this((KODIRPC.Video.Details.File)movie, appContext)
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
            ToWatchlist = new DelegateCommand(ToWatchlistExecute, ToWatchlistCanExecute);
            FromWatchlist = new DelegateCommand(FromWatchlistExecute, FromWatchlistCanExecute);

        }


        private bool ToWatchlistCanExecute()
        {
            return !_movie.tag.Contains(WatchlistKey);
        }
        private bool FromWatchlistCanExecute()
        {
            return _movie.tag.Contains(WatchlistKey);
        }

        async void ToWatchlistExecute()
        {
            //var mv = await _appContext.XBMC.VideoLibrary.GetMovieDetails(_movie.movieid, new KODIRPC.Video.Fields.Movie(){ KODIRPC.Video.Fields.MovieItem.genre});
            var tags = _movie.tag.ToList();
            if (!tags.Contains(WatchlistKey))
            {
                tags.Add(WatchlistKey);
                _movie.tag = tags.ToList();
                await _appContext.XBMC.VideoLibrary.SetMovieDetails(_movie.movieid, tag: tags.ToList());
            }

            ToWatchlist.NotifyCanExecuteChanged();
            FromWatchlist.NotifyCanExecuteChanged();
        }

        private async void FromWatchlistExecute()
        {
            var tags = _movie.tag.ToList();
            if (tags.Contains(WatchlistKey))
            {
                tags.Remove(WatchlistKey);
                _movie.tag = tags.ToList();
                await _appContext.XBMC.VideoLibrary.SetMovieDetails(_movie.movieid, tag: tags.ToList());
            }
            ToWatchlist.NotifyCanExecuteChanged();
            FromWatchlist.NotifyCanExecuteChanged();

        }

        private void TrailerExecute()
        {
            var t = "plugin://plugin.video.youtube/?action=play_video&videoid=";
            if (Trailer!=null && Trailer.Contains(t))
            {
                _appContext.PlatformServices.Launcher.LaunchUriAsync(new Uri("http://www.youtube.com/watch?hd=1&v=" + Trailer.Replace(t, "")));
            }
            else
            {
                _appContext.PlatformServices.Launcher.LaunchUriAsync(new Uri("http://www.youtube.com/results?search_query=" + Uri.EscapeDataString(Label)));
            }
            
        }

        private MovieVm(KODIRPC.Video.Details.File movie, IAppContext appContext) : base(movie, appContext)
        {
            _appContext = appContext;
            Label = movie.title;
            Runtime = movie.runtime;
            Content = movie.plot;
            Path = movie.file;
        }

        public int Runtime { get; set; }
        public int Year { get; set; }
        public string Content { get; set; }

        public IEnumerable<ICastVm> Cast
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
            _cast = _movie.cast.Select(c=>new CastVm(c,_appContext));
        }
        
        private IEnumerable<ICastVm> _cast;
        private Movie _movie;

        public MovieVm(All movie, IAppContext appContext)
            : this(movie.AsVideoDetailsFile, appContext)
        {
            SecondLabel = movie.tagline;
            Id = movie.id;
        }

        protected override async void PlayExecute()
        {
            await _appContext.XBMC.Player.Open( new ItemMovieid() { movieid = _movie.movieid });
            base.PlayExecute();
        }

        protected override async void SetWatched(bool value)
        {
            await _appContext.XBMC.VideoLibrary.SetMovieDetails(_movie.movieid, playcount: value ? 1 : 0);
        }

        public string Genre { get; set; }

        public string Country { get; set; }

        public string OriginalTitle { get; set; }

        public double Rating { get; set; }

        public double RatingBase5
        {
            get { return Rating / 2; }
            set { Rating = value * 2; }
        }

        public string Studio { get; set; }

        public string Writer { get; set; }

        public string Director { get; set; }

        public string Trailer { get; set; }

        public DelegateCommand PlayTrailer { get; private set; }

        public void GoTo()
        {
            var iRef = new ItemsSourceReference(ItemsSourceType.Movie, Id);
            _appContext.View.GotoMovie(iRef);
        }
    }

}