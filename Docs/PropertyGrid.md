
# PropertyGrid Control

The `PropertyGrid` is a WPF control that allows users to view and edit properties of a selected object. The properties can be displayed in a categorized view or a sorted list.


![PropertyGrid](https://i.imgur.com/3Fy8rGs.png)


## Features

- View and edit properties of a selected object
- Properties can be displayed in a categorized view or a sorted list
- Supports notification of property changes
- Customizable appearance through properties such as `CategoryBackground` and `CategoryForeground`

## Usage

To use the `PropertyGrid` in your WPF application, add a namespace declaration for its location in your XAML file:

```xml
xmlns:local="clr-namespace:YourNamespace"
```

Then, you can add a `PropertyGrid` control to your XAML:

```xml
<local:PropertyGrid SelectedObject="{Binding YourObject}" />
```

In this example, `YourObject` is a property in your view model that the `PropertyGrid` will display. You'll need to replace `YourObject` with the actual property you want to display in the `PropertyGrid`.



## Properties

- `SelectedObject`: The object that the `PropertyGrid` is displaying the properties of.
- `CategorizedView`: Determines whether the properties should be displayed in a categorized view or a sorted list.
- `CategoryBackground`: The background color for the category headers in the property grid.
- `CategoryForeground`: The foreground color for the category headers in the property grid.

## Events

- `PropertyChanged`: Raised when a property of the `PropertyGrid` is changed.
- `SelectedObjectChanged`: Raised when the `SelectedObject` in the `PropertyGrid` changes. This event can be used to react to changes in the `SelectedObject` property.



#### `SelectedObjectChanged` Event

The `SelectedObjectChanged` event is raised whenever the `SelectedObject` property of the `PropertyGrid` changes. This allows you to execute custom logic whenever the user selects a different object in the property grid.

Here's an example of how to subscribe to the `SelectedObjectChanged` event:

```csharp
PropertyGrid propertyGrid = new PropertyGrid();

// Subscribe to the SelectedObjectChanged event
propertyGrid.SelectedObjectChanged += (sender, args) =>
{
    // Code to execute when the SelectedObject changes
    Console.WriteLine("Selected object has been changed!");
};
```

In this example, whenever the `SelectedObject` changes, "Selected object has been changed!" will be printed to the console. You can replace the `Console.WriteLine` call with your own logic to execute whenever the `SelectedObject` changes.


Sure, let's provide a similar documentation snippet for the `PropertyChanged` event as well. Here's how you might explain its usage:

#### `PropertyChanged` Event

The `PropertyChanged` event is raised whenever a property of the `PropertyGrid` changes. This includes not only `SelectedObject`, but also any other properties defined in the `PropertyGrid` class such as `CategorizedView`, `CategoryBackground`, `CategoryForeground`, etc. 

Subscribing to the `PropertyChanged` event can be useful when you need to execute some logic in response to these changes. 

Here's an example of how to subscribe to the `PropertyChanged` event:

```csharp
PropertyGrid propertyGrid = new PropertyGrid();

// Subscribe to the PropertyChanged event
propertyGrid.PropertyChanged += (sender, args) =>
{
    // Code to execute when a property changes
    Console.WriteLine($"Property {args.PropertyName} has been changed!");
};
```

In this example, whenever a property of the `PropertyGrid` changes, a message stating which property has changed will be printed to the console. You can replace the `Console.WriteLine` call with your own logic to execute whenever a property changes.
## Styles

The `PropertyGrid` can be styled through the WPF styling system. For example, you can change the background color of the category headers by setting the `CategoryBackground` property. The default style for the `PropertyGrid` can be found in `YourProjectName/Themes/Generic.xaml`.
```
## Custom Templates

The `PropertyGrid` supports custom data templates. You can define your own templates to display and edit the properties in a way that is more suitable for your application.

```xml
<DataGridTemplateColumn Width="*" Header="Property">
    <DataGridTemplateColumn.CellTemplate>
        <DataTemplate>
            <TextBlock Text="{Binding PropertyName}" />
        </DataTemplate>
    </DataGridTemplateColumn.CellTemplate>
    <DataGridTemplateColumn.CellEditingTemplate>
        <DataTemplate>
            <TextBox Text="{Binding PropertyValue, UpdateSourceTrigger=PropertyChanged}" />
        </DataTemplate>
    </DataGridTemplateColumn.CellEditingTemplate>
</DataGridTemplateColumn>
```

In the above example, each property is displayed as a `TextBlock` and edited with a `TextBox`. The `UpdateSourceTrigger=PropertyChanged` ensures that the property value in the `SelectedObject` is updated as soon as the user types in the `TextBox`.

## Triggers

The `PropertyGrid` uses triggers to update its appearance based on its state. For example, it changes the background color of every other row for better readability:

```xml
<Style TargetType="DataGridRow">
    <Style.Triggers>
        <Trigger Property="AlternationIndex" Value="1">
            <Setter Property="Background" Value="{StaticResource RowAlternatingBackground}" />
        </Trigger>
    </Style.Triggers>
</Style>
```

## Custom Commands

The `PropertyGrid` also supports custom commands. For example, you can bind a command to the `ToggleCategorizedViewCommand` property to switch between categorized view and sorted list view:

```xml
<ToggleButton
    Command="{Binding ToggleCategorizedViewCommand, RelativeSource={RelativeSource AncestorType={x:Type local:PropertyGrid}}}"
    IsChecked="{TemplateBinding CategorizedView}" />
```

## Summary

The `PropertyGrid` is a versatile WPF control that allows users to view and edit properties of a selected object. It offers many customization options through properties, styles, templates, and commands. With the `PropertyGrid`, you can create a user-friendly interface for object property manipulation in your WPF application.
