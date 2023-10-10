using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities;

public class UserMessages:Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public string Message { get; set; }
}