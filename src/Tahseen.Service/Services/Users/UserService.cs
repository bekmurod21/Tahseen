using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities;
using Tahseen.Domain.Entities.Books;
using Tahseen.Service.DTOs.Users.User;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Interfaces.IUsersService;

namespace Tahseen.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }
        public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
        {
            var result = _userRepository.SelectAll().FirstOrDefault(e=> e.EmailAddress == dto.EmailAddress && e.Password == e.Password);
            if (result != null && result.IsDeleted == false)
            {
                throw new TahseenException(400, "User is exist");
            }
            var data = this._mapper.Map<User>(dto);
            var CreatedData = await this._userRepository.CreateAsync(data);
            return _mapper.Map<UserForResultDto>(CreatedData);

        }

        public async Task<UserForResultDto> ModifyAsync(long Id, UserForUpdateDto dto)
        {
            var data = await _userRepository.SelectAll().FirstOrDefaultAsync(e => e.Id == Id);
            if(data is not null && data.IsDeleted == false)
            {
                var MappedData = this._mapper.Map(dto, data);
                MappedData.UpdatedAt = DateTime.UtcNow;
                var result = await _userRepository.CreateAsync(MappedData);
                return _mapper.Map<UserForResultDto>(result);
            }
            throw new TahseenException(404, "User is not found");
        }

        public async Task<bool> RemoveAsync(long Id)
        {
            return await _userRepository.DeleteAsync(Id);
        }

        public ICollection<UserForResultDto> RetrieveAll()
        {
            var AllData = _userRepository.SelectAll().Where(t => t.IsDeleted == false);
            return _mapper.Map<ICollection<UserForResultDto>>(AllData);
        }

        public async Task<UserForResultDto> RetrieveByIdAsync(long Id)
        {
            var data = await _userRepository.SelectByIdAsync(Id);
            if(data != null && data.IsDeleted == false)
            {
                return this._mapper.Map<UserForResultDto>(data);
            }
            throw new TahseenException(404, "User is not found");
        }
    }
}
