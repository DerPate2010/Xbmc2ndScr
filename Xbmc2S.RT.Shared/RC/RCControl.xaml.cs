using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using Xbmc2S.Model;


namespace Xbmc2S.RT.RC
{
    public sealed partial class RCControl : UserControl
    {

        public RCControl()
        {
            this.InitializeComponent();

            Loaded += RCControl_Loaded;
        }

        void RCControl_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainVm.RemoteControl.Refresh();
            DataContext = App.MainVm.RemoteControl;
        }

        private void KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                var textBox = ((TextBox) sender);
                anybtn.Focus(FocusState.Keyboard);
                ((RemoteVm)DataContext).SendText(textBox.Text);
                textBox.Text = "";
            } 
        }

    }


}
