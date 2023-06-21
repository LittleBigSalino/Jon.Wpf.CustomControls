using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Jon.Wpf.CustomControls.Converters
{
    public class SelectedIndexConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is int selectedValue && values[1] is int itemCount)
            {
                return selectedValue < itemCount ? selectedValue : -1;
            }
            return -1;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value is int indexValue)
            {
                return new object[] { indexValue, Binding.DoNothing };
            }
            return new object[] { 0, Binding.DoNothing };
        }
    }


}
