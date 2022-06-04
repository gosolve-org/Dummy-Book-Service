using AutoMapper;
using GoSolve.Dummy.Book.Api.Business.Services.Interfaces;
using GoSolve.HttpClients.Dummy.Book.Contracts;
using GoSolve.HttpClients.Dummy.Review;
using Microsoft.AspNetCore.Mvc;

namespace GoSolve.Dummy.Book.Api.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("/api/v{version:apiVersion}/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        return Ok(await _bookService.GetBooks());
    }

    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetBookById(int bookId)
    {
        var bookResponse = await _bookService.GetBookById(bookId);
        if (bookResponse == null) return NotFound();
        return Ok(bookResponse);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(BookRequest bookRequest)
    {
        var bookResponse = await _bookService.AddBook(bookRequest);
        return CreatedAtAction(nameof(GetBookById), new { bookId = bookResponse.Id }, bookResponse);
    }
}
