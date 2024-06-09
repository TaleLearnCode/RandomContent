namespace TaleLearnCode.RandomContent.Quotes;

public class AddQuote(ILogger<AddQuote> logger)
{

	private readonly ILogger<AddQuote> _logger = logger;

	[Function(nameof(AddQuote))]
	public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "quotes")] HttpRequest request, [FromBody] QuoteRequest quoteRequest)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetQuotes));
		Task<int> newQuoteId = QuoteServices.CreateQuoteAsync(quoteRequest);
		return new CreatedAtRouteResult("GetQuote", new { id = newQuoteId }, newQuoteId);
	}

}