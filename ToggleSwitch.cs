using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Jon.Wpf.CustomControls
{
    public class ToggleSwitch : ToggleButton
    {
        public string OffText
        {
            get => (string)GetValue(OffTextProperty);
            set => SetValue(OffTextProperty, value);
        }
        public string OnText
        {
            get => (string)GetValue(OnTextProperty);
            set => SetValue(OnTextProperty, value);
        }
        public Brush OffForeground
        {
            get => (Brush)GetValue(OffForegroundProperty);
            set => SetValue(OffForegroundProperty, value);
        }
        public Brush OnForeground
        {
            get => (Brush)GetValue(OnForegroundProperty);
            set => SetValue(OnForegroundProperty, value);
        }
        static ToggleSwitch()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleSwitch), new FrameworkPropertyMetadata(typeof(ToggleSwitch)));
        }
        public static readonly DependencyProperty OffTextProperty =
            DependencyProperty.Register("OffText", typeof(string), typeof(ToggleSwitch), new PropertyMetadata("Off"));
        public static readonly DependencyProperty OnTextProperty =
            DependencyProperty.Register("OnText", typeof(string), typeof(ToggleSwitch), new PropertyMetadata("On"));
        public static readonly DependencyProperty OffForegroundProperty =
            DependencyProperty.Register("OffForeground", typeof(Brush), typeof(ToggleSwitch), new PropertyMetadata(Brushes.Black));
        public static readonly DependencyProperty OnForegroundProperty =
            DependencyProperty.Register("OnForeground", typeof(Brush), typeof(ToggleSwitch), new PropertyMetadata(Brushes.Black));
    }

}
