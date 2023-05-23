# TimePicker Control for WPF

![TimePicker Control](https://i.imgur.com/TDHHsJs.png)

## Description

The `TimePicker` is a custom control for .NET's WPF library, designed to facilitate easy time selection within your WPF applications. It addresses the need for a robust and customizable time selection feature, which is not available natively in the WPF control library. The control supports both 24-hour and 12-hour formats and provides the flexibility to set minimum and maximum time constraints.

## How to Use

To utilize the `TimePicker` control in your XAML, use the following syntax:

```xaml
<custom:TimePicker SelectedTime="{Binding SelectedTime}" Is24HourFormat="True" />
```

In the above snippet, replace `custom` with the XML namespace where your `TimePicker` control is defined.

## Exposed Properties

The `TimePicker` control exposes the following properties:

- `SelectedHour`: Represents the currently selected hour. For a 24-hour format, the range is 0-23 and for a 12-hour format, it is 1-12.
- `SelectedMinute`: Represents the currently selected minute, ranging from 0-59.
- `SelectedAmPm`: Used in the 12-hour format to indicate AM (0) or PM (1). This property is not applicable in the 24-hour format.
- `SelectedTime`: Combines the selected hour and minute into a `DateTime` object.
- `MinimumTime`: Defines the earliest time that can be selected. If not set, there are no minimum time constraints.
- `MaximumTime`: Defines the latest time that can be selected. If not set, there are no maximum time constraints.
- `Is24HourFormat`: Determines whether the control displays time in a 24-hour or 12-hour format. The default is `false` (12-hour format).
- `TimeFormat`: Allows customization of the string format for time display, using standard .NET DateTime format strings.

## Dependency Properties

The `TimePicker` control introduces several dependency properties including `SelectedHourProperty`, `SelectedMinuteProperty`, `SelectedAmPmProperty`, `SelectedTimeProperty`, `MinimumTimeProperty`, `MaximumTimeProperty`, `Is24HourFormatProperty`, and `TimeFormatProperty`. These properties extend support for data binding, default values, and property change notification.

## Template Parts

The `TimePicker` control uses the following parts:

- `PART_HourSelector`: A `ComboBox` displaying selectable hours.
- `PART_MinuteSelector`: A `ComboBox` displaying selectable minutes.
- `AmPmSelector`: A `ComboBox` displaying selectable AM/PM options (only applicable for the 12-hour format).

You can customize these parts using the Style property:

```xaml
<local:TimePicker>
    <local:TimePicker.Style>
        <!-- Your custom style here -->
    </local:TimePicker.Style>
</local:TimePicker>
```

## Customization

You can customize the `TimePicker` control by overriding its default style in your XAML. To customize a particular part of the control, style it using the respective part names: `PART_HourSelector`, `PART_MinuteSelector`, `AmPmSelector`.

For instance, to change the background color of the hour selector:

```xaml
<Style TargetType="{x:Type local:TimePicker}">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="{x:Type local:TimePicker}">
                <!-- Your custom template here -->
                <ComboBox x:Name="PART_HourSelector"

Apologies for the confusion. Here is the complete updated README:

# TimePicker Control for WPF

![TimePicker Control](https://i.imgur.com/TDHHsJs.png)

## Description

The `TimePicker` is a custom control for .NET's WPF library, designed to facilitate easy time selection within your WPF applications. It addresses the need for a robust and customizable time selection feature, which is not available natively in the WPF control library. The control supports both 24-hour and 12-hour formats and provides the flexibility to set minimum and maximum time constraints.

## How to Use

To utilize the `TimePicker` control in your XAML, use the following syntax:

```xaml
<custom:TimePicker SelectedTime="{Binding SelectedTime}" Is24HourFormat="True" />
```

In the above snippet, replace `custom` with the XML namespace where your `TimePicker` control is defined.

## Exposed Properties

The `TimePicker` control exposes the following properties:

- `SelectedHour`: Represents the currently selected hour. For a 24-hour format, the range is 0-23 and for a 12-hour format, it is 1-12.
- `SelectedMinute`: Represents the currently selected minute, ranging from 0-59.
- `SelectedAmPm`: Used in the 12-hour format to indicate AM (0) or PM (1). This property is not applicable in the 24-hour format.
- `SelectedTime`: Combines the selected hour and minute into a `DateTime` object.
- `MinimumTime`: Defines the earliest time that can be selected. If not set, there are no minimum time constraints.
- `MaximumTime`: Defines the latest time that can be selected. If not set, there are no maximum time constraints.
- `Is24HourFormat`: Determines whether the control displays time in a 24-hour or 12-hour format. The default is `false` (12-hour format).
- `TimeFormat`: Allows customization of the string format for time display, using standard .NET DateTime format strings.

## Dependency Properties

The `TimePicker` control introduces several dependency properties including `SelectedHourProperty`, `SelectedMinuteProperty`, `SelectedAmPmProperty`, `SelectedTimeProperty`, `MinimumTimeProperty`, `MaximumTimeProperty`, `Is24HourFormatProperty`, and `TimeFormatProperty`. These properties extend support for data binding, default values, and property change notification.

## Template Parts

The `TimePicker` control uses the following parts:

- `PART_HourSelector`: A `ComboBox` displaying selectable hours.
- `PART_MinuteSelector`: A `ComboBox` displaying selectable minutes.
- `AmPmSelector`: A `ComboBox` displaying selectable AM/PM options (only applicable for the 12-hour format).

You can customize these parts using the Style property:

```xaml
<local:TimePicker>
    <local:TimePicker.Style>
        <!-- Your custom style here -->
    </local:TimePicker.Style>
</local:TimePicker>
```

## Customization

You can customize the `TimePicker` control by overriding its default style in your XAML. To customize a particular part of the control, style it using the respective part names: `PART_HourSelector`, `PART_MinuteSelector`, `AmPmSelector`.

For instance, to change the background color of the hour selector:

```xaml
<Style TargetType="{x:Type local:TimePicker}">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="{x:Type local:TimePicker}">
                <!-- Your custom template here -->
                <ComboBox x:Name="PART_HourSelector" Background="Red"

```xml
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```
Please ensure that you keep the part names (`PART_HourSelector`, `PART_MinuteSelector`, `AmPmSelector`) intact when customizing the control, as the control uses these part names in its code-behind to apply functionality.

## Events

The `TimePicker` control raises the `SelectedTimeChanged` event when the selected hour, minute, or AM/PM value is changed. You can handle this event to respond to changes in the user's selection.

## Methods

The `TimePicker` control includes several methods essential for its operation:

- `OnSelectedHourChanged`: Called when the `SelectedHour` property changes. Updates the `SelectedTime` property.
- `OnSelectedMinuteChanged`: Called when the `SelectedMinute` property changes. Updates the `SelectedTime` property.
- `OnSelectedAmPmChanged`: Called when the `SelectedAmPm` property changes. Updates the `SelectedTime` property if the control is not in the 24-hour format.
- `OnIs24HourFormatChanged`: Called when the `Is24HourFormat` property changes. Updates the `TimeFormat` property to the default format for the new setting.
- `GetDefaultTimeFormat`: Returns the default time format string for the current `Is24HourFormat` setting.
- `OnApplyTemplate`: Overridden to initialize the template parts when the control's visual tree is generated.
- `PopulateHourSelector`: Populates the hour selector with the appropriate range of hours based on the current `Is24HourFormat` setting.
- `PopulateMinuteSelector`: Populates the minute selector with minutes from 00 to 59.

## Conclusion

The `TimePicker` control provides a versatile and robust solution for time selection in WPF applications. It offers a wide range of customization options, including support for both 24-hour and 12-hour formats, and the ability to set minimum and maximum time constraints. With built-in support for data binding and property change notification, it seamlessly integrates into MVVM applications, enriching your user interfaces with a comprehensive time selection feature.