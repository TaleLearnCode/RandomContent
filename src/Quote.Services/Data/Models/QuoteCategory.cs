#nullable disable

namespace TaleLearnCode.RandomContent.Quotes.Data.Models;

/// <summary>
/// Represents the relationship between a quote and a category.
/// </summary>
public partial class QuoteCategory
{
	/// <summary>
	/// The identifier of the quote category record.
	/// </summary>
	public int QuoteCategoryId { get; set; }

	/// <summary>
	/// The identifier of the quote record.
	/// </summary>
	public int QuoteId { get; set; }

	/// <summary>
	/// The identifier of the category record.
	/// </summary>
	public int CategoryId { get; set; }

	public virtual Category Category { get; set; }

	public virtual Quote Quote { get; set; }
}