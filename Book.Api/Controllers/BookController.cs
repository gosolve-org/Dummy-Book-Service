using AutoMapper;
using GoSolve.Dummy.Book.Business.Services.Interfaces;
using GoSolve.HttpClients.Dummy.Book.Contracts;
using GoSolve.HttpClients.Dummy.Review;
using GoSolve.HttpClients.Dummy.Review.Contracts;
using GoSolve.Tools.Common.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GoSolve.Dummy.Book.Api.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("/api/v{version:apiVersion}/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public BookController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        return Ok(_mapper.Map<IEnumerable<BookResponse>>(await _bookService.GetBooks()));
    }

    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetBookById(int bookId)
    {
        var (book, reviews) = await AsyncHelper.GetInParallel(
            _bookService.GetBookById(bookId),
            _bookService.GetReviewsForBook(bookId));

        if (book == null) return NotFound();

        var bookResponse = new DetailedBookResponse();
        _mapper.Map<Business.Models.Book, DetailedBookResponse>(book, bookResponse);
        _mapper.Map<IEnumerable<ReviewResponse>, DetailedBookResponse>(reviews, bookResponse);

        return Ok(bookResponse);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(BookRequest bookRequest)
    {
        var book = _mapper.Map<Business.Models.Book>(bookRequest);
        var bookResponse = _mapper.Map<BookResponse>(await _bookService.AddBook(book));
        return CreatedAtAction(nameof(GetBookById), new { bookId = bookResponse.Id }, bookResponse);
    }
}
