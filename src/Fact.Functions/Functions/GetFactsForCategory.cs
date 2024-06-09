namespace TaleLearnCode.RandomContent.Facts;

public class GetFactsForCategory(ILogger<GetFactsForCategory> logger)
{

	private readonly ILogger<GetFactsForCategory> _logger = logger;

	[Function(nameof(GetFactsForCategory))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "facts/categories/{category}")] HttpRequest request, string category)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetFactsForCategory));
		return new OkObjectResult(await FactServices.GetFactsForCategoryAsync(category));
	}

}