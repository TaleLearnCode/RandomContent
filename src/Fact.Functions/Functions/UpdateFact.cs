namespace TaleLearnCode.RandomContent.Facts;

public class UpdateFact(ILogger<UpdateFact> logger)
{

	private readonly ILogger<UpdateFact> _logger = logger;

	[Function(nameof(UpdateFact))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "put", Route = "facts/{id}")] HttpRequest req, [FromBody] FactRequest factRequest, int id)
	{
		try
		{
			_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(UpdateFact));
			await FactServices.UpdateFactAsync(id, factRequest);
			return new NoContentResult();
		}
		catch (ArgumentOutOfRangeException ex)
		{
			_logger.LogError(ex, "Error updating fact: {errorMessage}", ex.Message);
			return new NotFoundResult();
		}
	}

}