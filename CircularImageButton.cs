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
    public class CircularImageButton : Button
    {
        static CircularImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CircularImageButton), new FrameworkPropertyMetadata(typeof(CircularImageButton)));
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
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
