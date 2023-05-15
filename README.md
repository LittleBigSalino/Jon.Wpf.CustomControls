

# Jon.WPF.CustomControls

Welcome to Jon.WPF.CustomControls, a .NET 7.0 WPF C# custom control library. This library aims to provide an assortment of WPF controls to enhance your application's user interface.

![Banner](./assets/banner.png) 

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

## Getting Started

1. Clone the repo: `git clone https://github.com/yourusername/Jon.WPF.CustomControls.git`
2. Open the solution in Visual Studio 2023 or later.
3. Build the solution to ensure everything is set up correctly.
4. Start using the controls in your projects!

## Usage

Reference the `Jon.WPF.CustomControls.dll` in your WPF project. You can now use the controls by adding the appropriate namespace to your XAML files.

```xaml
xmlns:custom="clr-namespace:Jon.WPF.CustomControls;assembly=Jon.WPF.CustomControls"
```

You can then use the controls like any other WPF control:

```xaml
<custom:RgbColorPicker x:Name="MyColorPicker" />
```

## Controls

This library currently includes the following controls:

- [RgbColorPicker](./Docs/RGBColorPicker.md): A color picker control that allows users to select a color using RGB (Red, Green, Blue) components.
- [ColorPaletteControl](./Docs/ColorPaletteControl.md): A color palette control that provides a grid of colors for the user to choose from.
- [RatingControl](./Docs/RatingControl.md): A control for rating items on a scale.
- [TimePicker](./Docs/TimePicker.md): A time selection control.
- [ToggleSwitch](./Docs/ToggleSwitch.md): A binary selection control, similar to a checkbox, but with a sleek design.
- [WatermarkTextbox](./Docs/WatermarkTextbox.md): A text box with a placeholder text feature, also known as watermark.
- [PropertyGrid](./Docs/PropertyGrid.md): A control for displaying and editing the properties of an object.

Please refer to each control's documentation for more details.

## Contributing

We welcome contributions from everyone. Before you start, please see the [CONTRIBUTING.md](./CONTRIBUTING.md) for details on how to contribute to this project.

## License

This project is licensed under the MIT License. For more information, see the [LICENSE](./LICENSE) file.

## Contact

If you have any questions, feel free to open an issue or submit a pull request. We appreciate your feedback and contributions!