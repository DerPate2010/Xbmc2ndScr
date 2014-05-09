using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okra.Navigation
{
    public static class NavigationManagerEx
    {
        public static void NavigateTo(this INavigationBase navigationManager, Type pageName)
        {
            // Validate Parameters

            if (pageName == null)
                throw new ArgumentNullException("pageName");

            // Delegate to the actual INavigationManager

            navigationManager.NavigateTo(PageName.FromType(pageName));
        }

        public static void NavigateTo(this INavigationBase navigationManager, Type pageName, object arguments)
        {
            // Validate Parameters

            if (pageName == null)
                throw new ArgumentNullException("pageName");

            // Delegate to the actual INavigationManager

            navigationManager.NavigateTo(PageName.FromType(pageName), arguments);
        }
    }
}
