namespace TaleLearnCode.RandomContent.Quotes;

public class DeleteQuote(ILogger<DeleteQuote> logger)
{

	private readonly ILogger<DeleteQuote> _logger = logger;

	[Function(nameof(DeleteQuote))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "quotes/{id}")] HttpRequest req, int id)
	{
		try
		{
			_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(DeleteQuote));
			await QuoteServices.DeleteQuoteAsync(id);
			return new OkResult();
		}
		catch (ArgumentOutOfRangeException ex)
		{
			_logger.LogError(ex, "Error deleting quote: {errorMessage}", ex.Message);
			return new NotFoundResult();
		}
	}

}