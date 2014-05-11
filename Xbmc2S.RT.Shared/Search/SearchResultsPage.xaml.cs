using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Xbmc2S.RT.Common;

// The Search Contract item template is documented at http://go.microsoft.com/fwlink/?LinkId=234240

namespace Xbmc2S.RT
{
    /// <summary>
    /// This page displays search results when a global search is directed to this application.
    /// </summary>
    public sealed partial class SearchResultsPage :Page
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

        private string _queryText;
        private List<Filter> _filterList;

        public SearchResultsPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            navigationHelper.SaveState += navigationHelper_SaveState;
            Window.Current.SizeChanged += WindowSizeChanged;
            AdaptWindowSize();

            DefaultItemTemplate =GridCtrl.ItemTemplate;
        }

        DataTemplate DefaultItemTemplate { get; set; }

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



        void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            var filter = _filterList.FirstOrDefault(f => f.Active);
            e.PageState["ActiveFilter"] = _filterList.IndexOf(filter);
        }


        private Filter MovieTitleFilter { get; set; }


        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            _queryText = e.NavigationParameter as String;

            // TODO: Application-specific searching logic.  The search process is responsible for
            //       creating a list of user-selectable result categories:
            //
            //       filterList.Add(new Filter("<filter name>", <result count>));
            //
            //       Only the first filter, typically "All", should pass true as a third argument in
            //       order to start in an active state.  Results for the active filter are provided
            //       in Filter_SelectionChanged below.

            if (_filterList == null)
            {
                MovieTitleFilter = new MovieTitleFilter(_queryText);
                MovieFullFilter = new MovieFullFilter(_queryText);
                MovieExternFilter = new MovieExternFilter(_queryText);
                TVShowFilter = new TvShowFilter(_queryText);
                ActorFilter = new ActorFilter(_queryText);
                MusicFilter = new MusicFilter(_queryText);
                _filterList = new List<Filter>()
                    {
                        MovieTitleFilter,
                        MovieFullFilter,
                        MovieExternFilter,
                        TVShowFilter,
                        ActorFilter,
                        //MusicFilter
                    };
            }

            // Communicate results through the view model
            this.DefaultViewModel["QueryText"] = '\u201c' + _queryText + '\u201d';
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


        Filter MusicFilter { get; set; }

        Filter ActorFilter { get; set; }

        Filter TVShowFilter { get; set; }

        Filter MovieExternFilter { get; set; }

        Filter MovieFullFilter { get; set; }

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
                GridCtrl.ItemTemplate = selectedFilter is ActorFilter? ActorTemplate:DefaultItemTemplate;

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
    }
}
