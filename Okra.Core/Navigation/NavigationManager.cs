using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Okra.Helpers;
using Okra.Services;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.UI.Xaml;
using System.Reflection;
using Windows.UI.Xaml.Navigation;

namespace Okra.Navigation
{
    public class NavigationManager : NavigationBase, INavigationManager, ILifetimeAware
    {
        // *** Constants ***

        private const string STORAGE_FILENAME = "Okra_Navigation_NavigationManager.xml";

        // *** Fields ***

        private readonly INavigationTarget navigationTarget;
        private readonly IStorageManager storageManager;

        private string homePageName = SpecialPageNames.Home;
        private NavigationStorageType navigationStorageType = NavigationStorageType.None;

        // *** Constructors ***

        public NavigationManager(INavigationTarget navigationTarget, IViewFactory viewFactory, ILifetimeManager lifetimeManager, IStorageManager storageManager)
            : base(viewFactory)
        {
            this.storageManager = storageManager;

            // Use a default INavigationTarget if not specified

            if (navigationTarget != null)
                this.navigationTarget = navigationTarget;
            else
                this.navigationTarget = new WindowNavigationTarget();

            // Register with the LifetimeManager

            lifetimeManager.Register(this);
        }

        // *** Properties ***

        public override bool CanGoBack
        {
            get
            {
                // NB: We cannot navigate backwards from the first page in the stack

                return NavigationStack.Count > 1;
            }
        }

        public string HomePageName
        {
            get
            {
                return homePageName;
            }
            set
            {
                // Validate parameters

                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(ResourceHelper.GetErrorResource("Exception_ArgumentException_StringIsNullOrEmpty"), "HomePageName");

                // Set the property

                homePageName = value;
            }
        }

        public NavigationStorageType NavigationStorageType
        {
            get
            {
                return navigationStorageType;
            }
            set
            {
                navigationStorageType = value;
            }
        }

        public INavigationTarget NavigationTarget
        {
            get
            {
                return navigationTarget;
            }
        }

        // *** Methods ***

        public async Task<bool> RestoreNavigationStack()
        {
            // Retrieve a navigation stack from storage unless,
            //    (1) The NavigationStorageType is 'None'
            //    (2) Cannot find the navigation stack in storage

            NavigationManagerState restoredState = null;

            switch (NavigationStorageType)
            {
                case Navigation.NavigationStorageType.Local:
                    restoredState = await storageManager.RetrieveAsync<NavigationManagerState>(ApplicationData.Current.LocalFolder, STORAGE_FILENAME);
                    break;
                case Navigation.NavigationStorageType.Roaming:
                    restoredState = await storageManager.RetrieveAsync<NavigationManagerState>(ApplicationData.Current.RoamingFolder, STORAGE_FILENAME);
                    break;
            }

            // If a navigation stack is available, then restore this

            if (restoredState != null)
            {
                foreach (NavigationEntryState entryState in restoredState.NavigationStack.Reverse())
                {
                    // Push the restored navigation entry onto the stack

                    NavigationStack.Push(new NavigationEntry(entryState.PageName, entryState.ArgumentsData, entryState.StateData));
                }

                // Display the last page in the stack

                DisplayNavigationEntry(CurrentPage);

                // Call NavigatedTo() on the restored page

                CallNavigatedTo(CurrentPage, NavigationMode.Refresh);

                // Return true to signal success

                return true;
            }

            // Otherwise navigate to the home page and return false

            else
            {
                NavigateTo(HomePageName);

                return false;
            }
        }

        // *** ILifetimeAware Methods ***

        public Task OnExiting()
        {
            return Task.FromResult(true);
        }

        public Task OnResuming()
        {
            return Task.FromResult(true);
        }

        public async Task OnSuspending()
        {
            // Store the current navigation stack to the relevant place

            switch (NavigationStorageType)
            {
                case Navigation.NavigationStorageType.Local:
                    await StoreNavigationStack(ApplicationData.Current.LocalFolder);
                    break;
                case Navigation.NavigationStorageType.Roaming:
                    await StoreNavigationStack(ApplicationData.Current.RoamingFolder);
                    break;
            }
        }

        // *** Overriden Base Methods ***

        protected override void DisplayPage(object page)
        {
            // Navigate to the relevant page

            navigationTarget.NavigateTo(page);
        }

        // *** Private Methods ***

        private void SavePageState(NavigationEntry entry)
        {
            // If the view model is IActivatable<,> then use this to save the page state
            // NB: First check that the view has been created - this may still have state from a previous instance
            // NB: Use reflection as we do not know the generic parameter types

            if (entry.ViewLifetimeContext != null)
            {
                // Get the generic IActivatable<,> interface

                object viewModel = entry.ViewLifetimeContext.ViewModel;
                Type activatableInterface = ReflectionHelper.GetClosedGenericType(viewModel, typeof(IActivatable<,>));

                if (activatableInterface != null)
                {
                    // Save the state

                    MethodInfo saveStateMethod = activatableInterface.GetTypeInfo().GetDeclaredMethod("SaveState");
                    entry.State = saveStateMethod.Invoke(viewModel, null);

                    // Serialize the arguments and state

                    entry.SerializeData(activatableInterface.GenericTypeArguments[0], activatableInterface.GenericTypeArguments[1]);
                }
            }
        }

        private Task StoreNavigationStack(StorageFolder folder)
        {
            // Create an object for storage of the navigation state

            NavigationManagerState state = new NavigationManagerState();

            // Enumerate all NavigationEntries in the navigation stack

            foreach (NavigationEntry entry in NavigationStack)
            {
                // Save the page state
                // TODO : Do this when navigating away from each page to save time when suspending

                SavePageState(entry);

                // Create an object for storage of this entry

                NavigationEntryState entryState = new NavigationEntryState()
                        {
                            PageName = entry.PageName,
                            ArgumentsData = entry.ArgumentsData,
                            StateData = entry.StateData
                        };

                state.NavigationStack.Add(entryState);
            }

            // Store the state using the IStorageManager

            return storageManager.StoreAsync(folder, STORAGE_FILENAME, state);
        }

        // *** Private Sub-Classes ***

        [DataContract]
        private class NavigationManagerState
        {
            // *** Constructors ***

            public NavigationManagerState()
            {
                NavigationStack = new List<NavigationEntryState>();
            }

            // *** Properties ***

            [DataMember]
            public IList<NavigationEntryState> NavigationStack
            {
                get;
                private set;
            }
        }

        [DataContract]
        private class NavigationEntryState
        {
            // *** Properties ***

            [DataMember]
            public string PageName { get; set; }

            [DataMember]
            public byte[] ArgumentsData { get; set; }

            [DataMember]
            public byte[] StateData { get; set; }
        }
    }
}
