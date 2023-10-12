using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Feedback;
using Tahseen.Service.DTOs.Feedbacks.SurveyResponses;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Interfaces.IFeedbackService;

namespace Tahseen.Service.Services.Feedbacks;

public class SurveyResponseService:ISurveyResponseService
{
    private readonly IMapper _mapper;
    private readonly IRepository<SurveyResponses> _repository;

    public SurveyResponseService(IMapper mapper, IRepository<SurveyResponses>repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<SurveyResponseForResultDto> AddAsync(SurveyResponseForCreationDto dto)
    {
        var added = _mapper.Map<SurveyResponses> (dto);
        var result = await _repository.CreateAsync(added);
        return _mapper.Map<SurveyResponseForResultDto>(result); 
    }

    public async Task<SurveyResponseForResultDto> ModifyAsync(long id, SurveyResponseForUpdateDto dto)
    {
        var surveyResponse = await _repository.SelectByIdAsync(id);
        if (surveyResponse is null || surveyResponse.IsDeleted)
        {
            throw new TahseenException(404, "SurveyResponse doesn't found");
        }

        var modified = _mapper.Map(dto, surveyResponse);
        var result = await _repository.UpdateAsync(modified);
        return _mapper.Map<SurveyResponseForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
        => await _repository.DeleteAsync(id);

    public async ValueTask<SurveyResponseForResultDto?> RetrieveByIdAsync(long id)
    {
        var surveyResponse = await _repository.SelectByIdAsync(id);
        if (surveyResponse is null || surveyResponse.IsDeleted)
        {
            throw new TahseenException(404, "SurveyResponse doesn't found");
        }

        return _mapper.Map<SurveyResponseForResultDto>(surveyResponse);
    }

    public IQueryable<SurveyResponseForResultDto> RetrieveAll()
    {
        var surveyResponses = _repository.SelectAll().Where(x => !x.IsDeleted);
        return _mapper.Map<IQueryable<SurveyResponseForResultDto>>(surveyResponses);
    }
}