using GoSolve.HttpClients.Dummy.Book.Contracts;

namespace GoSolve.Dummy.Book.Api.Business.Services.Interfaces;

public interface IBookService
{
    Task<DetailedBookResponse> GetBookById(int bookId);

    Task<IEnumerable<BookResponse>> GetBooks();

    Task<BookResponse> AddBook(BookRequest bookRequest);
}
