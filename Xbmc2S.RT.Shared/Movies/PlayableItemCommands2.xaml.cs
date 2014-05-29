using System;
using Microsoft.PlayerFramework;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Xbmc2S.Model;


// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Xbmc2S.RT
{
    public sealed partial class PlayableItemCommands2 : UserControl
    {
        public PlayableItemCommands2()
        {
            this.InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var playableItem = (PlayableItemVm) DataContext;

            var playToTargets=playableItem.GetPlayToTargets();

            var f = new MenuFlyout();

            f.Placement=FlyoutPlacementMode.Bottom;
            
            foreach (var target in playToTargets)
            {
                var mi = new MenuFlyoutItem();
                mi.Text = target.Label;
                mi.Command = target.Play;
                f.Items.Add(mi);
            }

            f.ShowAt((FrameworkElement) sender);
        }

        private void SearchSelected(object sender, RoutedEventArgs e)
        {
            var f = new MenuFlyout();
            
            f.Placement = FlyoutPlacementMode.Bottom;


            var mi = new MenuFlyoutItem();
            mi.Text = "IMDB";
            mi.Command = new DelegateCommand(ImdbSelected);
            f.Items.Add(mi);
            mi = new MenuFlyoutItem();
            mi.Text = "Amazon";
            mi.Command = new DelegateCommand(AmazonSelected);
            f.Items.Add(mi);
            mi = new MenuFlyoutItem();
            mi.Text = "Google";
            mi.Command = new DelegateCommand(GoogleSelected);
            f.Items.Add(mi);
            mi = new MenuFlyoutItem();
            mi.Text = "Bing";
            mi.Command = new DelegateCommand(BingSelected);
            f.Items.Add(mi);

            f.ShowAt((FrameworkElement) sender);
        }

        private void GoogleSelected()
        {
            SearchText("https://www.google.com/search?q={0}");
        }

        private void BingSelected()
        {
            SearchText("http://www.bing.com/search?q={0}");
        }

        private void ImdbSelected()
        {
            SearchText("http://www.imdb.com/find?q={0}");
        }


        private void AmazonSelected()
        {
            SearchText("http://www.amazon.de/s/?tag=abituronline2-21&field-keywords={0}");
        }

        private void SearchText(string searchUrl)
        {
            string label;
            var itemDetails =  DataContext as IItemDetails;
            if (itemDetails != null)
            {
                label = itemDetails.Label;
            }
            else
            {
                var baseVm = (BaseVM) DataContext;
                label = baseVm.Label;
            }

            Launcher.LaunchUriAsync(new Uri(string.Format(searchUrl, label)));
        }

        private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
