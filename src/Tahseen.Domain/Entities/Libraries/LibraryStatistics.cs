using Tahseen.Domain.Commons;
using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Entities.Events;

namespace Tahseen.Domain.Entities.Library;

public class LibraryStatistics : Auditable
{
    public ICollection<User> TotalUsers { get; set;}
    public ICollection<Book> TotalBooks { get; set; }
    public ICollection<BookBorrowsHistory> TotalBorrows { get; set; }
    public ICollection<Event> TotalEvents { get; set; }
}