namespace TaleLearnCode.RandomContent.Facts;

public class GetFacts(ILogger<GetFacts> logger)
{

	private readonly ILogger<GetFacts> _logger = logger;

	[Function(nameof(GetFacts))]
	public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "facts")] HttpRequest req)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetFacts));
		return new OkObjectResult(await FactServices.GetFactsAsync());
	}

}