using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using Xbmc2S.Model;

namespace Xbmc2S.RT
{
    public sealed partial class GeneralDetailsView : UserControl
    {
        

        public DataTemplate HeaderControl
        {
            get; set;
        }

        public GeneralDetailsView()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += WindowSizeChanged;
            AdaptWindowSize();
        }

        private void WindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            AdaptWindowSize();
        }

        private void AdaptWindowSize()
        {
            if (Window.Current.Bounds.Width < 768)
            {
                VisualStateManager.GoToState(this, "Narrow", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "Normal", true);
            }
        }

        private void ItemsListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            //App.RootFrame.Navigate(typeof (SeasonOverviewPage), "3_3");
            //return;
            var item = (IItemDetails) e.ClickedItem;
            item.GoTo();
        }

        private void CastListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            string name = null;
            if (e.ClickedItem is CastVm) name = (((CastVm)e.ClickedItem).Name);
            if (e.ClickedItem is TmdbCast) name = (((TmdbCast)e.ClickedItem).Name);
            App.RootFrame.Navigate(typeof(PersonDetailPage), name);
        }
    }
}
