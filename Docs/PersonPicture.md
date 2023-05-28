

# PersonPicture Custom Control for WPF

## Overview

`PersonPicture` is a custom control for WPF applications, part of the `Jon.Wpf.CustomControls` library. It is designed to display a person's picture along with a status indicator. The control is an ellipse filled with an image, and it includes a smaller circular status indicator in the bottom right corner.

The control has three properties that can be set from XAML:

- `PictureSource`: The image source for the person's picture.
- `DisplayName`: The person's full name.
- `StatusPictureSource`: The image source for the status indicator.

If `PictureSource` is not set, the control will display the initials of the `DisplayName`.

## Usage

You can use the `PersonPicture` control in your XAML files just like any other control. Here's an example:

```xml
<local:PersonPicture 
    PictureSource="/Images/Person.jpg" 
    DisplayName="John Doe" 
    StatusPictureSource="/Images/Online.png" />
```

In this example, `local:PersonPicture` is the `PersonPicture` control. The `PictureSource`, `DisplayName`, and `StatusPictureSource` properties are set to the paths of the picture, the display name, and the status picture respectively.

Please replace `/Images/Person.jpg` and `/Images/Online.png` with the actual paths of your images.

## Installation

To use the `PersonPicture` control in your WPF application, you need to install the `Jon.Wpf.CustomControls` NuGet package. You can do this by running the following command in the Package Manager Console:

```
Install-Package Jon.Wpf.CustomControls
```

After installing the package, you can use the `PersonPicture` control in your XAML files.

## Contributing

Contributions are welcome! Please feel free to submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
```

Please replace the paths `/Images/Person.jpg` and `/Images/Online.png` with the actual paths of your images, and update the `License` section if your project is not licensed under the MIT License.