using Tahseen.Domain.Enums;

namespace Tahseen.Service.DTOs.Notifications;

public class NotificationForResultDto
{
    public long UserId { get; set; }
    public string Message { get; set; }
    public DateTime NotificationSentTime { get; set; }
    public NotificationStatus NotificationStatus { get; set; }
}
