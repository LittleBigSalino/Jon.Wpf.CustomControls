## Jon.Wpf.CustomControls.TtsReader Class

The `Jon.Wpf.CustomControls.TtsReader` class is a custom control that represents a text-to-speech reader. It inherits from the `Control` class and provides properties and methods for controlling the speech synthesis functionality.

### Usage

To use the `TtsReader` control in your application, follow these steps:

1. Add a reference to the assembly containing the `Jon.Wpf.CustomControls` namespace.
2. Include the appropriate namespace in your XAML file:

```xaml
xmlns:customControls="clr-namespace:Jon.Wpf.CustomControls"
```

3. Add the `TtsReader` control to your XAML:

```xaml
<customControls:TtsReader />
```

### Class Declaration

```csharp
namespace Jon.Wpf.CustomControls
{
    public class TtsReader : Control
    {
        // ...
    }
}
```

### Dependencies

The `TtsReader` class has the following dependency properties:

- `Text`: Represents the text to be synthesized as speech.
- `PlayStopCommand`: Represents the command for playing or stopping the speech synthesis.
- `OpenSettingsCommand`: Represents the command for opening the settings window.

### Properties

- `Text`: Gets or sets the text to be synthesized as speech.
- `PlayStopCommand`: Gets or sets the command for playing or stopping the speech synthesis.
- `OpenSettingsCommand`: Gets or sets the command for opening the settings window.

### Methods

- `PlayTextToSpeech()`: Plays or stops the speech synthesis based on the current state.
- `OpenSettingsWindow()`: Opens the settings window for configuring the speech synthesis.
- `ChangeVoice(string voice)`: Changes the voice used for speech synthesis (not implemented).
- `ChangeSpeed(int speed)`: Changes the speed of speech synthesis (not implemented).
- `ChangeCadence(int cadence)`: Changes the cadence of speech synthesis (not implemented).

### Example

```csharp
using Jon.Wpf.CustomControls;

TtsReader ttsReader = new TtsReader();
```

## Default Style

The default style for the `Jon.Wpf.CustomControls.TtsReader` control is defined using XAML markup.

### Style Declaration

```xaml
<Style TargetType="{x:Type local:TtsReader}">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="{x:Type local:TtsReader}">
                <Grid VerticalAlignment="Top">
                    <!-- Visual elements and button commands for playing and opening settings -->
                </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

### Example

```xaml
<customControls:TtsReader Style="{StaticResource TtsReaderStyle}" />
```

Make sure to include the necessary resources and namespaces in your XAML file for the default style to work correctly.
