using AutoMapper;
using GoSolve.HttpClients.Dummy.Book.Contracts;
using GoSolve.HttpClients.Dummy.Review.Contracts;

namespace GoSolve.Dummy.Book.Api.MappingProfiles;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<BookRequest, Business.Models.Book>();
        CreateMap<Business.Models.Book, BookResponse>();
        CreateMap<Business.Models.Book, DetailedBookResponse>();
        CreateMap<ReviewResponse, DetailedBookReviewResponse>();
        CreateMap<IEnumerable<ReviewResponse>, DetailedBookResponse>()
            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src));
    }
}
