using System;
using System.Windows.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Xbmc2S.RT
{
    internal class SmartDispatcherRT : IDispatcher
    {
        private CoreDispatcher _dispatcher;
        public bool DesignModeEnabled { get { return Windows.ApplicationModel.DesignMode.DesignModeEnabled; } }
        public bool HasThreadAccess { get { return _dispatcher.HasThreadAccess; } }
        public void RunAsync(Action a)
        {
            _dispatcher.RunAsync(CoreDispatcherPriority.Normal, ()=>a());
        }

        public SmartDispatcherRT()
        {
            _dispatcher = Window.Current.Dispatcher;
            if (_dispatcher == null)
            {
                throw new NotSupportedException();
            }
        }
    }
}