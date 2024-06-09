namespace TaleLearnCode.RandomContent.Quotes;

public class QuoteServices
{

	public static async Task<QuoteResponse?> GetQuoteAsync(int id)
	{

		using QuoteContext context = new();
		Quote? quote = await context.Quotes
			.Include(x => x.QuoteCategories)
				.ThenInclude(x => x.Category)
			.FirstOrDefaultAsync(x => x.QuoteId == id);
		return quote.ToResponse();
	}

	public static async Task<QuoteResponseList> GetQuotesAsync(int pageIndex = 1, int pageSize = 10)
	{
		using QuoteContext context = new();
		int totalCount = await context.Quotes.CountAsync();
		int pageCount = (totalCount > 0) ? (int)Math.Ceiling(totalCount / (double)pageSize) : 0;
		List<Quote> quotes = await context.Quotes
			.Include(x => x.QuoteCategories)
				.ThenInclude(x => x.Category)
			.Skip((pageIndex - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
		return quotes.ToResponse(totalCount, pageSize, pageCount, pageIndex);
	}

	public static async Task<QuoteResponse?> GetRandomQuoteAsync()
	{
		using QuoteContext context = new();
		int count = await context.Quotes.CountAsync();
		if (count == 0)
			return null;
		int randomId = new Random().Next(1, count + 1);
		return await GetQuoteAsync(randomId);
	}

	public static async Task<int> CreateQuoteAsync(QuoteRequest quoteRequest)
	{
		QuoteContext context = new();
		Quote quote = quoteRequest.ToQuote();
		context.Quotes.Add(quote);
		await context.SaveChangesAsync();
		await AddCategoriesToQuoteAsync(context, quote, quoteRequest.Categories);
		return quote.QuoteId;
	}

	public static async Task<List<string>> GetCategoriesAsync()
	{
		QuoteContext context = new();
		return await context.Categories.Where(x => x.CategoryTypeId == StaticValues.QuoteCategoryTypeId).Select(x => x.CategoryName).ToListAsync();
	}

	public static async Task<QuoteResponseList> GetQuotesForCategoryAsync(string category, int pageIndex = 1, int pageSize = 10)
	{
		QuoteContext context = new();
		int totalCount = await context.Quotes
			.Include(x => x.QuoteCategories)
				.ThenInclude(x => x.Category)
			.Where(x => x.QuoteCategories.Any(x => x.Category.CategoryName == category))
			.CountAsync();
		int pageCount = (totalCount > 0) ? (int)Math.Ceiling(totalCount / (double)pageSize) : 0;
		List<Quote> quotes = await context.Quotes
			.Include(x => x.QuoteCategories)
				.ThenInclude(x => x.Category)
			.Where(x => x.QuoteCategories.Any(x => x.Category.CategoryName == category))
			.Skip((pageIndex - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
		return quotes.ToResponse(totalCount, pageSize, pageIndex, pageCount);
	}

	public static async Task<QuoteResponse?> GetRandomQuoteForCategoryAsync(string category)
	{
		using QuoteContext context = new();
		int count = await context.Quotes
			.Where(x => x.QuoteCategories.Any(x => x.Category.CategoryName == category))
			.CountAsync();
		if (count == 0)
			return null;
		int randomId = new Random().Next(1, count + 1);
		return await context.Quotes
			.Include(x => x.QuoteCategories)
				.ThenInclude(x => x.Category)
			.Where(x => x.QuoteCategories.Any(x => x.Category.CategoryName == category))
			.Skip(randomId - 1)
			.Take(1)
			.Select(x => x.ToResponse())
			.FirstOrDefaultAsync();
	}

	public static async Task<List<string>> GetAuthorsAsync()
	{
		QuoteContext context = new();
		return await context.Quotes.Select(x => x.Author).Distinct().ToListAsync();
	}

	public static async Task<QuoteResponseList> GetQuotesForAuthorAsync(string author, int pageIndex = 1, int pageSize = 10)
	{
		QuoteContext context = new();
		int totalCount = await context.Quotes
			.Include(x => x.QuoteCategories)
				.ThenInclude(x => x.Category)
			.Where(x => x.Author == author)
			.CountAsync();
		int pageCount = (totalCount > 0) ? (int)Math.Ceiling(totalCount / (double)pageSize) : 0;
		List<Quote> quotes = await context.Quotes
			.Where(x => x.Author == author)
			.Skip((pageIndex - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
		return quotes.ToResponse(totalCount, pageSize, pageIndex, pageCount);
	}

	public static async Task<QuoteResponse?> GetRandomQuoteForAuthorAsync(string author)
	{
		using QuoteContext context = new();
		int count = await context.Quotes
			.Where(x => x.Author == author)
			.CountAsync();
		if (count == 0)
			return null;
		int randomId = new Random().Next(1, count + 1);
		return await context.Quotes
			.Include(x => x.QuoteCategories)
				.ThenInclude(x => x.Category)
			.Where(x => x.Author == author)
			.Skip(randomId - 1)
			.Take(1)
			.Select(x => x.ToResponse())
			.FirstOrDefaultAsync();
	}

	public static async Task UpdateQuoteAsync(int id, QuoteRequest quoteRequest)
	{
		QuoteContext context = new();
		Quote? quote = await RetrieveQuoteAsync(id, context)
			?? throw new ArgumentOutOfRangeException(nameof(id), "Quote not found");
		quote.Content = quoteRequest.Quote;
		quote.Author = quoteRequest.Author;
		context.Quotes.Update(quote);
		await context.SaveChangesAsync();
		await RemoveCategoriesAsync(context, quote);
		await AddCategoriesToQuoteAsync(context, quote, quoteRequest.Categories);
	}

	public static async Task DeleteQuoteAsync(int id)
	{
		QuoteContext context = new();
		Quote? quote = await RetrieveQuoteAsync(id, context)
			?? throw new ArgumentOutOfRangeException(nameof(id), "Quote not found");
		await RemoveCategoriesAsync(context, quote);
		context.Quotes.Remove(quote);
		await context.SaveChangesAsync();
	}

	private static async Task AddCategoriesToQuoteAsync(QuoteContext context, Quote quote, IEnumerable<string> categoryNames)
	{
		foreach (string categoryName in categoryNames)
		{
			Category? category = await context.Categories
				.FirstOrDefaultAsync(x => x.CategoryName == categoryName);
			if (category is null)
			{
				category = new()
				{
					CategoryName = categoryName,
					CategoryTypeId = StaticValues.QuoteCategoryTypeId
				};
				context.Categories.Add(category);
			}
			quote.QuoteCategories.Add(new() { Category = category });
		}
		await context.SaveChangesAsync();
	}

	private static async Task RemoveCategoriesAsync(QuoteContext context, Quote quote)
	{
		List<Category> categories = quote.QuoteCategories.Select(x => x.Category).ToList();
		context.RemoveRange(quote.QuoteCategories);
		await context.SaveChangesAsync();
		foreach (Category category in categories)
			if ((await context.QuoteCategories.CountAsync(x => x.CategoryId == category.CategoryId)) == 0)
				context.Categories.Remove(category);
		await context.SaveChangesAsync();
	}

	private static async Task<Quote?> RetrieveQuoteAsync(int id, QuoteContext? context = null)
	{
		context ??= new();
		return await context.Quotes
			.Include(x => x.QuoteCategories)
				.ThenInclude(x => x.Category)
			.FirstOrDefaultAsync(x => x.QuoteId == id);
	}

}