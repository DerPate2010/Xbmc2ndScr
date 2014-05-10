using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Xbmc2S.RT.Common
{
    public class NullToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
            {
                return string.IsNullOrWhiteSpace((string)value) ? Visibility.Collapsed : Visibility.Visible;
            }
            return value==null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}