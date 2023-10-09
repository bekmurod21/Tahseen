using Tahseen.Domain.Commons;
using Tahseen.Domain.Enums;

namespace Tahseen.Domain.Entities.Feedback;

public class WishList:Auditable
{
    public long UserId { get; set; }
    public long BookId { get; set; }
    public DateTime DataAdded { get; set; }
    public WishListStatus Status { get; set; }
}