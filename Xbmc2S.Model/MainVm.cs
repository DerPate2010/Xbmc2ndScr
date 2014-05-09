using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Okra.Core;
using TmdbWrapper;
using XBMCRPC.Audio.Fields;
using XBMCRPC.Files;
using XBMCRPC.List;
using XBMCRPC.List.Fields;
using XBMCRPC.List.Item;
using XBMCRPC.List.Items;
using XBMCRPC.Playlist;
using XBMCRPC.Video.Fields;
using Xbmc2S.Model.Download;
using Xbmc2S.RT.UPnP;
using Files = XBMCRPC.Methods.Files;

namespace Xbmc2S.Model
{
    public class MainVm:BindableBase
    {
        internal IPlatformServices PlatformServices { get; private set; }
        private AppContext _appContext;
        private TvShowSource _tvShowSource;
        private MusicArtistSource _musicArtistSource;
        private TVShowVm _lastTvShow;

        public SettingsVm Settings { get { return _appContext.Settings; } }


        public LibraryManager LibraryManager { get; private set; }

        public MainVm(IPlatformServices platformServices, IView view)
        {
            PlatformServices = platformServices;
            _appContext = new AppContext(PlatformServices, view);

            _appContext.Settings.SettingsChanged += Settings_SettingsChanged;

            InitHomePageGroups();

            LibraryManager= new LibraryManager(_appContext);
        }

        void Settings_SettingsChanged(object sender, EventArgs e)
        {
            _sourcesCache.Clear();
            InitHomePageGroups();
        }

        private void InitHomePageGroups()
        {
            MovieGroup = new MovieGroup(_appContext) {Title = "Movies"};
            PeopleGroup = new PeopleGroup(_appContext) {Title = "People"};
            TvGroup = new TVGroup(_appContext) {Title = "TV Shows"};
            MusicGroup = new MusicGroup(_appContext) {Title = "Music"};
        }

        public PeopleGroup PeopleGroup
        {
            get { return _peopleGroup; }
            set { SetProperty(ref _peopleGroup, value); }
        }

        public  MusicGroup MusicGroup
        {
            get { return _musicGroup; }
            set { SetProperty(ref _musicGroup, value); }
        }

        public TVGroup TvGroup
        {
            get { return _tvGroup; }
            set { SetProperty(ref _tvGroup, value); }
        }

        public MovieGroup MovieGroup
        {
            get { return _movieGroup; }
            set { SetProperty(ref _movieGroup, value); }
        }

        public MusicArtistSource MusicArtistSource
        {
            get { return _musicArtistSource; }
            set { _musicArtistSource = value; OnPropertyChanged();}
        }

        public RemoteVm RemoteControl
        {
            get
            {
                if (_remoteControl == null)
                {
                    _remoteControl= new RemoteVm(_appContext);
                }
                return _remoteControl;
            }
        }


        public CurrentConnectionVm CurrentConnection
        {
            get
            {
                if (_currentConnection == null)
                {
                    _currentConnection = new CurrentConnectionVm(_appContext);
                }
                return _currentConnection;
            }
        }

        public WatchListVm GetWatchList(IWatchListView view)
        {
            //return new WatchListVm(view, _appContext.WatchList);
            throw new NotSupportedException();
        }

        private Dictionary<ItemsSourceReference, IItemsSource> _sourcesCache = new Dictionary<ItemsSourceReference, IItemsSource>(new ItemSourceRefComparer());
        private MovieGroup _movieGroup;
        private TVGroup _tvGroup;
        private MusicGroup _musicGroup;
        private PeopleGroup _peopleGroup;
        private List<GroupBase> _items;
        private RemoteVm _remoteControl;
        private CurrentConnectionVm _currentConnection;

