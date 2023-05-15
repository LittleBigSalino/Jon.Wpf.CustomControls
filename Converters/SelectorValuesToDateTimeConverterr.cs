using System;
using System.Globalization;
using System.Windows.Data;

namespace Jon.Wpf.CustomControls.Converters
{
    public class SelectorValuesToDateTimeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 3)
                throw new ArgumentException("Expected 3 values (hour, minute, am/pm)");

            var hour = values[0] as int?;
            var minute = int.Parse((string)values[1]) as int?;
            var amPm = values[2] as string;

            if (hour == null || minute == null || amPm == null)
                return null;  // or return a default value

            if (amPm == "PM" && hour < 12)
                hour += 12;
            else if (amPm == "AM" && hour == 12)
                hour = 0;

            return new DateTime(1, 1, 1, hour.Value, minute.Value, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}