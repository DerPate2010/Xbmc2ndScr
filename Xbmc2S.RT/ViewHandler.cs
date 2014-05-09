using System;
using System.Globalization;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xbmc2S.Model;
using Xbmc2S.Model.Download;
using Xbmc2S.RT.WelcomeWizard;

namespace Xbmc2S.RT
{
    internal class ViewHandler : IView
    {

        public void GotoDownloads()
        {
            Navigate(typeof(DownloadsPage));
        }

        public void GotoCurrentPlaying()
        {
            Navigate(typeof(HubPage));
        }

        public void GotoHome()
        {
            Navigate(typeof(HubPage));
        }
        public void GotoWelcomeWizard()
        {
            Navigate(typeof(Welcome1));
        }
        
        public void GotoMovies(ItemsSourceReference itemsReference)
        {
            Navigate(typeof(MovieOverviewPage), itemsReference.ToString());
        }
        public void GotoTvShows()
        {
            Navigate(typeof(TvShowsPage));
        }
        public void GotoMusic()
        {
            App.MainVm.ResetMusic();
            Navigate(typeof(MusicArtistsPage));
        }
        public void GotoPeople()
        {
        }


        public CultureInfo PreferedCulture { get; private set; }
        public void GotoMovie(ItemsSourceReference itemsReference)
        {
            Navigate(typeof(GeneralDetailPage), itemsReference.ToString());
        }

        public void GotoSeason(string itemsReference)
        {
            Navigate(typeof(SeasonOverviewPage), itemsReference);
        }

        public void GotoEpisode(string episodeRef)
        {
            Navigate(typeof(EpisodeDetailPage), episodeRef);
        }

        public void GotoAlbum(int albumid)
        {
            Navigate(typeof(AlbumPage), albumid);
        }

        public void PrepareDownload(StartDownloadVm startDownloadVm)
        {
            StartDownloadVm.Current = startDownloadVm;
            Navigate(typeof(StartDownloadPage));
        }

        public  void ErrorMessage(string message)
        {
            MessageDialog dlg = new MessageDialog(message, "Error");
             dlg.ShowAsync();

        }


        public ViewHandler()
        {
            var uiCultureCode = Windows.System.UserProfile.GlobalizationPreferences.Languages.FirstOrDefault();
            if (uiCultureCode == null)
            {
                uiCultureCode = "en-US";
            }
            PreferedCulture = new CultureInfo(uiCultureCode);
        }

        private void Navigate(Type pageType, object navigationParameter=null)
        {

            if (App.RootFrame != null)
            {
                App.RootFrame.Navigate(pageType, navigationParameter);
            }
        }
    }
}