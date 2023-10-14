using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities;
using Tahseen.Domain.Entities.Books;
using Tahseen.Service.DTOs.Users.BorrowedBook;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Interfaces.IUsersService;

namespace Tahseen.Service.Services.Users
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly IRepository<BorrowedBook> _userRepository;
        private readonly IMapper _mapper;
        public BorrowedBookService(IRepository<BorrowedBook> userRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }
        public async Task<BorrowedBookForResultDto> AddAsync(BorrowedBookForCreationDto dto)
        {
            var data = this._mapper.Map<BorrowedBook>(dto);
            var result = await this._userRepository.CreateAsync(data);
            return this._mapper.Map<BorrowedBookForResultDto>(result);
        }

        public async Task<BorrowedBookForResultDto> ModifyAsync(long Id, BorrowedBookForUpdateDto dto)
        {
            var data = await this._userRepository.SelectAll().FirstOrDefaultAsync(e => e.Id == Id);
            if (data is not null && data.IsDeleted == false)
            {
                var MappedData = this._mapper.Map(dto, data);
                MappedData.UpdatedAt = DateTime.UtcNow;
                var result = await _userRepository.UpdateAsync(MappedData);
                return this._mapper.Map<BorrowedBookForResultDto>(result);
            }
            throw new TahseenException(404, "Borrowed book is not found");
        }

        public async Task<bool> RemoveAsync(long Id)
        {
            return await this._userRepository.DeleteAsync(Id);
        }

        public ICollection<BorrowedBookForResultDto> RetrieveAll()
        {
            var result = this._userRepository.SelectAll().Where(t => t.IsDeleted == false);
            return this._mapper.Map<ICollection<BorrowedBookForResultDto>>(result);
        }

        public async Task<BorrowedBookForResultDto> RetrieveByIdAsync(long Id)
        {
            var data = await this._userRepository.SelectByIdAsync(Id);
            if(data != null && data.IsDeleted == false)
            {
                return this._mapper.Map<BorrowedBookForResultDto>(data);
            }
            throw new TahseenException(404, "Borrowed book is not found");
        }
    }
}
