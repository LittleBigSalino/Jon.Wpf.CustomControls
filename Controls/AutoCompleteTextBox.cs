using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Jon.Wpf.CustomControls
{
    public class AutocompleteTextBox : TextBox, INotifyPropertyChanged
    {
        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public bool IsDropDownOpen
        {
            get { return _isDropDownOpen; }
            set
            {
                _isDropDownOpen = value;
                OnPropertyChanged();
            }
        }
        public ICommand ShowSuggestionsCommand
        {
            get { return (ICommand)GetValue(ShowSuggestionsCommandProperty); }
            set { SetValue(ShowSuggestionsCommandProperty, value); }
        }
        public IEnumerable FilteredItemsSource
        {
            get { return (IEnumerable)GetValue(FilteredItemsSourceProperty); }
            set { SetValue(FilteredItemsSourceProperty, value); }
        }
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public string SuggestionsDisplayMemberPath
        {
            get { return (string)GetValue(SuggestionsDisplayMemberPathProperty); }
            set { SetValue(SuggestionsDisplayMemberPathProperty, value); }
        }
        public ICommand SelectSuggestionCommand
        {
            get { return (ICommand)GetValue(SelectSuggestionCommandProperty); }
            set { SetValue(SelectSuggestionCommandProperty, value); }
        }
        public ICommand FocusListBoxCommand
        {
            get { return (ICommand)GetValue(FocusListBoxCommandProperty); }
            set { SetValue(FocusListBoxCommandProperty, value); }
        }
        public AutocompleteTextBox()
        {
            SelectSuggestionCommand = new RelayCommand<object>(SelectSuggestion);
            ShowSuggestionsCommand = new RelayCommand<object>(ShowSuggestions);
            FocusListBoxCommand = new RelayCommand<object>(_ => FocusListBox());
        }
        private bool _isDropDownOpen;
        private ListBox _listBox;
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(AutocompleteTextBox), new PropertyMetadata(null));
        public static readonly DependencyProperty ShowSuggestionsCommandProperty = DependencyProperty.Register("ShowSuggestionsCommand", typeof(ICommand), typeof(AutocompleteTextBox), new PropertyMetadata(default(ICommand)));
        public static readonly DependencyProperty FilteredItemsSourceProperty = DependencyProperty.Register("FilteredItemsSource", typeof(IEnumerable), typeof(AutocompleteTextBox), new PropertyMetadata(default(IEnumerable)));
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(AutocompleteTextBox), new PropertyMetadata(null));
        public static readonly DependencyProperty SuggestionsDisplayMemberPathProperty = DependencyProperty.Register("SuggestionsDisplayMemberPath", typeof(string), typeof(AutocompleteTextBox), new PropertyMetadata(null));
        public static readonly DependencyProperty SelectSuggestionCommandProperty = DependencyProperty.Register("SelectSuggestionCommand", typeof(ICommand), typeof(AutocompleteTextBox), new PropertyMetadata(null));
        public static readonly DependencyProperty FocusListBoxCommandProperty = DependencyProperty.Register("FocusListBoxCommand", typeof(ICommand), typeof(AutocompleteTextBox), new PropertyMetadata(default(ICommand)));
        public event PropertyChangedEventHandler PropertyChanged;

        private void ShowSuggestions(object obj)
        {
            IsDropDownOpen = true;
        }
        private void FocusListBox()
        {
            _listBox?.Focus();
        }
        private string GetDisplayString(object item)
        {
            if (string.IsNullOrEmpty(SuggestionsDisplayMemberPath))
            {
                return item.ToString();
            }

            var property = TypeDescriptor.GetProperties(item)[SuggestionsDisplayMemberPath];
            return property?.GetValue(item)?.ToString() ?? string.Empty;
        }
        private void SelectSuggestion(object item)
        {
            // Set the text of the TextBox to the selected suggestion
            Text = GetDisplayString(item);

            // Set the SelectedItem property to the selected item
            SelectedItem = item;

            // Hide the Popup
            IsDropDownOpen = false;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);

            // Display the dropdown when the TextBox receives focus
            IsDropDownOpen = true;

            var filteredItems = ItemsSource.Cast<object>()
                .Where(item => GetDisplayString(item).StartsWith(Text, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Set the ItemsSource of the ListBox to the filtered items
            FilteredItemsSource = filteredItems;

            // Show the Popup if there are any filtered items
            IsDropDownOpen = filteredItems.Any();
        }
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);

            // Set focus to the TextBox
            Focus();
        }
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            // Filter the items based on the current text
            var filteredItems = ItemsSource.Cast<object>()
                .Where(item => GetDisplayString(item).StartsWith(Text, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Set the ItemsSource of the ListBox to the filtered items
            FilteredItemsSource = filteredItems;

            // Show the Popup if there are any filtered items
            IsDropDownOpen = filteredItems.Any();
        }
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            if (e.Key == Key.Down)
            {
                // If the ListBox is not focused, focus it and select the first item
                if (!Equals(FocusManager.GetFocusedElement(this), _listBox))
                {
                    _listBox.Focus();
                    if (_listBox.SelectedIndex == -1)
                    {
                        _listBox.SelectedIndex = 0;
                    }
                }
                // If the ListBox is already focused, select the next item
                else if (_listBox.SelectedIndex < _listBox.Items.Count - 1)
                {
                    _listBox.SelectedIndex++;
                }

                e.Handled = true;
            }
            else if (e.Key == Key.Up)
            {
                // If the ListBox is focused and the selected index is not the first one, select the previous item
                if (Equals(FocusManager.GetFocusedElement(this), _listBox) && _listBox.SelectedIndex > 0)
                {
                    _listBox.SelectedIndex--;
                }

                e.Handled = true;
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _listBox = GetTemplateChild("PART_ListBox") as ListBox;
        }
    }

}