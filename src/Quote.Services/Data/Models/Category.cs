#nullable disable

namespace TaleLearnCode.RandomContent.Facts.Data.Models;

/// <summary>
/// Represents a category of random content to allow for better filtering..
/// </summary>
public partial class Category
{
	/// <summary>
	/// The identifier of the category record.
	/// </summary>
	public int CategoryId { get; set; }

	/// <summary>
	/// The identifier of the type of category being represented.
	/// </summary>
	public int CategoryTypeId { get; set; }

	/// <summary>
	/// The name of the category.
	/// </summary>
	public string CategoryName { get; set; }

	public virtual ICollection<QuoteCategory> QuoteCategories { get; set; } = new List<QuoteCategory>();
}