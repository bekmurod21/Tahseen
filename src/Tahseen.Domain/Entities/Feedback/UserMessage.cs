using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Feedback;

public class UserMessage:Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public string Messages { get; set; }
}