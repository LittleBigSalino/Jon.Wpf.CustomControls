# RgbColorPicker

`RgbColorPicker` is a WPF control that allows the user to select a color using RGB (Red, Green, Blue) values. It also supports hexadecimal color codes.

## Usage

First, add the `RgbColorPicker` to your XAML file:

```xaml
<local:RgbColorPicker x:Name="MyColorPicker" />
```

Then, you can customize its properties according to your needs.

## Properties

### `SelectedColor`

Type: `Color`

This property represents the selected color. It is a dependency property.

### `Red`

Type: `int`

This property represents the red component of the selected color. It is a dependency property.

### `Green`

Type: `int`

This property represents the green component of the selected color. It is a dependency property.

### `Blue`

Type: `int`

This property represents the blue component of the selected color. It is a dependency property.

### `Hexadecimal`

Type: `string`

This property represents the hexadecimal value of the selected color. It is a dependency property.

## Commands

### `UpdateColorCommand`

Type: `ICommand`

This command triggers the color update based on the Red, Green, and Blue property values.

## Events

### `ColorChanged`

This event is fired whenever the color changes.

## Contributing

Please see the [CONTRIBUTING.md](./CONTRIBUTING.md) file for details on how to contribute to this project.

## License

This project is licensed under the [MIT License](./LICENSE). Please see the [LICENSE](./LICENSE) file for more details.

## Contact

If you have any questions, feel free to open an issue or submit a pull request. We appreciate your feedback and contributions!