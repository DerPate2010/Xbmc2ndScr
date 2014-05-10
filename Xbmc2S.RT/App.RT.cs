using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xbmc2S.Model;
using Xbmc2S.RT.PlatformServices;
using Xbmc2S.RT.Search;
using Xbmc2S.RT.Settings;

namespace Xbmc2S.RT
{
    partial class App
    {
        private static ProgressIndicator _progressIndicator;
        private static GlobalSearchBox _globalSearchBox;


        private void DoPlatformDependentInitialization()
        {
            SettingsPane.GetForCurrentView().CommandsRequested += CommandsRequested;
        }

        private void CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(new SettingsCommand("WelcomeWizard", "Welcome Wizard", GotoWelcomeWizard));
            AddCommand<ConnectionFlyout>(args);
            AddCommand<HomeScreenFlyout>(args);
            AddCommand<LibrariesFlyout>(args);
            AddCommand<PrivacyFlyout>(args);
            AddCommand<AboutFlyout>(args);
        }


        private void AddCommand<T>(SettingsPaneCommandsRequestedEventArgs args) where T : SettingsFlyout, new()
        {
            var flyout = new T();
            args.Request.ApplicationCommands.Add(new SettingsCommand(typeof(T).Name, flyout.Title, (p) =>
            {
                flyout.Show();
            }));
        }



        private static ProgressIndicator ProgressIndicator
        {
            get
            {
                if (_progressIndicator == null)
                {
                    _progressIndicator = new ProgressIndicator() { HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Top };
                }
                return _progressIndicator;
            }
        }

        private static ILauncher GetLauncher()
        {
            return new LauncherRT();
        }
    }
}
