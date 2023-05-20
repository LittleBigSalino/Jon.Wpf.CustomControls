using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Jon.Wpf.CustomControls
{
    public class CircularImageButton : Button
    {
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        static CircularImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CircularImageButton), new FrameworkPropertyMetadata(typeof(CircularImageButton)));
        }
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(CircularImageButton), new PropertyMetadata(null));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var path = GetTemplateChild("PART_Path") as Path;
            if (path != null)
            {
                path.Data = new EllipseGeometry(new Point(), 1, 1);
            }
        }
    }
}