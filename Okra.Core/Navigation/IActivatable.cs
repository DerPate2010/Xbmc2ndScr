using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okra.Navigation
{
    public interface IActivatable<TArguments, TState>
    {
        // *** Methods ***

        void Activate(TArguments arguments, TState state);
        TState SaveState();
    }
}
