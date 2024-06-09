#nullable disable

namespace TaleLearnCode.RandomContent.Quotes.Data.Models;

/// <summary>
/// A quote from someone famous or interesting.
/// </summary>
public partial class Quote
{
	/// <summary>
	/// The identifier of the quote record.
	/// </summary>
	public int QuoteId { get; set; }

	/// <summary>
	/// The author of the quote.
	/// </summary>
	public string Author { get; set; }

	/// <summary>
	/// The content of the quote.
	/// </summary>
	public string Content { get; set; }

	public virtual ICollection<QuoteCategory> QuoteCategories { get; set; } = new List<QuoteCategory>();
}