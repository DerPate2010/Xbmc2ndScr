using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.PlayerFramework;
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
    public sealed partial class CurrentPlayingCtrl : UserControl
    {
        public CurrentPlayingCtrl()
        {
            this.InitializeComponent();
        }

        private CurrentPlaybackVm _currentPlayingItem { get { return DataContext as CurrentPlaybackVm; } }

        private void CurrentPlayingLinkClick(object sender, PointerRoutedEventArgs e)
        {
            _currentPlayingItem.CurrentItem.GotoDetails();
            //App.MainVm.DirectToMovie(_currentPlayingItem.CurrentItem);
            //this.Frame.Navigate(typeof(MovieDetailPage));
        }

        private void OpenTrackMenu(object sender, RoutedEventArgs e)
        {
            var video = _currentPlayingItem.CurrentItem as PlayingXbmcVideoVm;
            if (video != null)
            {
                var tracks = video.AudioTracks;
                OpenTrackMenu(sender, tracks);
            }
        }

        private static void OpenTrackMenu(object sender, List<TrackVm> tracks)
        {
            var f = new MenuFlyout();


            foreach (TrackVm target in tracks)
            {
                var mi = new MenuFlyoutItem();
                mi.Text = target.Label;
                mi.Command = target.Select;
                f.Items.Add(mi);
            }

            f.ShowAt((FrameworkElement) sender);
        }

        private void OpenSubtitleMenu(object sender, RoutedEventArgs e)
        {
            var video = _currentPlayingItem.CurrentItem as PlayingXbmcVideoVm;
            if (video != null)
            {
                var tracks = video.SubtitleTracks;
                OpenTrackMenu(sender, tracks);
            }
        }

        private void SeekableSlider_OnScrubbingCompleted(object sender, ValueRoutedEventArgs e)
        {
            _currentPlayingItem.CurrentItem.Seek(e.Value);
        }

        private void PlaylistClick(object sender, ItemClickEventArgs e)
        {
            var plItem = (PlaylistItemVm) e.ClickedItem;
            plItem.Open();
        }

        private void TogglePlaylist(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
