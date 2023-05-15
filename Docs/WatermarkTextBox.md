

---

# WatermarkTextBox Control for WPF .NET v7.0

A custom TextBox control for WPF .NET v7.0 with built-in watermark support. The watermark is a faint hint displayed in the TextBox that describes what is expected to be entered in the TextBox. It disappears when text is typed into the TextBox.

## Features

- Displays a watermark in the TextBox until text is entered.
- Allows setting the opacity of the watermark.
- Fully customizable including border and background color.

## Getting Started

### Prerequisites

- .NET v7.0
- A WPF application project

### Installation

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

## Customization

- You can set the opacity of the watermark using the `WatermarkOpacity` property:
    ```xaml
    <local:WatermarkTextBox WatermarkText="Enter text here" WatermarkOpacity="0.2" Width="200" Height="30" />
    ```

- You can also customize the border and background of the TextBox:
    ```xaml
    <local:WatermarkTextBox WatermarkText="Enter text here" WatermarkOpacity="0.5" Width="200" Height="30" BorderBrush="Black" Background="White"/>
    ```

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

Please replace `your-github-username` and `your-repo-name` with your actual GitHub username and repository name in the `Installation` section. Adjust any other sections as necessary for your specific project.