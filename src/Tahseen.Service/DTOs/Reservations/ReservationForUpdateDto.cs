using Tahseen.Domain.Entities;
using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Enums;

namespace Tahseen.Service.DTOs.Reservations;

public class ReservationForUpdateDto
{
    public User User { get; set; }
    public Book Book { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
}