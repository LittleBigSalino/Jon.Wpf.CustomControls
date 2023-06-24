using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Jon.Wpf.CustomControls.Converters
{
    public class TimeToPartsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is DateTime selectedTime)
            {
                return new object[]
                {
                selectedTime.Hour % 12,
                selectedTime.Minute,
                selectedTime.Hour >= 12 ? 1 : 0
                };
            }

            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value is object[] parts && parts.Length == 3 &&
                parts[0] is int hour && parts[1] is int minute && parts[2] is int amPm)
            {
                if (amPm == 1 && hour < 12)
                {
                    hour += 12;
                }
                else if (amPm == 0 && hour >= 12)
                {
                    hour -= 12;
                }

                return new object[] { new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0) };
            }

            return new object[] { DependencyProperty.UnsetValue };
        }
    }

}
