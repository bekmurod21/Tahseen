using Tahseen.Domain.Entities;
using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Enums;

namespace Tahseen.Service.DTOs.Reservitions;

public class ReservationForCreationDto
{
    public User User { get; set; }
    public Book Book { get; set; }
    public ReservationStatus ReservationStatus { get; set; } 
}