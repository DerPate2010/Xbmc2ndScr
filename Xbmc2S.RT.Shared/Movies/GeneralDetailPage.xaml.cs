using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232
using Xbmc2S.Model;
using Xbmc2S.RT.Common;

namespace Xbmc2S.RT
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class GeneralDetailPage :Page
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


        private int _selectedIndex;
        private const string StateKey = "SourceState";

        public GeneralDetailPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            navigationHelper.SaveState += navigationHelper_SaveState;
            flipView.SelectionChanged += flipView_SelectionChanged;
        }

        void flipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null)
            {
                var item = e.AddedItems.FirstOrDefault();
                if (item != null)
                {
                    if (item == MovieSource.Selected)
                    {
                        Dispatcher.RunIdleAsync((a) =>
                        {
                            VisualStateManager.GoToState(this, "SelectionLoaded", true);

                        });
                    }
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            VisualStateManager.GoToState(this, "SelectionLoading", false);

            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            MovieSource.Selected = itemsViewSource.View.CurrentItem;
            e.PageState[StateKey] = MovieSource.GetStateRepresentation();
        }

        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var stateRepresentation = GetStateRepresentation(e);

            MovieSource = App.MainVm.GetMovieSource(stateRepresentation);


            //VisualStateManager.GoToState(this, "SelectionLoading", false);

            await MovieSource.WaitForSelection();

            this.DefaultViewModel["Items"] = MovieSource.Items;
            Dispatcher.RunIdleAsync((a) => { itemsViewSource.View.MoveCurrentTo(MovieSource.Selected); });

            //flipView.DataContext = MovieSource.Items;
        }

        private static object GetStateRepresentation(LoadStateEventArgs e)
        {
            object stateRepresentation;
            if (e.PageState == null || !e.PageState.TryGetValue(StateKey, out stateRepresentation))
            {
                stateRepresentation = ItemsSourceReference.Parse(e.NavigationParameter);
            }
            return stateRepresentation;
        }

        public IItemsSource MovieSource { get; set; }

        public IEnumerable<IItemDetails> ItemsSource { get; set; }
    }
}
