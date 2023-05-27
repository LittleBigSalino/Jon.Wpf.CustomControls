using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Jon.Wpf.CustomControls
{
    public class PropertyGridValueTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? DefaultTemplate { get; set; }
        public DataTemplate? DateTimeTemplate { get; set; }
        public DataTemplate? CollectionTemplate { get; set; } // Add this line
        public DataTemplate? ObjectTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var propertyEntry = item as PropertyEntry;
            if (propertyEntry != null)
            {
                var propertyType = propertyEntry.PropertyDescriptor.PropertyType;

                if (propertyType == typeof(DateTime))
                {
                    return DateTimeTemplate;
                }
                else if (typeof(IEnumerable).IsAssignableFrom(propertyType))
                {
                    return CollectionTemplate;
                }
                else if (propertyType == typeof(string))
                {
                    return DefaultTemplate;
                }
                else if (propertyType == typeof(int))
                {
                    return DefaultTemplate;
                }
                else if (propertyType == typeof(double))
                {
                    return DefaultTemplate;
                }
                else if (propertyType == typeof(bool))
                {
                    return DefaultTemplate;
                }
                else
                {
                    // For all other types, use the ObjectTemplate
                    return ObjectTemplate;
                }
            }
            return DefaultTemplate;
        }

    }
}