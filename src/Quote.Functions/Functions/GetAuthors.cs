namespace TaleLearnCode.RandomContent.Quotes;

public class GetAuthors(ILogger<GetAuthors> logger)
{

	private readonly ILogger<GetAuthors> _logger = logger;

	[Function(nameof(GetAuthors))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "quotes/authors/")] HttpRequest request)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetAuthors));
		return new OkObjectResult(await QuoteServices.GetAuthorsAsync());
	}

}