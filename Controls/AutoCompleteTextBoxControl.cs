using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jon.Wpf.CustomControls
{

    public class AutoCompleteTextBoxControl : Control
    {
        private Popup autoListPopup;
        private ListBox autoList;
        private TextBox autoTextBox;
        private List<object> autoSuggestionList = new List<object>();

        public static readonly DependencyProperty AutoSuggestionListDisplayMemberPathProperty =
            DependencyProperty.Register("AutoSuggestionListDisplayMemberPath", typeof(string), typeof(AutoCompleteTextBoxControl), new PropertyMetadata(string.Empty));

        static AutoCompleteTextBoxControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AutoCompleteTextBoxControl), new FrameworkPropertyMetadata(typeof(AutoCompleteTextBoxControl)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            autoListPopup = GetTemplateChild("PART_AutoListPopup") as Popup;
            autoList = GetTemplateChild("PART_AutoList") as ListBox;
            autoTextBox = GetTemplateChild("PART_AutoTextBox") as TextBox;

            if (autoTextBox != null)
            {
                autoTextBox.TextChanged += AutoTextBox_TextChanged;
            }

            if (autoList != null)
            {
                autoList.SelectionChanged += AutoList_SelectionChanged;
            }
        }

        public List<object> AutoSuggestionList
        {
            get { return this.autoSuggestionList; }
            set { this.autoSuggestionList = value; }
        }

        public string AutoSuggestionListDisplayMemberPath
        {
            get { return (string)GetValue(AutoSuggestionListDisplayMemberPathProperty); }
            set { SetValue(AutoSuggestionListDisplayMemberPathProperty, value); }
        }

        private void OpenAutoSuggestionBox()
        {
            autoListPopup.Visibility = Visibility.Visible;
            autoListPopup.IsOpen = true;
            autoList.Visibility = Visibility.Visible;
            
            
        }


        private void CloseAutoSuggestionBox()
        {
            autoListPopup.Visibility = Visibility.Collapsed;
            autoListPopup.IsOpen = false;
            autoList.Visibility = Visibility.Collapsed;
        }

        private void AutoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(autoTextBox.Text))
            {
                CloseAutoSuggestionBox();
                return;
            }

            OpenAutoSuggestionBox();

            var propertyInfo = autoSuggestionList[0].GetType().GetProperty(AutoSuggestionListDisplayMemberPath);
            var displayList = AutoSuggestionList.Select(p => propertyInfo.GetValue(p, null).ToString()).ToList();
            autoList.ItemsSource = displayList.Where(p => p.ToLower().Contains(autoTextBox.Text.ToLower())).ToList();
        }

        private void AutoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down && autoListPopup.IsOpen)
            {
                autoList.Focus();
                autoList.SelectedIndex = 0;
            }
        }

        private void AutoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (autoList.SelectedIndex <= -1)
            {
                CloseAutoSuggestionBox();
                return;
            }

            CloseAutoSuggestionBox();

            autoTextBox.Text = autoList.SelectedItem.ToString();
            autoList.SelectedIndex = -1;

            // Return focus to the TextBox
            autoTextBox.Focus();
        }






    }


}
