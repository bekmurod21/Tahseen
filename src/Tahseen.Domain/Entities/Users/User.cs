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

    public IQueryable<Reservation> Reservations { get; set; }
    public IQueryable<BookReviews> BookReviews { get; set; }
    public IQueryable<BorrowedBook> BorrowedBooks { get; set; }
    public IQueryable<CompletedBooks> CompletedBooks { get; set; }
    public IQueryable<EventRegistration> EventRegistrations { get; set; }
    public IQueryable<SurveyResponses> SurveyResponses { get; set; }
    public IQueryable<UserMessage> UserMessages { get; set; }
    public IQueryable<UserRatings> UserRatings { get; set; }
    public IQueryable<Notification> Notifications { get; set; }
}