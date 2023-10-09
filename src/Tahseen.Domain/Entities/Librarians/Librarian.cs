using System.Data;
using System;
using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Librarian;

public class Librarian:Auditable
{
    public long LibraryCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string DateOfBirth { get; set; }
    //public Url Photo { get; set; }
   // public Role Roles { get; set; }

}