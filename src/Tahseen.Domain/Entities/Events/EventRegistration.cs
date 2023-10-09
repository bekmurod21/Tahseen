using Tahseen.Domain.Enums.Events;

namespace Tahseen.Domain.Entities.Events;

public class EventRegistration
{
    public long UserId { get; set; }
    public User User { get; set; }

    public long EventId { get; set; }
    public Event Event { get; set; }

    public DateTime RegistrationDate { get; set; }

    public EventRegistrationStatus Status { get; set; }
}
