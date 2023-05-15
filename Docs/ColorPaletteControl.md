# ColorPaletteControl

`ColorPaletteControl` is a WPF control that displays a palette of colors for the user to choose from. It provides properties to customize the number of rows and columns, as well as the dimensions of each color square.

## Usage

First, add the `ColorPaletteControl` to your XAML file:

```xaml
<local:ColorPaletteControl x:Name="MyColorPalette" />
```

Then, you can customize its properties according to your needs.

## Properties

### `Rows`

Type: `int`

This property represents the number of rows of color squares. It is a dependency property.

### `Columns`

Type: `int`

This property represents the number of columns of color squares. It is a dependency property.

### `ColorList`

Type: `List<Color>`

This property represents the list of colors displayed in the palette. It is a dependency property.

### `SelectedColor`

Type: `Color`

This property represents the selected color. It is a dependency property.

### `ColorSquareWidth`

Type: `Double`

This property represents the width of each color square. It is a dependency property.

### `ColorSquareHeight`

Type: `Double`

This property represents the height of each color square. It is a dependency property.

### `ColorSquareColumnCount`

Type: `int`

This property represents the number of color squares per column. It is a dependency property.

## Commands

### `SelectColorCommand`

Type: `ICommand`

This command selects a color from the palette.

## Events

### `ColorSelected`

This event is fired whenever a color is selected.

## Contributing

Please see the [CONTRIBUTING.md](./CONTRIBUTING.md) file for details on how to contribute to this project.

## License

This project is licensed under the [MIT License](./LICENSE). Please see the [LICENSE](./LICENSE) file for more details.

## Contact

If you have any questions, feel free to open an issue or submit a pull request. We appreciate your feedback and contributions!