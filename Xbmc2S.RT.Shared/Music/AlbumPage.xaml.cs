using System;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Xbmc2S.Model;
using Xbmc2S.RT.Common;

// The Group Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234229

namespace Xbmc2S.RT
{
    /// <summary>
    /// A page that displays an overview of a single group, including a preview of the items
    /// within the group.
    /// </summary>
    public sealed partial class AlbumPage : Page
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


        public AlbumPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            Window.Current.SizeChanged += WindowSizeChanged;
            AdaptWindowSize();
        }

        private void WindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            AdaptWindowSize();
        }

        private void AdaptWindowSize()
        {
            if (Window.Current.Bounds.Width < 768)
            {
                VisualStateManager.GoToState(this, "Narrow", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "Normal", true);
            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }


        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var albumID = (int) e.NavigationParameter;
            var album = await App.MainVm.GetAlbum(albumID);
            var songs = await album.GetSongs();

            DefaultViewModel["Group"] = album;
            this.DefaultViewModel["Items"] = songs;
        }

        private void ItemGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var track = (SongVm) e.ClickedItem;
            if (track.Play.CanExecute(null))
            {
                track.Play.Execute(null);
            }
        }
    }
}
