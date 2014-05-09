using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xbmc2S.RT.PlatformServices;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Xbmc2S.RT
{
    public sealed partial class ProgressIndicator : UserControl, IConnectionStatus
    {
        
        public ProgressIndicator()
        {
            this.InitializeComponent();
        }

        public IDisposable GetProgressToken()
        {
            var token= new ProgressToken(OnTokenDisposed);
            _token.Add(token);
            RefreshIsActive();
            return token;
        }

        public void SetError(string message)
        {
            if (Dispatcher.HasThreadAccess)
            {
                DisplayError(message);
            }
            else
            {
                Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => DisplayError(message));
            }
        }

        private async void DisplayError(string message)
        {
            if (string.IsNullOrEmpty(ErrorLabel.Text))
            {
                ErrorLabel.Text = message;
                await Task.Delay(4000);
                ErrorLabel.Text = "";
            }
        }

        private void OnTokenDisposed(IDisposable obj)
        {
            _token.Remove(obj);
            RefreshIsActive();
        }

        private List<IDisposable> _token = new List<IDisposable>();
        private bool _refreshPending;

        private class ProgressToken:IDisposable
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



        private void RefreshIsActive()
        {
            if (!_refreshPending)
            {
                _refreshPending = true;
                if (Dispatcher.HasThreadAccess)
                {
                    DoRefresh();
                }
                else
                {
                    Dispatcher.RunAsync(CoreDispatcherPriority.Normal, DoRefresh);
                }
            }
        }

        private async void DoRefresh()
        {
            await Task.Delay(300);
            _refreshPending = false;
            if (_token.Count == 0)
            {
                if (ProgressAnimation.IsActive)
                {
                    ProgressAnimation.IsActive = false;
                }
            }
            else
            {
                if (!ProgressAnimation.IsActive)
                {
                    ProgressAnimation.IsActive = true;
                }
            }
        }
    }
}
