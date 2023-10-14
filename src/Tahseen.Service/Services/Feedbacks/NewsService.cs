using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Feedback;
using Tahseen.Service.DTOs.Feedbacks.News;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Interfaces.IFeedbackService;

namespace Tahseen.Service.Services.Feedbacks;

public class NewsService:INewsService
{
    private readonly IMapper _mapper;
    private readonly IRepository<News> _repository;

    public NewsService(IMapper mapper, IRepository<News>repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<NewsForResultDto> AddAsync(NewsForCreationDto dto)
    {
        var mapped = _mapper.Map<News> (dto);
        var result = await _repository.CreateAsync(mapped);
        return _mapper.Map<NewsForResultDto>(result); 
    }

    public async Task<NewsForResultDto> ModifyAsync(long id, NewsForUpdateDto dto)
    {
        var news = await _repository.SelectByIdAsync(id);
        if (news is null || news.IsDeleted)
        {
            throw new TahseenException(404, "News doesn't found");
        }
        var mapped = _mapper.Map(dto, news);
        mapped.UpdatedAt = DateTime.UtcNow;
        var result = await _repository.UpdateAsync(mapped);
        return _mapper.Map<NewsForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
        => await _repository.DeleteAsync(id);

    public async ValueTask<NewsForResultDto?> RetrieveByIdAsync(long id)
    {
        var news = await _repository.SelectByIdAsync(id);
        if (news is null || news.IsDeleted)
        {
            throw new TahseenException(404, "News doesn't found");
        }
        return _mapper.Map<NewsForResultDto>(news);
    }

    public IQueryable<NewsForResultDto> RetrieveAll()
    {
        var news = _repository.SelectAll().Where(x => !x.IsDeleted);
        return _mapper.Map<IQueryable<NewsForResultDto>>(news);
    }
}