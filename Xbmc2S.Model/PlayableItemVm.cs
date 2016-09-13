using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Core;
using KODIRPC.Audio.Details;
using KODIRPC.List.Fields;
using Xbmc2S.Model.Download;
using Xbmc2S.RT.UPnP;
using Base = KODIRPC.Video.Details.Base;
using Media = KODIRPC.Files.Media;

namespace Xbmc2S.Model
{
    public abstract class PlayableItemVm:BaseVM
    {
        public const string WatchlistKey = "WatchList";


        protected PlayableItemVm(Base baseDetails, IAppContext appContext) : base(baseDetails, appContext)
        {
            WatchedCheck = baseDetails.playcount > 0;
            InitCommands();
        }

        private void InitCommands()
        {
            Play = new DelegateCommand(PlayExecute, PlayCanExecute);
            PlayToSelection = new DelegateCommand(PlayToSelectonExecute, PlayToSelectionCanExecute);
            PrepareDownload = new DelegateCommand(PrepareDownloadExecute, PrepareDownloadCanExecute);
            ToWatchlist = new DelegateCommand(WatchlistNeverExecute, WatchlistNeverCanExecute);
            FromWatchlist = new DelegateCommand(WatchlistNeverExecute, WatchlistNeverCanExecute);
        }

        private bool PrepareDownloadCanExecute()
        {
            return !IsOffline;
        }

        private bool PlayCanExecute()
        {
            return !IsOffline;
        }

        private bool PlayToSelectionCanExecute()
        {

            return !string.IsNullOrEmpty(Path) && !IsOffline;//Menu contains This device, too. && _appContext.Upnp.AvailableRenderDevices.Any();
        }

        private void PlayToSelectonExecute()
        {
            
        }

        protected PlayableItemVm(Song baseDetails, IAppContext appContext)
            : base(baseDetails, appContext)
        {
            WatchedCheck = baseDetails.playcount > 0;
            InitCommands();
        }
        protected PlayableItemVm(Album baseDetails, IAppContext appContext)
            : base(baseDetails, appContext)
        {
            WatchedCheck = baseDetails.playcount > 0;
            InitCommands();
        }

        private bool WatchlistNeverCanExecute()
        {
            return false;
        }

        private void WatchlistNeverExecute()
        {
            //var mv = await _appContext.XBMC.VideoLibrary.GetMovieDetails(_movie.movieid, KODIRPC.Video.Fields.Movie.AllFields());
            //var genres = mv.moviedetails.genre.ToList();
            //if (!genres.Contains("WatchList"))
            //{
            //    genres.Add("WatchList");
            //    await _appContext.XBMC.VideoLibrary.SetMovieDetails(_movie.movieid, genre: genres.ToArray());
            //}
            //var g = await _appContext.XBMC.VideoLibrary.GetGenres(properties: KODIRPC.Library.Fields.Genre.AllFields());
            //var gw = g.genres.FirstOrDefault(g2 => g2.title == "WatchList");
            //var mvs =
            //    await
            //    _appContext.XBMC.VideoLibrary.GetMovies2(KODIRPC.Video.Fields.Movie.AllFields(),
            //                                         filter: new VideoLibrary.GetMoviesfilter1() { genreid = gw.genreid });

        //    await _appContext.WatchList.AddItem(this);
        }

        public void PrepareDownloadExecute()
        {
            _appContext.Downloads.PrepareDownload(this, StorageType.VideoLibrary);
        }

        protected StorageType DefaultStorage = StorageType.VideoLibrary;

        public virtual async Task StartDownload(bool transcode, StorageType storage, string name, int audioTrack, int subtitleTrack)
        {
            var extension = System.IO.Path.GetExtension(Path);
            
            var download = new DownloadDefinition()
            {
                Path = Path,
                Label = name,
                Filename = name + extension,
                Storage = storage,
                Transcode = transcode,
                Username = _appContext.Settings.User,
                Password = _appContext.Settings.Password,
                AudioTrack=audioTrack,
                SubtitleTrack=subtitleTrack,
            };

            await _appContext.Downloads.AddDownload(download);
            _appContext.View.GotoDownloads();
        }

        public virtual string GetDownloadName()
        {
            return System.IO.Path.GetFileNameWithoutExtension(Path);
        }


        protected virtual void PlayExecute()
        {
            _appContext.View.GotoCurrentPlaying();
        }

        private bool? _isOffline;
        public bool IsOffline
        {
            get
            {
                if (_isOffline == null)
                {
                    _isOffline = false;
                    CalcAvailability();
                }
                return _isOffline.GetValueOrDefault(true);

            }
            private set {
                if (SetProperty(ref _isOffline, value))
                {
                    RefreshDependentCommands();
                } }
        }

        private void RefreshDependentCommands()
        {
            ((DelegateCommand)Play).NotifyCanExecuteChanged();
            ((DelegateCommand)PlayToSelection).NotifyCanExecuteChanged();
            ((DelegateCommand)PrepareDownload).NotifyCanExecuteChanged();
        }

        private async Task CalcAvailability()
        {
            IsOffline = await CalcAvailability(_appContext, Path);
        }
        public static async Task<bool> CalcAvailability(IAppContext appContext, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return false;
            }          
            if (path.EndsWith("\\"))
            {
                return false;
                
            }
            if (path.EndsWith(".disc"))
            {
                return true;
            }
            try
            {
                await appContext.XBMC.Files.GetFileDetails(path, Media.files);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool IsWatched
        {
            get
            {
                return WatchedCheck;
            }
            set
            {
                if (SetProperty(ref _watchedCheck, value))
                {
                    SetWatched(value);
                    OnPropertyChanged("WatchedCheck");
                }
            }
        }

        public ICommand Play { get; private set; }
        public ICommand PlayToSelection { get; private set; }
        public ICommand PrepareDownload { get; private set; }
        public DelegateCommand ToWatchlist { get; protected set; }
        public DelegateCommand FromWatchlist { get; protected set; }

        public string Path { get; protected set; }

        protected abstract void SetWatched(bool value);

        public PlayToVm[] GetPlayToTargets()
        {
            var local = new PlayToVm[] {new PlayToLocalVm(this),};
            return local.Concat(_appContext.Upnp.AvailableRenderDevices.Select(r=>new PlayToVm(this, r))).ToArray();
        }

        public async void PlayTo(MediaRendererDevice renderer)
        {
            await _appContext.Upnp.PlayItem(this, renderer);
            _appContext.View.GotoCurrentPlaying();
        }
        public async void PlayToLocal()
        {
            var fileInfo = await _appContext.XBMC.Files.GetFileDetails(Path, Media.video, Files.AllFields());
            var uri = await _appContext.Upnp.GetPlaybackUri(this);

            

            await _appContext.PlatformServices.Launcher.LaunchUriAsync(new Uri(uri), fileInfo.filedetails.mimetype);
            //_appContext.View.PlayMedia(uri, fileInfo.filedetails.mimetype);
            //_appContext.View.GotoCurrentPlaying();
        }
    }
}