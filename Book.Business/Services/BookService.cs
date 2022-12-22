using AutoMapper;
using GoSolve.Dummy.Book.Business.Services.Interfaces;
using GoSolve.HttpClients.Dummy.Review;
using GoSolve.HttpClients.Dummy.Review.Contracts;

namespace GoSolve.Dummy.Book.Business.Services;

public class BookService : IBookService
{
    private readonly IReviewHttpClient _reviewHttpClient;
    private readonly IMapper _mapper;

    private readonly Models.Book[] _bookDb = new Models.Book[]
    {
        new Models.Book { Id = 0, Title = "Book1", AmountOfPages = 360 },
        new Models.Book { Id = 1, Title = "Book2", AmountOfPages = 500 },
        new Models.Book { Id = 2, Title = "Book3", AmountOfPages = 180 }
    };

    public BookService(IReviewHttpClient reviewHttpClient, IMapper mapper)
    {
        _reviewHttpClient = reviewHttpClient;
        _mapper = mapper;
    }

    public Task<Models.Book> AddBook(Models.Book book)
    {
        book.Id = 201;
        return Task.FromResult(book);
    }

    public Task<Models.Book> GetBookById(int bookId)
    {
        return Task.FromResult(_bookDb.FirstOrDefault(book => book.Id == bookId));
    }

    public Task<IEnumerable<Models.Book>> GetBooks()
    {
        return Task.FromResult(_bookDb.AsEnumerable());
    }

    public async Task<IEnumerable<ReviewResponse>> GetReviewsForBook(int bookId)
    {
        return await _reviewHttpClient.GetForBook(bookId);
    }
}
