using Tahseen.Service.DTOs.Users.Registration;
using Tahseen.Service.DTOs.Users.User;

namespace Tahseen.Service.Interfaces.IUsersService
{
    public interface IRegistrationService
    {
        public Task<RegistrationForResultDto> AddAsync(RegistrationForCreationDto dto);
    }
}
