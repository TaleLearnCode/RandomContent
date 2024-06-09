
namespace TaleLearnCode.RandomContent.Quotes;

public class GetQuotesForCategory(ILogger<GetQuotesForCategory> logger)
{

	private readonly ILogger<GetQuotesForCategory> _logger = logger;

	[Function(nameof(GetQuotesForCategory))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "quotes/categories/{category}")] HttpRequest request, string category)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetQuotesForCategory));
		return new OkObjectResult(await QuoteServices.GetQuotesForCategoryAsync(category));
	}

}