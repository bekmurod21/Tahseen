using AutoMapper;
using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Entities.Feedback;
using Tahseen.Service.DTOs.Books.BookReviews;
using Tahseen.Service.DTOs.Books.CompletedBooks;
using Tahseen.Service.DTOs.Books.Publishers;
using Tahseen.Service.DTOs.Feedbacks.Feedback;
using Tahseen.Service.DTOs.Feedbacks.News;
using Tahseen.Service.DTOs.Feedbacks.SurveyResponses;
using Tahseen.Service.DTOs.Feedbacks.Surveys;

namespace Tahseen.Service.Mappings;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<BookReviews, BookReviewForCreationDto>().ReverseMap();
        CreateMap<BookReviews,BookReviewForResultDto>().ReverseMap();
        CreateMap<BookReviewForUpdateDto,BookReviews>().ReverseMap();

        CreateMap<CompletedBooks, CompletedBookForCreationDto>().ReverseMap();
        CreateMap<CompletedBooks,CompletedBookForResultDto>().ReverseMap();
        CreateMap<CompletedBooks,CompletedBookForUpdateDto>().ReverseMap();

        CreateMap<Publisher,PublisherForCreationDto>().ReverseMap();
        CreateMap<Publisher,PublisherForResultDto>().ReverseMap();
        CreateMap<Publisher,PublisherForUpdateDto>().ReverseMap();
        
        CreateMap<Feedback,FeedbackForCreationDto>().ReverseMap();
        CreateMap<Feedback,FeedbackForResultDto>().ReverseMap();
        CreateMap<Feedback,FeedbackForUpdateDto>().ReverseMap();
        
        CreateMap<News,NewsForCreationDto>().ReverseMap();
        CreateMap<News,NewsForResultDto>().ReverseMap();
        CreateMap<NewsForUpdateDto,News>().ReverseMap();
        
        CreateMap<Surveys,SurveyForCreationDto>().ReverseMap();
        CreateMap<Surveys,SurveyForResultDto>().ReverseMap();
        CreateMap<Surveys,SurveyForUpdateDto>().ReverseMap();
        
        CreateMap<SurveyResponses,SurveyResponseForCreationDto>().ReverseMap();
        CreateMap<SurveyResponses,SurveyResponseForResultDto>().ReverseMap();
        CreateMap<SurveyResponses,SurveyResponseForUpdateDto>().ReverseMap();
    }
}
