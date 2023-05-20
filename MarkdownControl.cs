using Markdig;
using System.Windows;
using System.Windows.Controls;

namespace Jon.Wpf.CustomControls
{
    public class MarkdownControl : ContentControl
    {
        public string Markdown
        {
            get { return (string)GetValue(MarkdownProperty); }
            set { SetValue(MarkdownProperty, value); }
        }
        static MarkdownControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MarkdownControl), new FrameworkPropertyMetadata(typeof(MarkdownControl)));
        }

        public MarkdownControl()
        {
            _webBrowser = new WebBrowser();
            this.Content = _webBrowser;
        }
        private readonly WebBrowser _webBrowser;
        public static readonly DependencyProperty MarkdownProperty =
                           DependencyProperty.Register("Markdown", typeof(string), typeof(MarkdownControl), new PropertyMetadata(OnMarkdownChanged));
        private static void OnMarkdownChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (MarkdownControl)d;
            control.UpdateMarkdown();
        }

        private void UpdateMarkdown()
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            var document = Markdig.Markdown.Parse(Markdown ?? string.Empty, pipeline);
            string html = Markdig.Markdown.ToHtml(document, pipeline);
            _webBrowser.NavigateToString(html);
        }

    }
}