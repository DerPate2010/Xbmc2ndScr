using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okra.Core;
using XBMCRPC.Playlist;
using XBMCRPC.Video.Details;
using Xbmc2S.Model.Download;

namespace Xbmc2S.Model
{
    public class EpisodeVm:PlayableItemVm, IItemDetails
    {
        private readonly Episode _episode;
        private readonly IAppContext _appContext;
        private readonly SeasonVm _seasonVm;
        private IEnumerable<ICastVm> _cast;

        public EpisodeVm(Episode episode, IAppContext appContext, SeasonVm seasonVm) : this(episode, appContext)
        {
            _seasonVm = seasonVm;
            ParentLabel = seasonVm.Label;
        }

        public EpisodeVm(Episode episode, IAppContext appContext):base(episode,appContext)
        {
            _episode = episode;
            _appContext = appContext;

            Number = episode.episode;
            Label= episode.title;
            SecondLabel = episode.season + "x" + episode.episode.ToString("d2");
            Content= episode.plot;
            Path = episode.file;
            Id = episode.episodeid;
            OriginalTitle = _episode.originaltitle;
            FirstAired = _episode.firstaired;
            DateTime dt;
            if (DateTime.TryParse(FirstAired, out dt))
            {
                Year = dt.Year;
            }
            Runtime = _episode.runtime;
            Rating = _episode.rating;
            RatingBase5 = _episode.rating/2;
            Writer = string.Join(", ", _episode.writer);
            Director = string.Join(", ", _episode.director);
        }

        public string ParentLabel { get; private set; }

        public int Number { get; private set; }

        public string FirstAired { get; set; }
        public int Runtime { get; private set; }
        public int Year { get; private set; }
        public string Content { get; private set; }

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
            _cast = _episode.cast.Select(c => new CastVm(c, _appContext));
        }
        public string Genre { get { return _seasonVm.Genre; }}
        public string Country { get { return _seasonVm.Country; } }
        public string OriginalTitle { get; private set; }
        public double Rating { get; private set; }
        public double RatingBase5 { get; set; }
        public string Studio { get { return _seasonVm.Studio; } }
        public string Writer { get; private set; }
        public string Director { get; private set; }
        public string Trailer { get { return _seasonVm.Trailer; } }
        public DelegateCommand PlayTrailer { get { return _seasonVm.PlayTrailer; } }

        public void GoTo()
        {
            _appContext.View.GotoEpisode(GetRef());
        }


        public string GetRef()
        {
            return GetRef(_episode.tvshowid , _episode.season,  _episode.episodeid);
        }

        public override string GetDownloadName()
        {
            return _episode.showtitle + " " + SecondLabel;
        }

        protected override async void PlayExecute()
        {
            await _appContext.XBMC.Player.Open(new ItemEpisodeid() { episodeid = _episode.episodeid }, null);
            base.PlayExecute();
        }

        protected override async void SetWatched(bool value)
        {
            await _appContext.XBMC.VideoLibrary.SetEpisodeDetails(_episode.episodeid, playcount: value ? 1 : 0);
            _seasonVm.ItemWatchedChanged(value);
        }

        public static string GetRef(int tvshowid, int season, int episode)
        {
            return tvshowid + "_" + season + "_" + episode;
        }
    }
}