namespace TaleLearnCode.RandomContent.Quotes;

public class GetRandomQuoteForAuthor(ILogger<GetRandomQuoteForAuthor> logger)
{

	private readonly ILogger<GetRandomQuoteForAuthor> _logger = logger;

	[Function(nameof(GetRandomQuoteForAuthor))]
	public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "random-quotes/authors/{author}")] HttpRequest request, string author)
	{
		_logger.LogInformation("C# HTTP function triggered: {functionName}.", nameof(GetRandomQuoteForAuthor));
		return new OkObjectResult(await QuoteServices.GetRandomQuoteForAuthorAsync(author));
	}

}