namespace TaleLearnCode.RandomContent.Quotes.Extensions;

public static class QuoteRequestExtensions
{
	public static Quote ToQuote(this QuoteRequest request)
		=> new()
		{
			Content = request.Quote,
			Author = request.Author,
		};
}