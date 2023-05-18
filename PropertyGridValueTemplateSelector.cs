using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Jon.Wpf.CustomControls
{
    public class PropertyGridValueTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? DefaultTemplate { get; set; }
        public DataTemplate? DateTimeTemplate { get; set; }
        public DataTemplate? CollectionTemplate { get; set; } // Add this line

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var propertyEntry = item as PropertyEntry;
            if (propertyEntry != null)
            {
                if (propertyEntry.PropertyDescriptor.PropertyType == typeof(DateTime))
                {
                    return DateTimeTemplate;
                }
                // Add this block
                if (typeof(IEnumerable).IsAssignableFrom(propertyEntry.PropertyDescriptor.PropertyType))
                {
                    return CollectionTemplate;
                }
            }
            return DefaultTemplate;
        }
    }
}
