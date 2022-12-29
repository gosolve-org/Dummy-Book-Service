using System.Linq.Expressions;
using System.Security.Cryptography;
using GoSolve.Dummy.Book.Data.Repositories.Interfaces;
using GoSolve.Tools.Common.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace GoSolve.Dummy.Book.Data.Repositories;

public class BookRepository : GenericRepository<Models.Book, int, BookDbContext>, IBookRepository
{
    public BookRepository(BookDbContext context)
        : base(context)
    {
    }

    public override IQueryable<Models.Book> PrepareDefaultReadSource(IQueryable<Models.Book> source)
    {
        return source.Include(b => b.Genre);
    }
}
