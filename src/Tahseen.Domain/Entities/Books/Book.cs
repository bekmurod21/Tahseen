using Tahseen.Domain.Enums;
using Tahseen.Domain.Commons;
using System.Text.Json.Serialization;
using Tahseen.Domain.Entities.Library;
using Tahseen.Domain.Entities.Feedbacks;
using Tahseen.Domain.Entities.Reservations;

namespace Tahseen.Domain.Entities.Books;

public class Book : Auditable
{
    public string Title { get; set; }
    public Language Language { get; set; }
    public long TotalCopies { get; set; }
    public long AvailableCopies { get; set; }
    public decimal Rating { get; set; }
    public long Reviews { get; set; }
    public BookFormat BookFormat { get; set; }
    public string ShelfLocation { get; set; }
    public BookCondition Condition { get; set; }
    public string BookImage { get; set;}

    public long AuthorId { get; set; }
    public Author Author { get; set; }

    public long GenreId { get; set; }
    public Genre Genre { get; set; }

    public long LibraryId { get; set; }
    public LibraryBranch LibraryBranch { get; set; }

    public long PublisherId { get; set; }
    public Publisher Publisher { get; set; }

    public BookReviews BookReviews { get; set; } 

    [JsonIgnore]
    public IEnumerable<Reservation> Reservations { get; set; }

    public IEnumerable<CompletedBooks> CompletedBooks { get; set;}
}
