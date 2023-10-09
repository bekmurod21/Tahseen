using Tahseen.Domain.Enums;

namespace Tahseen.Domain.Entities.Reservations;

public class Reservation
{
    public long UserId { get; set; }
    public long BookId { get; set; }
    public DateTime ReservationDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
}