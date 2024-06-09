namespace TaleLearnCode.RandomContent.Quotes;

public class UpdateQuote(ILogger<UpdateQuote> logger)
{

	private readonly ILogger<UpdateQuote> _logger = logger;

	[Function(nameof(UpdateQuote))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "put", Route = "quotes/{id}")] HttpRequest req, [FromBody] QuoteRequest quoteRequest, int id)
	{
		try
		{
			_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(UpdateQuote));
			await QuoteServices.UpdateQuoteAsync(id, quoteRequest);
			return new NoContentResult();
		}
		catch (ArgumentOutOfRangeException ex)
		{
			_logger.LogError(ex, "Error updating quote: {errorMessage}", ex.Message);
			return new NotFoundResult();
		}
	}

}