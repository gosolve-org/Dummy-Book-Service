using AutoMapper;
using GoSolve.Clients.Dummy.Book.Contracts.Requests;
using GoSolve.Clients.Dummy.Book.Contracts.Responses;
using GoSolve.Clients.Dummy.Review.Contracts.Responses;
using GoSolve.Tools.Common.ExtensionMethods;

namespace GoSolve.Dummy.Book.Business.MappingProfiles;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<Data.Models.BookGenre, BookGenreReponse>();
        CreateMap<BookCreationRequest, Data.Models.Book>();
        CreateMap<Data.Models.Book, BookResponse>();
        CreateMap<Data.Models.Book, DetailedBookResponse>();
        CreateMap<ReviewResponse, DetailedBookReviewResponse>();
    }
}
