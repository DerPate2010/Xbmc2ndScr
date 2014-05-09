using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okra.Internal
{
    internal class DelegateDisposable : IDisposable
    {
        // *** Fields ***

        private readonly Action disposeAction;
        private bool isDisposed;

        // *** Constructors ***

        public DelegateDisposable(Action disposeAction)
        {
            this.disposeAction = disposeAction;
        }

        // *** Methods ***

        public void Dispose()
        {
            if (!isDisposed)
            {
                disposeAction();
                isDisposed = true;
            }
        }
    }
}
