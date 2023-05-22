using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jon.Wpf.CustomControls
{

    public class RatingControlItem : Control
    {
        static RatingControlItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RatingControlItem), new FrameworkPropertyMetadata(typeof(RatingControlItem)));
        }

        public RatingControlItem()
        {
            BorderThickness = new Thickness(1);
            BorderBrush = Brushes.Red;
        }

        private void OnSelectedChanged()
        {
            if(IsSelected)
            {
                Background = SelectedBrush;
            }
            else
            {
                Background = UnselectedBrush;
            }
        }

        public Brush SelectedBrush
        {
            get { return (Brush)GetValue(SelectedBrushProperty); }
            set { SetValue(SelectedBrushProperty, value); OnSelectedChanged(); }
        }

        public static readonly DependencyProperty SelectedBrushProperty =
            DependencyProperty.Register("SelectedBrush", typeof(Brush), typeof(RatingControlItem), new PropertyMetadata(false));


        public Brush UnselectedBrush
        {
            get { return (Brush)GetValue(UnselectedBrushProperty); }
            set { SetValue(UnselectedBrushProperty, value); OnSelectedChanged(); }
        }

        public static readonly DependencyProperty UnselectedBrushProperty =
            DependencyProperty.Register("UnselectedBrush", typeof(Brush), typeof(RatingControlItem), new PropertyMetadata(false));





        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); OnSelectedChanged();  }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(RatingControlItem), new PropertyMetadata(false));


        public Geometry StarSymbol
        {
            get { return (Geometry)GetValue(StarSymbolProperty); }
            set { SetValue(StarSymbolProperty, value); }
        }
        public static readonly DependencyProperty StarSymbolProperty =
     DependencyProperty.Register("StarSymbol", typeof(Geometry), typeof(RatingControlItem), new PropertyMetadata(null));

    }
}
