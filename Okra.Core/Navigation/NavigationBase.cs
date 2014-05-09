using Okra.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace Okra.Navigation
{
    public abstract class NavigationBase : INavigationBase
    {
        // *** Fields ***

        private readonly IViewFactory viewFactory;

        private readonly Stack<INavigationEntry> navigationStack = new Stack<INavigationEntry>();

        // *** Events ***

        public event EventHandler CanGoBackChanged;

        // *** Constructors ***

        public NavigationBase(IViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        // *** Properties ***

        public virtual bool CanGoBack
        {
            get
            {
                return NavigationStack.Count > 0;
            }
        }

        public INavigationEntry CurrentPage
        {
            get
            {
                if (navigationStack.Count > 0)
                    return navigationStack.Peek();
                else
                    return null;
            }
        }

        // *** Protected Properties ***

        protected Stack<INavigationEntry> NavigationStack
        {
            get
            {
                return navigationStack;
            }
        }

        // *** Private Properties ***

        private NavigationEntry CurrentNavigationEntry
        {
            get
            {
                return CurrentPage as NavigationEntry;
            }
        }

        // *** Methods ***

        public void GoBack()
        {
            // Check that we can go back

            if (!CanGoBack)
                throw new InvalidOperationException(ResourceHelper.GetErrorResource("Exception_InvalidOperation_CannotGoBackWithEmptyBackStack"));

            // Pop the last page from the stack, call NavigationFrom() and dispose any cached items

            INavigationEntry oldNavigationEntry = NavigationStack.Pop();
            CallNavigatingFrom(oldNavigationEntry, NavigationMode.Back);

            if (oldNavigationEntry is NavigationEntry)
                ((NavigationEntry)oldNavigationEntry).DisposeCachedItems();

            // Display the new current page from the navigation stack

            DisplayNavigationEntry(CurrentNavigationEntry);

            // If the value of CanGoBack has changed then raise an event
            // NB: We can assume that the old value was true otherwise an exception is thrown on entry to this method

            if (!CanGoBack)
                OnCanGoBackChanged();

            // Call NavigatingTo()

            CallNavigatedTo(CurrentNavigationEntry, NavigationMode.Back);
        }

        public void NavigateTo(string pageName)
        {
            NavigateTo(pageName, null);
        }

        public void NavigateTo(string pageName, object arguments)
        {
            // Call NavigatingFrom on the existing navigation entry (if one exists)

            CallNavigatingFrom(CurrentNavigationEntry, NavigationMode.New);

            // Get the old value of CanGoBack

            bool oldCanGoBack = CanGoBack;

            // Create the new navigation entry and push it onto the navigation stack

            NavigationEntry navigationEntry = new NavigationEntry(pageName, arguments);
            navigationStack.Push(navigationEntry);

            // Navigate to the page

            DisplayNavigationEntry(navigationEntry);

            // If the value of CanGoBack has changed then raise an event

            if (CanGoBack != oldCanGoBack)
                OnCanGoBackChanged();

            // Call NavigatedTo on the new navigation entry

            CallNavigatedTo(navigationEntry, NavigationMode.New);
        }

        // *** Protected Methods ***

        protected void CallNavigatedTo(INavigationEntry entry, NavigationMode navigationMode)
        {
            if (entry == null)
                return;

            foreach (object element in entry.GetElements())
            {
                if (element is INavigationAware)
                    ((INavigationAware)element).NavigatedTo(navigationMode);
            }
        }

        protected void CallNavigatingFrom(INavigationEntry entry, NavigationMode navigationMode)
        {
            if (entry == null)
                return;

            foreach (object element in entry.GetElements())
            {
                if (element is INavigationAware)
                    ((INavigationAware)element).NavigatingFrom(navigationMode);
            }
        }

        protected void DisplayNavigationEntry(INavigationEntry entry)
        {
            if (entry == null)
            {
                // If this entry is null then simply pass null to the deriving class

                DisplayPage(null);
            }
            else
            {
                // Cast to the internal NavigationEntry class so we can access all members
                // TODO : Try to get rid of the need for this cast? (or check that it is of the correct type and provide alternatives for derived classes)

                NavigationEntry internalEntry = (NavigationEntry)entry;

                // If the page and VM have not been created then do so

                if (internalEntry.ViewLifetimeContext == null)
                    CreatePage(internalEntry);

                // Navigate to the relevant page

                DisplayPage(internalEntry.ViewLifetimeContext.View);
            }
        }

        protected abstract void DisplayPage(object page);

        protected virtual void OnCanGoBackChanged()
        {
            EventHandler eventHandler = CanGoBackChanged;

            if (eventHandler != null)
                eventHandler(this, new EventArgs());
        }

        // *** Private Methods ***

        private void CreatePage(NavigationEntry entry)
        {
            // Create the View

            IViewLifetimeContext viewLifetimeContext = viewFactory.CreateView(entry.PageName);
            entry.ViewLifetimeContext = viewLifetimeContext;

            // Activate the view model if it implements IActivatable<,>
            // NB: Use reflection as we do not know the generic parameter types

            object viewModel = entry.ViewLifetimeContext.ViewModel;
            Type activatableInterface = ReflectionHelper.GetClosedGenericType(viewModel, typeof(IActivatable<,>));

            if (activatableInterface != null)
            {
                // If required deserialize the arguments and state

                entry.DeserializeData(activatableInterface.GenericTypeArguments[0], activatableInterface.GenericTypeArguments[1]);

                // Activate the view model

                MethodInfo activateMethod = activatableInterface.GetTypeInfo().GetDeclaredMethod("Activate");
                activateMethod.Invoke(viewModel, new object[] { entry.Arguments, entry.State });
            }
        }
    }
}
