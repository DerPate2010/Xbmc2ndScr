using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
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
    public sealed partial class MovieGridCtrl : UserControl
    {
        public MovieGridCtrl()
        {
            this.InitializeComponent();

            groupesSource.Source = "#abcdefghijklmnopqrstuvwxyz".ToCharArray();

            App.MainVm.Settings.SettingsChanged += Settings_SettingsChanged;
        }

        void Settings_SettingsChanged(object sender, EventArgs e)
        {
            InvalidateViewState(ActualWidth);
        }

        private void InvalidateViewState(double width)
        {
            if (width == 0) return;
            if (width < 768)
            {
                VisualStateManager.GoToState(this, "Narrow", false);
            }
            else if (App.MainVm.Settings.UseListView)
            {
                VisualStateManager.GoToState(this, "ListView", false);
            }
            else
            {
                VisualStateManager.GoToState(this, "Normal", false);
            }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            InvalidateViewState(availableSize.Width);
            return base.MeasureOverride(availableSize);
        }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(object), typeof(MovieGridCtrl), new PropertyMetadata(null, ItemsSourceChanged));

        private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MovieGridCtrl)d).groupedItemsViewSource.Source = ((IItemsSource)e.NewValue).Items;
        }

        public IItemsSource ItemsSource
        {
            get { return (IItemsSource)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof (DataTemplate), typeof (MovieGridCtrl), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate) GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }


        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof (object), typeof (MovieGridCtrl), new PropertyMetadata(default(object), RefreshHeader));

        private static void RefreshHeader(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (MovieGridCtrl) d;
            if (ctrl.Header != null)
            {
                ((FrameworkElement) ctrl.Header).DataContext = ctrl.HeaderDataContext;
            }
        }

        public object Header
        {
            get { return (object) GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderDataContextProperty =
            DependencyProperty.Register("HeaderDataContext", typeof (object), typeof (MovieGridCtrl), new PropertyMetadata(default(object), RefreshHeader));

        public object HeaderDataContext
        {
            get { return (object) GetValue(HeaderDataContextProperty); }
            set { SetValue(HeaderDataContextProperty, value); }
        }

        /// <summary>
        /// Invoked when a group header is clicked.
        /// </summary>
        /// <param name="sender">The Button used as a group header for the selected group.</param>
        /// <param name="e">Event data that describes how the click was initiated.</param>
        void Header_Click(object sender, RoutedEventArgs e)
        {
            // Determine what group the Button instance represents
            var group = (sender as FrameworkElement).DataContext;

            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            //this.Frame.Navigate(typeof(GroupDetailPage), ((SampleDataGroup)group).UniqueId);
        }

        /// <summary>
        /// Invoked when an item within a group is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            if (e.ClickedItem is TmdbPerson)
            {
                App.RootFrame.Navigate(typeof(PersonDetailPage), ((TmdbPerson)e.ClickedItem).Label);
                return;
            }
            ItemsSource.Selected = e.ClickedItem;

            if (e.ClickedItem is TVShowVm)
            {
                App.RootFrame.Navigate(typeof(GeneralDetailPage), ItemsSource.GetStateRepresentation().ToString());
            }
            else if (e.ClickedItem is EpisodeVm)
            {
                var episode = (EpisodeVm) e.ClickedItem;
                App.RootFrame.Navigate(typeof(EpisodeDetailPage), episode.GetRef());
            }
            else
            {
                App.RootFrame.Navigate(typeof(GeneralDetailPage), ItemsSource.GetStateRepresentation().ToString());
            }
        }

        private async void SemanticZoom_OnViewChangeStarted(object sender, SemanticZoomViewChangedEventArgs e)
        {
            var groupedSource = ItemsSource as IGroupedItemsSource;
            if (groupedSource == null)
            {
                return;
            }

            if (e.IsSourceZoomedInView == false)
            {
                ListViewBase itemView = itemGridView;
                if (sender == ListZoom)
                {
                    itemView = itemListView;
                }

                LoadMessage.Visibility = Visibility.Visible;
                var chr = e.SourceItem.Item.ToString();
                if (chr == "#")
                {
                    ScrollIntoView(ItemsSource.Items[0]);
                }
                else
                {
                    var names = await groupedSource.FetchAllLabelsAsync();
                    var uiCultureCode = Windows.System.UserProfile.GlobalizationPreferences.Languages.FirstOrDefault();
                    if (uiCultureCode == null)
                    {
                        uiCultureCode = "en-US";
                    }
                    var culture = new CultureInfo(uiCultureCode);

                    for (int index = 0; index < names.Count; index++)
                    {
                        var name = names[index];

                        //name = ReplaceNoise(name);

                        var start = name[0].ToString();

                        start = start.ToLowerInvariant();

                        if (culture.CompareInfo.Compare(start, chr) >= 0)
                        {
                            ItemsSource.ChangeNotification.CollectionChanged += VirtualizingDataList_CollectionChanged;
                            var item2 = ItemsSource.Items[index];
                            if (item2 != null)
                            {
                                ScrollIntoView(item2);
                            }
                            break;
                        }
                    }
                }
                LoadMessage.Visibility = Visibility.Collapsed;
            }
        }
        string[] noise = new string[] { "the", "an", "a", "der", "die", "das", "ein", "eine", "un", "une", "la", "le" };

        private string ReplaceNoise(string input)
        {


            //surely this could be LINQ'd 
            foreach (string n in noise)
            {
                if (input.ToLower().StartsWith(n + " "))
                {
                    return input.Substring(n.Length + 1).Trim();
                }
            }
            return input;
        }



        void VirtualizingDataList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ItemsSource.ChangeNotification.CollectionChanged -= VirtualizingDataList_CollectionChanged;
            var item2 = ItemsSource.Items[e.NewStartingIndex];
            if (item2 != null)
            {
                ScrollIntoView(item2);
            }
        }

        public void ScrollIntoView(object selected)
        {
            ListViewBase itemView = itemGridView;
            if (ListZoom.Visibility==Visibility.Visible)
            {
                itemView = itemListView;
            }

            itemView.ScrollIntoView(selected, ScrollIntoViewAlignment.Leading);
        }
    }
}
