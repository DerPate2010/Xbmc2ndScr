
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
using Windows.Storage;
using Windows.UI.Popups;
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

            string firstLaunchkey = "firstLaunchMessageDone1";
            object firstLaunchMessageDoneObject;
            ApplicationData.Current.LocalSettings.Values.TryGetValue(firstLaunchkey, out firstLaunchMessageDoneObject);
            bool firstLaunchMessageDone = false;
            if (firstLaunchMessageDoneObject is bool)
            {
                firstLaunchMessageDone = (bool)firstLaunchMessageDoneObject;
            }
            if (!firstLaunchMessageDone)
            {
                var dlg =
                    new MessageDialog(
                        "This app is an open source companion for XBMC. It is free for everyone. Please help to make it the best XBMC experience on Windows Phone. You can support the development by adding code improvements or giving user feedback. ");
                await dlg.ShowAsync();
                ApplicationData.Current.LocalSettings.Values[firstLaunchkey] = true;
 
            }
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
