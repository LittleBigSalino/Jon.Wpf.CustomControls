# Jon.WPF.CustomControls

Welcome to Jon.WPF.CustomControls, a .NET 7.0/6.0 WPF C# custom control library. This library aims to provide an assortment of WPF controls to enhance your application's user interface. 

*Help me make this a comprehensive set of useful controls. Contributions are welcome. Submit suggestions and please submit issues if you find them and I'll fix them*.

## Table of Contents

- [About](#about)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Controls](#controls)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## About

Jon.WPF.CustomControls is a collection of custom, reusable WPF controls. It is built with .NET 7.0 and intended to provide developers with controls that are commonly used but not included in the standard WPF toolkit.

*RECOMMENDATIONS ARE WELCOME AND WANTED!!*

## Getting Started

1. Open Visual Studio 2023 or later.
2. Open your solution in Visual Studio.
3. Open the NuGet Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console).
4. Type `Install-Package Jon.Wpf.CustomControls` and press Enter to download and install the Jon.WPF.CustomControls NuGet package.
5. Build your solution to ensure everything is set up correctly.
6. Start using the controls in your projects!

To use the controls, you want to add a reference to the library for your project, plus you will also need to load the default styles for the controls.

To load the default styles, add the following to your App.xaml file:

```xml
<Application x:Class="ControlDriver.App" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" StartupUri="MainWindow.xaml">
  <Application.Resources>
    <!-- HERE --- >
    <ResourceDictionary Source="pack://application:,,,/Jon.WPF.CustomControls;component/Themes/Generic.xaml" />
    <!-- HERE --- >
  </Application.Resources>
</Application>
```

## Usage

Reference the `Jon.WPF.CustomControls.dll` in your WPF project. You can now use the controls by adding the appropriate namespace to your XAML files.

```xaml
xmlns:custom="clr-namespace:Jon.WPF.CustomControls;assembly=Jon.WPF.CustomControls"
```

You can then use the controls like any other WPF control:

```xaml
<custom:NumericUpDown x:Name="MyNumericUpDown" />
```

## Controls

This library currently includes the following controls:

