using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Books;

public class BookBorrowsHistory:Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long BookId { get; set; }
    public Book Book { get; set; }
}
