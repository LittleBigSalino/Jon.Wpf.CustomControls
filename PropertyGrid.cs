using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Jon.Wpf.CustomControls
{
    public class PropertyGrid : Control, INotifyPropertyChanged
    {
        public object SelectedObject
        {
            get { return GetValue(SelectedObjectProperty); }
            set
            {
                SetValue(SelectedObjectProperty, value);
                SelectedObjectName = SelectedObject.GetType().ToString();
                var properties = TypeDescriptor.GetProperties(SelectedObject);
                UpdatePropertyEntries();
            }
        }

        public PropertyEntry SelectedEntry
        {
            get { return (PropertyEntry)GetValue(SelectedEntryProperty); }
            set { SetValue(SelectedEntryProperty, value); }
        }



        public ICommand SelectionChangedCommand
        {
            get { return (ICommand)GetValue(SelectionChangedCommandProperty); }
            set { SetValue(SelectionChangedCommandProperty, value); }
        }
        public string SelectedObjectName
        {
            get { return (string)GetValue(SelectedObjectNameProperty); }
            set
            {
                SetValue(SelectedObjectNameProperty, value);

            }
        }
        public Brush CategoryBackground
        {
            get { return (Brush)GetValue(CategoryBackgroundProperty); }
            set { SetValue(CategoryBackgroundProperty, value); }
        }
        public Brush CategoryForeground
        {
            get { return (Brush)GetValue(CategoryForegroundProperty); }
            set { SetValue(CategoryForegroundProperty, value); }
        }
        public bool CategorizedView
        {
            get { return (bool)GetValue(CategorizedViewProperty); }
            set { SetValue(CategorizedViewProperty, value); }
        }
        public ObservableCollection<PropertyEntry> PropertyEntries
        {
            get { return (ObservableCollection<PropertyEntry>)GetValue(PropertyEntriesProperty); }
            set { SetValue(PropertyEntriesProperty, value); }
        }
        public ICollectionView GroupedPropertyEntries
        {
            get { return (ICollectionView)GetValue(GroupedPropertyEntriesProperty); }
            set { SetValue(GroupedPropertyEntriesProperty, value); }
        }
        public ICommand ToggleCategorizedViewCommand { get; set; }
        static PropertyGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGrid), new FrameworkPropertyMetadata(typeof(PropertyGrid)));
        }
        public PropertyGrid()
        {
            ToggleCategorizedViewCommand = new RelayCommand(OnCategoryViewSelectionChangedCommand);
            SelectionChangedCommand = new RelayCommand<PropertyEntry>(OnSelectionChanged);
            PropertyEntries = new ObservableCollection<PropertyEntry>();
            var collectionViewSource = new CollectionViewSource { Source = PropertyEntries };
            collectionViewSource.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            GroupedPropertyEntries = collectionViewSource.View;
        }
        public static readonly DependencyProperty SelectedEntryProperty =
            DependencyProperty.Register(nameof(SelectedEntry), typeof(PropertyEntry), typeof(CustomDataGrid), new PropertyMetadata(null));
        public static readonly DependencyProperty SelectionChangedCommandProperty =
            DependencyProperty.Register("SelectionChangedCommand", typeof(ICommand), typeof(PropertyGrid), new PropertyMetadata(null));
        public static readonly DependencyProperty GroupedPropertyEntriesProperty =
            DependencyProperty.Register("GroupedPropertyEntries", typeof(ICollectionView), typeof(PropertyGrid));
        public static readonly DependencyProperty SelectedObjectProperty =
            DependencyProperty.Register("SelectedObject", typeof(object), typeof(PropertyGrid), new PropertyMetadata(null));
        public static readonly DependencyProperty PropertyEntriesProperty =
            DependencyProperty.Register(nameof(PropertyEntries), typeof(ObservableCollection<PropertyEntry>), typeof(CustomDataGrid), new PropertyMetadata(null));
        public static readonly DependencyProperty SelectedObjectNameProperty =
            DependencyProperty.Register("SelectedObjectName", typeof(string), typeof(PropertyGrid), new PropertyMetadata("unset"));
        public static readonly DependencyProperty CategoryBackgroundProperty =
            DependencyProperty.Register("CategoryBackground", typeof(Brush), typeof(PropertyGrid), new FrameworkPropertyMetadata(Brushes.White));
        public static readonly DependencyProperty CategoryForegroundProperty =
            DependencyProperty.Register("CategoryForeground", typeof(Brush), typeof(PropertyGrid), new FrameworkPropertyMetadata(Brushes.Black));
        public static readonly DependencyProperty CategorizedViewProperty =
            DependencyProperty.Register("CategorizedView", typeof(bool), typeof(PropertyGrid), new FrameworkPropertyMetadata(false));
        public event PropertyChangedEventHandler? PropertyChanged;
        private void UpdateGroupDescriptions()
        {
            var collectionViewSource = (CollectionViewSource)this.Resources["GroupedPropertyEntries"];
            var collectionView = collectionViewSource.View;

            collectionView.GroupDescriptions.Clear();
            collectionView.SortDescriptions.Clear();

            if (CategorizedView)
            {
                collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            }
            else
            {
                collectionView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
        }
        private void UpdatePropertyEntries()
        {
            if (SelectedObject != null)
            {
                var properties = TypeDescriptor.GetProperties(SelectedObject);
                var propertyEntries = new List<PropertyEntry>();

                foreach (PropertyDescriptor property in properties)
                {
                    if (property.IsBrowsable)
                    {
                        var propertyEntry = new PropertyEntry(property, SelectedObject, property.Category);

                        propertyEntries.Add(propertyEntry);
                    }
                }
                PropertyEntries.Clear();
                foreach (var item in propertyEntries)
                {
                    PropertyEntries.Add(item);
                }
                var collectionViewSource = new CollectionViewSource { Source = PropertyEntries };
                collectionViewSource.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
                GroupedPropertyEntries = collectionViewSource.View;
                GroupedPropertyEntries.GroupDescriptions.Clear();
                GroupedPropertyEntries.SortDescriptions.Clear();

                if (CategorizedView)
                {
                    GroupedPropertyEntries.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
                }
                else
                {
                    GroupedPropertyEntries.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                }
            }
            else
            {
                PropertyEntries = null;
            }
        }

        private void OnCategoryViewSelectionChangedCommand(object param)
        {
            // Toggle the value of CategorizedView
            CategorizedView = !CategorizedView;

            // Update the property entries based on the new view
            UpdatePropertyEntries();

            // Fire the PropertyChanged event for the CategorizedView property
            OnPropertyChanged(nameof(CategorizedView));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnSelectionChanged(PropertyEntry selectedEntry)
        {
            SelectedEntry = selectedEntry;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedEntry)));
        }
    }
}