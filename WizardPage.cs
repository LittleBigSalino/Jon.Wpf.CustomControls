using System.Windows;
using System.Windows.Controls;

namespace Jon.Wpf.CustomControls
{
    public class WizardPage : ContentControl
    {
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
        public static DependencyProperty TitleProperty = DependencyProperty.Register(
                                            "Title", typeof(string), typeof(WizardPage), new PropertyMetadata(default(string)));

        public static DependencyProperty DescriptionProperty = DependencyProperty.Register(
            "Description", typeof(string), typeof(WizardPage), new PropertyMetadata(default(string)));
    }
}