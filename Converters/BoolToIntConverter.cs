using System;
using System.Globalization;
using System.Windows.Data;

namespace Jon.Wpf.CustomControls.Converters
{
    public class BoolToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool booleanValue && booleanValue) ? 1 : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is int intValue) && intValue == 1;
        }
    }
}