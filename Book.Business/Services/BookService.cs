using AutoMapper;
using GoSolve.Clients.Dummy.Book.Contracts.Requests;
using GoSolve.Clients.Dummy.Book.Contracts.Responses;
using GoSolve.Clients.Dummy.Review.Contracts.Responses;
using GoSolve.Clients.Dummy.Review.HttpClients.Interfaces;
using GoSolve.Dummy.Book.Business.Services.Interfaces;
using GoSolve.Dummy.Book.Data.Repositories.Interfaces;
using GoSolve.Tools.Common.Database.Models;
using GoSolve.Tools.Common.Database.Models.Interfaces;

namespace GoSolve.Dummy.Book.Business.Services;

public class BookService : IBookService
{
    private readonly IReviewHttpClient _reviewHttpClient;
    private readonly IBookRepository _bookRepository;
    private readonly IBookGenreRepository _bookGenreRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookService(
        IReviewHttpClient reviewHttpClient,
        IBookRepository bookRepository,
        IBookGenreRepository bookGenreRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _reviewHttpClient = reviewHttpClient;
        _bookRepository = bookRepository;
        _bookGenreRepository = bookGenreRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookResponse> Add(BookCreationRequest book)
    {
        var bookEntity = _mapper.Map<Data.Models.Book>(book);
        var bookGenre = await _bookGenreRepository.GetById(book.GenreId);
        if (bookGenre == null)
        {
            throw new ArgumentException($"Could not find BookGenre by id {book.GenreId}.");
        }

        _bookRepository.Add(bookEntity);

        await _unitOfWork.CompleteAsync();

        return _mapper.Map<BookResponse>(bookEntity);
    }

    public async Task<BookResponse> GetById(int id)
    {
        var book = await _bookRepository.GetById(id);
        if (book == null) return null;

        return _mapper.Map<BookResponse>(book);
    }

    public async Task<IEnumerable<BookResponse>> GetAll()
    {
        var books = await _bookRepository.GetAll();

        return _mapper.Map<IEnumerable<BookResponse>>(books);
    }

    public async Task<IEnumerable<ReviewResponse>> GetReviewsForBook(int bookId)
    {
        return await _reviewHttpClient.GetForBook(bookId);
    }

    public async Task<IEnumerable<BookGenreReponse>> GetGenres()
    {
        var bookGenres = await _bookGenreRepository.GetAll();

        return _mapper.Map<IEnumerable<BookGenreReponse>>(bookGenres);
    }
}
