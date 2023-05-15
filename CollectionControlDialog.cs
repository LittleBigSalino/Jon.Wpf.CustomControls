using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jon.Wpf.CustomControls
{
    public class CollectionControlDialog : Window
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(CollectionControlDialog), new FrameworkPropertyMetadata(null, OnItemsSourceChanged));

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(CollectionControlDialog), new FrameworkPropertyMetadata(null));

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public CollectionControlDialog()
        {
            // Set up the dialog window properties here

            // Button to add a new item
            var addButton = new Button { Content = "Add" };
            addButton.Click += (s, e) => AddNewItem();

            // Button to remove the selected item
            var removeButton = new Button { Content = "Remove" };
            removeButton.Click += (s, e) => RemoveSelectedItem();

            // TODO: Add your controls to the window
        }

        private void AddNewItem()
        {
            // TODO: Add logic to create a new item and add it to the collection

            // Raise the CollectionChanged event
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }

        private void RemoveSelectedItem()
        {
            // TODO: Add logic to remove the selected item from the collection

            // Raise the CollectionChanged event
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CollectionControlDialog;

            // TODO: Add logic to handle when the ItemsSource property changes
        }
    }
}
