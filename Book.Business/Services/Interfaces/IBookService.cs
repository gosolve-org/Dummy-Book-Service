using GoSolve.Clients.Dummy.Book.Contracts.Requests;
using GoSolve.Clients.Dummy.Book.Contracts.Responses;
using GoSolve.Clients.Dummy.Review.Contracts.Responses;

namespace GoSolve.Dummy.Book.Business.Services.Interfaces;

public interface IBookService
{
    Task<BookResponse> GetById(int id);

    Task<IEnumerable<ReviewResponse>> GetReviewsForBook(int bookId);

    Task<IEnumerable<BookResponse>> GetAll();

    Task<BookResponse> Add(BookCreationRequest bookRequest);

    Task<IEnumerable<BookGenreReponse>> GetGenres();
}
