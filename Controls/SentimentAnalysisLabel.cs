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
    public class SentimentAnalysisLabel : Label
    {
        // Dependency property to hold the text to be analyzed.
        public static readonly DependencyProperty AnalyzeTextProperty = DependencyProperty.Register(
            "AnalyzeText", typeof(string), typeof(SentimentAnalysisLabel), new PropertyMetadata("", OnAnalyzeTextChanged));

        public string AnalyzeText
        {
            get { return (string)GetValue(AnalyzeTextProperty); }
            set { SetValue(AnalyzeTextProperty, value); }
        }

        private static readonly HttpClient httpClient = new HttpClient();
        private CancellationTokenSource cts = new CancellationTokenSource();
        private static readonly TimeSpan delay = TimeSpan.FromSeconds(4);

        private async Task AnalyzeSentiment(CancellationToken cancellationToken)
        {
            // Wait for a delay to avoid making too many API requests.
            await Task.Delay(delay, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            // The prompt to ask the model.
            string prompt = $"What is the sentiment of the following text: \"{AnalyzeText}\"?";
            
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
                    // Assuming the model's response will be something like "The sentiment of the text is positive."
                    string sentiment = responseObject.choices[0].text.Trim();
                    switch (sentiment.ToLower())
                    {
                        case "positive":
                            Background = PositiveBrush;
                            break;
                        case "negative":
                            Background = NegativeBrush;
                            break;
                        case "neutral":
                            Background = NeutralBrush;
                            break;
                    }
                    Content = sentiment;
                }
                else
                {
                    // Handle non-success status codes.
                    Content = $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                }


            }
            catch (HttpRequestException e)
            {
                // Handle exceptions.
                Content = $"Error: {e.Message}";
            }
        }

        public static readonly DependencyProperty PositiveBrushProperty = DependencyProperty.Register(
       "PositiveBrush", typeof(Brush), typeof(SentimentAnalysisLabel), new PropertyMetadata(Brushes.LightGreen));

        public Brush PositiveBrush
        {
            get { return (Brush)GetValue(PositiveBrushProperty); }
            set { SetValue(PositiveBrushProperty, value); }
        }

        // Dependency property for the background color when the sentiment is negative.
        public static readonly DependencyProperty NegativeBrushProperty = DependencyProperty.Register(
            "NegativeBrush", typeof(Brush), typeof(SentimentAnalysisLabel), new PropertyMetadata(Brushes.LightCoral));

        public Brush NegativeBrush
        {
            get { return (Brush)GetValue(NegativeBrushProperty); }
            set { SetValue(NegativeBrushProperty, value); }
        }

        // Dependency property for the background color when the sentiment is neutral.
        public static readonly DependencyProperty NeutralBrushProperty = DependencyProperty.Register(
            "NeutralBrush", typeof(Brush), typeof(SentimentAnalysisLabel), new PropertyMetadata(Brushes.LightGray));

        public Brush NeutralBrush
        {
            get { return (Brush)GetValue(NeutralBrushProperty); }
            set { SetValue(NeutralBrushProperty, value); }
        }

        // Dependency property for the background color when there's an error.
        public static readonly DependencyProperty ErrorBrushProperty = DependencyProperty.Register(
            "ErrorBrush", typeof(Brush), typeof(SentimentAnalysisLabel), new PropertyMetadata(Brushes.LightSalmon));

        public Brush ErrorBrush
        {
            get { return (Brush)GetValue(ErrorBrushProperty); }
            set { SetValue(ErrorBrushProperty, value); }
        }


        private static async void OnAnalyzeTextChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var control = source as SentimentAnalysisLabel;

            if (control != null)
            {
                // Cancel the previous API request, if any.
                control.cts.Cancel();
                control.cts = new CancellationTokenSource();

                try
                {
                    await control.AnalyzeSentiment(control.cts.Token);
                }
                catch (OperationCanceledException)
                {
                    // Ignore the exception if the operation was cancelled.
                }
            }
        }
    }

    public class OpenAIResponse
    {
        public List<Choice> choices { get; set; }

        public class Choice
        {
            public string text { get; set; }
        }
    }

}
