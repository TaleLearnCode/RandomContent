namespace TaleLearnCode.RandomContent.Facts.Functions;

public class GetCategories
{
	private readonly ILogger<GetCategories> _logger;

	public GetCategories(ILogger<GetCategories> logger)
	{
		_logger = logger;
	}

	[Function(nameof(GetCategories))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "facts/categories")] HttpRequest request)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetCategories));
		return new OkObjectResult(await FactServices.GetCategoriesAsync());
	}
}