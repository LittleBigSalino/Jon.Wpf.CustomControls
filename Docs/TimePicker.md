# TimePicker.md

## Description

The `TimePicker` control is a custom component for .NET's WPF library. It fills in the gap left by the native WPF controls by providing a customizable and robust time selection feature. It supports both 24-hour and 12-hour formats, and exposes properties to set minimum and maximum time constraints.

## Usage

Here is an example of how to use the `TimePicker` control in your XAML:

```xaml
<custom:TimePicker SelectedTime="{Binding SelectedTime}" Is24HourFormat="True" />
```

Replace `custom` with the XML namespace where your custom control is defined.

## Properties

Below are the properties exposed by the `TimePicker` control.

### SelectedHour

The `SelectedHour` property represents the currently selected hour in the `TimePicker` control. It can be set to any integer from 0 to 23 (in case of 24-hour format) or 1 to 12 (in case of 12-hour format).

### SelectedMinute

The `SelectedMinute` property represents the currently selected minute in the `TimePicker` control. It can be set to any integer from 0 to 59.

### SelectedAmPm

The `SelectedAmPm` property is used in the 12-hour format to determine whether the selected time is AM (0) or PM (1). This property has no effect when the `TimePicker` is set to the 24-hour format.

### SelectedTime

The `SelectedTime` property represents the currently selected time in the `TimePicker` control as a `DateTime` object. This property combines the hour and minute selected by the user.

### MinimumTime

The `MinimumTime` property defines the earliest time that can be selected in the `TimePicker` control. It is a nullable `DateTime` object. If not set, there is no minimum time constraint.

### MaximumTime

The `MaximumTime` property defines the latest time that can be selected in the `TimePicker` control. It is a nullable `DateTime` object. If not set, there is no maximum time constraint.

### Is24HourFormat

The `Is24HourFormat` property determines whether the `TimePicker` should display time in a 24-hour format (`true`) or a 12-hour format (`false`). The default value is `false`.

### TimeFormat

The `TimeFormat` property allows you to set the string format for displaying the time. It uses the standard .NET DateTime format strings. By default, it is set to "HH:mm" for 24-hour format and "h:mm tt" for 12-hour format.

## Dependency Properties

The `TimePicker` control has several dependency properties. These include: `SelectedHourProperty`, `SelectedMinuteProperty`, `SelectedAmPmProperty`, `SelectedTimeProperty`, `MinimumTimeProperty`, `MaximumTimeProperty`, `Is24HourFormatProperty`, and `TimeFormatProperty`.

Each of these properties has a corresponding public property that you can use to get or set its value. The dependency properties also provide built-in support for data binding, default values, and property change notification.

## Template Parts

The `TimePicker` control uses the following parts:

- `PART_HourSelector`: A `ComboBox` that displays the selectable hours.
- `PART_MinuteSelector`: A `ComboBox` that displays the selectable minutes.
- `AmPmSelector`: A `ComboBox` that displays the selectable AM/PM options (only applicable for the 12-hour format).

## Events

The `TimePicker` control raises the `SelectionChanged` event when the user changes the selected hour, minute, or AM/PM value. You can handle this event to respond
to changes in the user's selection.

## Methods

The `TimePicker` control also includes several methods which allow it to function properly:

- `OnSelectedHourChanged`: This method is called when the `SelectedHour` property is changed. It updates the `SelectedTime` property accordingly.
- `OnSelectedMinuteChanged`: This method is called when the `SelectedMinute` property is changed. It updates the `SelectedTime` property accordingly.
- `OnSelectedAmPmChanged`: This method is called when the `SelectedAmPm` property is changed. It updates the `SelectedTime` property accordingly, if the control is not set to 24-hour format.
- `OnIs24HourFormatChanged`: This method is called when the `Is24HourFormat` property is changed. It updates the `TimeFormat` property to the default format for the new setting.
- `GetDefaultTimeFormat`: This method returns the default time format string for the current `Is24HourFormat` setting.
- `OnApplyTemplate`: This method is overridden to initialize the template parts when the control's visual tree is generated.
- `PopulateHourSelector`: This method populates the hour selector with the appropriate range of hours based on the current `Is24HourFormat` setting.
- `PopulateMinuteSelector`: This method populates the minute selector with minutes from 00 to 59.

## Conclusion

The `TimePicker` control is a versatile and robust solution for time selection in WPF applications. It provides a wide range of options for customization, including 24-hour and 12-hour formats, and minimum and maximum time constraints. With its support for data binding and property change notification, it can be seamlessly integrated into MVVM applications.