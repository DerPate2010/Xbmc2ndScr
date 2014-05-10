using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Xbmc2S.RT.Common
{
    public sealed class CanExecuteToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is ICommand && ((ICommand)value).CanExecute(parameter)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}