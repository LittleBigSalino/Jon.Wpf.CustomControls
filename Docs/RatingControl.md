Sure, here is your updated README.md:

# RatingControl

`RatingControl` is a customizable WPF control used for implementing a star rating system. This control is highly customizable, interactive, and data-bindable, providing a great user experience for rating systems.


![RatingControl](https://i.imgur.com/HcAQvb8.png?1)


## Usage

First, add the namespace and `RatingControl` to your XAML file:

```xaml
xmlns:customcontrols="clr-namespace:YourNamespace.Controls"
...
<customcontrols:RatingControl
    Width="100"
    RatingValue="0"
    StarSymbol="M12,21.35L10.55,20.03C5.4,15.36 2,12.27 2,8.5C2,5.41 4.42,3 7.5,3C9.24,3 10.91,3.81 12,5.08C13.09,3.81 14.76,3 16.5,3C19.58,3 22,5.41 22,8.5C22,12.27 18.6,15.36 13.45,20.03L12,21.35Z">
</customcontrols:RatingControl>
```

Then, you can customize its properties according to your needs.

Here are some examples of how to use the `RatingControl`:

```xaml
<customcontrols:RatingControl
    Width="100"
    Background="Blue"
    RatingValue="3"
    SelectedBrush="Yellow"
    StarSymbol="M463 192H315.9L271.2 58.6C269 52.1 262.9 48 256 48s-13 4.1-15.2 10.6L196.1 192H48c-8.8 0-16 7.2-16 16 0 .9.1 1.9.3 2.7.2 3.5 1.8 7.4 6.7 11.3l120.9 85.2-46.4 134.9c-2.3 6.5 0 13.8 5.5 18 2.9 2.1 5.6 3.9 9 3.9 3.3 0 7.2-1.7 10-3.6l118-84.1 118 84.1c2.8 2 6.7 3.6 10 3.6 3.4 0 6.1-1.7 8.9-3.9 5.6-4.2 7.8-11.4 5.5-18L352 307.2l119.9-86 2.9-2.5c2.6-2.8 5.2-6.6 5.2-10.7 0-8.8-8.2-16-17-16z"
    UnselectedBrush="Gray" />

<customcontrols:RatingControl
    x:Name="ratingControl2"
    Width="45"
    Margin="5,0,5,0"
    RatingValue="1"
    SelectedBrush="Red"
    StarSymbol="M12,21.35L10.55,20.03C5.4,15.36 2,12.27 2,8.5C2,5.41 4.42,3 7.5,3C9.24,3 10.91,3.81 12,5.08C13.09,3.81 14.76,3 16.5,3C19.58,3 22,5.41 22,8.5C22,12.27 18.6,15.36 13.45,20.03L12,21.35Z"
    UnselectedBrush="Black" />
```


This will create these two rating controls:

![StarsAndHearts](https://i.imgur.com/rj09urS.png)


## Properties

### `RatingValue`

Type: `double`

This property represents the current rating value of the control. It is a dependency property.

### `IsReadOnly`

Type: `bool`

This property indicates whether the

control is read-only. It is a dependency property.

### `StarSymbol`

Type: `string`

This property allows setting a custom star symbol using a `string` that represents the Geometry data for the Path of the star. It is a dependency property.

### `UnselectedBrush`

Type: `Brush`

This property defines the brush that is used to paint unselected stars. It is a dependency property.

### `SelectedBrush`

Type: `Brush`

This property defines the brush that is used to paint selected stars. It is a dependency property.

## Events

### `RatingValueChanged`

This event is fired whenever the rating value changes.

## Contributing

Please see the [CONTRIBUTING.md](./CONTRIBUTING.md) file for details on how to contribute to this project.

## License

This project is licensed under the [MIT License](./LICENSE). Please see the [LICENSE](./LICENSE) file for more details.

## Contact

If you have any questions, feel free to open an issue or submit a pull request. We appreciate your feedback and contributions!