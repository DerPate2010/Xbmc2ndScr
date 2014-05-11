using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace Xbmc2S.RT.Settings
{
    public sealed partial class LibrariesFlyout : SettingsFlyout
    {
        public LibrariesFlyout()
        {
            this.InitializeComponent();
            DataContext = App.MainVm.LibraryManager;
        }


        private async void Manage_Click(object sender, RoutedEventArgs e)
        {
            ManageInfo.Text = "The management task has been send to server.";
            await Task.Delay(3000);
            ManageInfo.Text = "";
        }
    }
}
