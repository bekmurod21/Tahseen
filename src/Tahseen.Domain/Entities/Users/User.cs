using Tahseen.Domain.Commons;
using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Entities.Events;
using Tahseen.Domain.Entities.Feedbacks;
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
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public MembershipStatus MembershipStatus { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Roles Role { get; set; }
    public decimal FineAmount { get; set; }
    public string UserImage { get; set; }

    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<BookReviews> BookReviews { get; set; }
    public ICollection<BorrowedBook> BorrowedBooks { get; set; }
    public ICollection<CompletedBooks> CompletedBooks { get; set; }
    public ICollection<EventRegistration> EventRegistrations { get; set; }
    public ICollection<SurveyResponses> SurveyResponses { get; set; }
    public ICollection<UserMessage> UserMessages { get; set; }
    public ICollection<UserRatings> UserRatings { get; set; }
    public ICollection<Notification> Notifications { get; set; }
}