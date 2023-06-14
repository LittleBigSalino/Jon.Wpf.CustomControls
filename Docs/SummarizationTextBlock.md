

# SummarizationTextBlock

`SummarizationTextBlock` is a custom control derived from `TextBlock` in Windows Presentation Foundation (WPF) for .NET 6.0/7.0. It automatically summarizes its input text using OpenAI's GPT-3 model when the text is changed.

## Features

- Automatically summarizes input text when changed.
- Set a maximum number of words for the summary.
- Set a delay time before the summarization starts after the user stops typing.
- Uses OpenAI's GPT-3 model for summarization.

## Properties

- `TextToSummarize`: The text to be summarized.
- `MaxWords`: The maximum number of words for the summary.
- `Delay`: The delay time (in milliseconds) before summarization starts after the user stops typing.

## Usage

Here's an example of how to use the `SummarizationTextBlock` control:

```xml
<local:SummarizationTextBlock x:Name="summarizationTextBlock" MaxWords="20" Delay="1000" />
```

Then, to set the text to be summarized in your code-behind:

```csharp
summarizationTextBlock.TextToSummarize = "Your text here";
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

- The `MaxWords` property currently only works correctly for numbers up to 20. This is due to the word form of the numbers being used for the GPT-3 prompt, and the word form is currently only implemented for numbers up to 20.

## Error Handling

If an error occurs during the HTTP request or if the API returns a non-success status code, the text of the `SummarizationTextBlock` will be set to an error message.