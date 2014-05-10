using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Xbmc2S.Model;

namespace Xbmc2S.RT.Common
{
    public class HasItemsToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is ICollectionDetails)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}