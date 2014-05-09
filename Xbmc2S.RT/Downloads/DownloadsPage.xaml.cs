using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xbmc2S.Model.Download;
// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233
using Xbmc2S.RT.Common;

namespace Xbmc2S.RT
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class DownloadsPage : Page, IDownloadView
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

        private DownloadsVm _downloads;

        public DownloadsPage()
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
            var downloads = App.MainVm.GetDownloads();
            _downloads = new DownloadsVm(this, downloads);
            DataContext = _downloads;
        }

        public IEnumerable<DownloadItem> SelectedItems { get { return itemGridView.SelectedItems.Cast<DownloadItem>(); } }

        public void SelectAll()
        {
            itemGridView.SelectAll();
        }

        private void ItemGridView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemGridView.SelectedItems.Count > 0)
            {
                BottomAppBar.IsOpen = true;
            }
            else
            {
                BottomAppBar.IsOpen = false;
            }
            _downloads.NotifySelectionChanged();
        }

        public void ClearSelection()
        {
            itemGridView.SelectedIndex = -1;
        }

        private void ShowAppBar(object sender, RoutedEventArgs e)
        {
            MovieOverviewPage.OpenAppBars(this);
        }
    }
}
