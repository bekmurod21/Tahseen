using Tahseen.Service.DTOs.Books.BookReviews;

namespace Tahseen.Service.Interfaces.IBookServices;
public interface IBookReviewService
{
    Task<BookReviewForResultDto> AddAsync(BookReviewForCreationDto dto);
    Task<BookReviewForResultDto> ModifyAsync(BookReviewForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<BookReviewForResultDto> RetrieveByIdAsync(long id);
    IQueryable<BookReviewForResultDto> RetrieveAll();
}
