using AutoMapper;
using GoSolve.Clients.Dummy.Book.Contracts.Requests;
using GoSolve.Clients.Dummy.Book.Contracts.Responses;
using GoSolve.Clients.Dummy.Review.Contracts.Responses;
using GoSolve.Dummy.Book.Business.Services.Interfaces;
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
    public async Task<IActionResult> Get()
    {
        return Ok(await _bookService.GetAll());
    }

    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetById(int bookId)
    {
        var (book, reviews) = await AsyncHelper.GetInParallel(
            _bookService.GetById(bookId),
            _bookService.GetReviewsForBook(bookId));

        if (book == null) return NotFound();

        var bookResponse = new DetailedBookResponse();
        _mapper.Map<BookResponse, DetailedBookResponse>(book, bookResponse);
        _mapper.Map<IEnumerable<ReviewResponse>, DetailedBookResponse>(reviews, bookResponse);

        return Ok(bookResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Add(BookCreationRequest request)
    {
        var bookResponse = await _bookService.Add(request);
        return CreatedAtAction(nameof(GetById), new { bookId = bookResponse.Id }, bookResponse);
    }
}
