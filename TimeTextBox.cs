using System.Windows.Controls;
using System.Windows;
using System;
using Microsoft.Xaml.Behaviors;

namespace Jon.Wpf.CustomControls
{
    public class TimeTextBox : TextBox
    {
        static TimeTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeTextBox), new FrameworkPropertyMetadata(typeof(TimeTextBox)));
        }

        public TimeTextBox()
        {
            Interaction.GetBehaviors(this).Add(new TimeInputBehavior());
            this.TextChanged += OnTextChanged;
        }

        public static readonly DependencyProperty SelectedTimeProperty = DependencyProperty.Register(
            "SelectedTime",
            typeof(DateTime?),
            typeof(TimeTextBox),
            new PropertyMetadata(null));

        public DateTime? SelectedTime
        {
            get => (DateTime?)GetValue(SelectedTimeProperty);
            set => SetValue(SelectedTimeProperty, value);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (DateTime.TryParse(this.Text, out DateTime time))
            {
                SelectedTime = time;
            }
            else
            {
                SelectedTime = null;
            }
        }
    }
}