        public IItemsSource GetMovieSource(ItemsSourceReference itemsSourceReference = null)
        {
            IItemsSource itemsSource=null;
            if (itemsSourceReference != null)
            {
                
                ItemsSourceReference current=null;
                if (_sourcesCache.TryGetValue(itemsSourceReference, out itemsSource))
                {
                    current = itemsSource.GetStateRepresentation();
                }
                if (!itemsSourceReference.Equals(current))
                {
                    switch (itemsSourceReference.Type)
                    {
                        case ItemsSourceType.Movie:
                            switch (itemsSourceReference.Filter)
                            {
                                case ItemsSourceFilter.All:
                                    itemsSource = new AllMovieSource(_appContext); 
                                    break;
                                case ItemsSourceFilter.Cast:
                                    itemsSource = new CastMovieSource(_appContext, itemsSourceReference.Param);
                                    break;
                                case ItemsSourceFilter.Id:
                                    itemsSource = new IdMovieSource(_appContext, int.Parse(itemsSourceReference.Param));
                                    break;
                                case ItemsSourceFilter.Title:
                                    itemsSource = new TitleMovieSource(_appContext, itemsSourceReference.Param);
                                    break;
                                case ItemsSourceFilter.FullText:
                                    itemsSource = new FullTextMovieSource(_appContext, itemsSourceReference.Param);
                                    break;
                            }
                            break;
                        case ItemsSourceType.Episode:
                            switch (itemsSourceReference.Filter)
                            {
                                case ItemsSourceFilter.Cast:
                                    itemsSource = new CastEpisodesSource(_appContext, itemsSourceReference.Param);
                                    break;
                            }
                            break;
                        case ItemsSourceType.TVShow:
                            switch (itemsSourceReference.Filter)
                            {
                                case ItemsSourceFilter.Title:
                                    itemsSource = new TitleTVShowSource(_appContext,itemsSourceReference.Param);
                                    break;
                                case ItemsSourceFilter.Cast:
                                    itemsSource = new CastTTVShowSource(_appContext,itemsSourceReference.Param);
                                    break;
                                case ItemsSourceFilter.All:
                                    itemsSource = new TvShowSource(_appContext);
                                    break;
                                case ItemsSourceFilter.Id:
                                    itemsSource = new TvShowIdSource(_appContext, int.Parse(itemsSourceReference.Param));
                                    break;
                            }
                            break;
                        case ItemsSourceType.WatchList:
                            switch (itemsSourceReference.Filter)
                            {
                                case ItemsSourceFilter.All:
                                    itemsSource = new WatchlistMovieSource(_appContext); 
                                    break;
                            }
                            break;
                        case ItemsSourceType.Season:
                            switch (itemsSourceReference.Filter)
                            {
                                case ItemsSourceFilter.All:
                                    itemsSource = new WatchlistMovieSource(_appContext); 
                                    break;
                            }
                            break;
                        case ItemsSourceType.Extern:
                            switch (itemsSourceReference.Filter)
                            {
                                case ItemsSourceFilter.Cast:
                                    itemsSource = new CastTmdbResult(itemsSourceReference.Param);
                                    break;
                                case ItemsSourceFilter.Title:
                                    itemsSource = new TmdbResult(itemsSourceReference.Param);
                                    break;
                            }
                            break;
                    }
                }
                _sourcesCache[itemsSourceReference] = itemsSource;
                current = itemsSource.GetStateRepresentation();
                if ((itemsSource.Selected==null ||
                    itemsSourceReference.Selection != current.Selection) && 
                    itemsSourceReference.Selection>=0)
                {
                    itemsSource.RestoreSelection(itemsSourceReference.Selection);
                }
            }
            if (itemsSource == null)
            {
                itemsSource = new AllMovieSource(_appContext); 
            }
            return itemsSource;
        }
        
        public async Task<CurrentPlaybackVm> GetCurrentPlayingItem()
        {
            return new CurrentPlaybackVm(_appContext);
        }

        public PersonVm SearchPerson(string name)
        {
            var person = new PersonVm(name);
            var movieRef = new ItemsSourceReference() { Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.Cast, Param = name };
            person.Movies= GetMovieSource(movieRef);
            movieRef = new ItemsSourceReference() { Type = ItemsSourceType.Episode, Filter = ItemsSourceFilter.Cast, Param = name }; 
            person.Episodes= GetMovieSource(movieRef);
            movieRef = new ItemsSourceReference() { Type = ItemsSourceType.TVShow, Filter = ItemsSourceFilter.Cast, Param = name }; 
            person.TVShows= GetMovieSource(movieRef);
            movieRef = new ItemsSourceReference() { Type = ItemsSourceType.Extern, Filter = ItemsSourceFilter.Cast, Param = name };
            person.External = GetMovieSource(movieRef);
            return person;
        }

        public void ResetMusic()
        {
            if (MusicArtistSource == null)
            {
                MusicArtistSource = new MusicArtistSource(_appContext);
            }
        }

