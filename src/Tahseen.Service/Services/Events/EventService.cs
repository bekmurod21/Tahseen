using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Events;
using Tahseen.Service.DTOs.Events.Events;
using Tahseen.Service.Interfaces.IEventsServices;

namespace Tahseen.Service.Services.Events;

public class EventService : IEventsService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Event> _repository;

    public EventService(IMapper mapper, IRepository<Event> repository)
    {
        this._mapper = mapper;
        this._repository = repository;
    }

    public async Task<EventForResultDto> AddAsync(EventForCreationDto dto)
    {
        var @event = _mapper.Map<Event>(dto);
        var result= await _repository.CreateAsync(@event);
        return _mapper.Map<EventForResultDto>(result);
    }

    public async Task<EventForResultDto> ModifyAsync(long id, EventForUpdateDto dto)
    {
        var @event = await _repository.SelectByIdAsync(id);
        if (@event is not null && !@event.IsDeleted)
        {
            var mappedEvent = _mapper.Map<Event>(dto);
            var result = await _repository.UpdateAsync(mappedEvent);
            result.UpdatedAt = DateTime.UtcNow;
            return _mapper.Map<EventForResultDto>(result);
        }
        throw new Exception("Event not found");
    }

    public async Task<bool> RemoveAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IQueryable<EventForResultDto>> RetrieveAllAsync()
    {
        var AllData = this._repository.SelectAll().Where(e => e.IsDeleted == false);
        return this._mapper.Map<IQueryable<EventForResultDto>>(AllData);
    }

    public async Task<EventForResultDto> RetrieveByIdAsync(long id)
    {
        var @event = await _repository.SelectByIdAsync(id);
        if (@event is not null && !@event.IsDeleted)
            return _mapper.Map<EventForResultDto>(@event);
        
        throw new Exception("Event  not found");
    }


}