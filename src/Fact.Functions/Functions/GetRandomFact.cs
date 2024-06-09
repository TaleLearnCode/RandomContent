namespace TaleLearnCode.RandomContent.Facts;

public class GetRandomFact(ILogger<GetRandomFact> logger)
{

	private readonly ILogger<GetRandomFact> _logger = logger;

	[Function(nameof(GetRandomFact))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "random-facts")] HttpRequest request)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetRandomFact));
		return new OkObjectResult(await FactServices.GetRandomFactAsync());
	}

}