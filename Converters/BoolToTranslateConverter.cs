using System;
using System.Globalization;
using System.Windows.Data;

namespace Jon.Wpf.CustomControls.Converters
{
    public class BoolToTranslateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool booleanValue && booleanValue) ? 50.0 : 0.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is double doubleValue) && doubleValue == 50.0;
        }
    }
}