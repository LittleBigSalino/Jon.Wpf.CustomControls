using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Jon.Wpf.CustomControls
{
    public static class TextBoxEnterCommandBehavior
    {
        public static readonly DependencyProperty EnterCommandProperty = DependencyProperty.RegisterAttached(
            "EnterCommand",
            typeof(ICommand),
            typeof(TextBoxEnterCommandBehavior),
            new PropertyMetadata(EnterCommandChanged));

        private static void EnterCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.KeyDown -= TextBox_KeyDown;
                if (e.NewValue != null)
                {
                    textBox.KeyDown += TextBox_KeyDown;
                }
            }
        }
        private static void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var textBox = (TextBox)sender;
                var command = GetEnterCommand(textBox);
                command.Execute(textBox.Text);
                textBox.Clear();
            }
        }
        public static void SetEnterCommand(TextBox target, ICommand value) => target.SetValue(EnterCommandProperty, value);

        public static ICommand GetEnterCommand(TextBox target) => (ICommand)target.GetValue(EnterCommandProperty);
    }
    public class TerminalControl : Control
    {
        public ICommand ExecuteCommandCommand
        {
            get { return (ICommand)GetValue(ExecuteCommandCommandProperty); }
            set { SetValue(ExecuteCommandCommandProperty, value); }
        }
        public string InputText
        {
            get { return (string)GetValue(InputTextProperty); }
            set { SetValue(InputTextProperty, value); }
        }
        public string OutputText
        {
            get { return (string)GetValue(OutputTextProperty); }
            set { SetValue(OutputTextProperty, value); }
        }
        public bool IsRealTerminal
        {
            get { return (bool)GetValue(IsRealTerminalProperty); }
            set { SetValue(IsRealTerminalProperty, value); }
        }
        public string CurrentDirectory
        {
            get { return (string)GetValue(CurrentDirectoryProperty); }
            set { SetValue(CurrentDirectoryProperty, value); }
        }
        static TerminalControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TerminalControl), new FrameworkPropertyMetadata(typeof(TerminalControl)));
        }
        public TerminalControl()
        {
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, PasteCommand));
            ExecuteCommandCommand = new RelayCommand(param => ExecuteCommandMethod(), param => CanExecuteCommandMethod());
        }
        public static readonly DependencyProperty InputTextProperty = DependencyProperty.Register(
                                                                    "InputText", typeof(string), typeof(TerminalControl), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty OutputTextProperty = DependencyProperty.Register(
            "OutputText", typeof(string), typeof(TerminalControl), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty IsRealTerminalProperty = DependencyProperty.Register(
            "IsRealTerminal", typeof(bool), typeof(TerminalControl), new PropertyMetadata(default(bool)));
        public static readonly DependencyProperty ExecuteCommandCommandProperty = DependencyProperty.Register(
    "ExecuteCommandCommand", typeof(ICommand), typeof(TerminalControl), new PropertyMetadata(default(ICommand)));
        public static readonly DependencyProperty CurrentDirectoryProperty = DependencyProperty.Register(
    "CurrentDirectory", typeof(string), typeof(TerminalControl), new PropertyMetadata(AppDomain.CurrentDomain.BaseDirectory));
        private void PasteCommand(object sender, ExecutedRoutedEventArgs e)
        {
            InputText = Clipboard.GetText();
        }

        private bool CanExecuteCommandMethod()
        {
            return !string.IsNullOrEmpty(InputText);
        }
        private void ExecuteCommandMethod()
        {
            ExecuteCommand(InputText);
            InputText = string.Empty;
        }
        private void ExecuteRealCommand(string command)
        {
            var processStartInfo = new ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = CurrentDirectory
            };

            var process = new Process { StartInfo = processStartInfo };
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            OutputText += output;

            if (command.StartsWith("cd "))
            {
                CurrentDirectory = new DirectoryInfo(command.Substring(3)).FullName;
            }
        }
        public void ExecuteCommand(string command)
        {
            if (IsRealTerminal)
            {
                ExecuteRealCommand(command);
            }
            else
            {
                // handle command within application
            }
        }
        // ... other methods and properties as per the specification
    }
}
