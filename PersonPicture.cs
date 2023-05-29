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

    public class PersonPicture : Control
    {
        private TextBlock _initialsTextBlock;
        private Ellipse _pictureEllipse;
        private Ellipse _statusEllipse;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _initialsTextBlock = GetTemplateChild("InitialsTextBlock") as TextBlock;
            _pictureEllipse = GetTemplateChild("PictureEllipse") as Ellipse;
            _statusEllipse = GetTemplateChild("StatusEllipse") as Ellipse;

            UpdateDisplay();
        }

        private static void OnPictureSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (PersonPicture)d;
            control.UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (PictureSource != null)
            {
                _initialsTextBlock.Visibility = Visibility.Collapsed;
                _pictureEllipse.Visibility = Visibility.Visible;
            }
            else
            {
                _initialsTextBlock.Visibility = Visibility.Visible;
                _pictureEllipse.Visibility = Visibility.Collapsed;

                var names = DisplayName.Split(' ');
                var initials = string.Join("", names.Select(name => name[0]));
                _initialsTextBlock.Text = initials;
            }
        }
        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(
    "StrokeThickness", typeof(double), typeof(PersonPicture), new PropertyMetadata(default(double)));

        public double StrokeThickness
        {
            get => (double)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }


        public static readonly DependencyProperty PictureSourceProperty = DependencyProperty.Register(
            "PictureSource", typeof(ImageSource), typeof(PersonPicture), new PropertyMetadata(default(ImageSource)));

        public ImageSource PictureSource
        {
            get => (ImageSource)GetValue(PictureSourceProperty);
            set => SetValue(PictureSourceProperty, value);
        }

        public static readonly DependencyProperty DisplayNameProperty = DependencyProperty.Register(
            "DisplayName", typeof(string), typeof(PersonPicture), new PropertyMetadata(default(string)));

        public string DisplayName
        {
            get => (string)GetValue(DisplayNameProperty);
            set => SetValue(DisplayNameProperty, value);
        }

        public static readonly DependencyProperty StatusPictureSourceProperty = DependencyProperty.Register(
            "StatusPictureSource", typeof(ImageSource), typeof(PersonPicture), new PropertyMetadata(default(ImageSource)));

        public ImageSource StatusPictureSource
        {
            get => (ImageSource)GetValue(StatusPictureSourceProperty);
            set => SetValue(StatusPictureSourceProperty, value);
        }

        static PersonPicture()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PersonPicture), new FrameworkPropertyMetadata(typeof(PersonPicture)));
        }

        public PersonPicture()
        {

        }
    }
}
