namespace Tahseen.Service.DTOs.Books.CompletedBooks;

public class CompletedBookForUpdateDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long BookId { get; set; }
    public string Comment { get; set; }
}
