using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Core;
using TmdbWrapper;
using TmdbWrapper.Movies;
using TmdbWrapper.Search;

namespace Xbmc2S.Model
{
    public class TmdbItem:BindableBase, IItemDetails
    {
        private readonly Config _config;
        private readonly Movie _movie;
        private readonly MovieSummary _summary;
        private string _content;
        private string _genre;
        private int _runtime;
        private int _year;
        private string _country;
        private string _originalTitle;
        private double _rating;
        private string _studio;
        private string _writer;
        private string _director;
        private string _trailer;
        private IEnumerable<ICastVm> _cast;

        public TmdbItem(Config config, MovieSummary summary)
        {
            _config = config;
            _summary = summary;
            Label = summary.Title;
            Images= new VideoImages(new Uri(config.BaseUrlPoster + summary.PosterPath),new Uri(config.BaseUrlBackdrop + summary.BackdropPath));

            OriginalTitle = summary.OriginalTitle;
            Rating = summary.VoteAverage;
            RatingBase5 = summary.VoteAverage/2;

            DisableCommands();

        }

        private void DisableCommands()
        {
            var noCommand = new DelegateCommand(() => { }, () => false);
            Play= noCommand;
            PlayToSelection= noCommand;
            WatchedCommand = noCommand;
            PlayTrailer= noCommand;
            PrepareDownload= noCommand;
            ToWatchlist= noCommand;
            FromWatchlist= noCommand;
        }

        public DelegateCommand PlayToSelection { get; set; }
        public DelegateCommand WatchedCommand { get; set; }

        public TmdbItem(Config config, Movie movie)
        {
            _config = config;
            _movie = movie;
            Label = movie.Title;
            Images = new VideoImages(new Uri(config.BaseUrlPoster + movie.PosterPath), new Uri(config.BaseUrlBackdrop + movie.BackdropPath));
            Rating = movie.VoteAverage;
            RatingBase5 = movie.VoteAverage / 2;
            FillByMovie(movie);
            DisableCommands();
        }

        private async Task LoadAll()
        {
            var movie = await _summary.MovieAsync();
            FillByMovie(movie);
        }

        private void FillByMovie(Movie movie)
        {
            Runtime = movie.Runtime;
            DateTime releaseDate;
            if (DateTime.TryParse(movie.ReleaseDate, out releaseDate))
            {
                Year = releaseDate.Year;
            }
            Content = movie.Overview;
            SecondLabel = movie.Tagline;
            Genre = string.Join(", ", movie.Genres);
            Country = string.Join(", ", movie.ProductionCountries);
            Studio = string.Join(", ", movie.ProductionCompanies);
            OriginalTitle = movie.OriginalTitle;
        }

        private async Task LoadCast()
        {
            var id = _summary==null ? _movie.Id : _summary.Id;
            var credits = await TheMovieDb.GetMovieCastAsync(id);
            Director = credits.Crew.Where(c => c.Job == "Director").Select(c => c.Name).FirstOrDefault();
            Writer = credits.Crew.Where(c => c.Job == "Writer").Select(c => c.Name).FirstOrDefault();
            Cast = credits.Cast.Select(CastFactory);
        }

        private TmdbCast CastFactory(CastPerson arg)
        {
            return new TmdbCast(arg,_config);
        }

        public bool WatchedCheck { get; set; }
        public int Id { get; private set; }
        public string Label { get; set; }
        public string SecondLabel { get; private set; }
        public void GoTo()
        {
            throw new NotImplementedException();
        }

        public VideoImages Images { get; private set; }

        public int Runtime
        {
            get { return _runtime; }
            set { SetProperty(ref _runtime, value); }
        }

        public int Year
        {
            get { return _year; }
            set { SetProperty(ref _year, value); }
        }

        public string Content
        {
            get
            {
                if (_content == null)
                {
                    LoadAll();
                }
                return _content;
            }
            set { SetProperty(ref _content, value); }
        }


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
            private set { SetProperty(ref _cast, value); }
        }

        public string Genre
        {
            get { return _genre; }
            set { SetProperty(ref _genre, value); }
        }

        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }

        public string OriginalTitle
        {
            get { return _originalTitle; }
            set { SetProperty(ref _originalTitle, value); }
        }

        public double Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }

        public double RatingBase5 { get; set; }

        public string Studio
        {
            get { return _studio; }
            set { SetProperty(ref _studio, value); }
        }

        public string Writer
        {
            get { return _writer; }
            set { SetProperty(ref _writer, value); }
        }

        public string Director
        {
            get { return _director; }
            set { SetProperty(ref _director, value); }
        }

        public string Trailer
        {
            get { return _trailer; }
            set { SetProperty(ref _trailer, value); }
        }

        public DelegateCommand PlayTrailer { get; private set; }
        public bool IsOffline { get; private set; }
        public bool IsWatched { get; set; }
        public ICommand Play { get; private set; }
        public ICommand PrepareDownload { get; private set; }
        public DelegateCommand ToWatchlist { get; private set; }
        public DelegateCommand FromWatchlist { get; private set; }
        public string Path { get; private set; }
    }
}