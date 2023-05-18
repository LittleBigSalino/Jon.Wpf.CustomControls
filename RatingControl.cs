using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Jon.Wpf.CustomControls
{
    public class RatingControl : Control
    {
        static RatingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RatingControl), new FrameworkPropertyMetadata(typeof(RatingControl)));
        }

        public RatingControl()
        {
            MouseOverCommand = new RelayCommand(param => MouseOverAction(param));
            ClickCommand = new RelayCommand(param => ClickAction(param));
            MouseLeaveCommand = new RelayCommand(param => MouseLeaveAction(param));
            Loaded += RatingControl_Loaded;
        }

        private void RatingControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateStars();
        }

        public double RatingValue
        {
            get { return (double)GetValue(RatingValueProperty); }
            set { SetValue(RatingValueProperty, value); }
        }
        public double MaxRatingValue
        {
            get { return (double)GetValue(MaxRatingValueProperty); }
            set { SetValue(MaxRatingValueProperty, value); }
        }
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        public Geometry StarSymbol
        {
            get { return (Geometry)GetValue(StarSymbolProperty); }
            set { SetValue(StarSymbolProperty, value); }
        }

        public Brush UnselectedBrush
        {
            get { return (Brush)GetValue(UnselectedBrushProperty); }
            set { SetValue(UnselectedBrushProperty, value); }
        }

        public Brush SelectedBrush
        {
            get { return (Brush)GetValue(SelectedBrushProperty); }
            set { SetValue(SelectedBrushProperty, value); }
        }

        public ICommand ClickCommand
        {
            get { return (ICommand)GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }

        public ICommand MouseOverCommand
        {
            get { return (ICommand)GetValue(MouseOverCommandProperty); }
            set { SetValue(MouseOverCommandProperty, value); }
        }

        public ICommand MouseLeaveCommand
        {
            get { return (ICommand)GetValue(MouseLeaveCommandProperty); }
            set { SetValue(MouseLeaveCommandProperty, value); }
        }

        public static readonly DependencyProperty UnselectedBrushProperty =
            DependencyProperty.Register("UnselectedBrush", typeof(Brush), typeof(RatingControl), new PropertyMetadata(Brushes.Gray));

        public static readonly DependencyProperty SelectedBrushProperty =
            DependencyProperty.Register("SelectedBrush", typeof(Brush), typeof(RatingControl), new PropertyMetadata(Brushes.Yellow));

        public static readonly DependencyProperty RatingValueProperty =
            DependencyProperty.Register("RatingValue", typeof(double), typeof(RatingControl),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnRatingValueChanged));

        public static readonly DependencyProperty MaxRatingValueProperty =
            DependencyProperty.Register("MaxRatingValue", typeof(double), typeof(RatingControl), new PropertyMetadata(5.0));

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(RatingControl), new PropertyMetadata(false));

        public static readonly DependencyProperty StarSymbolProperty =
            DependencyProperty.Register("StarSymbol", typeof(Geometry), typeof(RatingControl), new PropertyMetadata(null));

        public static readonly RoutedEvent RatingValueChangedEvent =
            EventManager.RegisterRoutedEvent("RatingValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<double>), typeof(RatingControl));

        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(RatingControl), new UIPropertyMetadata(null));      
        public static readonly DependencyProperty MouseOverCommandProperty =
            DependencyProperty.Register("MouseOverCommand", typeof(ICommand), typeof(RatingControl), new UIPropertyMetadata(null));

        public static readonly DependencyProperty MouseLeaveCommandProperty =
            DependencyProperty.Register("MouseLeaveCommand", typeof(ICommand), typeof(RatingControl), new UIPropertyMetadata(null));


        public event RoutedPropertyChangedEventHandler<double> RatingValueChanged
        {
            add { AddHandler(RatingValueChangedEvent, value); }
            remove { RemoveHandler(RatingValueChangedEvent, value); }
        }

        private void UpdateStars()
        {
            foreach (var star in FindVisualChildren<Path>(this)) // Replace UIElement with the type of your stars
            {                
                int thisStarNumber = Int32.Parse(star.Tag as string);
                if (thisStarNumber <= RatingValue)
                {
                    star.Fill = SelectedBrush;
                }
                else
                {
                    star.Fill = UnselectedBrush;
                }             
            }
        }

        private void RaiseRatingValueChangedEvent()
        {
            RoutedEventArgs args = new(RatingValueChangedEvent, this);
            args.Source = this;
            args.Handled = false;
            RaiseEvent(args);
        }

        private static void OnRatingValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RatingControl ratingControl = (RatingControl)d;
            ratingControl.UpdateStars();
            ratingControl.RaiseRatingValueChangedEvent();
        }


        private void MouseOverAction(object param)
        {
            Path? starOver = param as Path;

        }

        private void MouseLeaveAction(object param)
        {
            Path? starOver = param as Path;
        }

        private void ClickAction(object param)
        {
            Path? starOver = param as Path;
            int starNumber = Int32.Parse(starOver.Tag as string);
            RatingValue = starNumber;
            foreach (var star in FindVisualChildren<Path>(this)) // Replace UIElement with the type of your stars
            {
                if (star != starOver)
                {
                    int thisStarNumber = Int32.Parse(star.Tag as string);
                    if(thisStarNumber<=starNumber)
                    {
                        star.Fill = SelectedBrush;
                    }
                    else
                    {
                        star.Fill = UnselectedBrush;
                    }
                }
            }
            starOver.Fill = SelectedBrush;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }


    }
}