        public async Task<TVShowVm> GetTVShow(int tvshowid)
        {
            if (_lastTvShow != null && _lastTvShow.ID == tvshowid)
            {
                return _lastTvShow;
            }
            var tvshow = await _appContext.XBMC.VideoLibrary.GetTVShowDetails(tvshowid, TVShow.AllFields());
            _lastTvShow = new TVShowVm(tvshow.tvshowdetails, _appContext, false);
            return _lastTvShow ;
        }

        public AlbumSource GetAlbums(int artistId)
        {
            return new AlbumSource(_appContext, artistId);
        }

        public async Task<AlbumVm> GetAlbum(int albumId)
        {
            var album = await _appContext.XBMC.AudioLibrary.GetAlbumDetails(albumId, Album.AllFields());
            return new AlbumVm(album.albumdetails, _appContext);
        }

        public async Task<ArtistVm> GetArtist(int artistId)
        {
            var artist = await _appContext.XBMC.AudioLibrary.GetArtistDetails(artistId, Artist.AllFields());
            return new ArtistVm(artist.artistdetails, _appContext);
        }

        public IDownloadManager GetDownloads()
        {
            return _appContext.Downloads;
        }

        public Task Suspend()
        {
            return _appContext.Downloads.PersistDownloads();
        }

        public Task<int> GetSearchFullCount(string query)
        {
            return FullTextMovieSource.GetResultCount(_appContext, query);
        }

        public void GotoAllMovies()
        {
            var movieRef = new ItemsSourceReference() {Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.All};
            _appContext.View.GotoMovies(movieRef);
        }

        public void GoTo(MovieVm clickedItem)
        {
            var movieRef = new ItemsSourceReference() { Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.Id, Param = clickedItem.Id.ToString()};
            _appContext.View.GotoMovie(movieRef);
        }

        public IItemsSource GetMovieSource(object movieSourceRef)
        {
            return GetMovieSource(movieSourceRef as ItemsSourceReference);
        }

        public IItemsSource SearchFullText(string query)
        {
            var movieRef = new ItemsSourceReference() { Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.FullText, Param = query};
            return GetMovieSource(movieRef);
        }

        public IItemsSource SearchTitle(string query)
        {
            var movieRef = new ItemsSourceReference() { Type = ItemsSourceType.Movie, Filter = ItemsSourceFilter.Title, Param = query };
            return GetMovieSource(movieRef);
        }

        public void GotoWatchList()
        {
            var movieRef = new ItemsSourceReference() { Type = ItemsSourceType.WatchList, Filter = ItemsSourceFilter.All};
            _appContext.View.GotoMovies(movieRef);
        }

        public IItemsSource SearchExtern(string query)
        {
            var movieRef = new ItemsSourceReference() { Type = ItemsSourceType.Extern, Filter = ItemsSourceFilter.Title, Param = query };
            return GetMovieSource(movieRef);
        }

        public IItemsSource SearchShow(string query)
        {
            var movieRef = new ItemsSourceReference() { Type = ItemsSourceType.TVShow, Filter = ItemsSourceFilter.Title, Param = query };
            return GetMovieSource(movieRef);
        }

        public async Task<DirectoryInfo> GetDirectory(Media mediaType)
        {
            var sources = await _appContext.XBMC.Files.GetSources(mediaType,sort: new Sort(){method = Sort_method.label, order = Sort_order.@ascending});
            var di = DirectoryInfo.GetRootDirectoryInfo();
            if (sources.sources == null) return di;

            di.Items = sources.sources.Select(s => new DirectoryInfo(s)).ToList<DirectoryItem>();
            return di;
        }

        public async Task<DirectoryInfo> GetDirectory(string path, Media mediaType)
        {
            var content = await _appContext.XBMC.Files.GetDirectory(path, mediaType, properties: new XBMCRPC.List.Fields.Files()
            {
                FilesItem.title
            }, sort: new Sort() { method = Sort_method.label, order = Sort_order.@ascending });
            var di = new DirectoryInfo(path,content);
            return di;
        }

        public async Task<FileInfo> GetFileDetails(string path, Media mediaType)
        {
            var file = await _appContext.XBMC.Files.GetFileDetails(path, mediaType, XBMCRPC.List.Fields.Files.AllFields());
            
            return new FileInfo(file.filedetails, _appContext);
        }


        public async Task GetUnlistedFiles(IList<string> listToFill, Media mediaType = Media.video)
        {
            var sources = await _appContext.XBMC.Files.GetSources(mediaType);
            foreach (var source in sources.sources)
            {
                await GetUnlistedFiles(listToFill, mediaType, source.file);
            }
        }

