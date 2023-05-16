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

    public class WizardPage : ContentControl
    {
        public static DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", typeof(string), typeof(WizardPage), new PropertyMetadata(default(string)));

        public static DependencyProperty DescriptionProperty = DependencyProperty.Register(
            "Description", typeof(string), typeof(WizardPage), new PropertyMetadata(default(string)));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        static WizardPage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WizardPage), new FrameworkPropertyMetadata(typeof(WizardPage)));
        }        

        public WizardPage()
        {

        }
    }
}