- [TextToSqlQueryTextBlock](./Docs/TextToSqlQueryTextBlock.md): Translates English text into SQL queries using GPT-3 and displays the result.
  
  ![TextToSqlQueryTextBlock](https://i.imgur.com/ClJUlvN.png)

- [SentimentAnalysisLabel](./Docs/SentimentAnalysisLabel.md): Negative/Positive Sentiment Analysis Text you can bind to text for sentiment.
  
  ![SentimentAnalysisLabel](https://i.imgur.com/OhONHpj.png)
  ![SentimentAnalysisLabel](https://i.imgur.com/aLeWMtd.png)
  ![SentimentAnalysisLabel](https://i.imgur.com/KG3eaqg.png)

- [AutoCompleteTextBox](./Docs/AutoCompleteTextBox.md): A textbox control that automatically displays suggestions based on the filtered text typed.
  
  ![AutoCompleteTextBox](https://i.imgur.com/4vOf2kj.png)

- [PersonPicture](./Docs/PersonPicture.md): Person Icon Status control.
  
  ![PersonPicture](https://i.imgur.com/1AAKcz8.png)

- [TtsReader](./Docs/TtsReader.md): A text to speech reading control.
  
  ![TtsReader](https://i.imgur.com/WjrNDhT.png)

- [ToggleSwitch](./Docs/ToggleSwitch.md): A binary selection control, similar to a checkbox, but with a sleek design.
  
  ![ToggleSwitch](https://i.imgur.com/aaNDcSU.png)

- [NumericUpDown](./Docs/NumericUpDown.md): A NumericUpDown control that allows users to increase or decrease a numeric value with up and down buttons.
  
  ![NumericUpDown](https://i.imgur.com/m0Ey5nG.png?1)

- [WatermarkTextbox](./Docs/WatermarkTextbox.md): A text box with a placeholder text feature, also known as watermark.
  
  ![WatermarkTextBox](https://i.imgur.com/TB8I9Nu.png)

- [TimePicker](./Docs/TimePicker.md): A time selection control.
  
  ![TimePicker](https://i.imgur.com/TDHHsJs.png)

- [TimeTextBox](./Docs/TimeTextBox.md): A time selection control.
  
  ![TimeTextBox](https://i.imgur.com/AP1x2Pb.png)

- [RatingControl](./Docs/RatingControl.md): A control for rating items on a scale.
  
  ![RatingControl](https://i.imgur.com/HcAQvb8.png)

- [PropertyGrid](./Docs/PropertyGrid.md): A control for displaying and editing the properties of an object. Includes CollectionControl
  
  ![PropertyGrid](https://i.imgur.com/s5vxLn6.png)

- [ColorPaletteControl](./Docs/ColorPaletteControl.md): A color palette control that provides a grid of colors for the user to choose from.
  
  ![ColorPickers](https://i.imgur.com/TBgGxj8.png)

- [WizardControl](./Docs/WizardControl.md): A control that presents a series of WizardPages to assist the user in performing a task or series of tasks.
  
  ![WizardControl](https://i.imgur.com/iI6KZhK.png)

- [TerminalControl](./Docs/TerminalControl.md): A console terminal or a terminal for your application as well.
  
  ![Terminal Control](https://i.imgur.com/aMN3YlA.png)

- [Calculator](./Docs/Calculator.md): A drop-in working calculator control.
  
  ![Calculator](https://i.imgur.com/JeImAib.png)

Please refer to each control's documentation for more details.

Please refer to each control's documentation for more details.

## Converters

Converters are used in WPF to transform data from one type to another. They are often used in data binding scenarios, where the source data may not be in the correct format for the target property. Here are the converters included in this library:

- `BoolToIntConverter`: Converts a boolean value to an integer. Typically used for scenarios where a boolean value needs to be represented as an integer.
- `BoolToTranslateConverter`: Converts a boolean value to a translation transform. Useful for moving UI elements based on a boolean condition.
- `BoolToVisibilityConverter`: Converts a boolean value to a `Visibility` enumeration. Commonly used to show or hide UI elements based on a boolean condition.
- `BoolToCollapsedConverter`: Similar to `BoolToVisibilityConverter`, but collapses the UI element when the boolean is `false`.
- `ToggleSwitchForegroundConverter`: Used specifically for the `ToggleSwitch` control to determine the foreground color based on the switch's state.
- `ToggleSwitchBackgroundConverter`: Used specifically for the `ToggleSwitch` control to determine the background color based on the switch's state.
- `ToggleSwitchHandleColorConverter`: Used specifically for the `ToggleSwitch` control to determine the handle color based on the switch's state.
- `ColorToBrushConverter`: Converts a `Color` to a `Brush`. Useful for binding scenarios where a `Brush` is required but the source is a `Color`.
- `BrushToColorConverter`: Converts a `Brush` to a `Color`. Useful for binding scenarios where a `Color` is required but the source is a `Brush`.
- `HalfSizeConverter`: Takes a size and returns half of it. Useful for positioning or sizing elements relative to others.
- `DateTimeToAmPmConverter`: Converts a `DateTime` to a string representing either "AM" or "PM".
- `SelectorValuesToDateTimeConverter`: Converts selector values to a `DateTime`. Used in the `TimePicker` control.
- `ColorEqualityConverter`: Checks if two colors are equal. Useful for

color comparison scenarios.
- `ColorToNameConverter`: Converts a `Color` to its name as a string, if it has one.
- `PropertyNameConverter`: Converts a property name to a more user-friendly format.

Please note that the exact behavior of each converter may depend on its implementation and usage in the controls.

## Contributing

We welcome contributions from everyone. If you have controls that are not already in this toolkit and would like to help make them available to others, also welcome. I'd love to build this out to include a wide variety of reusable tools. Before you start, please see the [CONTRIBUTING.md](./CONTRIBUTING.md) for details on how to contribute to this project.

## License

This project is licensed under the MIT License. For more information, see the [LICENSE](./LICENSE) file.

## Contact

If you have any questions, feel free to reach out to us. You can contact us via [email](mailto:jonsales@jonmsales.com) or create an issue on our [GitHub](https://github.com/LittleBigSalino/Jon.Wpf.CustomControls/issues) page.

