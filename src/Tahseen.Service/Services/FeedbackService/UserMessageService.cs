using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Feedback;
using Tahseen.Service.DTOs.Feedbacks.UserMessages;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Interfaces.IFeedbackService;

namespace Tahseen.Service.Services.FeedbackService;

public class UserMessageService : IUserMessageService
{
    private readonly IMapper mapper;
    private readonly IRepository<UserMessage> repository;

    public UserMessageService(IMapper mapper, IRepository<UserMessage> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<UserMessageForResultDto> AddAsync(UserMessageForCreationDto dto)
    {
        var mapped = this.mapper.Map<UserMessage>(dto);
        var result = await this.repository.CreateAsync(mapped);
        return mapper.Map<UserMessageForResultDto>(result);
    }

    public async Task<UserMessageForResultDto> ModifyAsync(UserMessageForUpdateDto dto)
    {
        var getUserMessage = await this.repository.SelectByIdAsync(dto.Id);
        if (getUserMessage == null && getUserMessage.IsDeleted)
            throw new TahseenException(404, "UserMessage doesn't found");

        var mappedUserMessage = this.mapper.Map(dto, getUserMessage);
        var result = await this.repository.UpdateAsync(mappedUserMessage);

        return this.mapper.Map<UserMessageForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id) => await this.repository.DeleteAsync(id);

    IQueryable<UserMessageForResultDto> IUserMessageService.RetrieveAll()
    {
        var results = this.repository.SelectAll().Where(t=>!t.IsDeleted);
        return this.mapper.Map<IQueryable<UserMessageForResultDto>>(results);
    }

    public async ValueTask<UserMessageForResultDto> RetrieveByIdAsync(long id)
    {
        var result = await this.repository.SelectByIdAsync(id);
        if (result is null && result.IsDeleted)
            throw new TahseenException(404, "UserMessage doesn't found");
        
        return mapper.Map<UserMessageForResultDto>(result);
    }
}
