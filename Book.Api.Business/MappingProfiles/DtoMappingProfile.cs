using AutoMapper;
using GoSolve.HttpClients.Dummy.Book.Contracts;
using GoSolve.HttpClients.Dummy.Review.Contracts;

namespace GoSolve.Dummy.Book.Api.Business.MappingProfiles;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<BookRequest, Models.Book>();
        CreateMap<Models.Book, BookResponse>();
        CreateMap<Models.Book, DetailedBookResponse>();
        CreateMap<ReviewResponse, DetailedBookReviewResponse>();
    }
}
