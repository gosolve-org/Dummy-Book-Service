using GoSolve.Dummy.Book.Data.Models;
using GoSolve.Tools.Common.Database.Repositories.Interfaces;

namespace GoSolve.Dummy.Book.Data.Repositories.Interfaces;

public interface IBookGenreRepository : IReadOnlyRepository<BookGenre, int>
{
}
