using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Library;

public class LibraryStatistics:Auditable
{
    public long TotalUsers { get; set;}
    public long TotalBooks { get; set; }
    public long TotalBorrows { get; set; }
    public long TotalEvents { get; set; }
}