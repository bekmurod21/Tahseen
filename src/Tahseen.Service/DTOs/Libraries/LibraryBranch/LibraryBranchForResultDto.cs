using Tahseen.Domain.Entities.Librarians;

namespace Tahseen.Service.DTOs.Libraries.LibraryBranch;

public class LibraryBranchForResultDto
{
    public long Id { get; set; } 
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string OpeningHours { get; set; }
    public IQueryable<Librarian> Librarians { get; set; }
}
