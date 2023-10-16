using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Entities.Library;
using Tahseen.Domain.Enums;

namespace Tahseen.Service.DTOs.Books.Book;

public class BookForUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public Domain.Entities.Books.Author Author { get; set; }
    public Domain.Entities.Books.Genre Genre { get; set; }
    public Language Language { get; set; }
    public long TotalCopies { get; set; }
    public long AvailableCopies { get; set; }
    public BookFormat BookFormat { get; set; }
    public string ShelfLocation { get; set; }
    public BookCondition Condition { get; set; }
    public string BookImage { get; set; }
    public LibraryBranch LibraryBranch { get; set; }
    public Publisher Publisher { get; set; }
}