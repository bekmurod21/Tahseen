using Tahseen.Domain.Commons;
using Tahseen.Domain.Entities.Librarians;
using Tahseen.Domain.Entities.SchoolAndEducations;

namespace Tahseen.Domain.Entities.Library;
public class LibraryBranch:Auditable
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string OpeningHours { get; set; }
    public IQueryable<Librarian> Librarians { get; set; } 
    public List<Pupil> Pupils { get; set; }
}