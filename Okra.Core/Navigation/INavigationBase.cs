using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okra.Navigation
{
    public interface INavigationBase
    {
        // *** Events ***

        event EventHandler CanGoBackChanged;

        // *** Properties ***

        bool CanGoBack { get; }
        INavigationEntry CurrentPage { get; }

        // *** Methods ***

        void GoBack();
        void NavigateTo(string pageName);
        void NavigateTo(string pageName, object arguments);
    }
}
