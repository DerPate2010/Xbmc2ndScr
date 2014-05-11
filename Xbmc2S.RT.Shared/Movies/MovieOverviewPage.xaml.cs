using System.Collections.Specialized;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Xbmc2S.Model;
using Xbmc2S.RT.Common;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace Xbmc2S.RT
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class MovieOverviewPage : Page
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

        public MovieOverviewPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            navigationHelper.SaveState += navigationHelper_SaveState;
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
            object stateRepresentation;
            if (e.PageState == null || !e.PageState.TryGetValue(StateKey, out stateRepresentation))
            {
                stateRepresentation = ItemsSourceReference.Parse(e.NavigationParameter);
            }
            LoadState(stateRepresentation);
        }

        private void LoadState(object stateRepresentation)
        {


            MovieSource = App.MainVm.GetMovieSource(stateRepresentation);


            if (MovieSource is WatchlistMovieSource)
            {
                WatchlistHelp.Visibility = Visibility.Visible;
            }

            this.DefaultViewModel["Movies"] = MovieSource;
            this.DefaultViewModel["Caption"] = MovieSource.Caption;

            MovieGrid.ItemsSource = MovieSource;

            Dispatcher.RunIdleAsync((s) =>
            {
                if (MovieSource.Selected != null)
                {
                    MovieGrid.ScrollIntoView(MovieSource.Selected);
                }
            });

            this.DefaultViewModel["Groups"] = "#abcdefghijklmnopqrstuvwxyz".ToCharArray();
            this.DefaultViewModel["Settings"] = App.MainVm.Settings;
        }

        protected IItemsSource MovieSource { get; set; }

        void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            e.PageState[StateKey] = MovieSource.GetStateRepresentation();
        }

        private const string StateKey = "SourceState";

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            LoadState(MovieSource.GetStateRepresentation());
        }

        private void ShowAppBar(object sender, RoutedEventArgs e)
        {
            OpenAppBars(this);


        }



        internal static void OpenAppBars(Page page)
        {
            OpenAppBar(page.BottomAppBar);
            OpenAppBar(page.TopAppBar);
        }

        private static void OpenAppBar(AppBar appBar)
        {
            if (appBar != null && !appBar.IsOpen)
            {
                appBar.IsOpen = true;
            }
        }
    }
}
