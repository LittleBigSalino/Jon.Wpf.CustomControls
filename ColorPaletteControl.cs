using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Jon.Wpf.CustomControls
{
    public class ColorPaletteControl : Control
    {
        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }
        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }
        public List<Color> ColorList
        {
            get { return (List<Color>)GetValue(ColorListProperty); }
            set { SetValue(ColorListProperty, value); }
        }
        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public Double ColorSquareWidth
        {
            get { return (Double)GetValue(ColorSquareWidthProperty); }
            set { SetValue(ColorSquareWidthProperty, value); }
        }


        public Double ColorSquareHeight
        {
            get { return (Double)GetValue(ColorSquareHeightProperty); }
            set { SetValue(ColorSquareHeightProperty, value); }
        }

        public int ColorSquareColumnCount
        {
            get { return (int)GetValue(ColorSquareColumnCountProperty); }
            set { SetValue(ColorSquareColumnCountProperty, value); }
        }


        public ICommand SelectColorCommand { get; }
        public ColorPaletteControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPaletteControl), new FrameworkPropertyMetadata(typeof(ColorPaletteControl)));
            ColorList = GetAllColors();
            SelectColorCommand = new RelayCommand(param =>
            {
                if (param is Color color)
                {
                    SelectColor(color);
                }
            });
        }

        public static readonly DependencyProperty ColorSquareWidthProperty =
            DependencyProperty.Register("ColorSquareWidth", typeof(double), typeof(ColorPaletteControl), new PropertyMetadata(16.0));

        public static readonly DependencyProperty ColorSquareHeightProperty =
           DependencyProperty.Register("ColorSquareHeight", typeof(double), typeof(ColorPaletteControl), new PropertyMetadata(16.0));


        public static readonly DependencyProperty ColorSquareColumnCountProperty =
           DependencyProperty.Register("ColorSquareColumnCount", typeof(int), typeof(ColorPaletteControl), new PropertyMetadata(15));

        public static readonly DependencyProperty RowsProperty =
                                                            DependencyProperty.Register("Rows", typeof(int), typeof(ColorPaletteControl), new PropertyMetadata(5));

        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register("Columns", typeof(int), typeof(ColorPaletteControl), new PropertyMetadata(5));

        public static readonly DependencyProperty ColorListProperty =
            DependencyProperty.Register("ColorList", typeof(List<Color>), typeof(ColorPaletteControl), new PropertyMetadata(GetAllColors()));

        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorPaletteControl), new PropertyMetadata(Colors.Transparent));

        public static readonly RoutedEvent ColorSelectedEvent =
            EventManager.RegisterRoutedEvent("ColorSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ColorPaletteControl));
        public event RoutedEventHandler ColorSelected
        {
            add { AddHandler(ColorSelectedEvent, value); }
            remove { RemoveHandler(ColorSelectedEvent, value); }
        }

        private static List<Color> GetAllColors()
        {
            return typeof(Colors)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(prop => prop.PropertyType == typeof(Color))
                .Select(prop => (Color)prop.GetValue(null))
                .OrderBy(color => ColorToHue(color))
                .ToList();
        }
        private static double ColorToHue(Color color)
        {
            // Convert RGB to HSV and return the hue
            double hue = RGBtoHSV(color.ScR, color.ScG, color.ScB).Hue;

            return hue;
        }
        private static (double Hue, double Saturation, double Value) RGBtoHSV(float r, float g, float b)
        {
            double max = Math.Max(r, Math.Max(g, b)), min = Math.Min(r, Math.Min(g, b));
            double hue = max == min ? 0 : (max == r ? (g - b) / (max - min) + (g < b ? 6 : 0) : max == g ? (b - r) / (max - min) + 2 : (r - g) / (max - min) + 4);
            double saturation = max == 0 ? 0 : (max - min) / max;
            double value = max;

            return (hue * 60, saturation, value); // Hue is in degrees between 0 and 360. Saturation and Value are from 0 to 1
        }
        private void SelectColor(Color color)
        {
            SelectedColor = color;
            RaiseEvent(new RoutedEventArgs(ColorSelectedEvent, this));
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ColorList = GetAllColors();

            // Calculate the number of rows and columns
            int numberOfColors = ColorList.Count;
            int desiredWidth = ColorSquareColumnCount; // Set this to the desired number of columns

            Columns = desiredWidth;
            Rows = (int)Math.Ceiling((double)numberOfColors / desiredWidth);

        }
    }
}