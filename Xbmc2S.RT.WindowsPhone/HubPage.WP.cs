using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xbmc2S.RT.Settings;

namespace Xbmc2S.RT
{
    public partial class HubPage
    {

        private void AddAdvancedStepsPF(List<AdvancedStep> advancedSteps)
        {
            advancedSteps.Add(new AdvancedStep() { Header = "Settings", Execute = ShowSettings });
            AddCommand<ConnectionFlyout>(advancedSteps, true);
            AddCommand<HomeScreenFlyout>(advancedSteps, true);
            AddCommand<LibrariesFlyout>(advancedSteps, true);
            AddCommand<PrivacyFlyout>(advancedSteps);
            AddCommand<AboutFlyout>(advancedSteps);
        }

        private void AddCommand<T>(List<AdvancedStep> advancedSteps, bool intend=false) where T : SettingsFlyout, new()
        {
            var flyout = new T();
            advancedSteps.Add(new AdvancedStep() { Header = (intend?"    ":"") + flyout.Title, Type = typeof(T).Name, Execute = () =>
            {
                Frame.Navigate(typeof(SettingsPage), typeof(T).FullName);
            }});
        }
    }
}
