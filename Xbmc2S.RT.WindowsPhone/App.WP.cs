using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xbmc2S.Model;
using Xbmc2S.RT.PlatformServices;

namespace Xbmc2S.RT
{
    partial class App
    {
        private static IConnectionStatus _progressIndicator;

        private void DoPlatformDependentInitialization()
        {
            
        }

        private static IConnectionStatus ProgressIndicator
        {
            get
            {
                if (_progressIndicator == null)
                {
                    _progressIndicator = new ProgressIndicator() ;
                }
                return _progressIndicator;
            }
        }

        private static ILauncher GetLauncher()
        {
            return new LauncherWp();
        }
    }

    internal class ProgressIndicator :UserControl, IConnectionStatus
    {
        public IDisposable GetProgressToken()
        {
            var token = new ProgressToken(OnTokenDisposed);
            return token;
        }

        private void OnTokenDisposed(IDisposable obj)
        {
            
        }

        private class ProgressToken : IDisposable
        {
            private readonly Action<IDisposable> _onDisposed;

            public ProgressToken(Action<IDisposable> onDisposed)
            {
                _onDisposed = onDisposed;
            }

            public void Dispose()
            {
                _onDisposed(this);
            }
        }

        public void SetError(string message)
        {
            throw new NotImplementedException();
        }
    }
}
