using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xbmc2S.Model;
// The Group Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234229
using Xbmc2S.RT.Common;

namespace Xbmc2S.RT
{
    /// <summary>
    /// A page that displays an overview of a single group, including a preview of the items
    /// within the group.
    /// </summary>
    public sealed partial class PersonDetailPage : Page
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

        private PersonVm _source;
        private List<Filter> _filterList;

        public PersonDetailPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            navigationHelper.SaveState += navigationHelper_SaveState;
            Window.Current.SizeChanged += WindowSizeChanged;
            AdaptWindowSize();
        }

        private void WindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            AdaptWindowSize();
        }

        private void AdaptWindowSize()
        {
            if (Window.Current.Bounds.Width < 1024)
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


        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            if (e.NavigationParameter != null)
            {
                var name = e.NavigationParameter.ToString();
                DefaultViewModel["PersonName"] = name;
                _source = App.MainVm.SearchPerson(name);
                DefaultViewModel["Person"] = _source;
            }
            if (_filterList == null)
            {
                _filterList = new List<Filter>()
                    {
                        new Filter("My Movies", _source.Movies, this.MovieGridCtrl.ItemTemplate),
                        new Filter("Other Movies", _source.External, this.MovieGridCtrl.ItemTemplate),
                        new Filter("TV Shows", _source.TVShows, this.MovieGridCtrl.ItemTemplate),
                        new Filter("Episodes", _source.Episodes, EpisodeTemplate ),
                    };
            }
            this.DefaultViewModel["Filters"] = _filterList;
            this.DefaultViewModel["ShowFilters"] = _filterList.Count > 1;

            object filterIndex;
            if (e.PageState != null && e.PageState.TryGetValue("ActiveFilter", out filterIndex))
            {
                foreach (var filter in _filterList)
                {
                    filter.Active = false;
                }
                _filterList[(int)filterIndex].Active = true;
            }
        }

        void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            var filter = _filterList.FirstOrDefault(f => f.Active);
            e.PageState["ActiveFilter"] = _filterList.IndexOf(filter);
        }

        /// <summary>
        /// Invoked when a filter is selected using a RadioButton when not snapped.
        /// </summary>
        /// <param name="sender">The selected RadioButton instance.</param>
        /// <param name="e">Event data describing how the RadioButton was selected.</param>
        void Filter_Checked(object sender, RoutedEventArgs e)
        {
            // Mirror the change into the CollectionViewSource used by the corresponding ComboBox
            // to ensure that the change is reflected when snapped
            if (filtersViewSource.View != null)
            {
                var filter = (sender as FrameworkElement).DataContext;
                filtersViewSource.View.MoveCurrentTo(filter);
            }
        }

        /// <summary>
        /// Invoked when a filter is selected using the ComboBox in snapped view state.
        /// </summary>
        /// <param name="sender">The ComboBox instance.</param>
        /// <param name="e">Event data describing how the selected filter was changed.</param>
        void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Determine what filter was selected
            var selectedFilter = e.AddedItems.FirstOrDefault() as Filter;
            foreach (var filter in _filterList)
            {
                filter.Active = false;
            }
            if (selectedFilter != null)
            {
                // Mirror the results into the corresponding Filter object to allow the
                // RadioButton representation used when not snapped to reflect the change
                selectedFilter.Active = true;

                // TODO: Respond to the change in active filter by setting this.DefaultViewModel["Results"]
                //       to a collection of items with bindable Image, Title, Subtitle, and Description properties

                    DefaultViewModel["Results"] = selectedFilter.GetSource();
                this.MovieGridCtrl.ItemTemplate = selectedFilter.ItemTemplate;
                // Ensure results are found
                //object results;
                //ICollection resultsCollection;
                //if (this.DefaultViewModel.TryGetValue("Results", out results) &&
                //    (resultsCollection = results as ICollection) != null &&
                //    resultsCollection.Count != 0)
                {
                    VisualStateManager.GoToState(this, "ResultsFound", true);
                    return;
                }
            }

            // Display informational text when there are no search results.
            VisualStateManager.GoToState(this, "NoResultsFound", true);
        }
    }
}
