using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Jon.Wpf.CustomControls
{

    public class Calculator : Control
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(string), typeof(Calculator), new PropertyMetadata("0"));

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set 
            { 
                if(value.Length>1)
                {
                    if (value[0]=='0')
                    {
                        value = value.Substring(1);
                    }
                }                    
                SetValue(ValueProperty, value); 
            }
        }

        public static readonly RoutedEvent CalculationCompletedEvent = EventManager.RegisterRoutedEvent(
            "CalculationCompleted", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Calculator));

        public event RoutedEventHandler CalculationCompleted
        {
            add { AddHandler(CalculationCompletedEvent, value); }
            remove { RemoveHandler(CalculationCompletedEvent, value); }
        }

        private string _operation = "";
        private double _operand = 0;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            for (int i = 0; i <= 9; i++)
            {
                var button = GetTemplateChild("Button" + i) as Button;
                if (button != null)
                {
                    button.Click += (sender, args) => { Value += i.ToString(); };
                }
            }

            var addButton = GetTemplateChild("AddButton") as Button;
            if (addButton != null)
            {
                addButton.Click += (sender, args) => { SetOperation("+"); };
            }

            var subtractButton = GetTemplateChild("SubtractButton") as Button;
            if (subtractButton != null)
            {
                subtractButton.Click += (sender, args) => { SetOperation("-"); };
            }

            var multiplyButton = GetTemplateChild("MultiplyButton") as Button;
            if (multiplyButton != null)
            {
                multiplyButton.Click += (sender, args) => { SetOperation("*"); };
            }

            var divideButton = GetTemplateChild("DivideButton") as Button;
            if (divideButton != null)
            {
                divideButton.Click += (sender, args) => { SetOperation("/"); };
            }

            var equalsButton = GetTemplateChild("EqualsButton") as Button;
            if (equalsButton != null)
            {
                equalsButton.Click += (sender, args) => { Calculate(); };
            }
        }

        private void SetOperation(string operation)
        {
            _operation = operation;
            _operand = double.Parse(Value);
            Value = "0";
        }

        public void Calculate()
        {
            double result = 0;
            switch (_operation)
            {
                case "+":
                    result = _operand + double.Parse(Value);
                    break;
                case "-":
                    result = _operand - double.Parse(Value);
                    break;
                case "*":
                    result = _operand * double.Parse(Value);
                    break;
                case "/":
                    result = _operand / double.Parse(Value);
                    break;
            }

            Value = result.ToString();
            RaiseEvent(new RoutedEventArgs(CalculationCompletedEvent));
        }

        public ICommand ClearCommand { get; }

        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }
        public ICommand EqualsCommand { get; }
        public ICommand DigitCommand { get; }

        public Calculator()
        {
            AddCommand = new RelayCommand(param => SetOperation("+"));
            SubtractCommand = new RelayCommand(param => SetOperation("-"));
            MultiplyCommand = new RelayCommand(param => SetOperation("*"));
            DivideCommand = new RelayCommand(param => SetOperation("/"));
            EqualsCommand = new RelayCommand(param => Calculate());
            DigitCommand = new RelayCommand(param => Value += param.ToString());
            ClearCommand = new RelayCommand(param => Value = "0");
        }
    }
}
