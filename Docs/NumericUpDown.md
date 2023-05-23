# NumericUpDown Control for WPF

`NumericUpDown` is a custom control for WPF applications. It's a part of our custom control library and is designed to mimic the behavior of the `NumericUpDown` control found in Windows Forms.


![NumericUpDown](https://i.imgur.com/2Io00Tc.png)


## Features

- Increase or decrease a numeric value with up and down buttons.
- Set a minimum and maximum value range.
- Customizable through WPF ControlTemplates.
- ValueChanged event that fires whenever the value changes.

## Usage

Add the namespace to your XAML:

```xml
xmlns:local="clr-namespace:CustomControls"
```

Then use the control in your XAML:

```xml
<local:NumericUpDown Minimum="0" Maximum="100" Value="50" ValueChanged="NumericUpDown_ValueChanged"/>
```

## Properties

- `Minimum` (int): The minimum value for the control.
- `Maximum` (int): The maximum value for the control.
- `Value` (int): The current value of the control.

## Basic Styling


The below samples produce the numeric up down controls from the screenshot above.

```xml
  <StackPanel>
                                <customcontrols:NumericUpDown Margin="10" BorderThickness=".5" />
                                <customcontrols:NumericUpDown
                                    Margin="10"
                                    BorderBrush="Black"
                                    BorderThickness=".5" />
                                <customcontrols:NumericUpDown
                                    Margin="10"
                                    Background="Green"
                                    BorderBrush="Blue"
                                    BorderThickness=".5"
                                    Foreground="Yellow" />
                                <customcontrols:NumericUpDown
                                    Margin="10"
                                    BorderBrush="Blue"
                                    BorderThickness=".5"
                                    Foreground="Red" />
                                <customcontrols:NumericUpDown
                                    Margin="10"
                                    Background="LightGray"
                                    BorderThickness=".5" />
                            </StackPanel>
```

## Events

- `ValueChanged` (RoutedPropertyChangedEventHandler<int>): Occurs when the `Value` property changes.

## Example

```xml
<local:NumericUpDown Minimum="0" Maximum="100" Value="50" ValueChanged="NumericUpDown_ValueChanged"/>
```

```csharp
private void NumericUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e)
{
    // Handle the ValueChanged event here
    Console.WriteLine($"Value changed from {e.OldValue} to {e.NewValue}");
}
```

## Customization

The appearance of the `NumericUpDown` control can be customized using a `ControlTemplate`. 

Here is an example of a basic ControlTemplate:

```xml
<Style TargetType="{x:Type local:NumericUpDown}">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="{x:Type local:NumericUpDown}">
                <Grid>
                    <!-- Control implementation goes here -->
                </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## Authors

- Jon Sales
