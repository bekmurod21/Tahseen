using Tahseen.Service.DTOs.Users.Fine;

namespace Tahseen.Service.Interfaces.IUsersService
{
    public interface IFineService
    {
        public Task<FineServiceForResultDto> AddAsync(FineServiceForCreationDto dto);
        public Task<FineServiceForResultDto> ModifyAsync(long Id, FineServiceForUpdateDto dto);
        public Task<bool> RemoveAsync(long Id);
        public ICollection<FineServiceForResultDto> RetrieveAllAsync();
        public Task<FineServiceForResultDto> RetrieveById(long Id);
    }
}
