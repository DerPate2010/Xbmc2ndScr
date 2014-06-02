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
using Xbmc2S.Model;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Xbmc2S.RT
{
    public sealed partial class JumpList : UserControl
    {
        private IView _view;

        public JumpList()
        {
            this.InitializeComponent();
            _view = new ViewHandler();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if (availableSize.Width < 768)
            {

                LinkPanelVertical.Orientation=Orientation.Vertical;
            }
            else
            {
                LinkPanelVertical.Orientation = Orientation.Horizontal;
            }
            return base.MeasureOverride(availableSize);
        }

        private void GotoHomescreen(object sender, RoutedEventArgs e)
        {
            _view.GotoHome();
        }

        private void GotoMovies(object sender, RoutedEventArgs e)
        {
            App.MainVm.GotoAllMovies();
        }

        private void GotoDownloads(object sender, RoutedEventArgs e)
        {
            _view.GotoDownloads();
        }

        private void GotoMusic(object sender, RoutedEventArgs e)
        {
            _view.GotoMusic();
        }

        private void GotoTvShows(object sender, RoutedEventArgs e)
        {
            _view.GotoTvShows();
        }

        private void GotoWishList(object sender, RoutedEventArgs e)
        {
            
        }

        private void GotoWatchList(object sender, RoutedEventArgs e)
        {
            App.MainVm.GotoWatchList();
        }
    }
}
