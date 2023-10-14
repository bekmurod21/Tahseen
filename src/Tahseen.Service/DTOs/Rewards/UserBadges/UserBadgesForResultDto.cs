using Tahseen.Domain.Entities;

namespace Tahseen.Service.DTOs.Rewards.UserBadges;

public class UserBadgesForResultDto
{
    public long UserId {get; set;}
    public long BookId {get; set;}
    public string Description { get; set; }
}