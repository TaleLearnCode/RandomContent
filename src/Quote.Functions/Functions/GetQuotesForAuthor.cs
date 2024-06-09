namespace TaleLearnCode.RandomContent.Quotes;

public class GetQuotesForAuthor(ILogger<GetQuotesForAuthor> logger)
{

	private readonly ILogger<GetQuotesForAuthor> _logger = logger;

	[Function(nameof(GetQuotesForAuthor))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "quotes/authors/{author}")] HttpRequest request, string author)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetQuotesForAuthor));
		return new OkObjectResult(await QuoteServices.GetQuotesForAuthorAsync(author));
	}

}