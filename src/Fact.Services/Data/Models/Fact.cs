#nullable disable

namespace TaleLearnCode.RandomContent.Facts.Data.Models;

/// <summary>
/// A random fact about something interesting.
/// </summary>
public partial class Fact
{
	/// <summary>
	/// The identifier of the fact record.
	/// </summary>
	public int FactId { get; set; }

	/// <summary>
	/// The content of the fact.
	/// </summary>
	public string Content { get; set; }

	public virtual ICollection<FactCategory> FactCategories { get; set; } = [];
}