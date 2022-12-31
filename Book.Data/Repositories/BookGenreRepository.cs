using GoSolve.Dummy.Book.Data.Models;
using GoSolve.Dummy.Book.Data.Repositories.Interfaces;
using GoSolve.Tools.Common.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoSolve.Dummy.Book.Data.Repositories;

public class BookGenreRepository : ReadOnlyRepository<BookGenre, int, BookDbContext>, IBookGenreRepository
{
    public BookGenreRepository(BookDbContext context)
        : base(context)
    {
    }
}