        public async Task GetUnlistedFiles(IList<string> listToFill, Media mediaType, string directory)
        {

            GetDirectoryResponse files;
            try
            {
                files = await _appContext.XBMC.Files.GetDirectory(directory, mediaType, new XBMCRPC.List.Fields.Files() { FilesItem.mimetype });
            }
            catch (Exception ex)
            {
                return;
            }


            if (files.files != null)
            {
                foreach (var file in files.files)
                {
                    if (file.filetype == File_filetype.directory)
                    {
                        await GetUnlistedFiles(listToFill, mediaType, file.file);
                    }
                    else
                    {
                        if (file.id == 0)
                        {
                            listToFill.Add(file.file);
                        }
                    }
                }
            }
            
        }

        public async Task GoTo(ItemsSourceReference itemsSourceReference)
        {
            switch (itemsSourceReference.Type)
            {
                case ItemsSourceType.Episode:
                    var episode = await
                        _appContext.XBMC.VideoLibrary.GetEpisodeDetails(Convert.ToInt32(itemsSourceReference.Param),
                            Episode.AllFields());
                    var vm = new EpisodeVm(episode.episodedetails, _appContext);

                    vm.GoTo();
                    break;
                case ItemsSourceType.Movie:
                    _appContext.View.GotoMovie(itemsSourceReference);
                    break;
            }
        }


    }


    public abstract class DirectoryItem
    {
        public string Label { get; protected set; }
        public string Path { get; protected set; }

        protected DirectoryItem(string label, string path)
        {
            Label = label;
            Path = path;
        }
        protected DirectoryItem(File file)
        {
            var baseFile = file.AsMediaDetailsBase;
            if (baseFile != null)
            {
                if (string.IsNullOrEmpty(file.AsVideoDetailsFile.title))
                {
                    if (string.IsNullOrEmpty(file.AsAudioDetailsMedia.title))
                    {
                        Label = baseFile.label;
                    }
                    else
                    {
                        Label = file.AsAudioDetailsMedia.title;
                    }
                }
                else
                {
                    Label = file.AsVideoDetailsFile.title;
                }
            }
            else
            {
                Label = System.IO.Path.GetFileName(file.file.TrimEnd('\\', '/'));
            }
            Path = file.file;
        }
    }

    public class DirectoryInfo:DirectoryItem
    {
        public DirectoryInfo(File file)
            : base(file)
        {
            Path = System.IO.Path.GetDirectoryName(file.file);
        }

        private DirectoryInfo(string label) : base(label, string.Empty)
        {
        }

        public DirectoryInfo(SourcesItem sourcesItem) : base(sourcesItem.label, sourcesItem.file)
        {
            
        }

        public DirectoryInfo(string path, GetDirectoryResponse getDirectoryResponse)
            : base(System.IO.Path.GetFileName(path), path)
        {
            if (getDirectoryResponse.files != null)
            {
                Items = getDirectoryResponse.files.Select(GetDirItem).ToList();
            }
        }

        private DirectoryItem GetDirItem(File arg)
        {
            if (arg.filetype == File_filetype.directory)
            {
                return new DirectoryInfo(arg);
            }
            return new FileInfo(arg);
        }

        public static DirectoryInfo GetRootDirectoryInfo()
        {
            return new DirectoryInfo("Root");
        }

        public List<FileInfo> Files { get; set; }
        public List<DirectoryInfo> Directories { get; set; }
        public List<DirectoryItem> Items { get; set; }

    }

    public class FileInfo : DirectoryItem, IItemDetails
    {

        public FileInfo(File file):base(file)
        {
            switch (file.type)
            {
                case Base_type.movie: 
                    Type=ItemsSourceType.Movie;
                    break;
                case Base_type.episode: 
                    Type=ItemsSourceType.Episode;
                    break;
            }
            Id = file.id;
        }

        public bool TryGetLibraryRef(out ItemsSourceReference reference)
        {
            if (Type != null && Id > 0)
            {
                reference = new ItemsSourceReference(Type.Value, Id);
                return true;
            }
            reference = null;
            return false;
        }

        public ItemsSourceType? Type { get; set; }

