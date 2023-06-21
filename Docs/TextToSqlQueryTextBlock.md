# TextToSqlQueryTextBlock

TextToSqlQueryTextBlock is a WPF custom control that accepts English text and translates it into SQL using OpenAI's GPT-3. The SQL query is then displayed in a RichTextBox with SQL keywords highlighted.

![TextToSqlQueryTextBlock](https://i.imgur.com/ClJUlvN.png)

## Features

- Translates English text into SQL queries using GPT-3
- Highlights SQL keywords in the output
- Option to copy the translated SQL to clipboard

## Getting Started

### Prerequisites

- .NET 6.0 or later
- An OpenAI API key

### Installation

1. Install the `Jon.Wpf.CustomControls` NuGet package in Visual Studio. You can do this by right-clicking your project in the Solution Explorer, selecting "Manage NuGet Packages", searching for `Jon.Wpf.CustomControls`, and clicking "Install".
2. If you prefer to build from source, you can clone the full library from GitHub: 
```sh 
git clone https://github.com/LittleBigSalino/Jon.Wpf.CustomControls.git
```
3. Add a reference to `Jon.Wpf.CustomControls.dll` in your project.

## Usage

To use the TextToSqlQueryTextBlock control in your WPF application, first add the following namespace declaration to your XAML file:

```xml
xmlns:local="clr-namespace:Jon.Wpf.CustomControls;assembly=Jon.Wpf.CustomControls"
```

Then, you can add the TextToSqlQueryTextBlock control to your window like this:

```xml
<local:TextToSqlQueryTextBlock SqlText="{Binding YourTextProperty}" />
```

Replace `YourTextProperty` with the property in your view model that contains the English text to be translated.

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are greatly appreciated.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

Distributed under the MIT License. See `LICENSE` for more information.

## Contact

Your Name - jonmsales@gmail.com

Project Link: [GitHub Repo](https://github.com/LittleBigSalino/Jon.Wpf.CustomControls)

## Acknowledgements

- [OpenAI](https://openai.com/)
- [Microsoft WPF](https://dotnet.microsoft.com/apps/desktop/wpf)
