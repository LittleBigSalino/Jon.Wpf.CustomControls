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

        private int _currentIndex = 0;

        public WizardControl()
        {
            // Handle dynamic addition/removal of pages            
            ((INotifyCollectionChanged)Items).CollectionChanged += OnItemsChanged;
            BackCommand = new RelayCommand(_ => Back(), _ => _currentIndex > 0);
            NextCommand = new RelayCommand(_ => Next(), _ => _currentIndex < Items.Count - 1);
        }

        public event RoutedEventHandler Finished
        {
            add { AddHandler(FinishedEvent, value); }
            remove { RemoveHandler(FinishedEvent, value); }
        }

        public void Next()
        {
            if (_currentIndex < Items.Count - 1)
            {
                _currentIndex++;
                UpdateCurrentPage();
            }
            else
            {
                OnFinished();
            }
        }

        public void Back()
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
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
                page.Visibility = i == _currentIndex ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void OnFinished()
        {
            RaiseEvent(new RoutedEventArgs(FinishedEvent));
        }
    }
}
