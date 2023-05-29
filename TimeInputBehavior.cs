using System;
using System.Globalization;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace Jon.Wpf.CustomControls
{
    public class TimeInputBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.LostFocus += OnLostFocus;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.LostFocus -= OnLostFocus;
        }

        private void OnLostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // Validate and reformat the time when the control loses focus
            string text = this.AssociatedObject.Text.Trim();

            // If no AM/PM is specified, default to AM
            if (!text.EndsWith("AM", StringComparison.OrdinalIgnoreCase) && !text.EndsWith("PM", StringComparison.OrdinalIgnoreCase))
            {
                text += " AM";
            }

            if (DateTime.TryParse(text, out DateTime time))
            {
                this.AssociatedObject.Text = time.ToString("h:mm tt", CultureInfo.InvariantCulture);
            }
            else
            {
                this.AssociatedObject.Text = "";
            }
        }
    }
}
