namespace TaleLearnCode.RandomContent.Facts;

public class GetFact(ILogger<GetFact> logger)
{

	private readonly ILogger<GetFact> _logger = logger;

	[Function(nameof(GetFact))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "facts/{id}")] HttpRequest req, int id)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetFact));
		FactResponse? response = await FactServices.GetFactAsync(id);
		return response is null
			? new NotFoundObjectResult($"Fact with ID {id} not found.")
			: new OkObjectResult(await FactServices.GetFactAsync(id));
	}

}