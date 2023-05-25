using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

//namespace Jon.Wpf.CustomControls
//{
//    public class WizardControl : ItemsControl
//    {
//        public ICommand BackCommand { get; }
//        public ICommand NextCommand { get; }

//        public int CurrentPageNumber
//        {
//            get { return (int)GetValue(CurrentPageNumberProperty); }
//            set { SetValue(CurrentPageNumberProperty, value); }
//        }
//        public WizardControl()
//        {
//            // Handle dynamic addition/removal of pages
//            ((INotifyCollectionChanged)Items).CollectionChanged += OnItemsChanged;
//            BackCommand = new RelayCommand(_ => Back(), _ => CurrentPageNumber > 0);
//            NextCommand = new RelayCommand(_ => Next(), _ => CurrentPageNumber < Items.Count - 1);
//        }
//        public static readonly RoutedEvent FinishedEvent = EventManager.RegisterRoutedEvent(
//                            "Finished", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WizardControl));

//        public static readonly DependencyProperty CurrentPageNumberProperty = DependencyProperty.Register(
//            "CurrentPageNumber", typeof(int), typeof(WizardControl), new PropertyMetadata(0));
//        public event RoutedEventHandler Finished
//        {
//            add { AddHandler(FinishedEvent, value); }
//            remove { RemoveHandler(FinishedEvent, value); }
//        }

//        private void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
//        {
//            // Update current page if items are added/removed
//            UpdateCurrentPage();
//        }
//        private void UpdateCurrentPage()
//        {
//            for (int i = 0; i < Items.Count; i++)
//            {
//                ContentControl page = (ContentControl)Items[i];
//                page.Visibility = i == CurrentPageNumber ? Visibility.Visible : Visibility.Collapsed;
//            }
//        }
//        private void OnFinished()
//        {
//            RaiseEvent(new RoutedEventArgs(FinishedEvent));
//        }
//        public void Next()
//        {
//            if (CurrentPageNumber < Items.Count - 1)
//            {
//                CurrentPageNumber++;
//                UpdateCurrentPage();
//            }
//            else
//            {
//                OnFinished();
//            }
//        }

//        public void Back()
//        {
//            if (CurrentPageNumber > 0)
//            {
//                CurrentPageNumber--;
//                UpdateCurrentPage();
//            }
//        }
//    }
//}


namespace Jon.Wpf.CustomControls
{
    public class WizardControl : ItemsControl
    {
        public ICommand BackCommand { get; }
        public ICommand NextCommand { get; }

        public string NextButtonText
        {
            get { return (string)GetValue(NextButtonTextProperty); }
            set { SetValue(NextButtonTextProperty, value); }
        }

        public static readonly DependencyProperty NextButtonTextProperty = DependencyProperty.Register(
            "NextButtonText", typeof(string), typeof(WizardControl), new PropertyMetadata("Next"));

        public int CurrentPageNumber
        {
            get { return (int)GetValue(CurrentPageNumberProperty); }
            set { SetValue(CurrentPageNumberProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
    "Title", typeof(string), typeof(WizardControl), new PropertyMetadata(""));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public WizardControl()
        {
            ((INotifyCollectionChanged)Items).CollectionChanged += OnItemsChanged;
            BackCommand = new RelayCommand(_ => Back(), _ => CurrentPageNumber > 0);
            NextCommand = new RelayCommand(_ => Next(), _ => CurrentPageNumber <= Items.Count - 1);
            UpdateNextButtonText();
        }

        public static readonly RoutedEvent FinishedEvent = EventManager.RegisterRoutedEvent(
                            "Finished", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WizardControl));

        public static readonly DependencyProperty CurrentPageNumberProperty = DependencyProperty.Register(
            "CurrentPageNumber", typeof(int), typeof(WizardControl), new PropertyMetadata(0, OnCurrentPageNumberChanged));

        public event RoutedEventHandler Finished
        {
            add { AddHandler(FinishedEvent, value); }
            remove { RemoveHandler(FinishedEvent, value); }
        }

        private static void OnCurrentPageNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (WizardControl)d;
            control.UpdateNextButtonText();
        }

        private void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateCurrentPage();
        }

        private void UpdateNextButtonText()
        {
            NextButtonText = CurrentPageNumber >= Items.Count - 1 && Items.Count > 0 ? "Finish" : "Next";

            CommandManager.InvalidateRequerySuggested();
        }

        private void UpdateCurrentPage()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i] is ContentControl page)
                {
                    page.Visibility = i == CurrentPageNumber ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

        private void OnFinished()
        {
            RaiseEvent(new RoutedEventArgs(FinishedEvent));
        }

        public void Next()
        {
            if (CurrentPageNumber < Items.Count - 1)
            {
                CurrentPageNumber++;
                UpdateCurrentPage();
            }
            else if (CurrentPageNumber == Items.Count - 1)
            {
                OnFinished();
            }
        }


        public void Back()
        {
            if (CurrentPageNumber > 0)
            {
                CurrentPageNumber--;
                UpdateCurrentPage();
            }
        }
    }
}

