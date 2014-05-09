using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBMCRPC.Audio.Fields;
using XBMCRPC.Methods;
using XBMCRPC.Video.Fields;
using Xbmc2S.RT.Common;

namespace Xbmc2S.RT.Model
{
    class MainVm:BindableBase
    {
        public static MainVm Current = new MainVm();
        private ServerInfo _server;
        private MovieSource _movieSource;
        private TvShowSource _tvShowSource;
        private MusicArtistSource _musicArtistSource;


        public MovieSource MovieSource
        {
            get { return _movieSource; }
            set { _movieSource = value; OnPropertyChanged(); }
        }

        public List<GroupBase> Items { get; set; }

        public MainVm()
        {
            _server = new ServerInfo();
            ResetMovies();
            MovieGroup=new MovieGroup(_server) {Title = "Movies"};
            PeopleGroup=new PeopleGroup(_server) {Title = "People"};
            TvGroup=new TVGroup(_server) {Title = "TV Shows"};
            MusicGroup=new MusicGroup(_server) {Title = "Music"};

            Items= new List<GroupBase>()
                {
                    MovieGroup, TvGroup,MusicGroup, PeopleGroup
                };
        }

        public PeopleGroup PeopleGroup { get; set; }

        public  MusicGroup MusicGroup { get; set; }

        public TVGroup TvGroup { get; set; }

        public MovieGroup MovieGroup { get; set; }

        public TvShowSource TvShowSource
        {
            get { return _tvShowSource; }
            set { _tvShowSource = value; OnPropertyChanged(); }
        }

        public MusicArtistSource MusicArtistSource
        {
            get { return _musicArtistSource; }
            set { _musicArtistSource = value; OnPropertyChanged();}
        }

        public void Search(string query)
        {
            MovieSource=new TitleMovieSource(_server,query);
        }


        public async Task<CurrentPlaybackVm> GetCurrentPlayingItem()
        {
            return new CurrentPlaybackVm(_server);
        }

        public void Search(CastVm castItem)
        {
            MovieSource = new CastMovieSource(_server,castItem.Name);
        }

        public void ResetMovies(bool force=false)
        {
            if (force||!(MovieSource is AllMovieSource))
            {
                MovieSource = new AllMovieSource(_server); 
            }
        }    
        public void ResetTv()
        {
            if (TvShowSource == null)
            {
                TvShowSource = new TvShowSource(_server);
            }
        }
        public void ResetMusic()
        {
            if (MusicArtistSource == null)
            {
                MusicArtistSource = new MusicArtistSource(_server);
            }
        }

        public void DirectToMovie(int clickedItem)
        {
            MovieSource = new IdMovieSource(_server, clickedItem);
        }

        public async Task<List<SeasonVm>> GetTVShowSeasons(int tvshowid)
        {
            //var ep = await _server.XBMC.VideoLibrary.GetEpisodes(2, 1, Episode.AllFields());
            var seasons = await _server.XBMC.VideoLibrary.GetSeasons(tvshowid,Season.AllFields());
            
            return seasons.seasons.OrderBy(s=>s.season).Select(SeasonFactory).ToList();
        }

        private SeasonVm SeasonFactory(XBMCRPC.Video.Details.Season arg)
        {
            return new SeasonVm(arg,_server);
        }

        public async Task<TVShowVm> GetTVShow(int tvshowid)
        {
            var tvshow = await _server.XBMC.VideoLibrary.GetTVShowDetails(tvshowid, TVShow.AllFields());
            return new TVShowVm(tvshow.tvshowdetails, _server, false);
        }

        public async Task<List<EpisodeVm>> GetTVShowEpisodes(int tvshowid, int season)
        {
            var episodes = await _server.XBMC.VideoLibrary.GetEpisodes(tvshowid,season,Episode.AllFields());
            return episodes.episodes.OrderBy(e=>e.episode).Select(EpisodeFactory).ToList();
        }

        private EpisodeVm EpisodeFactory(XBMCRPC.Video.Details.Episode arg)
        {
            return new EpisodeVm(arg,_server);
        }

        public AlbumSource GetAlbums(int artistId)
        {
            return new AlbumSource(_server, artistId);
        }

        public async Task<List<SongVm>> GetSongs(int albumId)
        {
            var songs= await _server.XBMC.AudioLibrary.GetSongs2(Song.AllFields(),
                                                filter: new AudioLibrary.GetSongsfilter5() {albumid = albumId});
            return songs.songs.OrderBy(e => e.track).Select(SongFactory).ToList();
        }

        private SongVm SongFactory(XBMCRPC.Audio.Details.Song arg)
        {
            return new SongVm(arg,_server);
        }

        public async Task<AlbumVm> GetAlbum(int albumId)
        {
            var album = await _server.XBMC.AudioLibrary.GetAlbumDetails(albumId, Album.AllFields());
            return new AlbumVm(album.albumdetails, _server);
        }

        public async Task<ArtistVm> GetArtist(int artistId)
        {
            var artist = await _server.XBMC.AudioLibrary.GetArtistDetails(artistId, Artist.AllFields());
            return new ArtistVm(artist.artistdetails, _server);
        }
    }

}