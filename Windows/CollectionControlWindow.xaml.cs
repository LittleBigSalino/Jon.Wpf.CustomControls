using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Jon.Wpf.CustomControls.Windows
{
    /// <summary>
    /// Interaction logic for CollectionControlWindow.xaml
    /// </summary>
    public partial class CollectionControlWindow : Window
    {
        public ObservableCollection<object> Items { get; set; }
        public CollectionControlWindow()
        {
            InitializeComponent();
        }

        public CollectionControlWindow(IEnumerable<object> items)
        {
            InitializeComponent();
            Items = new ObservableCollection<object>();
            foreach(var item in items)
            {
                Items.Add(item);
            }
            CollectionControlMain.ItemsSource = Items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
