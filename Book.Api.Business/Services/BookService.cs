using AutoMapper;
using GoSolve.Dummy.Book.Api.Business.Services.Interfaces;
using GoSolve.HttpClients.Dummy.Book.Contracts;
using GoSolve.HttpClients.Dummy.Review;

namespace GoSolve.Dummy.Book.Api.Business.Services;

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

    public async Task<BookResponse> AddBook(BookRequest bookRequest)
    {
        var book = _mapper.Map<Models.Book>(bookRequest);
        book.Id = 201;
        return _mapper.Map<BookResponse>(book);
    }

    public async Task<DetailedBookResponse> GetBookById(int bookId)
    {
        var book = _bookDb.FirstOrDefault(book => book.Id == bookId);
        if (book == null) return null;

        var bookResponse = _mapper.Map<DetailedBookResponse>(book);

        var reviews = await _reviewHttpClient.GetReviewsForBook(bookId);
        bookResponse.Reviews = _mapper.Map<IEnumerable<DetailedBookReviewResponse>>(reviews);

        return bookResponse;
    }

    public async Task<IEnumerable<BookResponse>> GetBooks()
    {
        return _mapper.Map<IEnumerable<BookResponse>>(_bookDb.AsEnumerable());
    }
}
