using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Xbmc2S.RT.WelcomeWizard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Welcome3a : Page
    {
        public Welcome3a()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CheckConnection();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Launcher.LaunchUriAsync(new Uri("http://www.casa-del-stifler.de/?p=488&lang=en#upnp"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof (Welcome4));
        }

        private async Task<bool> CheckConnection()
        {
            BusyIndicator.Visibility = Visibility.Visible;

            if (await App.MainVm.CurrentConnection.UPnPAvailable())
            {


                StatusHeader.Visibility = Visibility.Visible;
                ConnectedLabel.Visibility = Visibility.Visible;
                ErrorDetails.Visibility = Visibility.Collapsed;
                ErrorLabel.Visibility = Visibility.Collapsed;
                ErrorDetails.Text = "";
                BusyIndicator.Visibility = Visibility.Collapsed;

                return true;
            }
            else
            {
                StatusHeader.Visibility = Visibility.Visible;
                ConnectedLabel.Visibility = Visibility.Collapsed;
                ErrorDetails.Visibility = Visibility.Visible;
                ErrorLabel.Visibility = Visibility.Visible;
                ErrorDetails.Text = "";
                BusyIndicator.Visibility = Visibility.Collapsed;
                return false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CheckConnection();
        }
    }
}
