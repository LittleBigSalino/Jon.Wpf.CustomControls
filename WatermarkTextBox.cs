using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jon.Wpf.CustomControls
{
    public class WatermarkTextBox : TextBox
    {
        public string WatermarkText
        {
            get => (string)GetValue(WatermarkTextProperty);
            set => SetValue(WatermarkTextProperty, value);
        }
        public double WatermarkOpacity
        {
            get => (double)GetValue(WatermarkOpacityProperty);
            set => SetValue(WatermarkOpacityProperty, value);
        }
        public Brush WatermarkColor
        {
            get => (Brush)GetValue(WatermarkColorProperty);
            set => SetValue(WatermarkColorProperty, value);
        }
        static WatermarkTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WatermarkTextBox), new FrameworkPropertyMetadata(typeof(WatermarkTextBox)));
        }

        public static readonly DependencyProperty WatermarkTextProperty = DependencyProperty.Register(
            "WatermarkText", typeof(string), typeof(WatermarkTextBox), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty WatermarkOpacityProperty = DependencyProperty.Register(
            "WatermarkOpacity", typeof(double), typeof(WatermarkTextBox), new PropertyMetadata(0.5d));
        public static readonly DependencyProperty WatermarkColorProperty = DependencyProperty.Register(
            "WatermarkColor", typeof(Brush), typeof(WatermarkTextBox), new PropertyMetadata(Brushes.Gray));
    }
}