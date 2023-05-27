using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Jon.Wpf.CustomControls
{
    public class PropertyEntry
    {
        public PropertyDescriptor PropertyDescriptor { get; }
        public object Instance { get; }
        public bool IsCategory { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description
        {
            get { return PropertyDescriptor != null ? PropertyDescriptor.Description : string.Empty; }
        }
        public object Value
        {
            get { return PropertyDescriptor?.GetValue(Instance); }
            set { PropertyDescriptor?.SetValue(Instance, value); }
        }
        public ICommand OpenCollectionCommand { get; }

        public PropertyEntry()
        {
            OpenCollectionCommand = new RelayCommand(_ => OpenCollection());
        }

        public PropertyEntry(PropertyDescriptor propertyDescriptor, object instance, string category = null)
            : this()
        {
            PropertyDescriptor = propertyDescriptor;
            Instance = instance;
            Category = category;
            Name = propertyDescriptor.Name;
        }

        private void OpenCollection()
        {
            if (PropertyDescriptor.PropertyType.GetInterface(nameof(IEnumerable)) != null)
            {
                var collection = Value as IEnumerable<object>;
                if (collection != null)
                {
                    
                }
            }
        }




    }
}