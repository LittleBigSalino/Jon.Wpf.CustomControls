using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Jon.Wpf.CustomControls.Converters
{
    public class ColorEqualityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is Color selectedColor && values[1] is Color color)
            {
                return selectedColor == color;
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}