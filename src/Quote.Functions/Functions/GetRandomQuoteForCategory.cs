namespace TaleLearnCode.RandomContent.Quotes;

public class GetRandomQuoteForCategory(ILogger<GetRandomQuoteForCategory> logger)
{

	private readonly ILogger<GetRandomQuoteForCategory> _logger = logger;

	[Function(nameof(GetRandomQuoteForCategory))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "random-quotes/categories/{category}")] HttpRequest request, string category)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetRandomQuoteForCategory));
		return new OkObjectResult(await QuoteServices.GetRandomQuoteForCategoryAsync(category));
	}

}