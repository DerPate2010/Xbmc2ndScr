using System.Threading.Tasks;
using System.Windows.Input;
using Windows.System;
using Microsoft.PlayerFramework;
using WinRTXamlToolkit.Controls.Extensions;
using Xbmc2S.Model;
using Xbmc2S.RT.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Hub Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=286574

namespace Xbmc2S.RT
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class HubPage : Page
    {

        private void AddAdvancedStepsPF(List<AdvancedStep> advancedSteps)
        {
            advancedSteps.Add(new AdvancedStep() { Header = "Settings", Execute = ShowSettings });
        }
    }
}
