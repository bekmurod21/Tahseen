using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Tahseen.Domain.Commons;
using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Entities.Events;
using Tahseen.Domain.Entities.Feedbacks;
using Tahseen.Domain.Entities.Library;
using Tahseen.Domain.Entities.Notifications;
using Tahseen.Domain.Entities.Reservations;
using Tahseen.Domain.Enums;


namespace Tahseen.Domain.Entities;

public class User:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public MembershipStatus MembershipStatus { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Roles Role { get; set; }
    public decimal? FineAmount { get; set; }
    public string UserImage { get; set; }
    public long? LibraryId { get; set; }
    public LibraryBranch LibraryBranch { get; set; }

}