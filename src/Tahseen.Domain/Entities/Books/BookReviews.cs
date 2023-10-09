using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Book;

public class BookReviews:Auditable
{
    public long UserId { get; set; }
    public long BookId { get; set; }
    public decimal Rating { get; set; }
}
