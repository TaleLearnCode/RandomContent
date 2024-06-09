namespace TaleLearnCode.RandomContent.Facts.Extensions;

internal static class FactContentExtensions
{

	internal static FactResponse? ToResponse(this Fact? fact)
		=> fact is null
			? null
			: new FactResponse
			{
				Id = fact.FactId,
				Fact = fact.Content,
				Categories = fact.FactCategories?.Select(x => x.Category.CategoryName).ToList() ?? []
			};

	internal static FactResponseList ToResponse(this IEnumerable<Fact> facts, int totalCount, int pageSize, int pageCount, int pageNumber)
	=> new()
	{
		TotalCount = totalCount,
		PageSize = pageSize,
		PageNumber = pageNumber,
		PageCount = pageCount,
		Facts = facts.Select(x => x.ToResponse()).ToList()
	};

}