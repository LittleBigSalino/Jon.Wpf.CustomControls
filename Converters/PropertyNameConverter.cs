using System;
using System.Globalization;
using System.Windows.Data;

namespace Jon.Wpf.CustomControls.Converters
{
    public class PropertyNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var propertyName = value as string;
            return string.IsNullOrEmpty(propertyName) ? string.Empty : propertyName.Replace('_', ' ');
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}