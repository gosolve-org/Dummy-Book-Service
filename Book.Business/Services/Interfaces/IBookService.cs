using GoSolve.HttpClients.Dummy.Review.Contracts;

namespace GoSolve.Dummy.Book.Business.Services.Interfaces;

public interface IBookService
{
    Task<Models.Book> GetBookById(int bookId);

    Task<IEnumerable<ReviewResponse>> GetReviewsForBook(int bookId);

    Task<IEnumerable<Models.Book>> GetBooks();

    Task<Models.Book> AddBook(Models.Book bookRequest);
}
