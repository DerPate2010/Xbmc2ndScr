using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Xbmc2S.Model;
using Xbmc2S.RT.Common;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace Xbmc2S.RT
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class MusicArtistsPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public MusicArtistsPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }


        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            this.DefaultViewModel["Items"] = App.MainVm.MusicArtistSource.VirtualizingDataList;
        }

        private void ItemGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(MusicArtistPage), ((ArtistVm)e.ClickedItem).ID);
        }
    }
}
