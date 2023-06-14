using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jon.Wpf.CustomControls
{
    public class SummarizationTextBlock : TextBlock
    {
        public static readonly DependencyProperty TextToSummarizeProperty = DependencyProperty.Register(
        "TextToSummarize", typeof(string), typeof(SummarizationTextBlock), new PropertyMetadata("", OnTextToSummarizeChanged));

        public string TextToSummarize
        {
            get { return (string)GetValue(TextToSummarizeProperty); }
            set { SetValue(TextToSummarizeProperty, value); }
        }

        // The delay (in milliseconds) before making an API request after the user stops typing.
        private const int delay = 1000;

        // The cancellation token source used to cancel the delay when the user types.
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private static void OnTextToSummarizeChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var control = source as SummarizationTextBlock;
            control?.StartAnalyzeTextDelay();
        }


        public static readonly DependencyProperty DelayProperty = DependencyProperty.Register(
      "Delay", typeof(int), typeof(SummarizationTextBlock), new PropertyMetadata(1000));

        public int Delay
        {
            get { return (int)GetValue(DelayProperty); }
            set { SetValue(DelayProperty, value); }
        }

        // Then replace the delay constant with this.Delay in your StartAnalyzeTextDelay method.
        private void StartAnalyzeTextDelay()
        {
            // Cancel the previous delay (if any).
            cancellationTokenSource.Cancel();
            cancellationTokenSource = new CancellationTokenSource();

            Task.Delay(this.Delay, cancellationTokenSource.Token).ContinueWith(t =>
            {
                if (!t.IsCanceled)
                {
                    Dispatcher.Invoke(async () =>
                    {
                        await SummarizeText(cancellationTokenSource.Token);
                    });
                }
            });
        }


        // Dependency property to hold the maximum number of words in the summary.
        public static readonly DependencyProperty MaxWordsProperty = DependencyProperty.Register(
            "MaxWords", typeof(int), typeof(SummarizationTextBlock), new PropertyMetadata(50));

        public int MaxWords
        {
            get { return (int)GetValue(MaxWordsProperty); }
            set { SetValue(MaxWordsProperty, value); }
        }

        private static readonly HttpClient httpClient = new HttpClient();


        private async Task SummarizeText(CancellationToken cancellationToken)
        {
            {
                // Convert MaxWords to word form. Please note this is a simple implementation and works for numbers up to 20.
                string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                           "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty"};
                string maxWordsInWordForm = MaxWords <= 20 ? words[MaxWords] : MaxWords.ToString();

                // The prompt to ask the model.
                string prompt = $"Please provide a {maxWordsInWordForm}-word summary of the following text: \"{TextToSummarize}\"";

                // The data to send in the body of the POST request.
                var data = new { model = "text-davinci-003", prompt = prompt, max_tokens = 200 };
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Set the API key in the headers.
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPENAI_API_KEY")}");

                // The URL of the OpenAI API.
                string url = "https://api.openai.com/v1/completions";

                try
                {
                    var response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonSerializer.Deserialize<OpenAIResponse>(responseContent);
                        Text = responseObject.choices[0].text.Trim();
                    }
                    else
                    {
                        // Handle non-success status codes.
                        Text = $"Error: {response.StatusCode}";
                    }
                }
                catch (HttpRequestException e)
                {
                    // Handle exceptions.
                    Text = $"Error: {e.Message}";
                }
            }
        }
    }
}
