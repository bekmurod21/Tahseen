using AutoMapper;
using Tahseen.Domain.Entities.Books;
using Tahseen.Service.DTOs.Books.BookReviews;
using Tahseen.Service.DTOs.Books.CompletedBooks;
using Tahseen.Service.DTOs.Books.Publishers;

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
    }
}
