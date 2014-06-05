using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using WinRTXamlToolkit.Controls.Extensions;
using Xbmc2S.RT.Common;

namespace Xbmc2S.RT.Global
{
    public sealed partial class CommonAppBar : CommandBar
    {
        public CommonAppBar()
        {
            this.InitializeComponent();
        }

        private bool _rcOpen = false;


        private void ToggleFlyout(object sender, RoutedEventArgs e)
        {
            if (_rcOpen)
            {
                RcButton.Flyout.Hide();
            }
        }

        private void RCFlyout_Closed(object sender, object e)
        {
            _rcOpen = false;
        }

        private void RCFlyout_Opened(object sender, object e)
        {
            _rcOpen = true;
        }

        private void SearchFlyout_Opening(object sender, object e)
        {
            var p = findb.GetFirstAncestorOfType<CommandBar>();
            if (p != null) p.Visibility = Visibility.Collapsed;
        }

        private void SearchFlyout_Closed(object sender, object e)
        {
            var p = findb.GetFirstAncestorOfType<CommandBar>();
            if (p != null) p.Visibility = Visibility.Visible;
        }

        private void SearchBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                App.RootFrame.Navigate(typeof(SearchResultsPage), ((TextBox)sender).Text);
            }
        }

        private void FindClick(object sender, RoutedEventArgs e)
        {
        }

        private void UIElement_OnLostFocus(object sender, RoutedEventArgs e)
        {
            findb.Flyout.Hide();
        }

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            GoToButton.Flyout.Hide();
        }
    }
}
