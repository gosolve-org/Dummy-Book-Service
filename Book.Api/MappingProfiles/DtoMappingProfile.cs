using AutoMapper;
using GoSolve.Clients.Dummy.Book.Contracts.Requests;
using GoSolve.Clients.Dummy.Book.Contracts.Responses;
using GoSolve.Clients.Dummy.Review.Contracts.Responses;

namespace GoSolve.Dummy.Book.Api.MappingProfiles;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<BookResponse, DetailedBookResponse>();
        CreateMap<BookResponse, DetailedBookReviewResponse>();
        CreateMap<IEnumerable<ReviewResponse>, DetailedBookResponse>()
            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src));
    }
}
