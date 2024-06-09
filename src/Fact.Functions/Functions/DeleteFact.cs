namespace TaleLearnCode.RandomContent.Facts;

public class DeleteFact(ILogger<DeleteFact> logger)
{

	private readonly ILogger<DeleteFact> _logger = logger;

	[Function(nameof(DeleteFact))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "facts/{id}")] HttpRequest req, int id)
	{
		try
		{
			_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(DeleteFact));
			await FactServices.DeleteFactAsync(id);
			return new OkResult();
		}
		catch (ArgumentOutOfRangeException ex)
		{
			_logger.LogError(ex, "Error deleting fact: {errorMessage}", ex.Message);
			return new NotFoundResult();
		}
	}

}