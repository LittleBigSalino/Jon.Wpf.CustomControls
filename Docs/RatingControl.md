# RatingControl

`RatingControl` is a customizable WPF control used for implementing a star rating system. This control is highly customizable and interactive, enabling a great user experience for rating systems.

## Usage

First, add the `RatingControl` to your XAML file:

```xaml
<local:RatingControl x:Name="MyRatingControl" />
```

Then, you can customize its properties according to your needs.

## Properties

### `RatingValue`

Type: `double`

This property represents the current rating value of the control. It is a dependency property.

### `MaxRatingValue`

Type: `double`

This property represents the maximum rating value of the control. It is a dependency property.

### `IsReadOnly`

Type: `bool`

This property indicates whether the control is read-only. It is a dependency property.

### `StarSymbol`

Type: `Geometry`

This property allows setting a custom star symbol using a `Geometry` object. It is a dependency property.

### `UnselectedBrush`

Type: `Brush`

This property defines the brush that is used to paint unselected stars. It is a dependency property.

### `SelectedBrush`

Type: `Brush`

This property defines the brush that is used to paint selected stars. It is a dependency property.

### `ClickCommand`

Type: `ICommand`

This property allows you to bind a command that is executed when a star is clicked. It is a dependency property.

### `MouseOverCommand`

Type: `ICommand`

This property allows you to bind a command that is executed when the mouse is over a star. It is a dependency property.

### `MouseLeaveCommand`

Type: `ICommand`

This property allows you to bind a command that is executed when the mouse leaves a star. It is a dependency property.

## Events

### `RatingValueChanged`

This event is fired whenever the rating value changes.

## Contributing

Please see the [CONTRIBUTING.md](./CONTRIBUTING.md) file for details on how to contribute to this project.

## License

This project is licensed under the [MIT License](./LICENSE). Please see the [LICENSE](./LICENSE) file for more details.

## Contact

If you have any questions, feel free to open an issue or submit a pull request. We appreciate your feedback and contributions!