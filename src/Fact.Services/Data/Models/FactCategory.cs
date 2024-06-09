#nullable disable

namespace TaleLearnCode.RandomContent.Facts.Data.Models;

/// <summary>
/// Represents the relationship between a fact and a category.
/// </summary>
public partial class FactCategory
{
	/// <summary>
	/// The identifier of the fact category record.
	/// </summary>
	public int FactCategoryId { get; set; }

	/// <summary>
	/// The identifier of the fact record.
	/// </summary>
	public int FactId { get; set; }

	/// <summary>
	/// The identifier of the category record.
	/// </summary>
	public int CategoryId { get; set; }

	public virtual Category Category { get; set; }

	public virtual Fact Fact { get; set; }
}