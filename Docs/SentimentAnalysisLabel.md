
# SentimentAnalysisLabel

`SentimentAnalysisLabel` is a custom WPF control derived from `Label` in .NET 6.0/7.0. It automatically analyzes the sentiment of the given text using OpenAI's GPT-3 model when the text is changed.

## Features

- Automatically analyzes the sentiment of the text.
- Changes background color based on the sentiment (positive, negative, neutral, or error).
- Set a delay time before the sentiment analysis starts after the user stops typing.
- Uses OpenAI's GPT-3 model for sentiment analysis.

## Properties

- `AnalyzeText`: The text to be analyzed.
- `PositiveBrush`: The background color when the sentiment is positive.
- `NegativeBrush`: The background color when the sentiment is negative.
- `NeutralBrush`: The background color when the sentiment is neutral.
- `ErrorBrush`: The background color when an error occurs.

## Usage

Here's an example of how to use the `SentimentAnalysisLabel` control:

```xml
<local:SentimentAnalysisLabel x:Name="sentimentAnalysisLabel" PositiveBrush="LightGreen" NegativeBrush="LightCoral" NeutralBrush="LightGray" ErrorBrush="LightSalmon" />
```

Then, to set the text to be analyzed in your code-behind:

```csharp
sentimentAnalysisLabel.AnalyzeText = "Your text here";
```

## Dependencies

- .NET 6.0 or 7.0
- System.Text.Json for handling JSON responses

## Setup

You need to set up your OpenAI API key in your environment variables:

```sh
setx OPENAI_API_KEY "your-api-key"
```

## Limitations

- The sentiment analysis is only as accurate as the GPT-3 model's understanding of sentiment in text.

## Error Handling

If an error occurs during the HTTP request or if the API returns a non-success status code, the text of the `SentimentAnalysisLabel` will be set to an error message and the background color will be set to `ErrorBrush`.