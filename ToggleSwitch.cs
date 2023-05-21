using System;
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
            set => SetValue(OffTextProperty, ValidateText(value, nameof(OffText)));
        }
        public string OnText
        {
            get => (string)GetValue(OnTextProperty);
            set => SetValue(OnTextProperty, ValidateText(value, nameof(OnText)));
        }
        public Brush OffForeground
        {
            get => (Brush)GetValue(OffForegroundProperty);
            set => SetValue(OffForegroundProperty, ValidateBrush(value, nameof(OffForeground)));
        }
        public Brush OnForeground
        {
            get => (Brush)GetValue(OnForegroundProperty);
            set => SetValue(OnForegroundProperty, ValidateBrush(value, nameof(OnForeground)));
        }
        static ToggleSwitch()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleSwitch), new FrameworkPropertyMetadata(typeof(ToggleSwitch)));
        }
        public static readonly DependencyProperty OffTextProperty =
            RegisterProperty("OffText", typeof(string), "Off");

        public static readonly DependencyProperty OnTextProperty =
            RegisterProperty("OnText", typeof(string), "On");

        public static readonly DependencyProperty OffForegroundProperty =
            RegisterProperty("OffForeground", typeof(Brush), Brushes.Black);

        public static readonly DependencyProperty OnForegroundProperty =
            RegisterProperty("OnForeground", typeof(Brush), Brushes.Black);

        private static DependencyProperty RegisterProperty(string name, Type type, object defaultValue)
        {
            return DependencyProperty.Register(name, type, typeof(ToggleSwitch), new PropertyMetadata(defaultValue));
        }

        private static string ValidateText(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Property {propertyName} cannot be null or whitespace.", propertyName);
            }

            return value;
        }

        private static Brush ValidateBrush(Brush value, string propertyName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(propertyName, $"Property {propertyName} cannot be null.");
            }

            return value;
        }
    }

}