namespace TaleLearnCode.RandomContent.Facts;

public class GetRandomFactForCategory
{
	private readonly ILogger<GetRandomFactForCategory> _logger;

	public GetRandomFactForCategory(ILogger<GetRandomFactForCategory> logger)
	{
		_logger = logger;
	}

	[Function(nameof(GetRandomFactForCategory))]
	public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "/random-facts/categories/{category}")] HttpRequest request, string category)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetRandomFactForCategory));
		return new OkObjectResult(FactServices.GetRandomFactForCategoryAsync(category));
	}
}