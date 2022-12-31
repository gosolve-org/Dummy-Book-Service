using GoSolve.Clients.Dummy.Book.Contracts.Requests;
using GoSolve.Clients.Dummy.Book.Contracts.Responses;
using GoSolve.Clients.Dummy.Review.Contracts.Responses;
using GoSolve.Dummy.Book.Business.Services.Interfaces;
using GoSolve.Tools.Common.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GoSolve.Dummy.Book.Api.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("/api/v{version:apiVersion}/book-genres")]
public class BookGenreController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookGenreController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _bookService.GetGenres());
    }
}
