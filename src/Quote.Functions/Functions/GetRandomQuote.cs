
namespace TaleLearnCode.RandomContent.Quotes;

public class GetRandomQuote(ILogger<GetRandomQuote> logger)
{

	private readonly ILogger<GetRandomQuote> _logger = logger;

	[Function(nameof(GetRandomQuote))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "random-quotes")] HttpRequest request)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetRandomQuote));
		return new OkObjectResult(await QuoteServices.GetRandomQuoteAsync());
	}
}