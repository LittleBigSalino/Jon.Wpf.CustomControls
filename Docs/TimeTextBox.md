# TimeTextBox Custom Control

## Overview

The `TimeTextBox` is a custom control for WPF applications, designed to allow users to input time values using keyboard and text. The control uses the familiar '1:27 PM' format and automatically formats the input as the user types. The control has a `SelectedTime` dependency property that holds the parsed `DateTime` value of the input, or `null` if the input is not a valid time.

## How to Use

1. Add a reference to the `Jon.Wpf.CustomControls` library in your WPF project.

2. Declare a namespace in your XAML file:

    ```xaml
    xmlns:custom="clr-namespace:Jon.Wpf.CustomControls;assembly=Jon.Wpf.CustomControls"
    ```

3. Use the `TimeTextBox` control in your XAML:

    ```xaml
    <custom:TimeTextBox SelectedTime="{Binding MyTimeProperty}" />
    ```

## Behavior

The `TimeTextBox` control ensures that user input is always a valid time. The control disallows non-numeric input and ensures that the input can be parsed as a valid time. The control formats the input as a time in the 'h:mm tt' format (e.g., '1:27 PM') as the user types. If no AM/PM specifier is provided, the control defaults to AM.

## SelectedTime Property

The `SelectedTime` property of the `TimeTextBox` control holds the parsed `DateTime` value of the input. This property is a dependency property, meaning it can participate in data binding. The `SelectedTime` property is updated every time the text changes. If the input is not a valid time, `SelectedTime` is set to `null`.

## Customization

The `TimeTextBox` control can be styled as needed to fit into the design of your application. Please refer to the provided default style as a starting point for your custom styles.
