using Tahseen.Service.DTOs.Books.Book;
using Tahseen.Service.DTOs.Books.BookReviews;

namespace Tahseen.Service.Interfaces.IBookServices;

public interface IBookService
{
    Task<BookForResultDto> AddAsync(BookForCreationDto dto);
    Task<BookForResultDto> ModifyAsync(BookForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<BookForResultDto> RetrieveByIdAsync(long id);
    IQueryable<BookForResultDto> GetAll();
}