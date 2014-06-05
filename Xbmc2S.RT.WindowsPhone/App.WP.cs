using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Networking;
using Windows.Networking.Connectivity;
using Windows.Networking.Sockets;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xbmc2S.Model;
using Xbmc2S.RT.Global;
using Xbmc2S.RT.PlatformServices;

namespace Xbmc2S.RT
{
    partial class App
    {
        private static IConnectionStatus _progressIndicator;

        private async void DoPlatformDependentInitialization()
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
            var page =e.Content as Page;
            if (page != null)
            {
                if (page.BottomAppBar == null)
                {
                    page.BottomAppBar = new CommonAppBar();
                }
                else
                {
                    var commandBar = page.BottomAppBar as CommandBar;
                    if (commandBar != null)
                    {
                        var commonBar = new CommonAppBar();
                        int pos=0;
                        foreach (var commandBarElement in commonBar.PrimaryCommands)
                        {
                            if (commandBar.PrimaryCommands.Count > 3)
                            {
                                commandBar.SecondaryCommands.Add(commandBarElement);
                            }
                            else
                            {
                                commandBar.PrimaryCommands.Insert(pos, commandBarElement);
                                pos++;
                            }
                        }
                        foreach (var commandBarElement in commonBar.SecondaryCommands)
                        {
                            commandBar.SecondaryCommands.Add(commandBarElement);
                        }
                    }
                }
            }
        }
    }
}
