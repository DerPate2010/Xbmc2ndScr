using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Threading;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Xbmc2S.RT.PlatformServices;

namespace Xbmc2S.RT
{
    internal class ProgressIndicator :IConnectionStatus
    {
        public ProgressIndicator()
        {
            _progressIndicator = StatusBar.GetForCurrentView().ProgressIndicator;
        }

        public IDisposable GetProgressToken()
        {
            var token = new ProgressToken(OnTokenDisposed);
            _token.Add(token);
            RefreshIsActive();
            return token;
        }


        private void OnTokenDisposed(IDisposable obj)
        {
            _token.Remove(obj);
            RefreshIsActive();
        }

        private List<IDisposable> _token = new List<IDisposable>();
        private bool _refreshPending;
        private StatusBarProgressIndicator _progressIndicator;

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



        private void RefreshIsActive()
        {
            if (!_refreshPending)
            {
                _refreshPending = true;
                SmartDispatcher.RunAsync(DoRefresh);
            }
        }

        private async void DoRefresh()
        {
            await Task.Delay(300);
            _refreshPending = false;
            if (_token.Count == 0)
            {
                _progressIndicator.ProgressValue = 0;
                await _progressIndicator.HideAsync();
            }
            else
            {
                    _progressIndicator.ProgressValue = null;
                    await _progressIndicator.ShowAsync();
            }
        }

        public void SetError(string message)
        {
            SmartDispatcher.RunAsync(()=>DisplayError(message));
        }


        private async void DisplayError(string message)
        {
            if (string.IsNullOrEmpty(_progressIndicator.Text))
            {
                _progressIndicator.Text = message;
                await _progressIndicator.ShowAsync();
                await Task.Delay(4000);
                _progressIndicator.Text = "";
            }
        }
    }
}