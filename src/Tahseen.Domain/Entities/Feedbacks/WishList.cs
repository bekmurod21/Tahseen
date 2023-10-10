using Tahseen.Domain.Commons;
using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Enums;

namespace Tahseen.Domain.Entities.Feedback;

public class WishList:Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long BookId { get; set; }
    public Book Book { get; set; }
    public WishListStatus Status { get; set; }
}