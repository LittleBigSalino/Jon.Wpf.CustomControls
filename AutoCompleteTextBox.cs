using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Jon.Wpf.CustomControls
{

    public class AutocompleteTextBox : TextBox
    {
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof(IEnumerable), typeof(AutocompleteTextBox), new PropertyMetadata(null));

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty SuggestionsDisplayMemberPathProperty = DependencyProperty.Register(
            "SuggestionsDisplayMemberPath", typeof(string), typeof(AutocompleteTextBox), new PropertyMetadata(null));

        public string SuggestionsDisplayMemberPath
        {
            get { return (string)GetValue(SuggestionsDisplayMemberPathProperty); }
            set { SetValue(SuggestionsDisplayMemberPathProperty, value); }
        }

        public static readonly DependencyProperty SelectSuggestionCommandProperty = DependencyProperty.Register(
            "SelectSuggestionCommand", typeof(ICommand), typeof(AutocompleteTextBox), new PropertyMetadata(null));

        public ICommand SelectSuggestionCommand
        {
            get { return (ICommand)GetValue(SelectSuggestionCommandProperty); }
            set { SetValue(SelectSuggestionCommandProperty, value); }
        }

        public AutocompleteTextBox()
        {
            SelectSuggestionCommand = new RelayCommand<object>(SelectSuggestion);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            // Filter the items based on the current text
            var filteredItems = ItemsSource.Cast<object>()
                .Where(item => GetDisplayString(item).StartsWith(Text, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // TODO: Set the ItemsSource of the ListBox to the filtered items
            // TODO: Show the Popup if there are any filtered items
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

            // TODO: Hide the Popup
        }
    }

}
