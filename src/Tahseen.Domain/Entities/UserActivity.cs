using Tahseen.Domain.Commons;
using Tahseen.Domain.Enums;

namespace Tahseen.Domain.Entities;

public class UserActivity:Auditable
{
    public long UserId { get; set; }
    public ActivityType ActivityType { get; set; }
    public DateTime ActivityTypeDate { get; set; }
}