using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Library;
public class LibraryBranch:Auditable
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public long[] Librarians { get; set; }
    public string OpeningHours { get; set; }
}