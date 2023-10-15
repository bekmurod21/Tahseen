using Tahseen.Domain.Commons;
using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Entities.Events;

namespace Tahseen.Domain.Entities.Library;

public class LibraryStatistics : Auditable
{
    //Userdagi getall shu vazifani bajaradi
    public ICollection<User> TotalUsers { get; set;}
    //Bookdagi getall shu vazifani bajaradi
    public ICollection<Book> TotalBooks { get; set; }
    //Eventdagi getall shu vazifani bajaradi
    public ICollection<Event> TotalEvents { get; set; }
}