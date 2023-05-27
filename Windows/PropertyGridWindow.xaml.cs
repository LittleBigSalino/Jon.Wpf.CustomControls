using System.Windows;

namespace Jon.Wpf.CustomControls.Windows
{
    /// <summary>
    /// Interaction logic for PropertyGridWindow.xaml
    /// </summary>
    public partial class PropertyGridWindow : Window
    {
        public object SelectedObject
        {
            get { return GetValue(SelectedObjectProperty); }
            set { SetValue(SelectedObjectProperty, value); }
        }

        public static readonly DependencyProperty SelectedObjectProperty =
           DependencyProperty.Register("SelectedObject", typeof(object), typeof(PropertyGridWindow), new PropertyMetadata(null));


        public PropertyGridWindow()
        {
            InitializeComponent();
        }

        public PropertyGridWindow(object parameter)
        {
            InitializeComponent();
            SelectedObject = parameter;
            PropertyGridMain.SelectedObject = SelectedObject;
            Title = $"Object of type : {parameter.GetType().ToString()}";
        }
    }
}
