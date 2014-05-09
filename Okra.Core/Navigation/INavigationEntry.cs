using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okra.Navigation
{
    public interface INavigationEntry
    {
        // *** Properties ***

        string PageName { get; }

        // *** Methods ***

        IEnumerable<object> GetElements();
    }
}
