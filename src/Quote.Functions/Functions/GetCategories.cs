
namespace TaleLearnCode.RandomContent.Quotes;

public class GetCategories(ILogger<GetCategories> logger)
{

	private readonly ILogger<GetCategories> _logger = logger;

	[Function("GetCategories")]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "categories")] HttpRequest request)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetRandomQuote));
		return new OkObjectResult(await QuoteServices.GetCategoriesAsync());
	}

}