
# WatermarkTextBox Control for WPF .NET v7.0

A custom TextBox control for WPF .NET v7.0 with built-in watermark support. The watermark is a faint hint displayed in the TextBox that describes what is expected to be entered in the TextBox. It disappears when text is typed into the TextBox.


![WatermarkTextBox](https://github.com/LittleBigSalino/Jon.Wpf.CustomControls/blob/master/images/watermarkTextbox.png?raw=true)

## Features

- Displays a watermark in the TextBox until text is entered.
- Allows setting the opacity of the watermark.
- Fully customizable including border and background color.

## Getting Started

### Prerequisites

- .NET v7.0
- A WPF application project

### Installation

The easiest way to use the `WatermarkTextBox` control in your project is to install the `Jon.Wpf.CustomControls` NuGet package.

- From the Visual Studio Package Manager Console, enter the following command:
    ```
    Install-Package Jon.Wpf.CustomControls
    ```

- Alternatively, you can search for `Jon.Wpf.CustomControls` in the NuGet Package Manager UI.

If you prefer to build from source:

1. Clone this repository:
    ```
    git clone https://github.com/your-github-username/your-repo-name.git
    ```

2. Build the `Jon.Wpf.CustomControls` library.

3. Add a reference to the built `Jon.Wpf.CustomControls.dll` in your WPF project.

### Usage

1. Add the following namespace to your XAML file:
    ```xaml
    xmlns:local="clr-namespace:Jon.Wpf.CustomControls"
    ```

2. Now you can use the `WatermarkTextBox` control in your XAML:
    ```xaml
    <local:WatermarkTextBox WatermarkText="Enter text here" WatermarkOpacity="0.5" Width="200" Height="30" />
    ```

The WatermarkTextBox has three properties:

- `WatermarkText`: The placeholder text that is displayed when the TextBox is empty and not focused.
- `WatermarkColor`: The color of the placeholder text.
- `WatermarkOpacity`: The opacity of the placeholder text, from 0 (completely transparent) to 1 (completely opaque).

## Customization

- You can set the opacity of the watermark using the `WatermarkOpacity` property:
    ```xaml
    <local:WatermarkTextBox WatermarkText="Enter text here" WatermarkOpacity="0.2" Width="200" Height="30" />
    ```

- You can also customize the border and background of the TextBox:
    ```xaml
    <local:WatermarkTextBox WatermarkText="Enter text here" WatermarkOpacity="0.5" Width="200" Height="30" BorderBrush="Black" Background="White"/>
    ```

When you run your application, you should see a TextBox with the specified placeholder text. When you click on the TextBox, the placeholder text disappears, and you can enter your own text. If you delete your text, the placeholder text reappears.

## Building

Use the .NET CLI to build the project:

```
dotnet build
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

[MIT](https://choosealicense.com/licenses/mit/)

---

Please replace `your-github-username` and `your-repo-name` with your actual GitHub username and repository name in the `Installation` section (if you're using the git method). Adjust any other sections as necessary for your specific project.