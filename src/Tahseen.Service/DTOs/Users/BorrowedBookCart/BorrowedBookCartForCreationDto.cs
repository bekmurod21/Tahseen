using Tahseen.Service.DTOs.Users.BorrowedBook;

namespace Tahseen.Service.DTOs.Users.BorrowedBookCart
{
    public class BorrowedBookCartForCreationDto
    {
        public long UserId { get; set; }
        public IEnumerable<BorrowedBookCartForResultDto> BorrowedBook { get; set; }

    }
}
