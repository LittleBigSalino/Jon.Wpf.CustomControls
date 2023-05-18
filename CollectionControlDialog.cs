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
    public class CollectionControlDialog<T> : Window
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable<T>), typeof(CollectionControlDialog<T>), new FrameworkPropertyMetadata(null, OnItemsSourceChanged));

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(T), typeof(CollectionControlDialog<T>), new FrameworkPropertyMetadata(null));

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public IEnumerable<T> ItemsSource
        {
            get { return (IEnumerable<T>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public T SelectedItem
        {
            get { return (T)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public CollectionControlDialog(List<T> items)
        {
            // Set up the dialog window properties here
            this.Title = "Collection Control Dialog";
            this.Width = 500;
            this.Height = 300;

            // Button to add a new item
            var addButton = new Button { Content = "Add" };
            addButton.Click += (s, e) => AddNewItem();

            // Button to remove the selected item
            var removeButton = new Button { Content = "Remove" };
            removeButton.Click += (s, e) => RemoveSelectedItem();

            // Add your controls to the window
            var stackPanel = new StackPanel();
            stackPanel.Children.Add(addButton);
            stackPanel.Children.Add(removeButton);

            // Create a ListBox to display the items
            var listBox = new ListBox
            {
                ItemsSource = items
            };
            stackPanel.Children.Add(listBox);

            this.Content = stackPanel;
        }

        private void AddNewItem()
        {
            // Add logic to create a new item and add it to the collection
            if (ItemsSource is IList<T> list)
            {
                list.Add(default);
            }

            // Raise the CollectionChanged event
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }

        private void RemoveSelectedItem()
        {
            // Add logic to remove the selected item from the collection
            if (ItemsSource is IList<T> list)
            {
                list.Remove(SelectedItem);
            }

            // Raise the CollectionChanged event
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CollectionControlDialog<T>;

            // Add logic to handle when the ItemsSource property changes
            if (e.NewValue is INotifyCollectionChanged newCollection)
            {
                newCollection.CollectionChanged += (s, e) => control.CollectionChanged?.Invoke(s, e);
            }
        }
    }


}
