using Tahseen.Domain.Commons;
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
    public long[] BorrowedBooks { get; set; }
    public decimal FineAmount { get; set; }
    public string UserImage { get; set; }
}