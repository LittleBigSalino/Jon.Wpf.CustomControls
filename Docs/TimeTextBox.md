## Jon.Wpf.CustomControls.TimeTextBox Class

The `Jon.Wpf.CustomControls.TimeTextBox` class is a custom control that extends the functionality of a standard `TextBox` control. It provides additional behavior for handling time input and formatting.

### Usage

To use the `TimeTextBox` control in your application, follow these steps:

1. Add a reference to the assembly containing the `Jon.Wpf.CustomControls` namespace.
2. Include the appropriate namespace in your XAML file:

```xaml
xmlns:customControls="clr-namespace:Jon.Wpf.CustomControls"
```

3. Add the `TimeTextBox` control to your XAML:

```xaml
<customControls:TimeTextBox />
```

### Class Declaration

```csharp
namespace Jon.Wpf.CustomControls
{
    public class TimeTextBox : TextBox
    {
        // ...
    }
}
```

### Constructors

- `TimeTextBox()`: Initializes a new instance of the `TimeTextBox` class. It attaches the `TimeInputBehavior` to the control.

### Example

```csharp
using Jon.Wpf.CustomControls;

TimeTextBox timeTextBox = new TimeTextBox();
```

## Jon.Wpf.CustomControls.TimeInputBehavior Class

The `Jon.Wpf.CustomControls.TimeInputBehavior` class is a behavior attached to the `Jon.Wpf.CustomControls.TimeTextBox` control. It provides the logic for validating and reformatting the time input when the control loses focus.

### Class Declaration

```csharp
namespace Jon.Wpf.CustomControls
{
    public class TimeInputBehavior : Behavior<TextBox>
    {
        // ...
    }
}
```

### Methods

- `OnAttached()`: Overrides the base `OnAttached` method to attach event handlers.
- `OnDetaching()`: Overrides the base `OnDetaching` method to detach event handlers.
- `OnLostFocus(object sender, RoutedEventArgs e)`: Handles the `LostFocus` event of the associated `TextBox`. It validates and reformats the time input.

### Example

```csharp
using Jon.Wpf.CustomControls;

TimeInputBehavior behavior = new TimeInputBehavior();
behavior.OnAttached();
```

## Default Style

The default style for the `Jon.Wpf.CustomControls.TimeTextBox` control is defined using XAML markup.

### Style Declaration

```xaml
<Style BasedOn="{StaticResource {x:Type TextBox}}" TargetType="{x:Type customControls:TimeTextBox}">
    <Setter Property="Background" Value="White" />
    <Setter Property="BorderBrush" Value="Gray" />
    <Setter Property="BorderThickness" Value="1" />
    <Setter Property="Padding" Value="2" />
</Style>
```

### Example

```xaml
<customControls:TimeTextBox Style="{StaticResource TimeTextBoxStyle}" />
```

Make sure to include the necessary resources and namespaces in your XAML file for the default style to work correctly.
