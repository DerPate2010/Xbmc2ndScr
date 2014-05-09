using System;
using System.Globalization;
using Xbmc2S.Model.Download;

namespace Xbmc2S.Model
{
    public interface IView
    {
        void GotoDownloads();
        void GotoCurrentPlaying();
        void GotoHome();
        void GotoMovies(ItemsSourceReference itemsReference);
        void GotoTvShows();
        void GotoMusic();
        void GotoPeople();
        CultureInfo PreferedCulture { get; }
        void GotoMovie(ItemsSourceReference itemsReference);
        void GotoSeason(string itemsReference);
        void GotoEpisode(string episodeRef);
        void GotoAlbum(int albumid);
        void PrepareDownload(StartDownloadVm startDownloadVm);
        void ErrorMessage(string message);
        void GotoWelcomeWizard();
    }
}