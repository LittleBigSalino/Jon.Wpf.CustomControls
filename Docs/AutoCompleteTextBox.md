
# AutocompleteTextBox Control for WPF

This repository contains a custom WPF control called `AutocompleteTextBox`. This control extends the standard WPF `TextBox` and adds autocomplete functionality to it.

![AutoCompleteTextBox](https://i.imgur.com/4vOf2kj.png)

## Features

- Autocomplete functionality: As you type in the `TextBox`, a dropdown list appears with suggestions that match the entered text.
- Customizable suggestion display: You can specify which property of your data objects to display in the suggestions dropdown.
- Selection of suggestions: You can select a suggestion from the dropdown list, and the selected suggestion will be set as the text of the `TextBox`.

## Usage

First, add the `AutocompleteTextBox` control to your XAML:

```xml
<local:AutocompleteTextBox x:Name="AutocompleteTextBoxMain" />
```

Then, in your code-behind, set the `ItemsSource` property to the list of items you want to use for autocomplete suggestions:

```csharp
AutocompleteTextBoxMain.ItemsSource = myItems;
```

If your items are objects and you want to display a specific property in the suggestions dropdown, set the `SuggestionsDisplayMemberPath` property:

```csharp
AutocompleteTextBoxMain.SuggestionsDisplayMemberPath = "MyProperty";
```

## Dependencies

This control uses the `RelayCommand` class for command handling. Make sure to include the `RelayCommand.cs` file in your project.

## Contributing

Contributions are welcome! Please feel free to submit a pull request.

## License

This project is licensed under the MIT License.

