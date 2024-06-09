namespace TaleLearnCode.RandomContent.Facts;

public class AddFact(ILogger<AddFact> logger)
{

	private readonly ILogger<AddFact> _logger = logger;

	[Function(nameof(AddFact))]
	public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "facts")] HttpRequest request, [FromBody] FactRequest factRequest)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetFacts));
		Task<int> newFactId = FactServices.CreateFactAsync(factRequest);
		return new CreatedAtRouteResult("GetFact", new { id = newFactId }, newFactId);
	}

}