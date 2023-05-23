# Thanks for Downloading and using my WPF controls. 

#### Please let me know if you have any questions or suggestions.  



The github address for this repo is here: https://github.com/LittleBigSalino/Jon.Wpf.CustomControls 

I'k happy to help any way I can. Thanks, Jon

To use the controls, you want to add a reference to the library for your project, plus you will also need to load the default styles for the controls. 

To load the default styles, add the following to your App.xaml file:

```xml
<Application
    x:Class="ControlDriver.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    StartupUri="MainWindow.xaml">
    <Application.Resources>
        <!-- HERE --- >
        <ResourceDictionary Source="pack://application:,,,/Jon.Wpf.CustomControls;component/Themes/Generic.xaml" />
        <!-- HERE --- >
    </Application.Resources>
</Application>