using Tahseen.Service.DTOs.Users.BorrowedBookCart;

namespace Tahseen.Service.Interfaces.IUsersService
{
    public interface IBorrowBookCartService
    {
        public Task<BorrowedBookCartForResultDto> AddAsync(BorrowedBookCartForCreationDto dto);
        public Task<bool> RemoveAsync(long Id);
        public Task<IQueryable<BorrowedBookCartForResultDto>> RetrieveAllAsync();
        public Task<BorrowedBookCartForResultDto> RetrieveByIdAsync(long Id); 
    }
}
