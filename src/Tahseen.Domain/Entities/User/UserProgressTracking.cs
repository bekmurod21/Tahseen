using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities;

public class UserProgressTracking:Auditable
{
    public long UserId { get; set; }
    public long BookId { get; set; }
    public long CurrentPage { get; set; }
    public long TotalPages { get; set; }
}