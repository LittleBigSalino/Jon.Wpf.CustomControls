using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Jon.Wpf.CustomControls
{
    public class TextToSqlQueryTextBlock : Control
    {
        static TextToSqlQueryTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextToSqlQueryTextBlock), new FrameworkPropertyMetadata(typeof(TextToSqlQueryTextBlock)));
        }


        private static readonly HashSet<string> sqlKeywords = new HashSet<string>
    {
        "select", "from", "where", "insert", "update", "delete", "group by", "order by"
        // Add more SQL keywords as needed.
    };


        // Dependency property to hold the text to be analyzed.
        public static readonly DependencyProperty SqlTextProperty = DependencyProperty.Register(
            "SqlText", typeof(string), typeof(TextToSqlQueryTextBlock), new PropertyMetadata("", OnSqlTextChanged));

        public string SqlText
        {
            get { return (string)GetValue(SqlTextProperty); }
            set { SetValue(SqlTextProperty, value); }
        }


        public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register(
      "DisplayText",
      typeof(string),
      typeof(TextToSqlQueryTextBlock),
      new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public string DisplayText
        {
            get { return (string)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        private static readonly HttpClient httpClient = new HttpClient();
        private CancellationTokenSource cts = new CancellationTokenSource();
        private static readonly TimeSpan delay = TimeSpan.FromSeconds(3);

        private async Task TranslateToSql(CancellationToken cancellationToken)
        {
            // Wait for a delay to avoid making too many API requests.
            await Task.Delay(delay, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            // The prompt to ask the model.
            string prompt = $"Translate the following English text to SQL query: \"{SqlText}\"?";

            // The data to send in the body of the POST request.
            var data = new { model = "text-davinci-003", prompt = prompt, max_tokens = 60 };
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Set the API key in the headers.
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPENAI_API_KEY")}");

            // The URL of the OpenAI API.
            string url = "https://api.openai.com/v1/completions";

            try
            {
                var response = await httpClient.PostAsync(url, content, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonSerializer.Deserialize<OpenAIResponse>(responseContent);
                    // Assuming the model's response will be the SQL query.
                    string sqlQuery = responseObject.choices[0].text.Trim();
                    DisplayText = sqlQuery; // Here is the change
                }
                else
                {
                    // Handle non-success status codes.
                    DisplayText = $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                }
            }
            catch (HttpRequestException e)
            {
                // Handle exceptions.
                DisplayText = $"Error: {e.Message}";
            }
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var displayText = GetTemplateChild("PART_DisplayText") as RichTextBox;
            var copyButton = GetTemplateChild("PART_CopyButton") as Button;

            if (copyButton != null)
            {
                copyButton.Click += (sender, e) =>
                {
                    Clipboard.SetText(new TextRange(displayText.Document.ContentStart, displayText.Document.ContentEnd).Text);
                };
            }
        }

        //private void DisplayFormattedSql(string sqlQuery)
        //{
        //    var displayText = GetTemplateChild("PART_DisplayText") as RichTextBox;
        //    displayText.Document.Blocks.Clear();

        //    var paragraph = new Paragraph();

        //    // Split the SQL query into words.
        //    var words = sqlQuery.Split(new[] { ' ', '\t', '\n', '\r', '(', ')', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
        //    foreach (var word in words)
        //    {
        //        // If the word is a SQL keyword, apply the highlight.
        //        if (sqlKeywords.Contains(word.ToLower()))
        //        {
        //            var run = new Run(word) { Foreground = Brushes.Blue };
        //            paragraph.Inlines.Add(run);
        //        }
        //        else
        //        {
        //            paragraph.Inlines.Add(new Run(word));
        //        }

        //        // Add a space after each word.
        //        paragraph.Inlines.Add(new Run(" "));
        //    }

        //    displayText.Document.Blocks.Add(paragraph);
        //}

        private void DisplayFormattedSql(string sqlQuery)
        {
            var displayText = GetTemplateChild("PART_DisplayText") as RichTextBox;
            displayText.Document.Blocks.Clear();
            var paragraph = new Paragraph();
            var words = sqlQuery.Split(new[] { ' ', '\t', '\n', '\r', '(', ')', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                string nextWord = i < words.Length - 1 ? words[i + 1] : null;

                // If the current word and the next word form a SQL keyword, treat them as one keyword.
                if (nextWord != null && sqlKeywords.Contains((word + " " + nextWord).ToLower()))
                {
                    var run = new Run(word + " " + nextWord) { Foreground = Brushes.Blue };
                    paragraph.Inlines.Add(run);
                    i++; // Skip the next word as it's part of the current keyword.
                }
                else if (sqlKeywords.Contains(word.ToLower()))
                {
                    var run = new Run(word) { Foreground = Brushes.Blue };
                    paragraph.Inlines.Add(run);
                }
                else
                {
                    paragraph.Inlines.Add(new Run(word));
                }

                // Add a space after each keyword/word.
                paragraph.Inlines.Add(new Run(" "));
            }
            displayText.Document.Blocks.Add(paragraph);
        }




        private static async void OnSqlTextChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var control = source as TextToSqlQueryTextBlock;

            if (control != null)
            {
                // Cancel the previous API request, if any.
                control.cts.Cancel();
                control.cts = new CancellationTokenSource();

                try
                {
                    await control.TranslateToSql(control.cts.Token);
                    control.DisplayFormattedSql(control.DisplayText);
                }
                catch (OperationCanceledException)
                {
                    // Ignore the exception if the operation was cancelled.
                }
            }
        }


    }
}
