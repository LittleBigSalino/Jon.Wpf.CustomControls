using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jon.Wpf.CustomControls
{
    public class RgbColorPicker : Control
    {
        // Define the dependency properties
        public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register("SelectedColor", typeof(Color), typeof(RgbColorPicker), new PropertyMetadata(default(Color), OnColorChanged));
        public static readonly DependencyProperty RedProperty = DependencyProperty.Register("Red", typeof(int), typeof(RgbColorPicker), new PropertyMetadata(default(int), OnColorComponentChanged));
        public static readonly DependencyProperty GreenProperty = DependencyProperty.Register("Green", typeof(int), typeof(RgbColorPicker), new PropertyMetadata(default(int), OnColorComponentChanged));
        public static readonly DependencyProperty BlueProperty = DependencyProperty.Register("Blue", typeof(int), typeof(RgbColorPicker), new PropertyMetadata(default(int), OnColorComponentChanged));
        public static readonly DependencyProperty HexadecimalProperty = DependencyProperty.Register("Hexadecimal", typeof(string), typeof(RgbColorPicker), new PropertyMetadata(default(string), OnHexadecimalChanged));

        // Define the commands
        public ICommand UpdateColorCommand { get; private set; }

        // Define the events
        public event EventHandler ColorChanged;

        public RgbColorPicker()
        {
            // Initialize the commands
            UpdateColorCommand = new RelayCommand(param => UpdateColor());
        }

        // Define the properties
        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public int Red
        {
            get { return (int)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        public int Green
        {
            get { return (int)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        public int Blue
        {
            get { return (int)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        public string Hexadecimal
        {
            get { return (string)GetValue(HexadecimalProperty); }
            set { SetValue(HexadecimalProperty, value); }
        }

        private void UpdateColor()
        {
            // Implement logic to update SelectedColor based on Red, Green, and Blue
            SelectedColor = Color.FromArgb(255, (byte)Red, (byte)Green, (byte)Blue);
        }

        private void UpdateRGB()
        {
            // Implement logic to update Red, Green, and Blue based on SelectedColor
            Red = SelectedColor.R;
            Green = SelectedColor.G;
            Blue = SelectedColor.B;
        }

        private void UpdateHexadecimal()
        {
            // Implement logic to update Hexadecimal based on SelectedColor
            Hexadecimal = string.Format("#{0:X2}{1:X2}{2:X2}", SelectedColor.R, SelectedColor.G, SelectedColor.B);
        }

        // Define the event handlers
        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = (RgbColorPicker)d;
            picker.UpdateRGB();
            picker.UpdateHexadecimal();
            picker.ColorChanged?.Invoke(picker, EventArgs.Empty);
        }

        private static void OnColorComponentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = (RgbColorPicker)d;
            picker.UpdateColor();
        }

        private static void OnHexadecimalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = (RgbColorPicker)d;
            // Implement logic to update SelectedColor based on Hexadecimal
        }
    }
}
