using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace Xbmc2S.RT
{
    public class AppBarToggleButton : ToggleButton
    {
        public AppBarToggleButton()
        {
            this.Click += AppBarToggleButton_Click;
        }

        void AppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, IsChecked.GetValueOrDefault() ? "Checked" : "Unchecked", false);
        }
    }

}
