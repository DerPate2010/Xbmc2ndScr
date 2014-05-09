using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Okra.Helpers;
using Okra.Navigation;
using Okra.Services;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Search;

namespace Okra.Search
{
    public class SearchManager : ISearchManager, IActivationHandler
    {
        // *** Fields ***

        private readonly INavigationManager navigationManager;

        private string searchPageName = null;
        private bool isActivated;

        // *** Constructors ***

        public SearchManager(INavigationManager navigationManager, IActivationManager activationManager)
        {
            this.navigationManager = navigationManager;

            // Register with the activation manager

            activationManager.Register(this);
            activationManager.Activated += OnActivationManagerActivated;
        }

        // *** Properties ***

        public string SearchPageName
        {
            get
            {
                return searchPageName;
            }
            set
            {
                // If we have been activated then do not allow setting of this property

                if (isActivated)
                    throw new InvalidOperationException(string.Format(ResourceHelper.GetErrorResource("Exception_InvalidOperation_PropertyCannotBeSetAfterActivation"), "SearchPageName"));

                // Set the property

                searchPageName = value;
            }
        }

        // *** Methods ***

        public async Task<bool> Activate(IActivatedEventArgs activatedEventArgs)
        {
            if (activatedEventArgs.Kind == ActivationKind.Search && !string.IsNullOrEmpty(SearchPageName))
            {
                ISearchActivatedEventArgs searchEventArgs = (ISearchActivatedEventArgs)activatedEventArgs;

                // If the previous execution state was terminated then attempt to restore the navigation stack

                if (activatedEventArgs.PreviousExecutionState == ApplicationExecutionState.Terminated)
                    await navigationManager.RestoreNavigationStack();

                // Otherwise if the application is a new instance navigate to the home page

                else if (activatedEventArgs.PreviousExecutionState == ApplicationExecutionState.ClosedByUser
                      || activatedEventArgs.PreviousExecutionState == ApplicationExecutionState.NotRunning)
                    navigationManager.NavigateTo(navigationManager.HomePageName);

                // Then display the search results

                DisplaySearchResults(searchEventArgs.QueryText, searchEventArgs.Language);

                return true;
            }

            return false;
        }

        // *** Protected Methods ***

        protected void OnActivationManagerActivated(object sender, IActivatedEventArgs e)
        {
            // Once the application is activated we register for the SearchPage.QuerySubmitted event
            // NB: This is a slightly more performant method of receiving search queries for running applications than via activation
            // NB: If the SearchPageName has not been set then we assume that we do not perform search so do not register
            
            if (!string.IsNullOrEmpty(SearchPageName) && !isActivated)
            {
                SearchPane searchPane = SearchPane.GetForCurrentView();
                searchPane.QuerySubmitted += OnQuerySubmitted;
            }

            // Set the isActivated flag

            isActivated = true;
        }

        protected void OnQuerySubmitted(SearchPane sender, SearchPaneQuerySubmittedEventArgs args)
        {
            DisplaySearchResults(args.QueryText, args.Language);
        }

        // *** Private Methods ***

        private void DisplaySearchResults(string queryText, string language)
        {
            // If there are no search results to display then just return

            if (queryText == "")
                return;

            // Navigate to the search page if it is not currently visible

            INavigationEntry currentPage = navigationManager.CurrentPage;

            if (currentPage == null || currentPage.PageName != SearchPageName)
                navigationManager.NavigateTo(SearchPageName);

            // For all page elements that implement ISearchPage then execute the query

            IEnumerable<ISearchPage> searchPages = navigationManager.CurrentPage.GetElements().Where(page => page is ISearchPage).Cast<ISearchPage>();

            foreach (ISearchPage searchPage in searchPages)
            {
                searchPage.PerformQuery(queryText, language);
            }
        }
    }
}
