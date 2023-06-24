

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Jon.Wpf.CustomControls
{
    public class TimePicker : Control
    {
        // Add null checks for SelectedTime in properties
        public int SelectedHour
        {
            get { return (SelectedTime.HasValue) ? SelectedTime.Value.Hour % 12 : DateTime.Now.Hour % 12; }
            set
            {
                if (SelectedTime.HasValue)
                {
                    var newTime = new DateTime(SelectedTime.Value.Year, SelectedTime.Value.Month, SelectedTime.Value.Day, value, SelectedMinute, 0);
                    SelectedTime = newTime;
                }
            }
        }
        public int SelectedMinute
        {
            get { return (SelectedTime.HasValue) ? SelectedTime.Value.Minute : DateTime.Now.Minute; }
            set
            {
                if (SelectedTime.HasValue)
                {
                    var newTime = new DateTime(SelectedTime.Value.Year, SelectedTime.Value.Month, SelectedTime.Value.Day, SelectedHour, value, 0);
                    SelectedTime = newTime;
                }
            }
        }
        public int SelectedAmPm
        {
            get { return (SelectedTime.HasValue) ? (SelectedTime.Value.Hour >= 12 ? 1 : 0) : (DateTime.Now.Hour >= 12 ? 1 : 0); }
            set
            {
                if (!Is24HourFormat)
                {
                    SetValue(SelectedAmPmProperty, value);
                }
            }
        }

        public DateTime? SelectedTime
        {
            get => (DateTime?)GetValue(SelectedTimeProperty);
            set => SetValue(SelectedTimeProperty, value);
        }
        public DateTime? MinimumTime
        {
            get => (DateTime?)GetValue(MinimumTimeProperty);
            set => SetValue(MinimumTimeProperty, value);
        }
        public DateTime? MaximumTime
        {
            get => (DateTime?)GetValue(MaximumTimeProperty);
            set => SetValue(MaximumTimeProperty, value);
        }
        public bool Is24HourFormat
        {
            get => (bool)GetValue(Is24HourFormatProperty);
            set => SetValue(Is24HourFormatProperty, value);
        }
        public string TimeFormat
        {
            get => (string)GetValue(TimeFormatProperty);
            set => SetValue(TimeFormatProperty, value);
        }
        static TimePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimePicker), new FrameworkPropertyMetadata(typeof(TimePicker)));
        }
        public TimePicker()
        {
            SetCurrentValue(TimeFormatProperty, GetDefaultTimeFormat());
            SelectedTime = DateTime.Now;

            // Add PropertyChanged event handler
            
        }
        public static readonly RoutedEvent SelectedTimeChangedEvent = EventManager.RegisterRoutedEvent(
                                                            "SelectedTimeChanged",
    RoutingStrategy.Bubble,
    typeof(RoutedPropertyChangedEventHandler<DateTime?>),
    typeof(TimePicker));

        // Group DependencyProperty fields together
        public static readonly DependencyProperty SelectedHourProperty = DependencyProperty.Register(
            "SelectedHour",
            typeof(int),
            typeof(TimePicker),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnTimeChanged));
        public static readonly DependencyProperty SelectedMinuteProperty = DependencyProperty.Register(
            "SelectedMinute",
            typeof(int),
            typeof(TimePicker),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnTimeChanged));
        public static readonly DependencyProperty SelectedAmPmProperty = DependencyProperty.Register(
            "SelectedAmPm",
            typeof(int),
            typeof(TimePicker),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedAmPmChanged));
        public static readonly DependencyProperty SelectedTimeProperty = DependencyProperty.Register(
            "SelectedTime",
            typeof(DateTime?),
            typeof(TimePicker),
            new PropertyMetadata(DateTime.Now, OnTimeChanged));
        public static readonly DependencyProperty MinimumTimeProperty = DependencyProperty.Register(
            "MinimumTime",
            typeof(DateTime?),
            typeof(TimePicker),
            new PropertyMetadata(null));
        public static readonly DependencyProperty MaximumTimeProperty = DependencyProperty.Register(
            "MaximumTime",
            typeof(DateTime?),
            typeof(TimePicker),
            new PropertyMetadata(null));
        public static readonly DependencyProperty Is24HourFormatProperty = DependencyProperty.Register(
            "Is24HourFormat",
            typeof(bool),
            typeof(TimePicker),
            new PropertyMetadata(false, OnIs24HourFormatChanged));
        public static readonly DependencyProperty TimeFormatProperty = DependencyProperty.Register(
            "TimeFormat",
            typeof(string),
            typeof(TimePicker),
            new PropertyMetadata(null));
        public event RoutedPropertyChangedEventHandler<DateTime?> SelectedTimeChanged
        {
            add { AddHandler(SelectedTimeChangedEvent, value); }
            remove { RemoveHandler(SelectedTimeChangedEvent, value); }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == SelectedTimeProperty)
            {
                // Update ComboBoxes
                var hourSelector = GetTemplateChild("PART_HourSelector") as ComboBox;
                var minuteSelector = GetTemplateChild("PART_MinuteSelector") as ComboBox;
                var amPmSelector = GetTemplateChild("AmPmSelector") as ComboBox;

                if (hourSelector != null)
                {
                    hourSelector.SelectedItem = SelectedHour;
                }

                if (minuteSelector != null)
                {
                    minuteSelector.SelectedItem = SelectedMinute.ToString("D2");
                }

                //if (amPmSelector != null)
                //{
                //    amPmSelector.SelectedItem = SelectedAmPm == 1 ? "PM" : "AM";
                //}
                if (amPmSelector != null)
                {
                    var newAmPm = SelectedAmPm == 1 ? "PM" : "AM";
                    var itemToSelect = amPmSelector.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content as string == newAmPm);
                    if (itemToSelect != null && amPmSelector.SelectedItem != itemToSelect)
                    {
                        amPmSelector.SelectedItem = itemToSelect;
                    }
                }

            }
        }



        private void TimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedTime))
            {
                // Update ComboBoxes
                var hourSelector = GetTemplateChild("PART_HourSelector") as ComboBox;
                var minuteSelector = GetTemplateChild("PART_MinuteSelector") as ComboBox;
                var amPmSelector = GetTemplateChild("AmPmSelector") as ComboBox;

                if (hourSelector != null)
                {
                    hourSelector.SelectedItem = SelectedHour;
                }

                if (minuteSelector != null)
                {
                    minuteSelector.SelectedItem = SelectedMinute.ToString("D2");
                }

                if (amPmSelector != null)
                {
                    amPmSelector.SelectedIndex = SelectedAmPm;
                }
            }
        }

        private static void OnTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TimePicker timePicker)
            {
                // Check which property changed
                if (e.Property == SelectedHourProperty || e.Property == SelectedMinuteProperty || e.Property == SelectedAmPmProperty)
                {
                    // Handle SelectedHour, SelectedMinute, and SelectedAmPm changes
                    DateTime currentTime = timePicker.SelectedTime.HasValue ? timePicker.SelectedTime.Value : DateTime.Now;
                    int newHour = timePicker.SelectedHour;
                    int newMinute = timePicker.SelectedMinute;

                    if (timePicker.SelectedAmPm == 1 && newHour < 12)
                    {
                        newHour += 12;
                    }
                    else if (timePicker.SelectedAmPm == 0 && newHour >= 12)
                    {
                        newHour -= 12;
                    }

                    DateTime? newValue = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, newHour, newMinute, currentTime.Second);

                    // Check to prevent recursive call
                    if (timePicker.SelectedTime != newValue)
                    {
                        // Don't raise the event here; we'll raise it after handling SelectedTime changes
                        timePicker.SelectedTime = newValue;
                    }
                }
                else if (e.Property == SelectedTimeProperty)
                {
                    // Handle SelectedTime changes
                    DateTime? newValue = (DateTime?)e.NewValue;

                    // Update SelectedHour, SelectedMinute, and SelectedAmPm according to the new SelectedTime
                    if (newValue.HasValue)
                    {
                        // Check to prevent recursive calls
                        if (timePicker.SelectedHour != newValue.Value.Hour % 12)
                        {
                            timePicker.SelectedHour = newValue.Value.Hour % 12;
                        }
                        if (timePicker.SelectedMinute != newValue.Value.Minute)
                        {
                            timePicker.SelectedMinute = newValue.Value.Minute;
                        }
                        if (timePicker.SelectedAmPm != (newValue.Value.Hour >= 12 ? 1 : 0))
                        {
                            timePicker.SelectedAmPm = newValue.Value.Hour >= 12 ? 1 : 0;
                        }
                    }

                    // Raise the SelectedTimeChanged event
                    DateTime? oldValue = (DateTime?)e.OldValue;
                    timePicker.RaiseSelectedTimeChangedEvent(oldValue, newValue);
                }
            }
        }




        private static void OnIs24HourFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TimePicker timePicker)
            {
                timePicker.SetCurrentValue(TimeFormatProperty, timePicker.GetDefaultTimeFormat());
                // Hide or disable AM/PM selection if 24-hour format is selected
                var amPmSelector = timePicker.GetTemplateChild("AmPmSelector") as ComboBox;
                if (amPmSelector != null)
                {
                    amPmSelector.IsEnabled = !timePicker.Is24HourFormat;
                }
            }
        }
        private static void OnSelectedAmPmChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TimePicker timePicker = (TimePicker)d;
            if (timePicker.Is24HourFormat)
            {
                return;
            }

            int newAmPmValue = (int)e.NewValue;
            DateTime currentTime = timePicker.SelectedTime.HasValue ? timePicker.SelectedTime.Value : DateTime.Now;
            int newHour = currentTime.Hour;

            if (newAmPmValue == 1 && newHour < 12)
            {
                newHour += 12;
            }
            else if (newAmPmValue == 0 && newHour >= 12)
            {
                newHour -= 12;
            }

            timePicker.SelectedTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, newHour, currentTime.Minute, currentTime.Second);
        }
        private void RaiseSelectedTimeChangedEvent(DateTime? oldValue, DateTime? newValue)
        {
            RoutedPropertyChangedEventArgs<DateTime?> args = new(oldValue, newValue, SelectedTimeChangedEvent);
            RaiseEvent(args);
        }
        private string GetDefaultTimeFormat()
        {
            return Is24HourFormat ? "HH:mm" : "h:mm tt";
        }

        private void PopulateHourSelector(ComboBox hourSelector)
        {
            int startHour = Is24HourFormat ? 0 : 1;
            int endHour = Is24HourFormat ? 23 : 12;

            for (int i = startHour; i <= endHour; i++)
            {
                hourSelector.Items.Add(i);
            }
        }

        private void PopulateMinuteSelector(ComboBox minuteSelector)
        {
            for (int i = 0; i < 60; i++)
            {
                minuteSelector.Items.Add(i.ToString("D2"));
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var hourSelector = GetTemplateChild("PART_HourSelector") as ComboBox;
            var minuteSelector = GetTemplateChild("PART_MinuteSelector") as ComboBox;
            var amPmSelector = GetTemplateChild("AmPmSelector") as ComboBox;

            if (hourSelector != null && minuteSelector != null && amPmSelector != null)
            {
                PopulateHourSelector(hourSelector);
                PopulateMinuteSelector(minuteSelector);
                hourSelector.SelectedItem = SelectedHour;
                minuteSelector.SelectedItem = SelectedMinute.ToString("D2");
                amPmSelector.SelectedIndex = SelectedAmPm;

                // Add SelectionChanged event handlers
                hourSelector.SelectionChanged += HourSelector_SelectionChanged;
                minuteSelector.SelectionChanged += MinuteSelector_SelectionChanged;
                amPmSelector.SelectionChanged += AmPmSelector_SelectionChanged;
            }
        }

        private void HourSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox hourSelector && hourSelector.SelectedItem is int selectedHour)
            {
                SelectedHour = selectedHour;
            }
        }

        private void MinuteSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox minuteSelector && minuteSelector.SelectedItem is string selectedMinuteStr && int.TryParse(selectedMinuteStr, out int selectedMinute))
            {
                SelectedMinute = selectedMinute;
            }
        }

        private void AmPmSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox amPmSelector && amPmSelector.SelectedItem is string selectedAmPm)
            {
                SelectedAmPm = selectedAmPm == "PM" ? 1 : 0;
            }
        }
    }
}