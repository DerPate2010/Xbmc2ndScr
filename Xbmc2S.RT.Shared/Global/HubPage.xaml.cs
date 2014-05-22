using System.Threading.Tasks;
using System.Windows.Input;
using Windows.System;
using Microsoft.PlayerFramework;
using WinRTXamlToolkit.Controls.Extensions;
using Xbmc2S.Model;
using Xbmc2S.RT.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Hub Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=286574

namespace Xbmc2S.RT
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class HubPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private CurrentPlaybackVm _currentPlayingItem;

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

        public HubPage()
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
            await ConnectViewModel();
        }

        private async Task ConnectViewModel()
        {
            this.DefaultViewModel["Settings"] = App.MainVm.Settings;
            this.DefaultViewModel["MovieGroup"] = App.MainVm.MovieGroup;
            this.DefaultViewModel["TvGroup"] = App.MainVm.TvGroup;
            this.DefaultViewModel["MusicGroup"] = App.MainVm.MusicGroup;
            this.DefaultViewModel["PeopleGroup"] = App.MainVm.PeopleGroup;
            var advancedSteps = new List<AdvancedStep>()
            {
                new AdvancedStep(){ Header = "Show Files", Execute = ShowFiles},
                new AdvancedStep(){ Header = "Find files not in library", Execute = ShowMissingFiles},
            }; 
            AddAdvancedStepsPF(advancedSteps);
            advancedSteps.Add(new AdvancedStep(){ Header = "Vote for new features", Execute = GotoUserVoice});
            this.DefaultViewModel["AdvancedSteps"] = advancedSteps;
            DefaultViewModel["CurrentConnection"] = App.MainVm.CurrentConnection; 
            _currentPlayingItem = await App.MainVm.GetCurrentPlayingItem();
            DefaultViewModel["CurrentPlayingItem"] = _currentPlayingItem;
        }

        private void GotoUserVoice()
        {
            Launcher.LaunchUriAsync(new Uri("https://xbmc2screen.uservoice.com/"));
        }

        private void ShowSettings()
        {
#if !WINDOWS_PHONE_APP
            Windows.UI.ApplicationSettings.SettingsPane.Show();
#else
            Frame.Navigate(typeof(SettingsPage));
#endif
        }

        private void ShowMissingFiles()
        {
            Frame.Navigate(typeof(MissingFilesPage));
        }

        private void ShowFiles()
        {
            Frame.Navigate(typeof(FileBrowser));
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


        private void ItemGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is MovieVm)
            {
                App.MainVm.GoTo((MovieVm)e.ClickedItem);
            }
            if (e.ClickedItem is TVShowVm)
            {

                var iRef = new ItemsSourceReference(ItemsSourceType.TVShow, ((TVShowVm)e.ClickedItem).ID);
                this.Frame.Navigate(typeof(GeneralDetailPage), iRef.ToString());
            }
            if (e.ClickedItem is AlbumVm)
            {
                this.Frame.Navigate(typeof(AlbumPage), ((AlbumVm)e.ClickedItem).Id);
            }
            if (e.ClickedItem is CastVm)
            {
                Frame.Navigate(typeof(PersonDetailPage), ((CastVm)e.ClickedItem).Name);
            }
        }


        private void Hub_OnSectionHeaderClick(object sender, HubSectionHeaderClickEventArgs e)
        {
            if (e.Section == MovieSection)
            {
                App.MainVm.GotoAllMovies();
            }
            if (e.Section == TVSection)
            {
                Frame.Navigate(typeof(TvShowsPage));
            }
            if (e.Section == MusicSection)
            {
                App.MainVm.ResetMusic();
                Frame.Navigate(typeof(MusicArtistsPage));
            }
            if (e.Section == PeopleSection)
            {
                App.MainVm.GotoAllMovies();
            }
        }

        private void Advanced_Click(object sender, ItemClickEventArgs e)
        {
            ((AdvancedStep) e.ClickedItem).Execute();
        }


        private void ConnectionsClick(object sender, RoutedEventArgs e)
        {
            var flyout = new MenuFlyout();

            flyout.Items.Clear();

            var recent = App.MainVm.CurrentConnection.GetRecentServers();

            var multiPort = recent.GroupBy(r => r.Host).Where(g => g.Count() > 1).Select(g=>g.First().Host).ToList();
            

            foreach (var server in recent)
            {
                RelayCommand command=null;
                var name = server.Host;
                if (multiPort.Contains(name))
                {
                    name += ":" + server.WebInterfacePort;
                }

                if (server.IsCurrent)
                {
                    name += " (active)";
                }
                else
                {
                    command = new RelayCommand(()=>ConnectToServerExecuted(server));
                }

                flyout.Items.Add(new MenuFlyoutItem() { Text = name, Command = command });
            }

            flyout.Items.Add(new MenuFlyoutSeparator());
            var discovered = App.MainVm.CurrentConnection.GetAvailableServers();

            if (discovered != null)
            {
                foreach (var server in discovered)
                {
                    RelayCommand command = null;
                    var name = server.FriendlyName;
                    if (server.IsCurrent)
                    {
                        name += " (active)";
                    }
                    else
                    {
                        command = new RelayCommand(() => ConnectToServerExecuted(server));
                        flyout.Items.Add(new MenuFlyoutItem() {Text = name, Command = command});
                    }
                }
            }

            if (!(flyout.Items.Last() is MenuFlyoutSeparator))
            {
                flyout.Items.Add(new MenuFlyoutSeparator());
                
            }
            flyout.Items.Add(new MenuFlyoutItem(){Text="Edit connection settings...", Command = new RelayCommand(EditConnectionExecuted)});
            flyout.Placement = FlyoutPlacementMode.Bottom;
            if (sender is AppBarButton)
            {
                flyout.ShowAt(pageRoot);
            }
            else
            {
                flyout.ShowAt((FrameworkElement) sender);
            }
        }

        private async void ConnectToServerExecuted(XbmcServer server)
        {
            await App.MainVm.Settings.LoadFromHistory(server);

            Frame.Navigate(typeof(HubPage));
            Frame.BackStack.Clear();
        }

        private void EditConnectionExecuted()
        {
            var view = new ViewHandler();
            view.GotoWelcomeWizard();
        }

        private void SearchFlyout_Opening(object sender, object e)
        {
            BottomAppBar.Visibility = Visibility.Collapsed;
        }

        private void SearchFlyout_Closed(object sender, object e)
        {
            BottomAppBar.Visibility = Visibility.Visible;
        }

        private void SearchBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                App.RootFrame.Navigate(typeof(SearchResultsPage), ((TextBox) sender).Text);
            }
        }

        private void ToggleFlyout(object sender, RoutedEventArgs e)
        {
            RcButton.Flyout.Hide();
        }
    }



    class AdvancedStep
    {
        public string Header { get; set; }
        public Action Execute { get; set; }
        public string Type { get; set; }
    }
}
