using Tahseen.Domain.Entities;

namespace Tahseen.Service.DTOs.Rewards.UserBadges;

public class UserBadgesForUpdateDto
{
    public User User { get; set; }
    public Domain.Entities.Rewards.Badge Badge { get; set; }
    public string Description { get; set; }
}