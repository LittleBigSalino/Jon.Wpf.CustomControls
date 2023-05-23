using System;
using System.Windows;
using System.Windows.Controls;

namespace Jon.Wpf.CustomControls
{
    //public class NumericUpDown : Control
    //{
    //    private Button _increaseButton;
    //    private Button _decreaseButton;

    //    static NumericUpDown()
    //    {
    //        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
    //    }

    //    public int Minimum
    //    {
    //        get { return (int)GetValue(MinimumProperty); }
    //        set
    //        {
    //            if (value > Maximum)
    //                throw new ArgumentException("Minimum value cannot be greater than Maximum value.");
    //            SetValue(MinimumProperty, value);
    //        }
    //    }

    //    public int Maximum
    //    {
    //        get { return (int)GetValue(MaximumProperty); }
    //        set
    //        {
    //            if (value < Minimum)
    //                throw new ArgumentException("Maximum value cannot be less than Minimum value.");
    //            SetValue(MaximumProperty, value);
    //        }
    //    }

    //    public int Value
    //    {
    //        get { return (int)GetValue(ValueProperty); }
    //        set { SetValue(ValueProperty, value); }
    //    }

    //    public static readonly DependencyProperty MinimumProperty =
    //        DependencyProperty.Register("Minimum", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0));

    //    public static readonly DependencyProperty MaximumProperty =
    //        DependencyProperty.Register("Maximum", typeof(int), typeof(NumericUpDown), new PropertyMetadata(10));

    //    public static readonly DependencyProperty ValueProperty =
    //        DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged));

    //    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //    {
    //        NumericUpDown numericUpDown = d as NumericUpDown;

    //        int newValue = (int)e.NewValue;

    //        if (newValue < numericUpDown.Minimum)
    //        {
    //            numericUpDown.Value = numericUpDown.Minimum;
    //        }
    //        else if (newValue > numericUpDown.Maximum)
    //        {
    //            numericUpDown.Value = numericUpDown.Maximum;
    //        }

    //        numericUpDown.ChangeValueAndRaiseEvent((int)e.OldValue, newValue);
    //    }

    //    private void IncreaseButton_Click(object sender, RoutedEventArgs e)
    //    {
    //        ChangeValueAndRaiseEvent(Value, Value + 1);
    //    }

    //    private void DecreaseButton_Click(object sender, RoutedEventArgs e)
    //    {
    //        ChangeValueAndRaiseEvent(Value, Value - 1);
    //    }

    //    private void ChangeValueAndRaiseEvent(int oldValue, int newValue)
    //    {
    //        if (newValue >= Minimum && newValue <= Maximum)
    //        {
    //            Value = newValue;
    //            OnValueChanged(oldValue, newValue);
    //        }
    //    }

    //    protected virtual void OnValueChanged(int oldValue, int newValue)
    //    {
    //        RoutedPropertyChangedEventArgs<int> args = new RoutedPropertyChangedEventArgs<int>(oldValue, newValue);
    //        args.RoutedEvent = ValueChangedEvent;
    //        RaiseEvent(args);
    //    }

    //    public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
    //"ValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<int>), typeof(NumericUpDown));


    //    public override void OnApplyTemplate()
    //    {
    //        base.OnApplyTemplate();

    //        if (_increaseButton != null)
    //        {
    //            _increaseButton.Click -= IncreaseButton_Click;
    //        }

    //        if (_decreaseButton != null)
    //        {
    //            _decreaseButton.Click -= DecreaseButton_Click;
    //        }

    //        if (Template.FindName("PART_IncreaseButton", this) is Button increaseButton)
    //        {
    //            _increaseButton = increaseButton;
    //            _increaseButton.Click += IncreaseButton_Click;
    //        }

    //        if (Template.FindName("PART_DecreaseButton", this) is Button decreaseButton)
    //        {
    //            _decreaseButton = decreaseButton;
    //            _decreaseButton.Click += DecreaseButton_Click;
    //        }
    //    }
    //}

    public class NumericUpDown : Control
    {
        private Button _increaseButton;
        private Button _decreaseButton;

        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }

        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set
            {
                if (value > Maximum)
                    throw new ArgumentException("Minimum value cannot be greater than Maximum value.");
                SetValue(MinimumProperty, value);
            }
        }

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set
            {
                if (value < Minimum)
                    throw new ArgumentException("Maximum value cannot be less than Minimum value.");
                SetValue(MaximumProperty, value);
            }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(NumericUpDown), new PropertyMetadata(10));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NumericUpDown numericUpDown = d as NumericUpDown;

            int newValue = (int)e.NewValue;
            int oldValue = (int)e.OldValue;

            numericUpDown.ChangeValueAndRaiseEvent(oldValue, newValue);
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeValueAndRaiseEvent(Value, Value + 1);
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeValueAndRaiseEvent(Value, Value - 1);
        }

        public event RoutedPropertyChangedEventHandler<int> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }


        private void ChangeValueAndRaiseEvent(int oldValue, int newValue)
        {
            if (newValue < Minimum)
            {
                newValue = Minimum;
            }
            else if (newValue > Maximum)
            {
                newValue = Maximum;
            }

            if (newValue != Value)
            {
                Value = newValue;
                OnValueChanged(oldValue, newValue);
            }
        }

        protected virtual void OnValueChanged(int oldValue, int newValue)
        {
            RoutedPropertyChangedEventArgs<int> args = new RoutedPropertyChangedEventArgs<int>(oldValue, newValue);
            args.RoutedEvent = ValueChangedEvent;
            RaiseEvent(args);
        }

        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
            "ValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<int>), typeof(NumericUpDown));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (_increaseButton != null)
            {
                _increaseButton.Click -= IncreaseButton_Click;
            }

            if (_decreaseButton != null)
            {
                _decreaseButton.Click -= DecreaseButton_Click;
            }

            if (Template.FindName("PART_IncreaseButton", this) is Button increaseButton)
            {
                _increaseButton = increaseButton;
                _increaseButton.Click += IncreaseButton_Click;
            }

            if (Template.FindName("PART_DecreaseButton", this) is Button decreaseButton)
            {
                _decreaseButton = decreaseButton;
                _decreaseButton.Click += DecreaseButton_Click;
            }
        }
    }


}