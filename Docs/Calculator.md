
# WPF Calculator Control

![Calculator Control Diagram](https://i.imgur.com/JeImAib.png)

This repository contains a custom WPF control for a simple calculator. The calculator can perform basic arithmetic operations: addition, subtraction, multiplication, and division.

## Features

- Customizable appearance through XAML styles
- Supports addition, subtraction, multiplication, and division operations
- Clear operation resets the calculator
- Value property reflects the current value of the calculator
- CalculationCompleted event is raised when an operation is performed

## Usage

To use the Calculator control in your WPF application, first add a reference to the CalculatorControl.dll in your project.

Then, you can add the Calculator control to your XAML:

```xml
<Window x:Class="YourNamespace.YourWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:CalculatorControl;assembly=CalculatorControl"
        Title="Your Window" Height="450" Width="800">
    <Grid>
        <local:Calculator HorizontalAlignment="Center" VerticalAlignment="Center"/>
    </Grid>
</Window>
```

You can customize the appearance of the Calculator control by modifying the control template in the Generic.xaml file.

## Contributing

Contributions are welcome! Please feel free to submit a pull request.

## License

This project is licensed under the MIT License.

[You can edit this diagram online if you want to make any changes.](https://showme.redstarplugin.com/s/TJ1xm4Fr)
```

Please replace "YourNamespace.YourWindow" with the actual namespace and class name of your window, and "CalculatorControl" with the actual namespace and assembly name of your Calculator control. You may also want to provide more details about how to customize the control, how to handle the CalculationCompleted event, etc.