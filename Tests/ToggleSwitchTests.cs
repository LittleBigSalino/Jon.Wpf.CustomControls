using Jon.Wpf.CustomControls;
using Xunit;

namespace Jon.Wpf.CustomControls.UnitTests
{
    public class ToggleSwitchTests
    {
        [WpfFact]
        public void IsChecked_ChangesState()
        {
            // Arrange
            var toggleSwitch = new ToggleSwitch();

            // Act
            toggleSwitch.IsChecked = true;

            // Assert
            Assert.True(toggleSwitch.IsChecked);
        }

        [WpfFact]
        public void SetOnText()
        {
            // Arrange
            var toggleSwitch = new ToggleSwitch();

            // Act
            toggleSwitch.IsChecked = true;

            // Assert
            Assert.True(toggleSwitch.IsChecked);
        }

        [WpfFact]
        public void SetOffText()
        {
            // Arrange
            var toggleSwitch = new ToggleSwitch();

            // Act
            toggleSwitch.IsChecked = true;

            // Assert
            Assert.True(toggleSwitch.IsChecked);
        }

        [WpfFact]
        public void IsEnabled_ChangesState()
        {
            // Arrange
            var toggleSwitch = new ToggleSwitch();

            // Act
            toggleSwitch.IsEnabled = false;

            // Assert
            Assert.False(toggleSwitch.IsEnabled);
        }

        [WpfFact]
        public void ToggleSwitchBackground_ChangesColor()
        {
            // Arrange
            var toggleSwitch = new ToggleSwitch();
            var expectedColor = System.Windows.Media.Brushes.Red;

            // Act
            toggleSwitch.Background = expectedColor;

            // Assert
            Assert.Equal(expectedColor, toggleSwitch.Background);
        }

        [WpfFact]
        public void ToggleOffForegroundColor_ChangesColor()
        {
            // Arrange
            var toggleSwitch = new ToggleSwitch();
            var expectedColor = System.Windows.Media.Brushes.Blue;

            // Act
            toggleSwitch.OffForeground = expectedColor;

            // Assert
            Assert.Equal(expectedColor, toggleSwitch.OffForeground);
        }

        [WpfFact]
        public void ToggleOnForegroundColor_ChangesColor()
        {
            // Arrange
            var toggleSwitch = new ToggleSwitch();
            var expectedColor = System.Windows.Media.Brushes.Green;

            // Act
            toggleSwitch.OnForeground = expectedColor;

            // Assert
            Assert.Equal(expectedColor, toggleSwitch.OnForeground);
        }

        [WpfFact]
        public void ToggleSwitchHandleColor_ChangesColor()
        {
            // Arrange
            var toggleSwitch = new ToggleSwitch();
            var expectedColor = System.Windows.Media.Brushes.Green;

            // Act
            toggleSwitch.Foreground = expectedColor;

            // Assert
            Assert.Equal(expectedColor, toggleSwitch.Foreground);
        }
    }
}