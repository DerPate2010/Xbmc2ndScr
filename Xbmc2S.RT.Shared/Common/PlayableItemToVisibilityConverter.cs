using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Xbmc2S.Model;

namespace Xbmc2S.RT.Common
{
    public sealed class PlayableItemToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            value = value as PlayableItemVm;
            return value==null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}