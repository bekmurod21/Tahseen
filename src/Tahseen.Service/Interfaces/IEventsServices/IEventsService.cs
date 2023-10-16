
using Tahseen.Service.DTOs.Events.Events;

namespace Tahseen.Service.Interfaces.IEventsServices
{
    public interface IEventsService
    {
        public Task<EventForResultDto> AddAsync(EventForCreationDto dto);
        public Task<EventForResultDto> ModifyAsync(EventForUpdateDto dto);
        public Task<bool> RemoveAsync(long id);
        public Task<EventForResultDto> RetrieveByIdAsync(long id);
        public ICollection<EventForResultDto> RetrieveAll();
    }
}
