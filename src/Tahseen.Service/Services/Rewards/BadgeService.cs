using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Reservations;
using Tahseen.Domain.Entities.Rewards;
using Tahseen.Service.DTOs.Books.Author;
using Tahseen.Service.DTOs.Reservations;
using Tahseen.Service.DTOs.Rewards.Badge;
using Tahseen.Service.DTOs.Users.User;
using Tahseen.Service.Interfaces.IRewardsService;

namespace Tahseen.Service.Services.Rewards;

public class BadgeService : IBadgeService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Badge> _repository;

    public BadgeService(IMapper mapper, IRepository<Badge> repository)
    {
        this._mapper = mapper;
        this._repository = repository;
    }

    public async Task<BadgeForResultDto> AddAsync(BadgeForCreationDto dto)
    {
        var badge = _mapper.Map<Badge>(dto);
        var result= await _repository.CreateAsync(badge);
        return _mapper.Map<BadgeForResultDto>(result);
    }

    public async Task<BadgeForResultDto> ModifyAsync(long id, BadgeForUpdateDto dto)
    {
        var badge = await _repository.SelectByIdAsync(id);
        if (badge is not null && !badge.IsDeleted)
        {
            var mappedBadge = _mapper.Map<Badge>(dto);
            mappedBadge.UpdatedAt = DateTime.UtcNow;
            var result = await _repository.UpdateAsync(mappedBadge);
            return _mapper.Map<BadgeForResultDto>(result);
        }
        throw new Exception("Badge not found");
    }

    public async Task<bool> RemoveAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IQueryable<BadgeForResultDto>> RetrieveAllAsync()
    {
        var AllData = this._repository.SelectAll().Where(t => t.IsDeleted == false);
        return _mapper.Map<IQueryable<BadgeForResultDto>>(AllData);
    }

    public async Task<BadgeForResultDto> RetrieveByIdAsync(long id)
    {
        var badge = await _repository.SelectByIdAsync(id);
        if (badge is not null && !badge.IsDeleted)
            return _mapper.Map<BadgeForResultDto>(badge);
        
        throw new Exception("Badge not found");
    }
}