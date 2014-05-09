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

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace Xbmc2S.RT.Settings
{
    public sealed partial class AboutFlyout : SettingsFlyout
    {
        public AboutFlyout()
        {
            this.InitializeComponent();
        }



        private void Website_Click(object sender, RoutedEventArgs e)
        {
            Launcher.LaunchUriAsync(
                new Uri("http://www.casa-del-stifler.de"));
        }

        private void Mail_Click(object sender, RoutedEventArgs e)
        {
            Launcher.LaunchUriAsync(
                new Uri("mailto://apps@casa-del-stifler.de"));

        }

        private void TvDbCredit_Click(object sender, RoutedEventArgs e)
        {
            Launcher.LaunchUriAsync(
                new Uri("http://www.themoviedb.org"));
        }
    }
}
