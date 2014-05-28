using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xbmc2S.Model;
using Xbmc2S.RT.PlatformServices;

namespace Xbmc2S.RT
{
    partial class App
    {
        private static IConnectionStatus _progressIndicator;

        private void DoPlatformDependentInitialization()
        {
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame frame = RootFrame;
            if (frame == null)
            {
                return;
            }

            if (frame.CanGoBack)
            {
                frame.GoBack();
                e.Handled = true;
            }
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

        private void RootFrame_Navigated(object sender, NavigationEventArgs e)
        {
            
        }
    }
}
