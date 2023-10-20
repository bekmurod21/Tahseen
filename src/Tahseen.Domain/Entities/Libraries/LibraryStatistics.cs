using Tahseen.Domain.Commons;
using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Entities.Events;

namespace Tahseen.Domain.Entities.Library;

public class LibraryStatistics : Auditable
{
    public IQueryable<User> TotalUsers { get; set;}
    public IQueryable<Book> TotalBooks { get; set; }
    public IQueryable<BorrowedBook> TotalBorrows { get; set; }
    public IQueryable<Event> TotalEvents { get; set; }
}