using Xbmc2S.Model;
using Xbmc2S.RT.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233
using KODIRPC.Files;
using KODIRPC.List.Item;

namespace Xbmc2S.RT
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class FileBrowser : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private string navParam;

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

        public FileBrowser()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            navParam=e.NavigationParameter as string;
            DirectoryInfo dir;

            if (navParam != null)
            {
                dir = await App.MainVm.GetDirectory(navParam, Media.video);
                DefaultViewModel["Location"] = "in " + navParam;
            }
            else
            {
                dir = await App.MainVm.GetDirectory(Media.video);
            }


            DefaultViewModel["Items"] = dir.Items;

        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void ItemGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var directoryInfo = e.ClickedItem as DirectoryInfo;
            if (directoryInfo != null)
            {
                Frame.Navigate(typeof (FileBrowser), directoryInfo.Path);
            }

            var fileInfo = e.ClickedItem as FileInfo;
            if (fileInfo != null)
            {
                ItemsSourceReference reference;
                if (fileInfo.TryGetLibraryRef(out reference))
                {
                    await App.MainVm.GoTo(reference);
                }
                else
                {
                    Frame.Navigate(typeof(FileDetailPage), fileInfo.Path);
                }
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (MissingFilesPage), navParam);
        }

        private void ShowAppBar(object sender, RoutedEventArgs e)
        {
            MovieOverviewPage.OpenAppBars(this);
        }
    }
}
