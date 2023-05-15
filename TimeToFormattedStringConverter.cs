using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Jon.Wpf.CustomControls
{
    public class TimeToFormattedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime && parameter is string format)
            {
                return dateTime.ToString(format, culture);
            }

            return DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string timeString && parameter is string format)
            {
                if (DateTime.TryParseExact(timeString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }
            }
            return DependencyProperty.UnsetValue;
        }

    }
}
