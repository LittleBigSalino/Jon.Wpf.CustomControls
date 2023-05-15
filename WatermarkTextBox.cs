using System.Windows;
using System.Windows.Controls;

namespace Jon.Wpf.CustomControls
{
    public class WatermarkTextBox : TextBox
    {
        static WatermarkTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WatermarkTextBox), new FrameworkPropertyMetadata(typeof(WatermarkTextBox)));
        }

        public static readonly DependencyProperty WatermarkTextProperty = DependencyProperty.Register(
            "WatermarkText", typeof(string), typeof(WatermarkTextBox), new PropertyMetadata(default(string)));

        public string WatermarkText
        {
            get => (string)GetValue(WatermarkTextProperty);
            set => SetValue(WatermarkTextProperty, value);
        }

        public static readonly DependencyProperty WatermarkOpacityProperty = DependencyProperty.Register(
            "WatermarkOpacity", typeof(double), typeof(WatermarkTextBox), new PropertyMetadata(0.5d));

        public double WatermarkOpacity
        {
            get => (double)GetValue(WatermarkOpacityProperty);
            set => SetValue(WatermarkOpacityProperty, value);
        }
    }
}
