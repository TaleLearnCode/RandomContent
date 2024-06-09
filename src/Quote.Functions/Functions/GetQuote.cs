namespace TaleLearnCode.RandomContent.Quotes;

public class GetQuote(ILogger<GetQuote> logger)
{

	private readonly ILogger<GetQuote> _logger = logger;

	[Function(nameof(GetQuote))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "quotes/{id}")] HttpRequest req, int id)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetQuote));
		QuoteResponse? response = await QuoteServices.GetQuoteAsync(id);
		return response is null
			? new NotFoundObjectResult($"Quote with ID {id} not found.")
			: new OkObjectResult(await QuoteServices.GetQuoteAsync(id));
	}

}