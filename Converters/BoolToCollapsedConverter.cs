using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Jon.Wpf.CustomControls.Converters
{
    public class BoolToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool boolValue))
                return Visibility.Visible;

            return boolValue ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Visibility visibilityValue))
                return false;

            return visibilityValue == Visibility.Collapsed;
        }
    }

}