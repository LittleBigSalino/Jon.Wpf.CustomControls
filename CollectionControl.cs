using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Jon.Wpf.CustomControls
{
    public class CollectionControl : Control
    {
        static CollectionControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CollectionControl), new FrameworkPropertyMetadata(typeof(CollectionControl)));
        }

        // Dependency Properties
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(CollectionControl), new PropertyMetadata(false));

        public new IEnumerable Items
        {
            get { return (IEnumerable)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public new static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(IEnumerable), typeof(CollectionControl), new PropertyMetadata(null));

        public new IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public new static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(CollectionControl), new PropertyMetadata(null));

        public Type ItemsSourceType
        {
            get { return (Type)GetValue(ItemsSourceTypeProperty); }
            set { SetValue(ItemsSourceTypeProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceTypeProperty =
            DependencyProperty.Register("ItemsSourceType", typeof(Type), typeof(CollectionControl), new PropertyMetadata(null));

        public IEnumerable NewItemTypes
        {
            get { return (IEnumerable)GetValue(NewItemTypesProperty); }
            set { SetValue(NewItemTypesProperty, value); }
        }

        public static readonly DependencyProperty NewItemTypesProperty =
            DependencyProperty.Register("NewItemTypes", typeof(IEnumerable), typeof(CollectionControl), new PropertyMetadata(null));

        public object PropertyGrid
        {
            get { return GetValue(PropertyGridProperty); }
            set { SetValue(PropertyGridProperty, value); }
        }

        public static readonly DependencyProperty PropertyGridProperty =
            DependencyProperty.Register("PropertyGrid", typeof(object), typeof(CollectionControl), new PropertyMetadata(null));

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(CollectionControl), new PropertyMetadata(null));

        // Events
        public event EventHandler ItemAdded;
        public event EventHandler ItemAdding;
        public event EventHandler ItemDeleted;
        public event EventHandler ItemDeleting;

        public CollectionControl()
        {
            SelectionChangedCommand = new RelayCommand<SelectionChangedEventArgs>(args =>
            {
               
            });
        }

        protected virtual void OnItemAdded(EventArgs e)
        {
            ItemAdded?.Invoke(this, e);
        }

        protected virtual void OnItemAdding(EventArgs e)
        {
            ItemAdding?.Invoke(this, e);
        }

        protected virtual void OnItemDeleted(EventArgs e)
        {
            ItemDeleted?.Invoke(this, e);
        }

        protected virtual void OnItemDeleting(EventArgs e)
        {
            ItemDeleting?.Invoke(this, e);
        }




        public ICommand SelectionChangedCommand
        {
            get { return (ICommand)GetValue(SelectionChangedCommandProperty); }
            set { SetValue(SelectionChangedCommandProperty, value); }
        }

        public static readonly DependencyProperty SelectionChangedCommandProperty =
            DependencyProperty.Register("SelectionChangedCommand", typeof(ICommand), typeof(CollectionControl), new PropertyMetadata(null));



   
    }

    public static class SelectionChangedBehavior
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(SelectionChangedBehavior), new PropertyMetadata(OnCommandChanged));

        public static void SetCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(CommandProperty, value);
        }

        public static ICommand GetCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(CommandProperty);
        }

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ListBox listBox)
            {
                listBox.SelectionChanged -= OnSelectionChanged;

                if (e.NewValue is ICommand)
                {
                    listBox.SelectionChanged += OnSelectionChanged;
                }
            }
        }

        private static void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            var command = GetCommand(listBox);

            if (command != null && command.CanExecute(e))
            {
                command.Execute(e);
            }
        }
    }

}
