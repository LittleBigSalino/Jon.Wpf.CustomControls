using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Jon.Wpf.CustomControls.Converters
{
    public class ToggleSwitchBackgroundConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 3)
            {
                return DependencyProperty.UnsetValue;
            }

            if (values[0] is bool isOn && values[1] is Brush onBackground && values[2] is Brush offBackground)
            {
                return isOn ? onBackground : offBackground;
            }

            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}