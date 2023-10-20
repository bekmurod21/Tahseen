using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities;
using Tahseen.Service.DTOs.Users.UserSettings;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Interfaces.IUsersService;

namespace Tahseen.Service.Services.Users
{
    public class UserSettingsService : IUserSettingService
    {
        private readonly IRepository<UserSettings> _repository;
        private readonly IMapper _mapper;
        public UserSettingsService(IRepository<UserSettings> Repository, IMapper Mapper)
        {
            this._mapper = Mapper;
            this._repository = Repository;
        }
        public async Task<UserSettingsForResultDto> AddAsync(UserSettingsForCreationDto dto)
        {
            var Checking = await this._repository.SelectAll().Where(u => u.UserId == dto.UserId && u.IsDeleted == false).FirstOrDefaultAsync();
            if (Checking == null)
            {
                throw new TahseenException(404, "NotFound");
            }
            var Data = this._mapper.Map<UserSettings>(dto);
            var result = await this._repository.CreateAsync(Data);
            return this._mapper.Map<UserSettingsForResultDto>(result);
        }

        public async Task<UserSettingsForResultDto> ModifyAsync(long Id, UserSettingsForUpdateDto dto)
        {
            var Data = await this._repository.SelectAll().Where(e => e.Id == Id && e.IsDeleted == false).FirstOrDefaultAsync();
            if(Data != null)
            {
                var MappedData = this._mapper.Map(dto, Data);
                MappedData.UpdatedAt = DateTime.UtcNow;
                var result = await this._repository.UpdateAsync(MappedData);
                return this._mapper.Map<UserSettingsForResultDto>(result);
            }
            throw new TahseenException(404, "User is not found");
        }

        public async Task<bool> RemoveAsync(long Id)
        {
            return await this._repository.DeleteAsync(Id);
        }

        public async Task<IQueryable<UserSettingsForResultDto>> RetrieveAllAsync()
        {
            var AllData = this._repository.SelectAll();
            return this._mapper.Map<IQueryable<UserSettingsForResultDto>>(AllData);    
        }

        public async Task<UserSettingsForResultDto> RetrieveByIdAsync(long Id)
        {
            var Data = await this._repository.SelectByIdAsync(Id);
            return this._mapper.Map<UserSettingsForResultDto>(Data);
        }
    }
}
