using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jon.Wpf.CustomControls
{
    public class CustomDataGrid : DataGrid
    {
        static CustomDataGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomDataGrid), new FrameworkPropertyMetadata(typeof(CustomDataGrid)));
        }

        public Brush CategoryColor
        {
            get { return (Brush)GetValue(CategoryColorProperty); }
            set { SetValue(CategoryColorProperty, value); }
        }
        public static readonly DependencyProperty CategoryColorProperty =
            DependencyProperty.Register(nameof(CategoryColor), typeof(Brush), typeof(CustomDataGrid), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0x4E, 0x94, 0xDB))));


        public Brush CategoryForeground
        {
            get { return (Brush)GetValue(CategoryForegroundProperty); }
            set { SetValue(CategoryForegroundProperty, value); }
        }
        public static readonly DependencyProperty CategoryForegroundProperty =
            DependencyProperty.Register(nameof(CategoryForeground), typeof(Brush), typeof(CustomDataGrid), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        public Brush CategoryBackground
        {
            get { return (Brush)GetValue(CategoryBackgroundProperty); }
            set { SetValue(CategoryBackgroundProperty, value); }
        }
        public static readonly DependencyProperty CategoryBackgroundProperty =
            DependencyProperty.Register(nameof(CategoryBackground), typeof(Brush), typeof(CustomDataGrid), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        public bool CategorizedView
        {
            get { return (bool)GetValue(CategorizedViewProperty); }
            set { SetValue(CategorizedViewProperty, value); }
        }
        public static readonly DependencyProperty CategorizedViewProperty =
            DependencyProperty.Register(nameof(CategorizedView), typeof(bool), typeof(CustomDataGrid), new PropertyMetadata(false));
    }
}
