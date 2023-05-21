# ToggleSwitch.md

![ToggleSwitch](https://github.com/LittleBigSalino/Jon.Wpf.CustomControls/blob/master/images/ToggleSwitch.png?raw=true)

## Overview

The `ToggleSwitch` is a custom control that extends the `ToggleButton` in the WPF framework. This control provides a user-friendly way to switch an option on or off. It visually represents the binary state of the bound value, with customizable text and color for both states.

## Properties

The `ToggleSwitch` control exposes the following properties:

- `OffText`: A `string` that represents the text to be displayed when the toggle switch is in the off state. This is a dependency property.

- `OnText`: A `string` that represents the text to be displayed when the toggle switch is in the on state. This is a dependency property.

- `OffForeground`: A `Brush` that represents the foreground color of the `OffText`. This is a dependency property.

- `OnForeground`: A `Brush` that represents the foreground color of the `OnText`. This is a dependency property.

All of these properties can be set in XAML or in code, and they all support data binding.

## Control Template

The `ToggleSwitch` control has a custom control template that defines its appearance and behavior. It consists of a `Border` containing a `Grid`, with three columns for the `OffText`, handle, and `OnText` respectively.

When the control's `IsChecked` property is `true`, the handle moves to the left and the `OnText` is displayed. When `IsChecked` is `false`, the handle moves to the right and the `OffText` is displayed. The movement of the handle is animated over a duration of 0.3 seconds.

The `Foreground` property of the `OffText` and `OnText` is bound to the `OffForeground` and `OnForeground` properties respectively, allowing for custom text color in each state.

## Usage

The `ToggleSwitch` control can be used in XAML as follows:

```xml
<local:ToggleSwitch OffText="Disabled" OnText="Enabled" OffForeground="Gray" OnForeground="Green" />
```

This will create a toggle switch that displays "Disabled" in gray when it's off and "Enabled" in green when it's on.

This control can be used anywhere a `ToggleButton` would be used, but provides a more intuitive and visually appealing way for users to interact with boolean values.
# Template Parts

This control uses several named parts in its template:

- `PART_RootGrid`: The main layout container. Its columns house the `OffText`, handle, and `OnText`.
- `PART_OffText`: The `TextBlock` that displays the `OffText`.
- `PART_HandleGrid`: The `Grid` that contains the handle. It moves from right to left or left to right when the toggle state changes.
- `PART_Handle`: The handle that visually represents the state of the switch.
- `PART_OnText`: The `TextBlock` that displays the `OnText`.
- `PART_HandleTranslateTransform`: The `TranslateTransform` applied to `PART_HandleGrid` to animate the handle's movement.

## Visual States

The control defines two visual state groups:

- `CommonStates`: This includes the `Normal`, `MouseOver`, `Pressed`, and `Disabled` states, which are common to all button-based controls.
- `CheckStates`: This includes the `Checked`, `Unchecked`, and `Indeterminate` states. The `Checked` and `Unchecked` states animate the handle's position to visually represent the switch's state.

## Styling and Theming

The `ToggleSwitch` control can be styled just like any other WPF control. You can change its appearance by creating a new `Style` with `TargetType="{x:Type local:ToggleSwitch}"`. You can override the control's template to completely change its appearance and behavior.

The control's default style is based on the `ToggleButton` style. You can base your custom style on the default style by setting `BasedOn="{StaticResource {x:Type ToggleButton}}"`.

## Extending the Control

The `ToggleSwitch` control can be extended to add new functionality. For example, you could add a `TransitionDuration` property to allow the animation speed to be customized. Or you could add a `HandleColor` property to allow the handle's color to be customized.

Here's an example of how you might add a `TransitionDuration` property:

```csharp
public static readonly DependencyProperty TransitionDurationProperty =
    DependencyProperty.Register(
        "TransitionDuration",
        typeof(Duration),
        typeof(ToggleSwitch),
        new PropertyMetadata(new Duration(TimeSpan.FromSeconds(0.3))));

public Duration TransitionDuration
{
    get => (Duration)GetValue(TransitionDurationProperty);
    set => SetValue(TransitionDurationProperty, value);
}
```

Then, in the control's template, you would bind the `DoubleAnimation.Duration` property to this new property:

```xml
<DoubleAnimation
    Storyboard.TargetName="PART_HandleTranslateTransform"
    Storyboard.TargetProperty="X"
    To="0"
    Duration="{Binding TransitionDuration, RelativeSource={RelativeSource TemplatedParent}}" />
```

With this change, you can now set the transition duration in XAML:

```xml
<local:ToggleSwitch TransitionDuration="0:0:1" />
```

This will make the handle transition take 1 second, instead of the default 0.3 seconds.To further enhance your `ToggleSwitch` control, you might want to handle the case when the control is disabled. This can be achieved by using the `Disabled` visual state. You can also adjust the appearance of the control when the mouse is over it or when it is pressed by using the `MouseOver` and `Pressed` states respectively.

Here's an example of how to define these states:

```xml
<VisualStateGroup x:Name="CommonStates">
    <VisualState x:Name="Normal" />
    <VisualState x:Name="MouseOver">
        <Storyboard>
            <ColorAnimation Storyboard.TargetName="PART_Handle"
                            Storyboard.TargetProperty="Fill.(SolidColorBrush.Color)"
                            To="LightGray"
                            Duration="0:0:0.1" />
        </Storyboard>
    </VisualState>
    <VisualState x:Name="Pressed">
        <Storyboard>
            <ColorAnimation Storyboard.TargetName="PART_Handle"
                            Storyboard.TargetProperty="Fill.(SolidColorBrush.Color)"
                            To="DarkGray"
                            Duration="0:0:0.1" />
        </Storyboard>
    </VisualState>
    <VisualState x:Name="Disabled">
        <Storyboard>
            <ColorAnimation Storyboard.TargetName="PART_Handle"
                            Storyboard.TargetProperty="Fill.(SolidColorBrush.Color)"
                            To="Gray"
                            Duration="0:0:0.1" />
        </Storyboard>
    </VisualState>
</VisualStateGroup>
```

In this example, the handle's color changes to `LightGray` when the mouse is over the control, to `DarkGray` when the control is pressed, and to `Gray` when the control is disabled.

Finally, you can also handle the `Indeterminate` state in a similar manner as `Checked` and `Unchecked` states, if you want to support a three-way switch.

That's it for the main features of the `ToggleSwitch` control. You can now use it in your WPF applications. Here's an example of how to use it:

```xml
<Window x:Class="Jon.Wpf.CustomControls.TestWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:Jon.Wpf.CustomControls"
        Title="Test Window" Height="200" Width="200">
    <Grid>
        <local:ToggleSwitch HorizontalAlignment="Center"
                            VerticalAlignment="Center"
                            OffText="Light Off"
                            OnText="Light On"
                            OnForeground="Green"
                            OffForeground="Red" />
    </Grid>
</Window>
```

In this example, the `ToggleSwitch` control is placed in the center of the window. The text displayed when the switch is off is "Light Off", and the text displayed when the switch is on is "Light On". The text color is red when the switch is off and green when the switch is on.

Remember to add the namespace for your custom control at the top of your XAML file. Replace "Jon.Wpf.CustomControls" with the actual namespace where your control is defined.