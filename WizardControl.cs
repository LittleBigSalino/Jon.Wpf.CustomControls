using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Jon.Wpf.CustomControls
{
    public class WizardControl : ItemsControl
    {
        public ICommand BackCommand { get; }
        public ICommand NextCommand { get; }

        public static readonly RoutedEvent FinishedEvent = EventManager.RegisterRoutedEvent(
            "Finished", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WizardControl));

        public static readonly DependencyProperty CurrentPageNumberProperty = DependencyProperty.Register(
            "CurrentPageNumber", typeof(int), typeof(WizardControl), new PropertyMetadata(0));

        public int CurrentPageNumber
        {
            get { return (int)GetValue(CurrentPageNumberProperty); }
            set { SetValue(CurrentPageNumberProperty, value); }
        }

        public WizardControl()
        {
            // Handle dynamic addition/removal of pages            
            ((INotifyCollectionChanged)Items).CollectionChanged += OnItemsChanged;
            BackCommand = new RelayCommand(_ => Back(), _ => CurrentPageNumber > 0);
            NextCommand = new RelayCommand(_ => Next(), _ => CurrentPageNumber < Items.Count - 1);
        }

        public event RoutedEventHandler Finished
        {
            add { AddHandler(FinishedEvent, value); }
            remove { RemoveHandler(FinishedEvent, value); }
        }

        public void Next()
        {
            if (CurrentPageNumber < Items.Count - 1)
            {
                CurrentPageNumber++;
                UpdateCurrentPage();
            }
            else
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

        private void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Update current page if items are added/removed
            UpdateCurrentPage();
        }

        private void UpdateCurrentPage()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                ContentControl page = (ContentControl)Items[i];
                page.Visibility = i == CurrentPageNumber ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void OnFinished()
        {
            RaiseEvent(new RoutedEventArgs(FinishedEvent));
        }
    }
}