        public FileInfo(File filedetails, IAppContext appContext) : this(filedetails)
        {


            Size = filedetails.size;
            Modified = filedetails.lastmodified;
            MimeType = filedetails.mimetype;
            SecondLabel = filedetails.tagline;

            var file = filedetails.AsMediaDetailsBase;
            if (file != null)
            {
                Images = new VideoImages(appContext, file);

            }
            var media = filedetails.AsMediaDetailsBase;
            if (media != null)
            {
                Images = new VideoImages(appContext, media);
            }

            Play = new PlayFileCommand(appContext, Path);
        }

        public string MimeType { get; set; }

        public string Modified { get; set; }

        public int Size { get; set; }

        public class PlayFileCommand : ICommand
        {
            private readonly IAppContext _appContext;
            private readonly string _path;

            public PlayFileCommand(IAppContext appContext, string path)
            {
                _appContext = appContext;
                _path = path;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public async void Execute(object parameter)
            {
                await _appContext.XBMC.Player.Open(new ItemFile() { file = _path});
                _appContext.View.GotoCurrentPlaying();
            }

            public event EventHandler CanExecuteChanged;
        }


        public int Runtime { get; private set; }
        public int Year { get; private set; }
        public string Content { get; private set; }
        public IEnumerable<ICastVm> Cast { get; private set; }
        public string Genre { get; private set; }
        public string Country { get; private set; }
        public string OriginalTitle { get; private set; }
        public double Rating { get; private set; }
        public double RatingBase5 { get; set; }
        public string Studio { get; private set; }
        public string Writer { get; private set; }
        public string Director { get; private set; }
        public string Trailer { get; private set; }
        public DelegateCommand PlayTrailer { get; private set; }
        public bool IsOffline { get; private set; }
        public bool IsWatched { get; set; }
        public ICommand Play { get; private set; }
        public ICommand PrepareDownload { get; private set; }
        public DelegateCommand ToWatchlist { get; private set; }
        public DelegateCommand FromWatchlist { get; private set; }

        public int Id { get; set; }
        public string SecondLabel { get; private set; }
        public void GoTo()
        {
            throw new NotImplementedException();
        }

        public VideoImages Images { get; private set; }
    }

    public class LibraryManager
    {
        private readonly AppContext _appContext;

        public LibraryManager(AppContext appContext)
        {
            _appContext = appContext;
            CleanVideoLib = new DelegateCommand(CleanVideoExecute);
            CleanAudioLib = new DelegateCommand(CleanAudioExecute);
            ScanVideoLib = new DelegateCommand(ScanVideoExecute);
            ScanAudioLib = new DelegateCommand(ScanAudioExecute);
        }

        private async void ScanAudioExecute()
        {
            try
            {
                await _appContext.XBMC.AudioLibrary.Scan();
            }
            catch (Exception)
            {
            }
            
        }

        private async void ScanVideoExecute()
        {
            try
            {
                await _appContext.XBMC.VideoLibrary.Scan();
            }
            catch (Exception)
            {
            }
        }

        private async void CleanAudioExecute()
        {

            try
            {
                await _appContext.XBMC.AudioLibrary.Clean();

            }
            catch (Exception)
            {
            }
        }

        private async void CleanVideoExecute()
        {
            try
            {
                await _appContext.XBMC.VideoLibrary.Clean();
            }
            catch (Exception)
            {
            }        }

        public ICommand CleanVideoLib { get; private set; }
        public ICommand CleanAudioLib { get; private set; }
        public ICommand ScanVideoLib { get; private set; }
        public ICommand ScanAudioLib { get; private set; }

    }

    public class PersonVm:BindableBase
    {
        private readonly string _name;
        public IItemsSource Movies { get; set; }

        private TmdbPerson _info;
        private Task _infoTask;

        public PersonVm(string name)
        {
            _name = name;
        }

        public TmdbPerson Info
        {
            get
            {
                if (_info == null && _infoTask == null)
                {
                    _infoTask = LoadInfoAsync();
                }
                return _info;
            }
            private set
            {
                if (Equals(value, _info)) return;
                _info = value;
                OnPropertyChanged();
            }
        }

        public IItemsSource Episodes { get; set; }

        public IItemsSource TVShows { get; set; }

        public IItemsSource External { get; set; }

        private async Task LoadInfoAsync()
        {
            var tmdbConfig = await TheMovieDb.GetConfiguration();
            var tmdbInfo = await TheMovieDb.SearchPersonAsync(_name);
            if (tmdbInfo.Results != null && tmdbInfo.Results.Count == 1)
            {
                var details = await tmdbInfo.Results[0].PersonAsync();
                Info = new TmdbPerson(tmdbConfig, details);
            }
        }


    }
}