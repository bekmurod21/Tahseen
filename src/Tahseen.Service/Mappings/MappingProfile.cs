using AutoMapper;
using Tahseen.Domain.Entities;
using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Entities.Feedback;
using Tahseen.Domain.Entities.SchoolAndEducations;
using Tahseen.Service.DTOs.Books.BookReviews;
using Tahseen.Service.DTOs.Books.CompletedBooks;
using Tahseen.Service.DTOs.Books.Publishers;
using Tahseen.Service.DTOs.Feedbacks.Feedback;
using Tahseen.Service.DTOs.Feedbacks.News;
using Tahseen.Service.DTOs.Feedbacks.SurveyResponses;
using Tahseen.Service.DTOs.Feedbacks.Surveys;
using Tahseen.Service.DTOs.SchoolAndEducations;
using Tahseen.Service.DTOs.Users.User;

namespace Tahseen.Service.Mappings;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<BookReviews, BookReviewForCreationDto>().ReverseMap();
        CreateMap<BookReviews,BookReviewForResultDto>().ReverseMap();
        CreateMap<BookReviews, BookReviewForUpdateDto>().ReverseMap();

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
        CreateMap<News, NewsForUpdateDto>().ReverseMap();
        
        CreateMap<Surveys,SurveyForCreationDto>().ReverseMap();
        CreateMap<Surveys,SurveyForResultDto>().ReverseMap();
        CreateMap<Surveys,SurveyForUpdateDto>().ReverseMap();
        
        CreateMap<SurveyResponses,SurveyResponseForCreationDto>().ReverseMap();
        CreateMap<SurveyResponses,SurveyResponseForResultDto>().ReverseMap();
        CreateMap<SurveyResponses,SurveyResponseForUpdateDto>().ReverseMap();
        
        CreateMap<PupilBookConnection,PupilBookConnectionForCreationDto>().ReverseMap();
        CreateMap<PupilBookConnection,PupilBookConnectionForResultDto>().ReverseMap();
        CreateMap<PupilBookConnection,PupilBookConnectionForUpdateDto>().ReverseMap();
        
        CreateMap<Pupil,PupilForCreationDto>().ReverseMap();
        CreateMap<Pupil,PupilForResultDto>().ReverseMap();
        CreateMap<Pupil,PupilForUpdateDto>().ReverseMap();
        
        CreateMap<SchoolBook,SchoolBookForCreationDto>().ReverseMap();
        CreateMap<SchoolBook,SchoolBookForResultDto>().ReverseMap();
        CreateMap<SchoolBook,SchoolBookForUpdateDto>().ReverseMap();

        CreateMap<User, UserForCreationDto>().ReverseMap();
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();



    }
}
