using System.Windows;
using System.Windows.Controls;

namespace Jon.Wpf.CustomControls
{
    public class NumericUpDown : Control
    {
        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }
        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
                                            "ValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<int>), typeof(NumericUpDown));
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(NumericUpDown), new PropertyMetadata(100));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged));

        public event RoutedPropertyChangedEventHandler<int> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NumericUpDown numericUpDown = d as NumericUpDown;

            int newValue = (int)e.NewValue;

            if (newValue < numericUpDown.Minimum)
            {
                numericUpDown.Value = numericUpDown.Minimum;
            }
            else if (newValue > numericUpDown.Maximum)
            {
                numericUpDown.Value = numericUpDown.Maximum;
            }

            numericUpDown.OnValueChanged((int)e.OldValue, newValue);
        }
        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value < Maximum)
            {
                int oldValue = Value;
                Value++;
                OnValueChanged(oldValue, Value);
            }
        }
        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value > Minimum)
            {
                int oldValue = Value;
                Value--;
                OnValueChanged(oldValue, Value);
            }
        }
        protected virtual void OnValueChanged(int oldValue, int newValue)
        {
            RoutedPropertyChangedEventArgs<int> args = new RoutedPropertyChangedEventArgs<int>(oldValue, newValue);
            args.RoutedEvent = NumericUpDown.ValueChangedEvent;
            RaiseEvent(args);
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (Template.FindName("PART_IncreaseButton", this) is Button increaseButton)
            {
                increaseButton.Click += IncreaseButton_Click;
            }

            if (Template.FindName("PART_DecreaseButton", this) is Button decreaseButton)
            {
                decreaseButton.Click += DecreaseButton_Click;
            }
        }
    }
}