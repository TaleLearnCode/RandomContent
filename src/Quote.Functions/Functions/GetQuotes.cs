namespace TaleLearnCode.RandomContent.Quotes;

public class GetQuotes(ILogger<GetQuotes> logger)
{

	private readonly ILogger<GetQuotes> _logger = logger;

	[Function(nameof(GetQuotes))]
	public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "quotes")] HttpRequest req)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetQuotes));
		return new OkObjectResult(await QuoteServices.GetQuotesAsync());
	}

}