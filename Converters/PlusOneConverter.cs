using System;
using System.Globalization;
using System.Windows.Data;

namespace Jon.Wpf.CustomControls.Converters
{
    public class PlusOneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int number)
            {
                return number + 1;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int number)
            {
                return number - 1;
            }
            return value;
        }
    }
}