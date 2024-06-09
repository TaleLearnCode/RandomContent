namespace TaleLearnCode.RandomContent.Facts;

public static class FactServices
{

	public static async Task<FactResponse?> GetFactAsync(int id)
	{
		Fact? fact = await RetrieveFactAsync(id);
		return fact.ToResponse();
	}

	public static async Task<FactResponseList> GetFactsAsync(int pageIndex = 1, int pageSize = 10)
	{
		FactContext context = new();
		int totalCount = await context.Facts.CountAsync();
		int pageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
		List<Fact> facts = await context.Facts
			.Include(x => x.FactCategories)
				.ThenInclude(x => x.Category)
			.Skip((pageIndex - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
		return facts.ToResponse(totalCount, pageSize, pageCount, pageIndex);
	}

	public static async Task<int> CreateFactAsync(FactRequest request)
	{
		FactContext context = new();
		Fact factContent = request.ToFact();
		context.Facts.Add(factContent);
		await context.SaveChangesAsync();
		await AddCategoriesToFactAsync(context, factContent, request.Categories);
		return factContent.FactId;
	}

	public static async Task UpdateFactAsync(int id, FactRequest request)
	{
		FactContext context = new();
		Fact fact = await RetrieveFactAsync(id, context)
			?? throw new ArgumentOutOfRangeException(nameof(id), id, "Fact not found");
		fact.Content = request.Fact;
		context.Facts.Update(fact);
		await context.SaveChangesAsync();
		await RemoveCategoriesAsync(context, fact);
		await AddCategoriesToFactAsync(context, fact, request.Categories);
	}

	public static async Task DeleteFactAsync(int id)
	{
		FactContext context = new();
		Fact fact = await context.Facts
			.Include(x => x.FactCategories)
			.FirstOrDefaultAsync(x => x.FactId == id)
			?? throw new ArgumentOutOfRangeException(nameof(id), id, "Fact not found");
		await RemoveCategoriesAsync(context, fact);
		context.Facts.Remove(fact);
		await context.SaveChangesAsync();
	}

	public static async Task<List<string>> GetCategoriesAsync()
	{
		FactContext context = new();
		return await context.Categories
			.Where(x => x.CategoryTypeId == StaticValues.QuoteCategoryTypeId)
			.Select(x => x.CategoryName).ToListAsync();
	}

	public static async Task<FactResponseList> GetFactsForCategory(string category, int pageIndex = 1, int pageSize = 10)
	{
		FactContext context = new();
		int totalCount = await context.Facts
			.Include(x => x.FactCategories)
				.ThenInclude(x => x.Category)
			.Where(x => x.FactCategories.Any(x => x.Category.CategoryName == category))
			.CountAsync();
		int pageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
		List<Fact> facts = await context.Facts
			.Include(x => x.FactCategories)
				.ThenInclude(x => x.Category)
			.Where(x => x.FactCategories.Any(x => x.Category.CategoryName == category))
			.Skip((pageIndex - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
		return facts.ToResponse(totalCount, pageSize, pageCount, pageIndex);
	}

	private static async Task<Fact?> RetrieveFactAsync(int id, FactContext? context = null)
	{
		context ??= new();
		return await context.Facts
			.Include(x => x.FactCategories)
				.ThenInclude(x => x.Category)
			.FirstOrDefaultAsync(x => x.FactId == id);
	}

	private static async Task AddCategoriesToFactAsync(FactContext context, Fact fact, List<string> categories)
	{
		foreach (string category in categories)
		{
			Category? factCategory = await context.Categories.FirstOrDefaultAsync(x => x.CategoryName == category);
			if (factCategory is null)
			{
				factCategory = new Category
				{
					CategoryName = category,
					CategoryTypeId = StaticValues.QuoteCategoryTypeId
				};
				context.Categories.Add(factCategory);
				await context.SaveChangesAsync();
			}
			context.FactCategories.Add(new FactCategory
			{
				FactId = fact.FactId,
				CategoryId = factCategory.CategoryId
			});
		}
		await context.SaveChangesAsync();
	}

	private static async Task RemoveCategoriesAsync(FactContext context, Fact fact)
	{
		List<Category> categories = fact.FactCategories.Select(x => x.Category).ToList();
		context.RemoveRange(fact.FactCategories);
		await context.SaveChangesAsync();
		foreach (Category category in categories)
			if ((await context.FactCategories.CountAsync(x => x.CategoryId == category.CategoryId)) == 0)
				context.Categories.Remove(category);
		await context.SaveChangesAsync();
	}

}