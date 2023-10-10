using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Feedback;

public class UserRatings:Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long BooksCompleted { get; set; }
    public decimal Rating { get; set; }
}