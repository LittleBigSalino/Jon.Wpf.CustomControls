using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Jon.Wpf.CustomControls.Converters
{
    public class ColorToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                // Get all public static properties of the Colors class
                var colorProperties = typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static);
                foreach (var colorProperty in colorProperties)
                {
                    // Check if the current property's color matches the given color
                    if ((Color)colorProperty.GetValue(null) == color)
                    {
                        // If a match is found, return the name of the color
                        return colorProperty.Name;
                    }
                }
            }

            // If no named color was found, return a formatted string with the RGB values
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This converter is only used for one-way binding, so we don't need to implement ConvertBack
            throw new NotImplementedException();
        }
    }

}
