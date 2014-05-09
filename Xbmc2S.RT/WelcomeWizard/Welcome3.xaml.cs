using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using XBMCRPC;
using XBMCRPC.Application.Property;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Xbmc2S.RT.WelcomeWizard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Welcome3 : Page
    {
        public Welcome3()
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
            txtHost.Text = App.MainVm.Settings.Host;
            txtPort.Text = App.MainVm.Settings.Port.ToString();
            txtUser.Text = App.MainVm.Settings.User;
            txtPass.Password = App.MainVm.Settings.Password??"";
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var success= await CheckConnection();

            if (success){

                Frame.Navigate(typeof (Welcome3a));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CheckConnection();
        }

        private async Task<bool> CheckConnection()
        {
            BusyIndicator.Visibility = Visibility.Visible;

            try
            {
                var settings = App.MainVm.Settings;
                var host = txtHost.Text;
                if (string.IsNullOrWhiteSpace(host))
                {
                    host = "nohost";
                }



                int port;
                if (!int.TryParse(txtPort.Text, out port))
                {
                    port = 80;
                }
                if (port < 1)
                {
                    port = 80;
                }
                txtPort.Text = port.ToString();

                var xbmc = new Client(new PlatformServices.PlatformServices(), host, port, txtUser.Text,
                                      txtPass.Password);
                var props = await xbmc.Application.GetProperties(new Name[] { XBMCRPC.Application.Property.Name.version });

                App.MainVm.Settings.Set(host, port, txtUser.Text, txtPass.Password);

                StatusHeader.Visibility = Visibility.Visible;
                ConnectedLabel.Visibility = Visibility.Visible;
                ErrorDetails.Visibility = Visibility.Collapsed;
                ErrorLabel.Visibility = Visibility.Collapsed;
                ErrorDetails.Text = "";

                return true;
            }
            catch (Exception ex)
            {
                StatusHeader.Visibility = Visibility.Visible;
                ConnectedLabel.Visibility = Visibility.Collapsed;
                ErrorDetails.Visibility = Visibility.Visible;
                ErrorLabel.Visibility = Visibility.Visible;
                ErrorDetails.Text = ex.Message;
                return false;
            }
            finally
            {
                BusyIndicator.Visibility = Visibility.Collapsed;

            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Launcher.LaunchUriAsync(new Uri("http://www.casa-del-stifler.de/?p=488&lang=en#webif"));
        }
    }
}
